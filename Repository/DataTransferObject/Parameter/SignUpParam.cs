﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataTransferObject.Parameter
{
    public class SignUpParam
    {
        [Required]
        public string Username { get; set; }
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Role { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }
    }
}
