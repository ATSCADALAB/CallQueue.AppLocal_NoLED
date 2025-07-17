using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Reflection;

namespace SQLHelper
{
    public static class Extensions
    {
        /// <summary>
        /// Convert the DataRow to the specified object <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of the DataRow need to be convert</typeparam>
        /// <param name="dataRow">The DataRow need to be convert</param>
        /// <returns></returns>
        public static T ToObject<T>(this DataRow dataRow)
            where T : new()
        {
            T item = new T();
            foreach (DataColumn column in dataRow.Table.Columns)
            {
                PropertyInfo property = GetProperty(typeof(T), column.ColumnName);

                if (property != null && dataRow[column] != DBNull.Value && dataRow[column].ToString() != "NULL")
                {
                    property.SetValue(item, dataRow[column].ConvertTo(property.PropertyType) , null);
                }
            }
            return item;
        }

        /// <summary>
        /// Convert the <see cref="DataTable"/> to the List of the object <see cref="T"/>
        /// </summary>
        /// <typeparam name="T">Type of the object will be converted</typeparam>
        /// <param name="dataTable">The DataTable will be converted</param>
        /// <returns></returns>
        public static List<T> ToObjects<T>(this DataTable dataTable)
            where T : new()
        {
            List<T> objects = new List<T>();
            foreach (DataRow dtRow in dataTable.Rows)
            {
                T obj = dtRow.ToObject<T>();
                objects.Add(obj);
            }
            return objects;
        }

        /// <summary>
        /// Get the property info of the type
        /// </summary>
        /// <param name="type">The type need to get the property info</param>
        /// <param name="attributeName">The attribute name</param>
        /// <returns></returns>
        private static PropertyInfo GetProperty(Type type, string attributeName)
        {
            PropertyInfo property = type.GetProperty(attributeName);

            if (property != null)
            {
                return property;
            }

            return type.GetProperties()
                 .Where(p => p.IsDefined(typeof(DisplayAttribute), false) && p.GetCustomAttributes(typeof(DisplayAttribute), false).Cast<DisplayAttribute>().Single().Name == attributeName)
                 .FirstOrDefault();
        }

        /// <summary>
        /// Convert the object to the specified type
        /// </summary>
        /// <param name="value">The object to be convert</param>
        /// <param name="type">The type of object is convert to</param>
        /// <returns></returns>
        public static object ConvertTo<T>(this object value)
        {
            return value.ConvertTo(typeof(T));
        }

        /// <summary>
        /// Convert the object to the specified type
        /// </summary>
        /// <param name="value">The object to be convert</param>
        /// <param name="type">The type of object is convert to</param>
        /// <returns></returns>
        public static object ConvertTo(this object value, Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }

                return Convert.ChangeType(value, Nullable.GetUnderlyingType(type));
            }

            return Convert.ChangeType(value, type);
        }
    }
}
