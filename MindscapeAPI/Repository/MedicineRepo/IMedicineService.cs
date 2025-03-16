using MindscapeAPI.DTOs.Medicine;

namespace MindscapeAPI.Repository.MedicineRepo
{
	public interface IMedicineService
	{
		Task<MedicineDTO> AddMedicineAsync(MedicineDTO medicinedto, string userId);
		Task<MedicineDTO> GetMedicineByIdAsync(int medicineId, string userId);
		Task<List<MedicineDTO>> GetAllMedicinesAsync(string userId);
		Task<MedicineDTO> GetLastMedicineAdded(string userId);
		Task<List<MedicineDTO>> GetMedicinesByDate(DateTime date, string userId);
		Task<MedicineDTO> UpdateMedicineAsync(int medicineId, MedicineDTO medicinedto, string userId);
		Task<bool> DeleteMedicineAsync(int medicineId, string userId);
		Task<bool> DeleteAllMedicines(string userId);
	}
}
