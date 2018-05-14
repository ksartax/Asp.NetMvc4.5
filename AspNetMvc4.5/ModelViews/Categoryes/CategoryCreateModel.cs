﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetMvc4._5.Models
{
    public class CategoryCreateModel
    {
        [
            Required(ErrorMessage = "Pole wymagane"),
            MaxLength(250, ErrorMessage = "Pole musi miec max 250 znaków"),
            MinLength(5, ErrorMessage = "Pole musi mieć min 5 znaków")
        ]
        public string Description { get; set; }
    }
}