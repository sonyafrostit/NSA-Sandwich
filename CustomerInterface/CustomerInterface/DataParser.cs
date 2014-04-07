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
    class DataParser
    {
        private CultureInfo ci;

        public DataParser(CultureInfo c)
        {
            ci = c;
        }

        public string parseCategory(string name)
        {
            string translatedWord;

            Assembly a = Assembly.Load("CustomerInterface");
            ResourceManager rm = new ResourceManager("CustomerInterface.Lang.lang", a);
            translatedWord = rm.GetString(name.ToLower(), ci);

            if (String.IsNullOrEmpty(translatedWord))
                return name;

            return translatedWord;
        }

        public string parseMenuItem(string name)
        {
            string translatedWord;                

            Assembly a = Assembly.Load("CustomerInterface");
            ResourceManager rm = new ResourceManager("CustomerInterface.Lang.components", a);
            translatedWord = rm.GetString(name.ToLower(), ci);

            if(String.IsNullOrEmpty(translatedWord))
                return name;

            return translatedWord;
        }

        public string parseComponent(string component)
        {
            string splitComponent = component.Substring(1);

            string translatedWord;

            Assembly a = Assembly.Load("CustomerInterface");
            ResourceManager rm = new ResourceManager("CustomerInterface.Lang.components", a);
            translatedWord = rm.GetString(splitComponent.ToLower(), ci);

            if(String.IsNullOrEmpty(translatedWord))
                return component;

            return "+" + translatedWord;
        }
    }
}
