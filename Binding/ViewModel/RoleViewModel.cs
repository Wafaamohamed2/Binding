﻿using System.ComponentModel.DataAnnotations;

namespace Binding.ViewModel
{
    public class RoleViewModel
    {
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
