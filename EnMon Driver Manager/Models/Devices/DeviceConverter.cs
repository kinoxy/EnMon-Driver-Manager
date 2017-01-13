using System.ComponentModel;

namespace EnMon_Driver_Manager.Models.Devices
{
    class DeviceConverter : TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(TemporaryValues.devices);

        }

    }
}
