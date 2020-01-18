using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Rd.Helper
{
	public static class StringHelper
    {
		public static IEnumerable<byte> ToBytes(this string str)
		{
			byte[] byteArray = Encoding.UTF8.GetBytes(str);
			return byteArray;
		}

		public static byte[] ToByteArray(this string str)
		{
			byte[] byteArray = Encoding.UTF8.GetBytes(str);
			return byteArray;
		}

		public static byte[] ToUtf8(this string str)
		{
			byte[] byteArray = Encoding.UTF8.GetBytes(str);
			return byteArray;
		}

		public static void ToStream(string obj, MemoryStream stream)
		{
			stream = new MemoryStream(Encoding.UTF8.GetBytes(obj));
		}

		public static object FromBytes(Type type, byte[] bytes, int index, int count)
		{
			return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
		}

		public static object FromBytes(object message, byte[] bytes, int index, int count)
		{
			message = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
			return message;
		}


		public static object FromStream(Type type, MemoryStream stream)
		{
			var bytes = stream.ToArray();
			return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
		}

		public static object FromStream(object message, MemoryStream stream)
		{
			//message = Convert.ToBase64String(stream.ToArray());
			var b = stream.ToArray();
            message = Encoding.UTF8.GetString(b, 0, b.Length);
			return message;
		}

		//public static byte[] HexToBytes(this string hexString)
		//{
		//	if (hexString.Length % 2 != 0)
		//	{
		//		throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
		//	}

		//	var hexAsBytes = new byte[hexString.Length / 2];
		//	for (int index = 0; index < hexAsBytes.Length; index++)
		//	{
		//		string byteValue = "";
		//		byteValue += hexString[index * 2];
		//		byteValue += hexString[index * 2 + 1];
		//		hexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		//	}
		//	return hexAsBytes;
		//}

		public static string Fmt(this string text, params object[] args)
		{
			return string.Format(text, args);
		}

		public static string ListToString<T>(this List<T> list)
		{
			StringBuilder sb = new StringBuilder();
			foreach (T t in list)
			{
				sb.Append(t);
				sb.Append(",");
			}
			return sb.ToString();
		}


		public static string MessageToStr(object message)
		{
			return (string)message;
		}
	}
}
