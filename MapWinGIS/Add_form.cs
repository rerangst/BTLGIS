using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MapWinGIS
{
    public partial class Add_form : Form
    {
        public delegate void dltruyen(string s, int a);
        public event dltruyen Sk_sua;
        public Add_form()
        {          
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            
            Sk_sua(txt_name.Text, cb_type.SelectedIndex);
            this.Close();
        }

        
    }
}
