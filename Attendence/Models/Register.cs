

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Attendence.Models
{
    public class Register:Response
    {
        public int Id { get; set; } 
        [Required(ErrorMessage = "Name is required.")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Mobile No is required.")]
        public string ContactNumber { get; set; }
        
    }
    public class Response
    {
        [DefaultValue(0)]
        public int status { get; set; }
        [DefaultValue("Something Went Wrong!")]
        public string msg { get; set; } 
    }
}
