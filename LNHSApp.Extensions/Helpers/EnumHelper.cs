using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNHSApp.Extensions.Helpers
{
    public class EnumHelper
    {
        public static IDictionary<int, string> GetEnumDictionary<TEnum>()
            where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum)
                return null;

            var dictionary = Enum.GetValues(typeof(TEnum))
               .Cast<TEnum>()
               .ToDictionary(e => Convert.ToInt32(e), e => e.ToString());
            return dictionary;
        }
    }
}
