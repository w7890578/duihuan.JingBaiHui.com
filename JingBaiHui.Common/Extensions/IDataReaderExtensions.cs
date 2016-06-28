using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace JingBaiHui.Common
{
    /// <summary>
    /// Contains extension methods for the IDataReader interface.
    /// </summary>
    /// <remark>Author : PetterLiu 2009-04-17 22:34  http://wintersun.cnblogs.com </remark>
    public static class IDataReaderExtensions
    {
        /// <summary>
        /// Gets the IDataReader value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader">The reader.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <example><code>
        /// <![CDATA[
        ///   IDataReader reader = command.ExecuteReader();
        ///  if (reader.Read())
        ///  {
        ///    DateTime date = reader.GetValue<DateTime>("CreationDate");
        ///    Int32? orderId = reader.GetValue<Int32?>("NullableID");
        ///  }
        /// ]]>
        /// </code></example>
        /// <returns>The column value within the reader typed as T</returns>
        public static T GetValue<T>(this IDataReader reader, String fieldName)
        {
            if (String.IsNullOrEmpty(fieldName))
                throw new ArgumentNullException("Field Name cannot be null");
            if (reader[fieldName] is DBNull)
                return default(T);
            return (T)reader[fieldName];
        }

        /// <summary>
        /// Gets the value or default.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader">The reader.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <returns>The column value within the reader typed as T.</returns>
        /// <remark>PetterLiu 2009-04-17 22:34  http://wintersun.cnblogs.com </remark>
        /// <example><code>
        /// <![CDATA[
        /// int? myInt = reader.GetValueOrDefault<int?>("myColumnName");
        /// DateTime myDate = reader.GetValueOrDefault<DateTime>("myColumnName");
        /// ]]>
        /// </code></example>
        public static T GetValueOrDefault<T>(this IDataReader reader, string columnName)
        {
            return GetValueOrDefault<T>(reader, columnName, default(T));
        }

        /// <summary>
        /// Gets the value or default.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader">The reader.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The column value within the reader typed as T.</returns>
        /// <remark>PetterLiu 2009-04-17 22:34  http://wintersun.cnblogs.com </remark>
        /// <example><code>
        /// <![CDATA[
        ///  //Default to true if myColumnName is null
        /// bool myBool = reader.GetValueOrDefault<bool>("myColumnName", true);
        /// ]]>
        /// </code></example>
        public static T GetValueOrDefault<T>(this IDataReader reader, string columnName, T defaultValue)
        {
            T returnValue = defaultValue;
            int ordinal;
            try
            {
                ordinal = reader.GetOrdinal(columnName);
            }
            catch
            {
                throw new Exception(string.Format("Column {0} was not found on IDataReader.", columnName));
            }
            object columnValue = reader.GetValue(ordinal);
            if (!(columnValue is DBNull))
            {
                Type returnType = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
                returnValue = (T)Convert.ChangeType(columnValue, returnType);
            }
            return returnValue;
        }

        /// <summary>
        /// This method will return the value of the specified columnIndex, cast to
        /// the type specified in T.  However, if the value found in the reader is
        /// DBNull, this method will return the default value of the type T.
        /// </summary>
        /// <typeparam name="T">The type to which the value found in the reader should be cast.</typeparam>
        /// <param name="reader">The reader in which columnIndex exists.</param>
        /// <param name="columnName">The columnIndex to retrieve.</param>
        /// <returns>The column value within the reader typed as T.</returns>
        public static T GetValueOrDefault<T>(this IDataReader reader, int columnIndex)
        {
            return reader.GetValueOrDefault<T>(reader.GetName(columnIndex));
        }


        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader">The reader.</param>
        /// <param name="field">The field.</param>
        /// <param name="code">The code.</param>
        /// <returns>The column value within the reader typed as T.</returns>
        /// <example><code>address.ID = dr.GetValue("ID", i => dr.GetInt32(i));</code></example>
        /// <remark>PetterLiu 2009-04-17 22:35  http://wintersun.cnblogs.com </remark>
        public static T GetValue<T>(this IDataReader reader, string field, Func<int, T> code)
        {
            T value = default(T);
            int ordinal = reader.GetOrdinal(field);
            if (!reader.IsDBNull(ordinal))
                value = code(ordinal);
            return (value);
        }

        /// <summary>
        /// Gets the value or null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader">The reader.</param>
        /// <param name="field">The field.</param>
        /// <param name="code">The code.</param>
        /// <returns>The column value within the reader typed as T.</returns>
        /// <remark> PetterLiu 2009-04-17 22:38  http://wintersun.cnblogs.com </remark>
        public static T? GetValueOrNull<T>(this IDataReader reader, string field, Func<int, T> code) where T : struct
        {
            T? value = null;
            int ordinal = reader.GetOrdinal(field);
            if (!reader.IsDBNull(ordinal))
                value = code(ordinal);
            return (value);
        }


        /// <summary>
        /// Returns a string if one is present, or null if not
        /// </summary>
        /// <param name="reader">The IDbReader to read from</param>
        /// <param name="index">The index of the column to read from</param>
        /// <returns>A string, or null if the column's value is NULL</returns>
        public static string GetNullableString(this IDataRecord reader, int index)
        {
            return reader.IsDBNull(index) ? (string)null : reader.GetString(index);
        }

        /// <summary>
        /// Returns a bool if one is present, or null if not
        /// </summary>
        /// <param name="reader">The IDbReader to read from</param>
        /// <param name="index">The index of the column to read from</param>
        /// <returns>A bool, or null if the column's value is NULL</returns>
        public static bool? GetNullableBool(this IDataRecord reader, int index)
        {
            return reader.IsDBNull(index) ? (bool?)null : reader.GetBoolean(index);
        }

        /// <summary>
        /// Returns a DateTime if one is present, or null if not
        /// </summary>
        /// <param name="reader">The IDbReader to read from</param>
        /// <param name="index">The index of the column to read from</param>
        /// <returns>A DateTime, or null if the column's value is NULL</returns>
        public static DateTime? GetNullableDateTime(this IDataRecord reader, int index)
        {
            return reader.IsDBNull(index) ? (DateTime?)null : reader.GetDateTime(index);
        }

        /// <summary>
        /// Returns a byte if one is present, or null if not
        /// </summary>
        /// <param name="reader">The IDbReader to read from</param>
        /// <param name="index">The index of the column to read from</param>
        /// <returns>A byte, or null if the column's value is NULL</returns>
        public static byte? GetNullableByte(this IDataRecord reader, int index)
        {
            return reader.IsDBNull(index) ? (byte?)null : reader.GetByte(index);
        }

        /// <summary>
        /// Returns a short if one is present, or null if not
        /// </summary>
        /// <param name="reader">The IDbReader to read from</param>
        /// <param name="index">The index of the column to read from</param>
        /// <returns>A short, or null if the column's value is NULL</returns>
        public static short? GetNullableInt16(this IDataRecord reader, int index)
        {
            return reader.IsDBNull(index) ? (short?)null : reader.GetInt16(index);
        }

        /// <summary>
        /// Returns an int if one is present, or null if not
        /// </summary>
        /// <param name="reader">The IDbReader to read from</param>
        /// <param name="index">The index of the column to read from</param>
        /// <returns>An int, or null if the column's value is NULL</returns>
        public static int? GetNullableInt32(this IDataRecord reader, int index)
        {
            return reader.IsDBNull(index) ? (int?)null : reader.GetInt32(index);
        }

        /// <summary>
        /// Returns a float if one is present, or null if not
        /// </summary>
        /// <param name="reader">The IDbReader to read from</param>
        /// <param name="index">The index of the column to read from</param>
        /// <returns>A float, or null if the column's value is NULL</returns>
        public static float? GetNullableFloat(this IDataRecord reader, int index)
        {
            return reader.IsDBNull(index) ? (float?)null : reader.GetFloat(index);
        }

        /// <summary>
        /// Returns a double if one is present, or null if not
        /// </summary>
        /// <param name="reader">The IDbReader to read from</param>
        /// <param name="index">The index of the column to read from</param>
        /// <returns>A double, or null if the column's value is NULL</returns>
        public static double? GetNullableDouble(this IDataRecord reader, int index)
        {
            return reader.IsDBNull(index) ? (double?)null : reader.GetDouble(index);
        }

    }
}
