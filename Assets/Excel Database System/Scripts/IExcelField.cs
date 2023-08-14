using System;
using System.Reflection;

namespace ExcelDB
{

    public interface IExcelField
    {
        public object Read(string data);
        public string FieldName { get; set; }
    }
    public abstract class ExcelField : IExcelField
    {
        public static IExcelField GetField(Type type, string fieldName)
        {
            var field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
            Type fieldType = field?.FieldType;

            // 타입 반환 (필드 종류에 따라 추가해 줘야 함
            if (fieldType == typeof(string)) return new stringField();
            else if (fieldType == typeof(System.Int32)) return new intField();
            else if (fieldType == typeof(System.UInt32)) return new uintField();
            else if (fieldType == typeof(System.Single)) return new floatField();
            else return null;
            //
        }
        public abstract object Read(string data);
        public string FieldName { get; set; }
    }

    #region example
    public class uintField : ExcelField
    {
        public override object Read(string data)
        {
            try
            {
                if (data == null || data == "") return (uint)0;
                return uint.Parse(data);
            }
            catch
            {
                return (uint)0;
            }
        }
    }
    public class stringField : ExcelField
    {
        public override object Read(string data)
        {
            return data;
        }
    }
    public class intField : ExcelField
    {
        public override object Read(string data)
        {
            try
            {
                if (data == null || data == "") return 0;
                return int.Parse(data);
            }
            catch
            {
                return 0;
            }
        }
    }
    public class floatField : ExcelField
    {
        public override object Read(string data)
        {
            try
            {
                if (data == null || data == "") return 0f;
                return float.Parse(data);
            }
            catch
            {
                return 0f;
            }

        }

    }
    #endregion
}