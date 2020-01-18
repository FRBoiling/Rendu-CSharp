using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Rd.Networking.IOCP
{
    public enum ChannelType
    {
        Accept,
        Connect
    }

    public abstract class AChannel
    {
        public long Id;
        public ChannelType ChannelType { get; }

        public AService Service { get; private set; }

        public bool IsDisposed { get; set; }

        public IPEndPoint RemoteAddress { get; protected set; }
        public IPEndPoint LocalAddress { get; protected set; }

        private Action<MemoryStream> readCallback;

        public event Action<MemoryStream> ReadCallback
        {
            add => readCallback += value;
            remove => readCallback -= value;
        }

        public int Error { get; set; }
        public object LastRecvTime { get; set; }

        private Action<AChannel, int> errorCallback;

        public event Action<AChannel, int> ErrorCallback
        {
            add => errorCallback += value;
            remove => errorCallback -= value;
        }

        protected AChannel(AService service, ChannelType channelType)
        {
            ChannelType = channelType;
            Service = service;
        }

        protected void OnRead(MemoryStream memoryStream)
        {
            readCallback.Invoke(memoryStream);
        }

        protected void OnError(int e)
        {
            Error = e;
            errorCallback?.Invoke(this, e);
        }

        public abstract void Send(MemoryStream stream);

        public abstract void Start();

        public virtual void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }
            IsDisposed = true;

            this.Service.Remove(Id);
        }

        public override string ToString()
        {
            return $"channel {Id} {ChannelType.ToString()} (local:{LocalAddress}  remote:{RemoteAddress})";
        }

    }
}
