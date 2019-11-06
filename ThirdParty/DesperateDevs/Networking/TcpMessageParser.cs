using System;

namespace DesperateDevs.Networking
{
    public class TcpMessageParser
    {
        private readonly byte[] _lengthBuffer = new byte[4];
        public const int LENGH_BUFFER_LENGTH = 4;
        private byte[] _messageBuffer;
        private int _readIndex;
        private int _writeIndex;

        public event TcpMessageParser.TcpMessageParserMessage OnMessage;

        public static byte[] WrapMessage(byte[] message)
        {
            byte[] bytes = BitConverter.GetBytes(message.Length);
            byte[] numArray = new byte[bytes.Length + message.Length];
            bytes.CopyTo((Array) numArray, 0);
            message.CopyTo((Array) numArray, bytes.Length);
            return numArray;
        }

        public static byte[] UnwrapMessage(byte[] message)
        {
            byte[] numArray1 = new byte[4];
            byte[] numArray2 = new byte[message.Length - 4];
            Array.Copy((Array) message, (Array) numArray1, 4);
            Array.Copy((Array) message, 4, (Array) numArray2, 0, numArray2.Length);
            return numArray2;
        }

        public void Receive(byte[] bytes)
        {
            while (this._readIndex < bytes.Length)
            {
                if (this._messageBuffer == null)
                    this.readLength(bytes);
                if (this._messageBuffer != null)
                    this.readMessage(bytes);
            }

            this._readIndex = 0;
        }

        private void readLength(byte[] bytes)
        {
            if (!this.read(bytes, this._lengthBuffer, 4))
                return;
            this._messageBuffer = new byte[BitConverter.ToInt32(this._lengthBuffer, 0)];
        }

        private void readMessage(byte[] bytes)
        {
            if (!this.read(bytes, this._messageBuffer, this._messageBuffer.Length))
                return;
            byte[] messageBuffer = this._messageBuffer;
            this._messageBuffer = (byte[]) null;
            if (this.OnMessage == null)
                return;
            this.OnMessage(this, messageBuffer);
        }

        private bool read(byte[] bytes, byte[] buffer, int length)
        {
            int length1 = length - this._writeIndex;
            int length2 = bytes.Length - this._readIndex;
            if (length1 <= length2)
            {
                Array.Copy((Array) bytes, this._readIndex, (Array) buffer, this._writeIndex, length1);
                this._readIndex += length1;
                this._writeIndex = 0;
                return true;
            }

            Array.Copy((Array) bytes, this._readIndex, (Array) buffer, this._writeIndex, length2);
            this._readIndex += length2;
            this._writeIndex += length2;
            return false;
        }

        public delegate void TcpMessageParserMessage(TcpMessageParser messageParser, byte[] bytes);
    }
}