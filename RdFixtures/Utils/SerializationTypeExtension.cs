using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rd.Utils
{
    public static class SerializationTypeExtension
    {
        private static readonly Dictionary<string, string> _builtInTypesToString = new Dictionary<string, string>
        {
            {
                "System.Boolean",
                "bool"
            },
            {
                "System.Byte",
                "byte"
            },
            {
                "System.SByte",
                "sbyte"
            },
            {
                "System.Char",
                "char"
            },
            {
                "System.Decimal",
                "decimal"
            },
            {
                "System.Double",
                "double"
            },
            {
                "System.Single",
                "float"
            },
            {
                "System.Int32",
                "int"
            },
            {
                "System.UInt32",
                "uint"
            },
            {
                "System.Int64",
                "long"
            },
            {
                "System.UInt64",
                "ulong"
            },
            {
                "System.Object",
                "object"
            },
            {
                "System.Int16",
                "short"
            },
            {
                "System.UInt16",
                "ushort"
            },
            {
                "System.String",
                "string"
            },
            {
                "System.Void",
                "void"
            }
        };

        private static readonly Dictionary<string, string> _builtInTypeStrings = new Dictionary<string, string>
        {
            {
                "bool",
                "System.Boolean"
            },
            {
                "byte",
                "System.Byte"
            },
            {
                "sbyte",
                "System.SByte"
            },
            {
                "char",
                "System.Char"
            },
            {
                "decimal",
                "System.Decimal"
            },
            {
                "double",
                "System.Double"
            },
            {
                "float",
                "System.Single"
            },
            {
                "int",
                "System.Int32"
            },
            {
                "uint",
                "System.UInt32"
            },
            {
                "long",
                "System.Int64"
            },
            {
                "ulong",
                "System.UInt64"
            },
            {
                "object",
                "System.Object"
            },
            {
                "short",
                "System.Int16"
            },
            {
                "ushort",
                "System.UInt16"
            },
            {
                "string",
                "System.String"
            },
            {
                "void",
                "System.Void"
            }
        };

        public static string ToCompilableString(this Type type)
        {
            if (_builtInTypesToString.ContainsKey(type.FullName))
                return _builtInTypesToString[type.FullName];
            if (type.IsGenericType)
                return type.FullName.Split('`')[0] + "<" + string.Join(", ", type.GetGenericArguments().Select(argType => argType.ToCompilableString()).ToArray()) + ">";
            if (type.IsArray)
                return type.GetElementType().ToCompilableString() + "[" + new string(',', type.GetArrayRank() - 1) + "]";
            if (type.IsNested)
                return type.FullName.Replace('+', '.');
            else
            {
                Regex regex = new Regex(@"<[^>]+>|</[^>]+>"); 
                var fullName = regex.Replace(type.FullName, "");
                return fullName;
            }
        }

        public static Type ToType(this string typeString)
        {
            var typeString1 = generateTypeString(typeString);
            var type1 = Type.GetType(typeString1);
            if (type1 != null)
                return type1;
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var type2 = assembly.GetType(typeString1);
                if (type2 != null)
                    return type2;
            }

            return null;
        }

        public static string ShortTypeName(this string fullTypeName)
        {
            var strArray = fullTypeName.Split('.');
            return strArray[strArray.Length - 1];
        }

        public static string RemoveDots(this string fullTypeName)
        {
            return fullTypeName.Replace(".", string.Empty);
        }

        private static string generateTypeString(string typeString)
        {
            if (_builtInTypeStrings.ContainsKey(typeString))
            {
                typeString = _builtInTypeStrings[typeString];
            }
            else
            {
                typeString = generateGenericArguments(typeString);
                typeString = generateArray(typeString);
            }

            return typeString;
        }

        private static string generateGenericArguments(string typeString)
        {
            var separator = new string[1] {", "};
            typeString = Regex.Replace(typeString, "<(?<arg>.*)>", m =>
            {
                var typeString1 = generateTypeString(m.Groups["arg"].Value);
                return "`" + (object) typeString1.Split(separator, StringSplitOptions.None).Length + "[" + typeString1 + "]";
            });
            return typeString;
        }

        private static string generateArray(string typeString)
        {
            typeString = Regex.Replace(typeString, "(?<type>[^\\[]*)(?<rank>\\[,*\\])", m => generateTypeString(m.Groups["type"].Value) + m.Groups["rank"].Value);
            return typeString;
        }
    }
}