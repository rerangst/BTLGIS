using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapWinGIS;
namespace MapWinGIS
{
    public partial class BandRender : Form
    {
        public delegate void deleBandIdx(int redIdx, int greenIdx, int blueIdx);
        public event deleBandIdx SelectBand;
        public BandRender(MapWinGIS.Image img)
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 0; i < img.NoBands; i++)
            {
                comboBox1.Items.Add("Band " + (i + 1).ToString());
                comboBox2.Items.Add("Band " + (i + 1).ToString());
                comboBox3.Items.Add("Band " + (i + 1).ToString());
            }
            button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SelectBand(comboBox1.SelectedIndex + 1, comboBox2.SelectedIndex + 1, comboBox3.SelectedIndex + 1);
        }
    }
}
