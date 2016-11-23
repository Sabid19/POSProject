using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessEntity
{
   public class Login
    {    
        public string UserId { get; set; }
        [DisplayName("User Name")]
        [Required(ErrorMessage ="Please Insert a valid user name")]
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string UserType { get; set; }
        public string UserStatus { get; set; }
        public Int32 Counter { get; set; }
    }
}
