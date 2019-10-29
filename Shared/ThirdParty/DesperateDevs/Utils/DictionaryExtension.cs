using System;
using System.Collections.Generic;
using System.Linq;

namespace DesperateDevs.Utils
{
    public static class DictionaryExtension
    {
        public static Dictionary<TKey, TValue> Merge<TKey, TValue>(
            this Dictionary<TKey, TValue> dictionary,
            params Dictionary<TKey, TValue>[] dictionaries)
        {
            return ((IEnumerable<Dictionary<TKey, TValue>>) dictionaries).Aggregate<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>>(dictionary, (Func<Dictionary<TKey, TValue>, Dictionary<TKey, TValue>, Dictionary<TKey, TValue>>) ((current, dict) => current.Union<KeyValuePair<TKey, TValue>>((IEnumerable<KeyValuePair<TKey, TValue>>) dict).ToDictionary<KeyValuePair<TKey, TValue>, TKey, TValue>((Func<KeyValuePair<TKey, TValue>, TKey>) (kv => kv.Key), (Func<KeyValuePair<TKey, TValue>, TValue>) (kv => kv.Value))));
        }
    }
}