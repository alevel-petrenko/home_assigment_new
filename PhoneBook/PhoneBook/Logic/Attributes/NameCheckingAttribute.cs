using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Attributes
{
    public class NameCheckingAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null && value is string name)
            {
                return name.StartsWith("A");
            }
            return true;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return base.IsValid(value, validationContext);
        }
    }
}
