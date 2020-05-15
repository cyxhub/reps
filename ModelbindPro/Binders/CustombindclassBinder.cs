using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelbindPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelbindPro.Binders
{
    public class CustombindclassBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //获取parameter名称
            var parameterName = bindingContext.ModelMetadata.ParameterName;
            //https://localhost:44325/Person/index2?person=1 通过id索引person对象的值
            var value = bindingContext.ValueProvider.GetValue(parameterName).FirstValue;
            
            Person person = new Person
            {
                id=1,
                name="iorjg"
            };
       
            bindingContext.Result = ModelBindingResult.Success(person);
            return Task.CompletedTask;
        }
    }
}
