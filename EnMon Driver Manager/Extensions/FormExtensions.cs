using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnMon_Driver_Manager.Extensions
{
    public static class FormExtensions
    {
        public static void AddToPanel(this Form frm, Panel panel, bool clearPanelBeforeAdd)
        {
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Visible = true;
            if (clearPanelBeforeAdd) panel.Controls.Clear();
            panel.Controls.Add(frm);
            panel.Show();
        }
    }
}
