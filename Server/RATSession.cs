using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Rat_Server
{
    internal class RATSession
    {
        private NetworkStream stream;

        public void Start(TcpClient client)
        {
            Task.Run(() =>
            {
                stream = client.GetStream();

                while (true)
                {
                    string[] input = Receive();

                    switch (input[0])
                    {
                        
                    }
                }
            });
        }

        public void Stop()
        {
            stream.Close();
        }

        public string[] Receive()
        {
            byte[] bytes = new byte[1024];
            int bytesRead = stream.Read(bytes, 0, bytes.Length);

            if (bytesRead > 0)
            {
                return Encoding.ASCII.GetString(bytes, 0, bytesRead).Split('|');
            }

            return Array.Empty<string>();
        }

        public void Send(string message)
        {
            byte[] data = Encoding.ASCII.GetBytes(message + "|");
            stream.Write(data, 0, data.Length);
            stream.Flush();
        }
    }
}
