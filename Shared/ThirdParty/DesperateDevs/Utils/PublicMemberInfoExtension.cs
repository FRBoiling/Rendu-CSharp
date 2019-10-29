using System;
using System.Collections.Generic;
using System.Reflection;

namespace DesperateDevs.Utils
{
    public static class PublicMemberInfoExtension
    {
        public static List<PublicMemberInfo> GetPublicMemberInfos(this Type type)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            List<PublicMemberInfo> publicMemberInfoList = new List<PublicMemberInfo>(fields.Length + properties.Length);
            for (int index = 0; index < fields.Length; ++index)
                publicMemberInfoList.Add(new PublicMemberInfo(fields[index]));
            for (int index = 0; index < properties.Length; ++index)
            {
                PropertyInfo info = properties[index];
                if (info.CanRead && info.CanWrite && info.GetIndexParameters().Length == 0)
                    publicMemberInfoList.Add(new PublicMemberInfo(info));
            }
            return publicMemberInfoList;
        }

        public static object PublicMemberClone(this object obj)
        {
            object instance = Activator.CreateInstance(obj.GetType());
            obj.CopyPublicMemberValues(instance);
            return instance;
        }

        public static T PublicMemberClone<T>(this object obj) where T : new()
        {
            T obj1 = new T();
            obj.CopyPublicMemberValues((object) obj1);
            return obj1;
        }

        public static void CopyPublicMemberValues(this object source, object target)
        {
            List<PublicMemberInfo> publicMemberInfos = source.GetType().GetPublicMemberInfos();
            for (int index = 0; index < publicMemberInfos.Count; ++index)
            {
                PublicMemberInfo publicMemberInfo = publicMemberInfos[index];
                publicMemberInfo.SetValue(target, publicMemberInfo.GetValue(source));
            }
        }
    }
}