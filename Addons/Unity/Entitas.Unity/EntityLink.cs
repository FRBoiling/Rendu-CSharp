using System;
using UnityEngine;

namespace Entitas.Unity
{
    public class EntityLink : MonoBehaviour
    {
        private IEntity _entity;
        private bool _applicationIsQuitting;

        public IEntity entity
        {
            get
            {
                return this._entity;
            }
        }

        public void Link(IEntity entity)
        {
            if (this._entity != null)
                throw new Exception("EntityLink is already linked to " + (object) this._entity + "!");
            this._entity = entity;
            this._entity.Retain((object) this);
        }

        public void Unlink()
        {
            if (this._entity == null)
                throw new Exception("EntityLink is already unlinked!");
            this._entity.Release((object) this);
            this._entity = (IEntity) null;
        }

        private void OnDestroy()
        {
            if (this._applicationIsQuitting || this._entity == null)
                return;
            Debug.LogWarning((object) ("EntityLink got destroyed but is still linked to " + (object) this._entity + "!\nPlease call gameObject.Unlink() before it is destroyed."));
        }

        private void OnApplicationQuit()
        {
            this._applicationIsQuitting = true;
        }

        public override string ToString()
        {
            return "EntityLink(" + this.gameObject.name + ")";
        }
    }
}