using UnityEngine;

namespace DesperateDevs.Unity.Editor
{
    public static class Styles
    {
        private static GUIStyle _sectionHeader;
        private static GUIStyle _sectionContent;

        public static GUIStyle sectionHeader
        {
            get
            {
                if (Styles._sectionHeader == null)
                    Styles._sectionHeader = new GUIStyle((GUIStyle) "OL Title");
                return Styles._sectionHeader;
            }
        }

        public static GUIStyle sectionContent
        {
            get
            {
                if (Styles._sectionContent == null)
                {
                    Styles._sectionContent = new GUIStyle((GUIStyle) "OL Box");
                    Styles._sectionContent.stretchHeight = false;
                }
                return Styles._sectionContent;
            }
        }
    }
}