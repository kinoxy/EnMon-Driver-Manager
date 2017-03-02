using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnMon_Driver_Manager.Forms
{
    public partial class frm_PropertyGrid<T> : Form where T : new()
    {
        public T _object;
        public frm_PropertyGrid(T _object, string title)
        {
            InitializeComponent();
            this.Text = title;
            this._object = _object;
            propertyGrid1.SelectedObject = _object;
        }

        public PropertyGridEventHandler Submitted;

        private void OnSubmitted()
        {
            PropertyGridEventArgs<T> args = new PropertyGridEventArgs<T>();
            args.item = (T)propertyGrid1.SelectedObject;
            Submitted?.Invoke(this, args);

            
        }



        private void btn_Add_Click(object sender, EventArgs e)
        {
            OnSubmitted();
            this.Close();
        }

        public delegate void PropertyGridEventHandler(object source, PropertyGridEventArgs<T> args);
    }

    public class PropertyGridEventArgs<T> : EventArgs
    {
        public T item;
    }

    
}
