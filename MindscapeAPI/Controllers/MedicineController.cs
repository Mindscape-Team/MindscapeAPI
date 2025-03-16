using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MindscapeAPI.DTOs.Medicine;
using MindscapeAPI.Models;
using MindscapeAPI.Repository.MedicineRepo;
using System.Globalization;
using System.Security.Claims;

namespace MindscapeAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MedicineController : ControllerBase
	{
		private readonly IMedicineService _medicineService;
		private readonly IMapper _mapper;

		public MedicineController(IMedicineService medicineService, IMapper mapper)
		{
			_medicineService = medicineService;
			_mapper = mapper;
		}

		[HttpPost("AddMedicine")]
		public async Task<IActionResult> AddMedicine([FromBody] MedicineDTO medicineDTO)
		{
			var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (user == null) return Unauthorized();

			var result = await _medicineService.AddMedicineAsync(medicineDTO, user);
			if (result == null) return BadRequest("Invalid medicine data");

			return Ok(new { Message = "Medicine added successfully", Medicine = result });
		}

		[HttpGet("GetAllMedicines")]
		public async Task<IActionResult> GetAllMedicine()
		{
			var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (user == null) return Unauthorized();

			var medicines = await _medicineService.GetAllMedicinesAsync(user);

			return Ok(medicines);
		}

		[HttpGet("GetMedicineById/{id}")]
		public async Task<IActionResult> GetMedicineById([FromRoute] int id)
		{
			var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (user == null) return Unauthorized();

			var medicine = await _medicineService.GetMedicineByIdAsync(id, user);
			if (medicine == null) return NotFound("Medicine not found");

			return Ok(medicine);
		}

		[HttpGet("GetLastMedicine")]
		public async Task<IActionResult> GetLastMedicine()
		{
			var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (user == null) return Unauthorized();

			var medicine = await _medicineService.GetLastMedicineAdded(user);
			if (medicine == null) return NotFound("No medicines found");

			return Ok(medicine);
		}

		[HttpGet("GetMedicinesByDate")]
		public async Task<IActionResult> GetMedicineByDate([FromQuery] string date)
		{
			if (!DateTime.TryParseExact(date, "yyyy-MM-ddTHH:mm:ss",
							  CultureInfo.InvariantCulture,
							  DateTimeStyles.None, out DateTime parsedDate))
			{
				return BadRequest("Invalid date format. Expected format: yyyy-MM-ddTHH:mm:ss");
			}

			var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (user == null) return Unauthorized();

			var medicines = await _medicineService.GetMedicinesByDate(parsedDate, user);

			if (medicines == null || medicines.Count == 0)
				return NotFound("No medicines found for this date.");

			return Ok(medicines);
		}

		[HttpPut("UpdateMedicine/{id}")]
		public async Task<IActionResult> UpdateMedicineAsync([FromRoute] int id, [FromBody] MedicineDTO medicineDTO)
		{
			var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (user == null) return Unauthorized();

			var updatedMedicine = await _medicineService.UpdateMedicineAsync(id, medicineDTO, user);
			if (updatedMedicine == null) return NotFound("Medicine not found or invalid data");

			return Ok(new { Message = "Medicine updated successfully", updatedMedicine });
		}

		[HttpDelete("DeleteMedicine/{id}")]
		public async Task<IActionResult> DeleteMedicine([FromRoute] int id)
		{
			var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (user == null) return Unauthorized();

			var result = await _medicineService.DeleteMedicineAsync(id, user);
			if (!result) return NotFound("Medicine not found");

			return Ok("Medicine deleted successfully");
		}

		[HttpDelete("DeleteAllMedicines")]
		public async Task<IActionResult> DeleteAllMedicines()
		{
			var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			if (user == null) return Unauthorized();

			var result = await _medicineService.DeleteAllMedicines(user);
			if (!result) return NotFound("Medicines not found");

			return Ok("Medicine deleted successfully");
		}
	}
}
