using Rd.Serialization;

namespace Rendu.Unity.Editor
{
    public interface IPreferencesDrawer
    {
        string title { get; }

        void Initialize(Preferences preferences);

        void DrawHeader(Preferences preferences);

        void DrawContent(Preferences preferences);
    }
}