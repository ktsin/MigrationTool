using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTool.Helpers
{
    public static class ServiceContainerExtensionsMethods
    {
        public static T GetService<T>(this IServiceProvider services) where T : class
        {
            var result = (T?)services.GetService(typeof(T));
            if(result is null)
            {
                throw new InvalidOperationException($"Service {typeof(T).Name} is not registered in DI container");
            }
            return result;
        }
    }
}
