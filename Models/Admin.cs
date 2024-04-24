﻿using System.ComponentModel.DataAnnotations;

namespace Magazin_Online.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
    }
}
