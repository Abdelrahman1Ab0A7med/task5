using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace task5.Models
{
	public class User
	{
		public int Id { get; set; }
		[RegularExpression("^[a-z A-Z]{3,20}$")]
		[MinLength(3) ,MaxLength(20) ]
		public string Name { get; set; } = string.Empty;
		[MinLength(8), MaxLength(20)]
		public string Password { get; set; } = string.Empty;
		[Range(20,40,ErrorMessage ="{0} must between {1} : {2}")]        
		public int Age { get; set; }
		[RegularExpression("01[0125][0-9]{8}",ErrorMessage = "The phone number must match 0101234567 or 0111234567 or 01234567891 or 01512345678")]
		public string phone { get; set; } = string.Empty;
		[RegularExpression("^[a-zA-Z0-9\\._%+-]+@[a-zA-Z0-9\\.-]+\\.[a-zA-Z]{2,}$",ErrorMessage = "Email must match this example@example.com")]
		public string Email { get; set; } = string.Empty;
		[DisplayName("Course")]
        public int CourseId { get; set; }
        public Course? course { get; set; }
    }
}
