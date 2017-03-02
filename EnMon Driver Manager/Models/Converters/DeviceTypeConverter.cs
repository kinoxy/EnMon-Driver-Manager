using EnMon_Driver_Manager.Models.DeviceTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Models.Converters
{
    class DeviceTypeConverter : TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(TemporaryValues.deviceTypes);
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
                if ((value is byte))
                {
                    var first = TemporaryValues.deviceTypes.Find(d => d.ID == (byte)value);
                    if (first != null) return first.Name;
                    else return "";

                }
                if (value is DeviceType)
                {
                    var first = TemporaryValues.deviceTypes.Find(d => d.ID == ((DeviceType)value).ID);
                    if (first != null) return first.Name;
                    else return "";
                }

            }
            return base.ConvertTo(context, culture, value, destType);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {

            if (sourceType == typeof(string) || sourceType == typeof(byte))
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
                var first = TemporaryValues.deviceTypes.Find(d => d.Name == (string)value);
                if (first != null) return first.ID;
            }
            if (value.GetType() == typeof(byte))
            {
                if ((byte)value == 0) value = 1;
                var first = TemporaryValues.deviceTypes.Find(d => d.ID == (byte)value);
                if (first != null) return first.Name;
            }
            return null;
            //return base.ConvertFrom(context, culture, value);
        }
    }
}
