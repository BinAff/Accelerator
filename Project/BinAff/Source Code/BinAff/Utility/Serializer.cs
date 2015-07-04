using System;
using System.Reflection;

namespace BinAff.Utility
{

    public static class Serializer
    {

        public static String Serialize(Object obj)
        {
            String ret = String.Empty;
            PropertyInfo[] properties = obj.GetType().GetProperties();
            ret += String.Format("<{0}>", obj.GetType().Name);
            foreach (PropertyInfo property in properties)
            {
                if(property.PropertyType.IsValueType || property.PropertyType.Name == "String")
                {
                    ret += String.Format("<{0}>{1}</{0}>", property.Name, property.GetValue(obj, null));
                }
                else if (property.PropertyType.Name == "List`1")
                {
                    ret += String.Format("<{0}>", property.Name);
                    System.Collections.IList list = property.GetValue(obj, null) as System.Collections.IList;
                    foreach (Object item in list)
                    {
                        ret += Serialize(item);
                    }
                    ret += String.Format("</{0}>", property.Name);
                }
                else
                {
                    ret += String.Format("<{0}>{1}</{0}>", property.Name, Serialize(property.GetValue(obj, null)));
                }
            }
            ret += String.Format("</{0}>", obj.GetType().Name);
            return ret;
        }

    }

}