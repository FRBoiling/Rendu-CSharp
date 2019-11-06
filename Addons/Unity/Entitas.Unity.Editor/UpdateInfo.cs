using System;

namespace Entitas.Unity.Editor
{
    public class UpdateInfo
    {
        public readonly string localVersionString;
        public readonly string remoteVersionString;
        private readonly UpdateState _updateState;

        public UpdateState updateState
        {
            get
            {
                return this._updateState;
            }
        }

        public UpdateInfo(string localVersionString, string remoteVersionString)
        {
            this.localVersionString = localVersionString.Trim();
            this.remoteVersionString = remoteVersionString.Trim();
            if (remoteVersionString != string.Empty)
            {
                Version version = new Version(localVersionString);
                switch (new Version(remoteVersionString).CompareTo(version))
                {
                    case -1:
                        this._updateState = UpdateState.AheadOfLatestRelease;
                        break;
                    case 0:
                        this._updateState = UpdateState.UpToDate;
                        break;
                    case 1:
                        this._updateState = UpdateState.UpdateAvailable;
                        break;
                }
            }
            else
                this._updateState = UpdateState.NoConnection;
        }
    }
}