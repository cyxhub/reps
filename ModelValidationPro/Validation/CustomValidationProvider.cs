using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModelValidationPro.Validation
{
    public class CustomValidationProvider:ValidationAttributeAdapterProvider,IValidationAttributeAdapterProvider
    {
        
        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            var requierdattribute = attribute as RequiredAttribute;
            if (requierdattribute != null)
            {
                if (requierdattribute.ErrorMessage == null && requierdattribute.ErrorMessageResourceName == null)
                {
                    requierdattribute.ErrorMessage = "{0}未填写";
                }
            }
            var lengthattribute = attribute as StringLengthAttribute;
            if (lengthattribute != null)
            {
                if (lengthattribute.ErrorMessage == null && lengthattribute.ErrorMessageResourceName == null)
                {
                    lengthattribute.ErrorMessage = "{0}长度应小于3";
                }
            }
            
            return base.GetAttributeAdapter(attribute,stringLocalizer);
        }
    }
}
