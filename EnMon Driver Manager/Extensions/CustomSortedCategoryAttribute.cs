using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnMon_Driver_Manager.Extensions
{
    public class CustomSortedCategoryAttribute : CategoryAttribute
    {
        private const char NonPrintableChar = '\t';

        public CustomSortedCategoryAttribute(string category,
                                                ushort categoryPos)
            : base(category.PadLeft(category.Length + (100 - categoryPos),
                        CustomSortedCategoryAttribute.NonPrintableChar))
        {

        }
    }

    public class CustomSortedDisplayNameAttribute : DisplayNameAttribute
    {
        private const char NonPrintableChar = '\t';

        public CustomSortedDisplayNameAttribute(string category,
                                                ushort categoryPos)
            : base(category.PadLeft(category.Length + (100 - categoryPos),
                        CustomSortedDisplayNameAttribute.NonPrintableChar))
        {

        }
    }
}
