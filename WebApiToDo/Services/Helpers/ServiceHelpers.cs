using System;

namespace WebApiToDo.Services.Helpers
{
    public static class ServiceHelpers
    {
        public static int ConvertBoolToInt(bool boolValue) => Convert.ToInt32(boolValue);
    }
}
