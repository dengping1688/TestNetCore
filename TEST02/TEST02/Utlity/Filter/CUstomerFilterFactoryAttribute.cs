using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TEST02.Utlity.Filter
{
    public class CUstomerFilterFactoryAttribute : Attribute, IFilterFactory
    {
        private Type _filterType = null;

        public CUstomerFilterFactoryAttribute(Type type)
        {
            this._filterType = type;
        }
        public bool IsReusable => true;

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return (IFilterMetadata)serviceProvider.GetService(_filterType);
        }
    }
}
