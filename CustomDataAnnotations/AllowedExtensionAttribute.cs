﻿using System.ComponentModel.DataAnnotations;

namespace SoppingCart.CustomDataAnnotations
{
    public class AllowedExtensionAttribute : ValidationAttribute
    {
        private readonly string _allowedExtension;
        public AllowedExtensionAttribute(string allowedExtension)
        {

            _allowedExtension = allowedExtension;

        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (!_allowedExtension.Split(',').Contains(Path.GetExtension(file.FileName)))
                {
                    return new ValidationResult(errorMessage: $"Allowed file extensions are : {_allowedExtension.Split(',')}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
