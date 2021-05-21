using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Juice_Demo_Modulr.Core.Validation
{
    public class CustomAttributeValidation : ValidationAttribute
    {
        private readonly string _dependsOnPropertyName;
        private readonly string[] _currentPropertyForDependsOnValue;
        private readonly bool _canBeNull;

        public CustomAttributeValidation(string dependsOnPropertyName, string[] currentPropertyForDependsOnValue, bool canBeNull)
        {
            _dependsOnPropertyName = dependsOnPropertyName;
            _currentPropertyForDependsOnValue = currentPropertyForDependsOnValue;
            _canBeNull = canBeNull;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext != null)
            {
                var dependsOnPropertyInfo = validationContext.ObjectType.GetProperty(_dependsOnPropertyName);
                var dependsOnPropertyValue = dependsOnPropertyInfo.GetValue(validationContext.ObjectInstance, null);

                if (_canBeNull && !_currentPropertyForDependsOnValue.Contains(dependsOnPropertyValue) && value == null)
                {
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }
                if (!_canBeNull && _currentPropertyForDependsOnValue.Contains(dependsOnPropertyValue) && value == null)
                {
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }
                return base.IsValid(value, validationContext);
            }
            return null;

        }
    }
}
