﻿using System.ComponentModel.DataAnnotations;

namespace Assignment_12._1.Models
{
    public class AllLetters: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value != null)
            {
                return ((string)value).All(Char.IsLetter);  //apply this validation to Product.cs
            }
            return false;
        }
    }
}
