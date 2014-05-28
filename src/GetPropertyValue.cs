using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insya.Localization
{
    public class GetPropertyByValue
    {

        /// <summary>
        /// Get Property Value by name
        /// </summary>
        /// <param name="car"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public object GetValue(object car, string propertyName)
        {
            return car.GetType().GetProperties()
               .Single(pi => pi.Name == propertyName)
               .GetValue(car, null);
        }
    }
}
