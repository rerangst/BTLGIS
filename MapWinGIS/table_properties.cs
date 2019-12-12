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
    public partial class table_properties : Form
    {
        public delegate void dltruyen();
        public event dltruyen Sk_sua;
        public delegate void dltruyen_luu(string filenames);
        public event dltruyen_luu Sk_luu;
        public delegate void dltruyen_bang(string value, int ColumnIndex, int RowIndex);
        public event dltruyen_bang Sk_sua_table;
        public delegate void dltruyen_shape(int rowindex);
        public event dltruyen_shape Sk_select_shape;
        public delegate void dltruyen_fieldtype(string s, int ft);
        public event dltruyen_fieldtype Sk_add_field,Sk_remove_field;

        MapWinGIS.Table tb = new MapWinGIS.Table();
        
        public table_properties(MapWinGIS.Table _table)
        {
            InitializeComponent();
            tb = _table;
        }

        private void table_properties_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < tb.NumFields; i++)
            {
                dgv.Columns.Add(Convert.ToString(i), tb.Field[i].Name);
            }

            for (int i = 0; i < tb.NumRows; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dgv.Rows[0].Clone();
                for (int j = 0; j < tb.NumFields; j++)
                {
                    row.Cells[j].Value = tb.get_CellValue(j, i);
                }
                dgv.Rows.Add(row);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Sk_sua();
            dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
            dgv.ReadOnly = false;
        }
        void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Sk_select_shape(e.RowIndex);
            //MessageBox.Show(Convert.ToString(e.RowIndex));
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Sk_sua_table(Convert.ToString(dgv[e.ColumnIndex, e.RowIndex].Value), e.ColumnIndex, e.RowIndex);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            dgv.ReadOnly = true;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Chon vi tri luu";
            sfd.Filter = "*.shp|*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Sk_luu(sfd.FileName);
                dgv.ReadOnly = true;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Add_form add_frm = new Add_form();
            add_frm.Sk_sua += new Add_form.dltruyen(add_frm_Sk_sua);
            add_frm.Show();
        }

        void add_frm_Sk_sua(string s, int a)
        {
            dgv.Columns.Add(Convert.ToString(dgv.ColumnCount + 1), s);
            Sk_add_field(s,a);                       
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            Remove_form re_frm = new Remove_form(tb);
            re_frm.Sk_xoa += new Remove_form.dltruyen(re_frm_Sk_xoa);
            re_frm.Show();
        }

        void re_frm_Sk_xoa(string field_name, int field_index)
        {
            dgv.Columns.RemoveAt(field_index);
            Sk_remove_field(field_name, field_index);
        }
    }
}
