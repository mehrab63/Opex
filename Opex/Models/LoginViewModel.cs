using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Opex.Models
{
    public class LoginViewModel
    {
        #region Properties  
        /// Gets or sets to username address.
        //  [Required(ErrorMessage = "نام کاربری الزامی است")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        //Gets or sets to password address.  
        // [Required(ErrorMessage = "کلمه عبور را وارد کنید.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        #endregion
    }
}
