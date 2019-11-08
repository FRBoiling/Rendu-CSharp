using System.Text;

namespace Entitas.Matcher
{
    public partial class Matcher<TEntity>
    {
        private StringBuilder _toStringBuilder;

        private string _toStringCache;

        public override string ToString()
        {
            if (_toStringCache == null)
            {
                if (_toStringBuilder == null) _toStringBuilder = new StringBuilder();
                _toStringBuilder.Length = 0;
                if (allOfIndices != null) appendIndices(_toStringBuilder, "AllOf", allOfIndices, componentNames);
                if (anyOfIndices != null)
                {
                    if (allOfIndices != null) _toStringBuilder.Append(".");
                    appendIndices(_toStringBuilder, "AnyOf", anyOfIndices, componentNames);
                }

                if (noneOfIndices != null) appendIndices(_toStringBuilder, ".NoneOf", noneOfIndices, componentNames);
                _toStringCache = _toStringBuilder.ToString();
            }

            return _toStringCache;
        }

        private static void appendIndices(StringBuilder sb, string prefix, int[] indexArray, string[] componentNames)
        {
            const string separator = ", ";
            sb.Append(prefix);
            sb.Append("(");
            var lastSeparator = indexArray.Length - 1;
            for (var i = 0; i < indexArray.Length; i++)
            {
                var index = indexArray[i];
                if (componentNames == null)
                    sb.Append(index);
                else
                    sb.Append(componentNames[index]);

                if (i < lastSeparator) sb.Append(separator);
            }

            sb.Append(")");
        }
    }
}