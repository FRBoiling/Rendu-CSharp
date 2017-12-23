using System;

namespace DataParserLib
{
    public enum AttributeValueType
    {
        INT,
        FLOAT,
        STRING,
        //BOOL,
    }

    public class Attribute : ICloneable
    {
        private AttributeValueType _type;
        public object Clone()
        {
            var clone = new Attribute(_type, _key, _value);
            clone._type = _type;
            clone._key = _key;
            clone._value = _value;
            return clone;
        }

        private string _key;
        private object _value;

        public string Key { get => _key; set => _key = value; }
        public object Value { get => _value; set => _value = value; }


        public Attribute(AttributeValueType type,string key,object value)
        {
            Set(type, key, value);
        }

        private void Set(AttributeValueType type, string key, object value)
        {
            _type = type;
            _key = key;
            _value = value;
        }

        /// <summary>
        /// 取int值
        /// </summary>
        /// <returns></returns>
        public int GetInt()
        {
            int ret = 0;
            switch (_type )
            {
                case AttributeValueType.INT:
                    int.TryParse(_value.ToString().Trim(), out ret);
                    break;
                case AttributeValueType.FLOAT:
                    ret = (int)(float)_value;
                    break;
                case AttributeValueType.STRING:
                //case AttributeValueType.BOOL:
                default:
                    ret = (int)_value;
                    break;
            }
            return ret;
        }

        /// <summary>
        /// 取string值
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            return _value.ToString().Trim();
        }

        /// <summary>
        /// 取float值
        /// </summary>
        /// <returns></returns>
        public float GetFloat()
        {
            float ret = 0.0f;
            switch (_type)
            {
                case AttributeValueType.INT:
                    ret = (int)_value;
                    break;
                case AttributeValueType.FLOAT:
                    float.TryParse(_value.ToString().Trim(), out ret);
                    break;
                case AttributeValueType.STRING:
                //case AttributeValueType.BOOL:
                default:
                    ret = (float)_value; 
                    break;
            }
            return ret;
        }
   
    }
}
