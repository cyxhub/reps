using Microsoft.AspNetCore.Mvc.ModelBinding;
using ModelbindPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelbindPro.Binders
{
    //此类应在startup中注册
    public class CustombinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(Person))
            {
                return new CustombindclassBinder();
            }
            return null;
        }
    }
}
