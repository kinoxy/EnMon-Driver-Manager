using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Models.StatusTexts
{
    class StatusTextTypeConverter : TypeConverter
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
                if ((value is uint))
                {
                    var first = TemporaryValues.statusTexts.FirstOrDefault(d => d.StatusID == (uint)value);
                    if (first != null) return first.Name;

                }
                if (value is StatusText)
                {
                    var first = TemporaryValues.statusTexts.FirstOrDefault(d => d.StatusID == ((StatusText)value).StatusID);
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
                var first = TemporaryValues.statusTexts.FirstOrDefault(d => d.Name == (string)value);
                if (first != null) return first.StatusID;
            }
            if (value.GetType() == typeof(uint))
            {
                if ((uint)value == 0) value = 1;
                var first = TemporaryValues.statusTexts.FirstOrDefault(d => d.StatusID == (uint)value);
                if (first != null) return first.Name;
            }
            return null;
            //return base.ConvertFrom(context, culture, value);
        }
    }
}
