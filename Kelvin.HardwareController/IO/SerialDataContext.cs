using System;
using System.IO.Ports;

namespace Kelvin.HardwareController.IO {

    internal sealed class SerialDataContext : IDisposable {

        private SerialPort port;

        public event Action<string> Received;

        public SerialDataContext(string portName) {
            port = new SerialPort(portName, 9600);
            port.Open();
        }

        public void Send(string s) {
            if (port?.IsOpen == true) {
                port.Write(s);
            }
        }

        public string Receive() {
            port.DiscardInBuffer();
            return port.ReadLine();
        }

        public void Dispose() => port.Close();
    }
}