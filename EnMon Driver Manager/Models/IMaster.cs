using System.Collections.Generic;

namespace EnMon_Driver_Manager.Models
{
    public interface IDriverMaster
    {

        PollingTimer pollingTimer { get; set; }

        List<Device> Devices { get; set; }

        event ModbusEventHandler AnyBinarySignalValueChanged;

        event ModbusEventHandler AnyAnalogSignalValueChanged;

        event ModbusEventHandler DeviceConnectionStateChanged;

        void Connect();

        void ReadValues();

    }
}