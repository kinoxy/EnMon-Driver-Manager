using System.Collections.Generic;

namespace EnMon_Driver_Manager.Drivers.Abstract
{
    public interface ITCPDriver
    {
        int PortNumber { get; set; }

        List<string> ipAddresses { get; set; }

        void DeviceConnectionStateChanged(object source, TCPClientEventArgs e);

        void AnyAnalogSignalValueChanged(object sender, TCPClientEventArgs e);

        void AnyBinarySignalValueChanged(object sender, TCPClientEventArgs e);

        void DisconnectedFromServer(object sender, TCPClientEventArgs e);

        void ConnectedToServer(object sender, TCPClientEventArgs e);

    }
}
