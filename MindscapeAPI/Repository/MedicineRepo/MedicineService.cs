using AutoMapper;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MindscapeAPI.Data;
using MindscapeAPI.DTOs.Medicine;
using MindscapeAPI.Models;

namespace MindscapeAPI.Repository.MedicineRepo
{
	public class MedicineService : IMedicineService
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;
		private readonly IMemoryCache _memoryCache;

        public MedicineService(ApplicationDbContext context, IMapper mapper, IMemoryCache memoryCache)
        {
				_context = context;
				_mapper = mapper;
			    _memoryCache = memoryCache;
        }

		public async Task<MedicineDTO> AddMedicineAsync(MedicineDTO medicinedto, string userId)
		{
			if (medicinedto == null) return null;

			var medicine = _mapper.Map<Medicine>(medicinedto);
			medicine.UserId = userId;

			await _context.Medicines.AddAsync(medicine);
			var result = await _context.SaveChangesAsync() > 0;

			if (result)
			{
				_memoryCache.Remove($"AllMedicines_{userId}");
				return _mapper.Map<MedicineDTO>(medicine); 
			}
			return null;
		}

		public async Task<List<MedicineDTO>> GetAllMedicinesAsync(string userId)
		{
			string cacheKey = $"AllMedicines_{userId}";

			if (_memoryCache.TryGetValue(cacheKey, out List<MedicineDTO> cachedMedicines))
				return cachedMedicines;

			var medicines = await _context.Medicines
				.Where(m => m.UserId == userId)
				.ToListAsync();

			if(!medicines.Any()) return new List<MedicineDTO>();

			var medicinedto = _mapper.Map<List<MedicineDTO>>(medicines);
			_memoryCache.Set(cacheKey, medicinedto, TimeSpan.FromMinutes(10));

			return medicinedto;
		}

		public async Task<MedicineDTO> GetMedicineByIdAsync(int medicineId, string userId)
		{
			string cacheKey = $"Medicine_{medicineId}";

			if (_memoryCache.TryGetValue(cacheKey, out MedicineDTO cachedMedicine))
				return cachedMedicine;

			var medicine= await _context.Medicines
				.FirstOrDefaultAsync(m => m.Id == medicineId && m.UserId == userId);

			if (medicine == null) return null;

			var medicinedto= _mapper.Map<MedicineDTO>(medicine);
			_memoryCache.Set(cacheKey, medicinedto, TimeSpan.FromMinutes(10));

			return medicinedto;
		}
		public async Task<MedicineDTO> GetLastMedicineAdded(string userId)
		{
			var medicine = await _context.Medicines
				.Where(m => m.UserId == userId)
				.OrderByDescending(m => m.Id)
				.FirstOrDefaultAsync();

			return medicine == null ? null : _mapper.Map<MedicineDTO>(medicine);
		}
		public async Task<List<MedicineDTO>> GetMedicinesByDate(DateTime date, string userId)
		{
			var medicines = await _context.Medicines
		.Where(m => m.Date >= date.Date && m.Date < date.Date.AddDays(1) && m.UserId == userId)
		.ToListAsync();

			return medicines.Select(m => new MedicineDTO
			{
				Name = m.Name,
				DosageFrequency = m.DosageFrequency,
				Dosage = m.Dosage,
				MedicineTime = m.MedicineTime,
				MedicinePhoto = m.MedicinePhoto,
				Date = m.Date.ToString("yyyy-MM-ddTHH:mm:ss") // Ensure consistent format
			}).ToList();
		}

		public async Task<bool> DeleteMedicineAsync(int medicineId, string userId)
		{
			var medicine = await _context.Medicines
				.FirstOrDefaultAsync(m => m.Id == medicineId && m.UserId == userId);

			if (medicine == null) return false;

			_context.Medicines.Remove(medicine);
			var result = await _context.SaveChangesAsync() > 0;

			if (result)
			{
				_memoryCache.Remove($"Medicine_{medicineId}");
				_memoryCache.Remove($"AllMedicines_{userId}");
			}

			return result;
		}
		public async Task<bool> DeleteAllMedicines(string userId)
		{
			string cacheKey = $"AllMedicines_{userId}";
			_memoryCache.Remove(cacheKey);

			var medicines = await _context.Medicines
				.Where(m => m.UserId == userId)
				.ToListAsync();

			if (!medicines.Any()) return false;

			_context.Medicines.RemoveRange(medicines);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<MedicineDTO> UpdateMedicineAsync(int medicineId, MedicineDTO medicinedto, string userId)
		{
			var medicine = await _context.Medicines
				.FirstOrDefaultAsync(m => m.Id == medicineId && m.UserId == userId);

			if (medicine == null) return null;

			bool isUpdated = false;

			if (medicinedto.Name != null && medicinedto.Name != medicine.Name)
			{
				medicine.Name = medicinedto.Name;
				isUpdated = true;
			}
			if (medicinedto.DosageFrequency != null && medicinedto.DosageFrequency != medicine.DosageFrequency)
			{
				medicine.DosageFrequency = medicinedto.DosageFrequency;
				isUpdated = true;
			}
			if (medicinedto.Dosage != null && medicinedto.Dosage != medicine.Dosage)
			{
				medicine.Dosage = medicinedto.Dosage;
				isUpdated = true;
			}
			if (medicinedto.MedicineTime != null && medicinedto.MedicineTime != medicine.MedicineTime)
			{
				medicine.MedicineTime = medicinedto.MedicineTime;
				isUpdated = true;
			}
			if (medicinedto.MedicinePhoto != null && medicinedto.MedicinePhoto != medicine.MedicinePhoto)
			{
				medicine.MedicinePhoto = medicinedto.MedicinePhoto;
				isUpdated = true;
			}

			if (!isUpdated) return _mapper.Map<MedicineDTO>(medicine); 

			var result = await _context.SaveChangesAsync() > 0;

			if (result)
			{
				_memoryCache.Remove($"Medicine_{medicineId}");
				_memoryCache.Remove($"AllMedicines_{userId}");
			}

			return _mapper.Map<MedicineDTO>(medicine);
		}
	}
}
