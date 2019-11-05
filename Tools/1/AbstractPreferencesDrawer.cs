using DesperateDevs.Serialization;

namespace DesperateDevs.Unity.Editor
{
    public abstract class AbstractPreferencesDrawer : IPreferencesDrawer
    {
        protected bool _drawContent = true;

        public abstract string title { get; }

        public abstract void Initialize(Preferences preferences);

        public abstract void DrawHeader(Preferences preferences);

        public virtual void DrawContent(Preferences preferences)
        {
            this._drawContent = EditorLayout.DrawSectionHeaderToggle(this.title, this._drawContent);
            if (!this._drawContent)
                return;
            EditorLayout.BeginSectionContent();
            this.drawContent(preferences);
            EditorLayout.EndSectionContent();
        }

        protected abstract void drawContent(Preferences preferences);
    }
}