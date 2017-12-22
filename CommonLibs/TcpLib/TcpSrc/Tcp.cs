using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TcpLib.TcpSrc
{
    public partial class Tcp
    {
        private Socket _workSocket = null;
        private Socket _listenSocket = null;

        private Socket Listen(ushort port)
        {
            _listenSocket = TcpMng.CreateInstance().GetListenSocket(port); 
            if (_listenSocket == null)
            {
                Socket socket = null;
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, port);
                socket.Bind(ep);
                socket.Listen(10);
                TcpMng.CreateInstance().AddListenSocket(port, socket);
                return socket;
            }
            else
            {
                return _listenSocket;
            }
        }

        public bool Connect(string ip, ushort port)
        {
            if (_workSocket !=null) 
            {
                return false;
            }
            else
            {
                IPAddress ipAddress = IPAddress.Parse(ip);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
                try
                {
                    // Create a TCP/IP socket.     
                    Socket socket = null;
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), socket);

                }
                catch (Exception e)
                {
                    Console.WriteLine("connect error:{0}" , e.ToString());
                    return false;
                }
             

            }
            
            return true;
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            // Retrieve the socket from the state object.     
            Socket socket = (Socket)ar.AsyncState;
            if (socket == null)
            {
                OnConnect(false);
                return;
            }
            try
            {
                // Complete the connection.     
                socket.EndConnect(ar);
                Console.WriteLine("socket connected to {0}", socket.RemoteEndPoint.ToString());
                Recv(socket);
                OnConnect(true);
            }
            catch (Exception e)
            {
                OnConnect(false);
                //Console.WriteLine(e.ToString());
            }
        }     
        
        public bool Accept(ushort port)
        {
            Socket listenr = Listen(port);
            try
            {
                listenr.BeginAccept(new AsyncCallback(AcceptCallback), listenr);
            }
            catch (Exception e)
            {
                Console.WriteLine("accept error:{0}", e.ToString());
                return false;
            }
            return true;
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            try
            {  
                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);
                Recv(handler);
                OnAccept(true);
            }
            catch (Exception e)
            {
                Console.WriteLine("acceptcallback error:{0}", e.ToString());
                OnAccept(false);
            }
            return;
        }

        private void Recv(Socket socket)
        {
            try
            {
                // Create the state object.     
                StateObject state = new StateObject();
                state.workSocket = socket;
                _workSocket = socket;
                // Begin receiving the data from the remote device.     
                socket.BeginReceive(state.buffer, 0, StateObject.BufferSize, SocketFlags.None, new AsyncCallback(RecvCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void RecvCallback(IAsyncResult ar)
        {
            SocketError errorCode;
            // Retrieve the state object and the handler socket     
            // from the asynchronous state object.     
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;
            if (handler == null)
            {
                Console.WriteLine("accepte socket is null");
                return;
            }

            try
            {
                // Read data from the client socket.     
                int len = handler.EndReceive(ar, out errorCode);
                if (len <= 0)
                {
                    Console.WriteLine("RecvCallback disconnected!");
                    Disconnect();
                    return;
                }
                Console.WriteLine("Recv {0} bytes.", len);
                len = state.offset + len;

                MemoryStream transferred = new MemoryStream(state.buffer, 0, len, true, true);
                if (OnRecv != null)
                {
                    OnRecv(transferred);
                }
                state.offset = len - (int)transferred.Position;
                if (state.offset < 0)
                {
                    Console.WriteLine("RecvCallback disconnected!");
                    Disconnect();
                    return;
                }
                int size = 16384;
                if (transferred.Position == 0)
                {
                    size = (int)(transferred.Length * 2);
                }
                if (size > 65535)
                {
                    Console.WriteLine("RecvCallback disconnected!");
                    Disconnect(); 
                    return;
                }
                byte[] buffer = new byte[size];
                Array.Copy(state.buffer, transferred.Position, buffer, 0, state.offset);
                state.buffer = buffer;

                handler.BeginReceive(state.buffer, state.offset, size - state.offset, SocketFlags.None, new AsyncCallback(RecvCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine("recvcallback error:{0}", e.ToString());
                Disconnect();
            }
            return;
        }

        IList<ArraySegment<byte>> _sendStreams = new List<ArraySegment<byte>>();
        IList<ArraySegment<byte>> _waitStreams = new List<ArraySegment<byte>>();

        public bool Send(MemoryStream stream)
        {
            //// Convert the string data to byte data using ASCII encoding.     
            //byte[] byteData = Encoding.ASCII.GetBytes(data);
            if (stream.Length == 0)
            {
                return true;
            }
            ArraySegment<byte> segment = new ArraySegment<byte>(stream.GetBuffer(), 0, (int)stream.Length);
            if (_sendStreams.Count == 0)
            {
                _sendStreams.Add(segment);
                try
                {
                    _workSocket.BeginSend(_sendStreams, 0, new AsyncCallback(SendCallback), _workSocket);
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            else
            {
                _waitStreams.Add(segment);
            }
            return true;
        }

        public bool Send(MemoryStream head,MemoryStream body)
        {
            head.Seek(0, SeekOrigin.Begin);
            body.Seek(0, SeekOrigin.Begin);
            if (body.Length ==0)
            {
                return Send(head);
            }
            lock (this)
            {
                ArraySegment<byte> arrHead = new ArraySegment<byte>(head.GetBuffer(), 0, (int)head.Length);
                ArraySegment<byte> arrBody = new ArraySegment<byte>(body.GetBuffer(), 0, (int)body.Length);

                if (_sendStreams.Count == 0)
                {
                    _sendStreams.Add(arrHead);
                    _sendStreams.Add(arrBody);
                    try
                    {
                        _workSocket.BeginSend(_sendStreams, SocketFlags.None, SendCallback, _workSocket);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
                else
                {
                    _waitStreams.Add(arrHead);
                    _waitStreams.Add(arrBody);
                }
            }
            return true;
        }

        public bool Send(ArraySegment<byte> head,ArraySegment<byte> body)
        {
            lock (this)
            {
                if (_sendStreams.Count == 0)
                {
                    _sendStreams.Add(head);
                    _sendStreams.Add(body);
                    try
                    {
                        _workSocket.BeginSend(_sendStreams, SocketFlags.None, SendCallback, null);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                }
                else
                {
                    _waitStreams.Add(head);
                    _waitStreams.Add(body);
                }
            }
            return true;
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.     
                Socket handler = (Socket)ar.AsyncState;
                // Complete sending the data to the remote device.     
                int len = handler.EndSend(ar);
                Console.WriteLine("Send {0} bytes.", len);

                _sendStreams.Clear();
                if (_waitStreams.Count > 0)
                {
                    IList<ArraySegment<byte>> temp = _sendStreams;
                    _sendStreams = _waitStreams;
                    _waitStreams = temp;
                    _workSocket.BeginSend(_sendStreams, SocketFlags.None, SendCallback, handler);
                }
                //handler.Shutdown(SocketShutdown.Both);
                //handler.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


        public delegate bool AsyncConnectCallback(bool ret);
        public delegate bool AsyncAcceptCallback(bool ret);
        public delegate void AsyncReadCallback(MemoryStream stream);
        public delegate bool AsyncDisconnectCallback();

        private AsyncConnectCallback onConnet = DefaultOnConnect;
        public AsyncConnectCallback OnConnect
        {
            set { onConnet = value; }
            get { return onConnet; }
        }

        private AsyncAcceptCallback onAccept = DefaultOnAccept;
        public AsyncAcceptCallback OnAccept
        {
            set { onAccept = value; }
            get { return onAccept; }
        }

        private AsyncReadCallback onRecv = DefaultOnRecv;
        public AsyncReadCallback OnRecv
        {
            set { onRecv = value; }
            get { return onRecv; }
        }

        private AsyncDisconnectCallback onDisconnect = DefaultOnDisconnect;
        public AsyncDisconnectCallback OnDisconnect
        {
            set { onDisconnect = value; }
            get { return onDisconnect; }
        }


        private static bool DefaultOnConnect(bool ret)
        {
            Console.WriteLine("default on DefaultOnConnect function called,check it");
            return false;
        }

        static private bool DefaultOnAccept(bool ret)
        {
            Console.WriteLine("default on DefaultOnAccept function called,check it");
            return false;
        }

        static private void DefaultOnRecv(MemoryStream stream)
        {
            stream.Seek(0, SeekOrigin.End);
        }

        static private bool DefaultOnDisconnect()
        {
            Console.WriteLine("default on DefaultOnDisconnect function called,check it");
            return false;
        }

        public void Disconnect()
        {
            if (_workSocket == null)
            {
                return;
            }
            else
            {
                lock (this)
                {
                    _workSocket.Close();
                    _workSocket = null;
                    _waitStreams.Clear();
                    _sendStreams.Clear();
                    OnDisconnect();
                }
            }
        }

    }
}
