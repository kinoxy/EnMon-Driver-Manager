using System;
using System.ComponentModel;
using System.Globalization;

namespace EnMon_Driver_Manager.Models.Signals
{
    internal class PageShownConverter : BooleanConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)

        {
            if (value != null)
            {
                return (bool)value ? "Evet" : "Hayır";
            }
            return null;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)

        {
            return (string)value == "Evet";
        }
    }
}