using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ServiceLayer.Utility
{
    public static class Mapper<M>
    {
        public static M Map<T>(T tableObj)
        {
            M modelObj = Activator.CreateInstance<M>();

            var tableProperties = tableObj.GetType().GetProperties();
            var modelProperties = modelObj.GetType().GetProperties();

            foreach (PropertyInfo tblProperty in tableProperties)
            {
                foreach (PropertyInfo modelProperty in modelProperties)
                {
                    if(modelProperty.Name == tblProperty.Name)
                    {
                        modelProperty.SetValue(modelObj, tblProperty.GetValue(tableObj));
                    }
                }
            }

            return modelObj;
        }
    }
}
