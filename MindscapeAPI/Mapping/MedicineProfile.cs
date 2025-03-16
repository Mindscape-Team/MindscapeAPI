using AutoMapper;
using MindscapeAPI.DTOs.Medicine;
using MindscapeAPI.Models;

namespace MindscapeAPI.Mapping
{
	public class MedicineProfile:Profile
	{
		public MedicineProfile()
		{
			CreateMap<Medicine, MedicineDTO>().ReverseMap();
		}
	}
}
