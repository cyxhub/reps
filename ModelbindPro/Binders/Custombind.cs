using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelbindPro.Binders
{
    public class Custombind : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var parm = bindingContext.ValueProvider.GetValue("text").FirstValue;
            if (parm != null)
            {
                bindingContext.Result = ModelBindingResult.Success(parm.ToUpper());
            }
            return Task.CompletedTask;
        }
    }
}
