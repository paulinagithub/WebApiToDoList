using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiToDo.Services.Helpers
{
    public static class ServiceHelpers
    {
        public static int ConvertBoolToInt(bool boolValue) => Convert.ToInt32(boolValue);
    }
}
