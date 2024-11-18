using System.ComponentModel.DataAnnotations;

namespace SimpleSchoolSystem.ServicesLayer.Dto.Dept
{
	public class GetAllDept
	{
		[Key]
		public int DepartmentId { get; set; }
		[MaxLength(100)]
		public string? DepartmentName { get; set; }

	}
}
