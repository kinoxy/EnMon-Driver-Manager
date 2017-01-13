using System.ComponentModel;

namespace EnMon_Driver_Manager.Models.Stations
{
    class StationConverter :  TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(TemporaryValues.stations);

        }
    }
}
