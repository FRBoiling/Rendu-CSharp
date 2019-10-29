using System;
using System.Reflection;

namespace DesperateDevs.Utils
{
    public class PublicMemberInfo
    {
        public readonly Type type;
        public readonly string name;
        public readonly AttributeInfo[] attributes;
        private readonly FieldInfo _fieldInfo;
        private readonly PropertyInfo _propertyInfo;

        public PublicMemberInfo(FieldInfo info)
        {
            this._fieldInfo = info;
            this.type = this._fieldInfo.FieldType;
            this.name = this._fieldInfo.Name;
            this.attributes = PublicMemberInfo.getAttributes(this._fieldInfo.GetCustomAttributes(false));
        }

        public PublicMemberInfo(PropertyInfo info)
        {
            this._propertyInfo = info;
            this.type = this._propertyInfo.PropertyType;
            this.name = this._propertyInfo.Name;
            this.attributes = PublicMemberInfo.getAttributes(this._propertyInfo.GetCustomAttributes(false));
        }

        public PublicMemberInfo(Type type, string name, AttributeInfo[] attributes = null)
        {
            this.type = type;
            this.name = name;
            this.attributes = attributes;
        }

        public object GetValue(object obj)
        {
            if (this._fieldInfo == null)
                return this._propertyInfo.GetValue(obj, (object[]) null);
            return this._fieldInfo.GetValue(obj);
        }

        public void SetValue(object obj, object value)
        {
            if (this._fieldInfo != null)
                this._fieldInfo.SetValue(obj, value);
            else
                this._propertyInfo.SetValue(obj, value, (object[]) null);
        }

        private static AttributeInfo[] getAttributes(object[] attributes)
        {
            AttributeInfo[] attributeInfoArray = new AttributeInfo[attributes.Length];
            for (int index = 0; index < attributes.Length; ++index)
            {
                object attribute = attributes[index];
                attributeInfoArray[index] = new AttributeInfo(attribute, attribute.GetType().GetPublicMemberInfos());
            }
            return attributeInfoArray;
        }
    }
}