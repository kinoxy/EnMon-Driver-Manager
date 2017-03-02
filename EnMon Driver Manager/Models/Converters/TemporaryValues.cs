using System.Collections.Generic;
using EnMon_Driver_Manager.Models.ArchivePeriods;
using EnMon_Driver_Manager.Models.DataTypes;
using EnMon_Driver_Manager.Models.Signals;
using EnMon_Driver_Manager.Models.Devices;
using EnMon_Driver_Manager.Models.StatusTexts;
using EnMon_Driver_Manager.Models.DeviceTypes;

namespace EnMon_Driver_Manager.Models
{
    public static class TemporaryValues
    {
        public static Signal signal;
        public static AnalogSignal analogsignal;
        public static BinarySignal binarysignal;

        public static Station station;
        public static List<Station> stations;

        public static Device device;
        public static List<Device> devices;

        public static ArchivePeriod archivePeriod;
        public static List<ArchivePeriod> archivePeriods;

        public static DataType dataType;
        public static List<DataType> dataTypes;

        public static StatusText statusText;
        public static List<StatusText> statusTexts;

        public static CommunicationProtocol protocol;
        public static List<CommunicationProtocol> protocols;

        public static DeviceType deviceType;
        public static List<DeviceType> deviceTypes;

    }
}
