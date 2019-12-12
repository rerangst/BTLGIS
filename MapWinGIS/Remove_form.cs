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
    public partial class Remove_form : Form
    {
        public delegate void dltruyen(string field_name, int field_index);
        public event dltruyen Sk_xoa;

        public Remove_form(Table _tb)
        {
            InitializeComponent();
            for (int i = 0; i < _tb.NumFields; i++)
            {
                cbb_remove.Items.Add(_tb.Field[i].Name);
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(cbb_remove.SelectedIndex.ToString());
            Sk_xoa(cbb_remove.SelectedItem.ToString(), cbb_remove.SelectedIndex);
            this.Close();
        }
    }
}
