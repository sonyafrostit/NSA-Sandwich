using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Resources;
using System.Globalization;

namespace CustomerInterface
{
    class ComponentParser
    {
        private CultureInfo ci;

        public ComponentParser(CultureInfo c)
        {
            ci = c;
        }

        public string parseComponent(string component)
        {
            string translatedWord;

            Assembly a = Assembly.Load("CustomerInterface");
            ResourceManager rm = new ResourceManager("CustomerInterface.Lang.components", a);
            translatedWord = rm.GetString(component.ToLower(), ci);

            if(String.IsNullOrEmpty(translatedWord))
                return component;

            return translatedWord;
        }
    }
}
