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

        //parses components and menu items
        public string parseItem(string component)
        {
            //replace all spaces in case of two-word component
            string translatedWord = component.Replace(" ", String.Empty);

            //load assembly and resource manager
            Assembly a = Assembly.Load("CustomerInterface");
            ResourceManager rm = new ResourceManager("CustomerInterface.Lang.components", a);
            translatedWord = rm.GetString(translatedWord.ToLower(), ci); //set it to lowercase

            if(String.IsNullOrEmpty(translatedWord)) //if the string wasnt found, it will be empty
                return component;

            return translatedWord; //if it wasnt, we return the translated word
        }
    }
}
