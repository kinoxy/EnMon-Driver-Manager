using System;
using System.ComponentModel;
using System.Globalization;

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
            return new StandardValuesCollection(TemporaryValues.statusTexts);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destType)
        {
            if (destType == typeof(string))
            {
                return true;
            }
            return false;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)

        {

            if (destType == typeof(string))
            {
                if ((value is ushort))
                {
                    var first = TemporaryValues.stations.Find(d => d.ID == (ushort)value);
                    if (first != null) return first.Name;
                    else return "";

                }
                if (value is Station)
                {
                    var first = TemporaryValues.stations.Find(d => d.ID == ((Station)value).ID);
                    if (first != null) return first.Name;
                }

            }
            return base.ConvertTo(context, culture, value, destType);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {

            if (sourceType == typeof(string) || sourceType == typeof(uint))
            {
                return true;
            }
            //return base.CanConvertFrom(context, sourceType);
            return false;

        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)

        {
            if (value.GetType() == typeof(string))
            {
                var first = TemporaryValues.stations.Find(d => d.Name == (string)value);
                if (first != null) return first.ID;
            }
            if (value.GetType() == typeof(uint))
            {
                if ((uint)value == 0) value = 1;
                var first = TemporaryValues.stations.Find(d => d.ID == (uint)value);
                if (first != null) return first.Name;
            }
            return null;
            //return base.ConvertFrom(context, culture, value);
        }
    }
}
