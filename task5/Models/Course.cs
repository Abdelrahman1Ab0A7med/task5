using System.ComponentModel.DataAnnotations;

namespace task5.Models
{
	public class Course
	{
		public int Id { get; set; }
		[RegularExpression("^[a-z .#&A-Z]{2,20}$",ErrorMessage ="Please Enter only Characters")]
		[MinLength(2), MaxLength(20)]
		public string Name { get; set; } = string.Empty;
		[Range(1,90 ,ErrorMessage ="{0} must between {1} : {2}")]
        public int Hour { get; set; }
        public string Description { get; set; } = string.Empty;
		public virtual List<User>? users { get; set; }//=> new List<User>();
	}
}
