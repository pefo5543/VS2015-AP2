using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Game_AVP2.Models
{
    public class BaseModel
    {

        private static void SetValue(object original, string theProperty, object theValue)
        {
            try
            {
                PropertyInfo propertyInfo = original.GetType().GetProperty(theProperty);
                propertyInfo.SetValue(original, theValue, null);
                propertyInfo.GetType().GetProperties();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        protected static object SetViewModelProperties(object viewModel, object model)
        {
            PropertyInfo[] propertyInfos = model.GetType().GetProperties();
            PropertyInfo[] thisInfos = viewModel.GetType().GetProperties();
            foreach (PropertyInfo p in propertyInfos)
            {
                int pos = 0;
                foreach (PropertyInfo t in thisInfos)
                {
                    if (p.PropertyType == t.PropertyType && p.Name == t.Name)
                    {
                        thisInfos[pos].SetValue(viewModel, p.GetValue(model), null);
                        break;
                    }
                    pos++;
                }
            }

            return viewModel;
        }

        protected static bool SetEditValues(ApplicationDbContext db, object original, object updated)
        {
            var entry = db.Entry(original);
            bool noPropertyChanged = true;
            entry.CurrentValues.SetValues(updated);
            entry.OriginalValues.SetValues(original);
            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                noPropertyChanged = false;
            }

            return noPropertyChanged;
        }
    }
}