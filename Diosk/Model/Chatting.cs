using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows;

namespace Diosk.Model
{
    public delegate void handleLogin();
    public class Chatting
    {
        public Socket socket;
        public bool isLogin = false;
        public string loginDate = string.Empty;
        public string logoutDate = string.Empty;
        public event handleLogin hl;

        public void Create()
        {
            if (socket == null)
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Connect();
        }

        public void Connect()
        {
            try
            {
                var ipEndPoint = new IPEndPoint(IPAddress.Parse("10.80.162.108"), 8000); // 접속
                socket.BeginConnect(ipEndPoint, ConnectCallback, socket);
            }
            catch (SocketException)
            {
                MessageBox.Show("접속 실패");
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("로그인 중 입니다.");
            }
        }

        public void Login()
        {
            try
            {
                byte[] loginMsg = new byte[1024];
                loginMsg = Encoding.UTF8.GetBytes("@2104");

                socket.BeginSend(loginMsg, 0, loginMsg.Length, SocketFlags.None, sendCallBack, null);

                Receive(loginMsg);

                loginDate = DateTime.Now.ToString();
                isLogin = true;
                hl();

                MessageBox.Show("로그인 되었습니다.");
            } catch (SocketException)
            {
                MessageBox.Show("로그인에서 오류가 발생했습니다!");
                isLogin = false;
            }
        }

        public void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                socket.EndConnect(ar);
                if (!isLogin)
                    Login();
                
            }
            catch (SocketException)
            {
                MessageBox.Show("접속 실패");
            }
        }

        public void Receive(byte[] message)
        {
            try
            {
                socket.BeginReceive(message, 0, message.Length, SocketFlags.None, receiveCallback, socket);
            }
            catch (SocketException)
            {
                MessageBox.Show("ERROR");
            }
        }

        public void receiveCallback(IAsyncResult ar)
        {
            try
            {
                int receiveIdx = socket.EndReceive(ar);
            }
            catch (SocketException)
            {
                MessageBox.Show("ERROR");
            }
        }

        public void Send(string msg)
        {
            try
            {
                byte[] message = new byte[1024];
                message = Encoding.UTF8.GetBytes(msg);

                socket.BeginSend(message, 0, message.Length, SocketFlags.None, sendCallBack, null);

                Receive(message);
            }
            catch (SocketException)
            {
                MessageBox.Show("ERROR");
            }
            catch (ObjectDisposedException)
            {
                MessageBox.Show("socket이 삭제되어 있습니다 다시 로그인 하세요");
            }
        }

        public void sendCallBack(IAsyncResult ar)
        {
            try
            {
                socket.EndSend(ar); 
            }
            catch (SocketException)
            {
                MessageBox.Show("ERROR");
            }
        }

        public void Close()
        {
            if (isLogin)
            {
                try
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    socket = null;

                    logoutDate = DateTime.Now.ToString();
                    isLogin = false;
                    hl();

                    MessageBox.Show("소켓 연결을 끊었습니다.");
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("로그인 부터 하세용");
                }
            } else
            {
                MessageBox.Show("이미 로그아웃되어 있습니다.");
            }
        }
    }
}
