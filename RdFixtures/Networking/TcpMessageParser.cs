using System;

namespace Rd.Networking
{
    public class TcpMessageParser
    {
        public delegate void TcpMessageParserMessage(TcpMessageParser messageParser, byte[] bytes);

        public const int LENGH_BUFFER_LENGTH = 4;
        private readonly byte[] _lengthBuffer = new byte[4];
        private byte[] _messageBuffer;
        private int _readIndex;
        private int _writeIndex;

        public event TcpMessageParserMessage OnMessage;

        public static byte[] WrapMessage(byte[] message)
        {
            var bytes = BitConverter.GetBytes(message.Length);
            var numArray = new byte[bytes.Length + message.Length];
            bytes.CopyTo(numArray, 0);
            message.CopyTo(numArray, bytes.Length);
            return numArray;
        }

        public static byte[] UnwrapMessage(byte[] message)
        {
            var numArray1 = new byte[4];
            var numArray2 = new byte[message.Length - 4];
            Array.Copy(message, numArray1, 4);
            Array.Copy(message, 4, numArray2, 0, numArray2.Length);
            return numArray2;
        }

        public void Receive(byte[] bytes)
        {
            while (_readIndex < bytes.Length)
            {
                if (_messageBuffer == null)
                    readLength(bytes);
                if (_messageBuffer != null)
                    readMessage(bytes);
            }

            _readIndex = 0;
        }

        private void readLength(byte[] bytes)
        {
            if (!read(bytes, _lengthBuffer, 4))
                return;
            _messageBuffer = new byte[BitConverter.ToInt32(_lengthBuffer, 0)];
        }

        private void readMessage(byte[] bytes)
        {
            if (!read(bytes, _messageBuffer, _messageBuffer.Length))
                return;
            var messageBuffer = _messageBuffer;
            _messageBuffer = null;
            if (OnMessage == null)
                return;
            OnMessage(this, messageBuffer);
        }

        private bool read(byte[] bytes, byte[] buffer, int length)
        {
            var length1 = length - _writeIndex;
            var length2 = bytes.Length - _readIndex;
            if (length1 <= length2)
            {
                Array.Copy(bytes, _readIndex, buffer, _writeIndex, length1);
                _readIndex += length1;
                _writeIndex = 0;
                return true;
            }

            Array.Copy(bytes, _readIndex, buffer, _writeIndex, length2);
            _readIndex += length2;
            _writeIndex += length2;
            return false;
        }
    }
}