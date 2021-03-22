using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Domain.Login
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage ="Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string RoleName { get; set; }
        public List<SelectListItem> RoleList { get; set; }
        [Display(Name = "Pre School")]
        public int? PreSchoolId { get; set; }

        public RegisterViewModel()
        {
            RoleList = new List<SelectListItem>() { 
                new SelectListItem
                { Value = "Parent", Text = "Parent" },
                new SelectListItem
                { Value = "Operator", Text = "Operator" } 
            };
        }
    }
}
