using System;
using System.Collections.Generic;
using System.Reflection;

namespace DesperateDevs.Utils
{
    public static class PublicMemberInfoExtension
    {
        public static List<PublicMemberInfo> GetPublicMemberInfos(this Type type)
        {
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var publicMemberInfoList = new List<PublicMemberInfo>(fields.Length + properties.Length);
            for (var index = 0; index < fields.Length; ++index)
                publicMemberInfoList.Add(new PublicMemberInfo(fields[index]));
            for (var index = 0; index < properties.Length; ++index)
            {
                var info = properties[index];
                if (info.CanRead && info.CanWrite && info.GetIndexParameters().Length == 0)
                    publicMemberInfoList.Add(new PublicMemberInfo(info));
            }

            return publicMemberInfoList;
        }

        public static object PublicMemberClone(this object obj)
        {
            var instance = Activator.CreateInstance(obj.GetType());
            obj.CopyPublicMemberValues(instance);
            return instance;
        }

        public static T PublicMemberClone<T>(this object obj) where T : new()
        {
            var obj1 = new T();
            obj.CopyPublicMemberValues((object) obj1);
            return obj1;
        }

        public static void CopyPublicMemberValues(this object source, object target)
        {
            var publicMemberInfos = source.GetType().GetPublicMemberInfos();
            for (var index = 0; index < publicMemberInfos.Count; ++index)
            {
                var publicMemberInfo = publicMemberInfos[index];
                publicMemberInfo.SetValue(target, publicMemberInfo.GetValue(source));
            }
        }
    }
}