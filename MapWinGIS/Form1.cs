using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AxMapWinGIS;
using System.IO;

namespace MapWinGIS
{
    public partial class Form1 : Form
    {
        List<string> listLayerName = new List<string>();
        ContextMenu rightClickMenu = new ContextMenu();
        int idxLayerTmp = -1;
        int idxLayerRaster = -1;
        MapWinGIS.Image img;
        Shapefile tmpLayer;
        public Form1()
        {
            InitializeComponent();
            ConfigConTrol();
        }

        private void ConfigConTrol()
        {
            //
            axMap1.SendMouseMove = true;
            this.axMap1.MouseMoveEvent += axMap1_MouseMoveEvent;
            axMap1.CursorMode = tkCursorMode.cmPan;
            axMap1.ShowRedrawTime = false;
            //
            //
            MenuItem itemOpenTable = new MenuItem("Mở bảng thuộc tính");
            itemOpenTable.Click += ItemOpenTable_Click;
            MenuItem itemDel = new MenuItem("Xóa");
            itemDel.Click += ItemDel_Click;
            rightClickMenu.MenuItems.Add(itemOpenTable);
            rightClickMenu.MenuItems.Add(itemDel);
            //
            tvListLayer.CheckBoxes = true;
            tvListLayer.AfterCheck += TvListLayer_AfterCheck;
            tvListLayer.NodeMouseClick += TvListLayer_NodeMouseClick;
            //
            btnAnotation.Click += BtnAnotation_Click;
            btnVP.Click += BtnVP_Click;
            btnImport.Click += BtnImport_Click;
            btnExport.Click += BtnExport_Click;
            btnShowCellInfo.Click += BtnShowCellInfo_Click;
            btnExport.Enabled = false;
            btnAnotation.Checked = false;
            btnVP.Checked = false;
            //
        }

        private void BtnShowCellInfo_Click(object sender, EventArgs e)
        {
            if (idxLayerRaster<0)
            {
                return;
            }
            btnShowCellInfo.Checked = !btnShowCellInfo.Checked;
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (btnAnotation.Checked)
            {
                var sf = axMap1.get_Shapefile(idxLayerTmp);
                if (sf.NumShapes > 0)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    sfd.FilterIndex = 0;
                    sfd.RestoreDirectory = true;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        StreamWriter streamWriter = new StreamWriter(sfd.FileName);
                        for (int i = 0; i < sf.NumShapes; i++)
                        {
                            streamWriter.Write(i + " ");
                            for (int j = 0; j < sf.Shape[i].numPoints; j++)
                            {
                                var xt = sf.Shape[i].Point[j].x.ToString();
                                var yt = sf.Shape[i].Point[j].y.ToString();
                                streamWriter.Write("(" + xt + ";" + yt + "), ");
                            }
                            streamWriter.WriteLine("");
                        }
                        streamWriter.Close();
                        MessageBox.Show("Done!!");
                    }
                }
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            if (idxLayerTmp >= 0)
            {
                axMap1.RemoveLayer(idxLayerTmp);
            }
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            sfd.FilterIndex = 0;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamWriter = new StreamReader(sfd.FileName);
                tmpLayer = new Shapefile();
                tmpLayer.CreateNewWithShapeID("", ShpfileType.SHP_POLYGON);

                while (!streamWriter.EndOfStream)
                {
                    var line = streamWriter.ReadLine();
                    var listPtn = line.Split(' ');
                    Shape shp = new Shape();
                    shp.Create(ShpfileType.SHP_POLYGON);
                    for (int i = 1; i < listPtn.Length - 1; i++)
                    {
                        var xy = listPtn[i].Remove(listPtn[i].Length - 1).Replace('(', ' ').Replace(')', ' ').Split(';');
                        MapWinGIS.Point ptn = new MapWinGIS.Point();
                        ptn.Set(Convert.ToDouble(xy[0]), Convert.ToDouble(xy[1]));
                        shp.InsertPoint(ptn, ref i);
                    }
                    tmpLayer.EditAddShape(shp);
                }
                streamWriter.Close();
                MessageBox.Show("Done!!");
                idxLayerTmp = axMap1.AddLayer(tmpLayer, true);
            }            
        }

        private void BtnAnotation_Click(object sender, EventArgs e)
        {
            btnAnotation.Checked = !btnAnotation.Checked;
            if (btnAnotation.Checked)
            {
                btnExport.Enabled = true;
                //toolStripButton6.Enabled
                axMap1.CursorMode = tkCursorMode.cmMeasure;
                axMap1.Measuring.MeasuringType = tkMeasuringType.MeasureArea;
                axMap1.Measuring.ShowLength = false;
                axMap1.MeasuringChanged += AxMap1_MeasuringChanged;
                tmpLayer = new Shapefile();
                if (!tmpLayer.CreateNewWithShapeID("", ShpfileType.SHP_POLYGON))
                {
                    MessageBox.Show("Failed to create shapefile: " + tmpLayer.ErrorMsg[tmpLayer.LastErrorCode]);
                    return;
                }

                idxLayerTmp = axMap1.AddLayer(tmpLayer, true);
                //i_layer1 = axMap1.AddLayer(sf_1, true);
                axMap1.set_ShapeLayerFillColor(idxLayerTmp, Convert.ToUInt32(System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Aqua)));
                axMap1.set_ShapeLayerLineColor(idxLayerTmp, Convert.ToUInt32(System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Aqua)));
            }
            else
            {
                btnExport.Enabled = false;
                axMap1.CursorMode = tkCursorMode.cmPan;
                if (idxLayerTmp >= 0)
                {
                    axMap1.RemoveLayer(idxLayerTmp);
                }
            }
        }

        private void ItemDel_Click(object sender, EventArgs e)
        {
            int layerHander = (int)rightClickMenu.Tag;
            axMap1.RemoveLayer(layerHander);
            tvListLayer.Nodes.RemoveAt(layerHander);
        }

        private void ItemOpenTable_Click(object sender, EventArgs e)
        {
            var sfTmp = axMap1.get_Shapefile((int)rightClickMenu.Tag);
            if (sfTmp==null)
            {                
                BandRender bandRender = new BandRender(axMap1.get_Image(idxLayerRaster));
                bandRender.SelectBand += BandRender_SelectBand;
                bandRender.ShowDialog();
            }
            table_properties frm_2 = new table_properties(sfTmp.Table);
            frm_2.FormClosed += Frm_2_FormClosed;
            frm_2.Sk_sua += new table_properties.dltruyen(frm_2_Sk_sua);
            frm_2.Sk_sua_table += new table_properties.dltruyen_bang(frm_2_Sk_sua_table);
            frm_2.Sk_select_shape += new table_properties.dltruyen_shape(frm_2_Sk_select_shape);
            frm_2.Sk_luu += new table_properties.dltruyen_luu(frm_2_Sk_luu);
            frm_2.Sk_add_field += new table_properties.dltruyen_fieldtype(frm_2_Sk_add_field);
            frm_2.Sk_remove_field += new table_properties.dltruyen_fieldtype(frm_2_Sk_remove_field);
            frm_2.Show();
        }

        private void BandRender_SelectBand(int redIdx, int greenIdx, int blueIdx)
        {
            var imgTmp = axMap1.get_Image(idxLayerRaster);
            imgTmp.RedBandIndex = redIdx;
            imgTmp.GreenBandIndex =greenIdx;
            imgTmp.BlueBandIndex = blueIdx;
            axMap1.Redraw();
        }

        private void Frm_2_FormClosed(object sender, FormClosedEventArgs e)
        {
            var sfTmp = axMap1.get_Shapefile((int)rightClickMenu.Tag);
            sfTmp.SelectNone();
            axMap1.Redraw();
        }

        private void TvListLayer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            // Select this node.
            TreeNode node_here = tvListLayer.GetNodeAt(e.X, e.Y);
            tvListLayer.SelectedNode = node_here;

            // See if we got a node.
            if (node_here == null) return;
            rightClickMenu.Tag = node_here.Index;
            if (axMap1.get_Shapefile((int)rightClickMenu.Tag)==null)
            {
                rightClickMenu.MenuItems[0].Text = "Chọn band render";
            }
            else
            {
                rightClickMenu.MenuItems[0].Text = "Mở bảng thuộc tính";

            }
            rightClickMenu.Show(tvListLayer, new System.Drawing.Point(e.X, e.Y));
        }

        void AddLayer(string layerName)
        {
            listLayerName.Add(layerName);
            TreeNode tmp = new TreeNode(layerName);
            tmp.Checked = true;
            tvListLayer.Nodes.Add(tmp);
        }

        private void TvListLayer_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //axMap1.get_L
            //var node = sender as TreeNode;
            //Debug.Print(node.Name);
            axMap1.set_LayerVisible(e.Node.Index, e.Node.Checked);
            //axMap1.get_l e.Node.Name
        }
        private void menu_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Mo tap tin du lieu";
            //ofd.Filter = "*.shp|*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.ToLower().EndsWith(".shp"))
                {
                    MapWinGIS.Shapefile tmpSf = new Shapefile();
                    var result = tmpSf.Open(@ofd.FileName, null);
                    int iHandle = axMap1.AddLayer(tmpSf, true);
                    AddLayer(axMap1.get_LayerName(iHandle));
                }
                else if (ofd.FileName.ToLower().EndsWith(".tif") ||
                    ofd.FileName.ToLower().EndsWith(".png") ||
                    ofd.FileName.ToLower().EndsWith(".jpg"))
                {
                    img = new MapWinGIS.Image();
                    img.Open(@ofd.FileName);
                    idxLayerRaster = axMap1.AddLayer(img, true);
                    AddLayer(axMap1.get_LayerName(idxLayerRaster));
                }
            }
        }

        public double Percentile(double[] sequence, double excelPercentile)
        {
            Array.Sort(sequence);
            int N = sequence.Length;
            double n = (N - 1) * excelPercentile + 1;
            //double n = (N + 1) * excelPercentile;
            // Another method: double n = (N + 1) * excelPercentile;
            if (n == 1d) return sequence[0];
            else if (n == N) return sequence[N - 1];
            else
            {
                int k = (int)n;
                double d = n - k;
                var tm = sequence[k - 1];
                return sequence[k - 1] + d * (sequence[k] - sequence[k - 1]);
            }
        }

        //public static double Percentile(double[] elements, double percentile)
        //{
        //    Array.Sort(elements);
        //    double realIndex = percentile * (elements.Length - 1);
        //    int index = (int)realIndex;
        //    double frac = realIndex - index;
        //    if (index + 1 < elements.Length)
        //        return elements[index] * (1 - frac) + elements[index + 1] * frac;
        //    else
        //        return elements[index];
        //}
        private void axMap1_MouseMoveEvent(object sender, AxMapWinGIS._DMapEvents_MouseMoveEvent e)
        {
            if (btnShowCellInfo.Checked)
            {
                string stt = "";
                int row;
                int column;
                double X = 0;
                double Y = 0;
                axMap1.PixelToProj(e.x, e.y, ref X, ref Y);
                stt += "Kinh độ: " + Convert.ToString(Math.Round(X, 3)) +
                        " Vĩ độ: " + Convert.ToString(Math.Round(Y, 3))  +
                        ". Giá trị Band: ";
                MapWinGIS.Image img = axMap1.get_Image(idxLayerRaster);
                img.ProjectionToImage(X, Y, out column, out row);
                double[] vals = new double[img.NoBands];
                for (int i = 1; i <= img.NoBands; i++)
                {
                    GdalRasterBand rst = img.get_Band(i);
                    double pVal;
                    rst.get_Value(row, column, out pVal);
                    vals[i - 1] = pVal;
                    stt += i.ToString() +" : "+ Math.Round(pVal, 3).ToString()+ "; ";
                }

                toolStripStatusLabel1.Text = stt;
            }
            else
            {
                double x, y;
                x = y = 0;
                axMap1.PixelToProj(e.x, e.y, ref x, ref y);
                x = Math.Round(x, 3);
                y = Math.Round(y, 3);

                toolStripStatusLabel1.Text = "Kinh độ: " + Convert.ToString(x) + " Vĩ độ: " + Convert.ToString(y);
            }
        }

        private void zoom_in_Click(object sender, EventArgs e)
        {
            axMap1.CursorMode = MapWinGIS.tkCursorMode.cmZoomIn;
        }

        private void zoom_out_Click(object sender, EventArgs e)
        {
            axMap1.CursorMode = MapWinGIS.tkCursorMode.cmZoomOut;
        }

        private void pan_Click(object sender, EventArgs e)
        {
            axMap1.CursorMode = MapWinGIS.tkCursorMode.cmPan;

        }

        private void zoom_more_Click(object sender, EventArgs e)
        {
            int layerHander = (int)rightClickMenu.Tag;

            axMap1.ZoomToLayer(layerHander);
        }


        /****************************/
        public void LayersInfo()
        {
            int pointCount = 0;
            int lineCount = 0;
            int polyCount = 0;
            int imgCount = 0;

            for (int i = 0; i < axMap1.NumLayers; i++)
            {
                object layer = axMap1.get_GetObject(axMap1.get_LayerHandle(i));
                Shapefile sf_test = layer as Shapefile;
                if (sf_test != null)
                {
                    switch (sf_test.ShapefileType)
                    {
                        case ShpfileType.SHP_POINT:
                            pointCount++;
                            break;
                        case ShpfileType.SHP_POLYLINE:
                            lineCount++;
                            break;
                        case ShpfileType.SHP_POLYGON:
                            polyCount++;
                            break;
                    }
                }
                else
                {
                    MapWinGIS.Image img = layer as MapWinGIS.Image;
                    if (img != null)
                    {
                        imgCount++;
                    }
                }
            }

            string s = string.Format("Thong tin map:" + Environment.NewLine +
                                     "So Point shapefiles: {0}" + Environment.NewLine +
                                     "So Polyline shapefiles: {1}" + Environment.NewLine +
                                     "So Polygon shapefiles: {2}" + Environment.NewLine +
                                     "So Images: {3}", pointCount, lineCount, polyCount, imgCount);
            MessageBox.Show(s);
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayersInfo();
        }

        private void edit_1_Click(object sender, EventArgs e)
        {
            //table_properties frm_2 = new table_properties(sf.Table);
            //frm_2.Sk_sua += new table_properties.dltruyen(frm_2_Sk_sua);
            //frm_2.Sk_sua_table += new table_properties.dltruyen_bang(frm_2_Sk_sua_table);
            //frm_2.Sk_select_shape += new table_properties.dltruyen_shape(frm_2_Sk_select_shape);
            //frm_2.Sk_luu += new table_properties.dltruyen_luu(frm_2_Sk_luufrm_2_Sk_luu);
            //frm_2.Sk_add_field += new table_properties.dltruyen_fieldtype(frm_2_Sk_add_field);
            //frm_2.Sk_remove_field += new table_properties.dltruyen_fieldtype(frm_2_Sk_remove_field);
            //frm_2.Show();
        }

        void frm_2_Sk_remove_field(string s, int ft)
        {
            var sf = axMap1.get_Shapefile((int)rightClickMenu.Tag);
            sf.StartEditingShapes(true, null);
            sf.EditDeleteField(ft, null);
            sf.StopEditingShapes(true, true, null);
        }

        void frm_2_Sk_add_field(string s, int ft)
        {
            var sf = axMap1.get_Shapefile((int)rightClickMenu.Tag);
            sf.StartEditingShapes(true, null);
            switch (ft)
            {
                case 0:
                    sf.EditAddField(s, FieldType.STRING_FIELD, 10, 12);
                    break;
                case 1:
                    sf.EditAddField(s, FieldType.INTEGER_FIELD, 10, 12);
                    break;
                case 2:
                    sf.EditAddField(s, FieldType.DOUBLE_FIELD, 10, 12);
                    break;
            }
            sf.StopEditingShapes(true, true, null);
        }

        void frm_2_Sk_luu(string filenames)
        {
            var sf = axMap1.get_Shapefile((int)rightClickMenu.Tag);
            sf.SaveAs(@filenames + ".shp", null);
        }

        void frm_2_Sk_select_shape(int rowindex)
        {
            var sf = axMap1.get_Shapefile((int)rightClickMenu.Tag);
            sf.SelectNone();
            sf.set_ShapeSelected(rowindex, true);
            axMap1.ZoomToShape((int)rightClickMenu.Tag, rowindex);
            axMap1.Redraw();
        }

        void frm_2_Sk_sua_table(string value, int ColumnIndex, int RowIndex)
        {
            var sf = axMap1.get_Shapefile((int)rightClickMenu.Tag);
            sf.StartEditingShapes(true, null);
            sf.Table.EditCellValue(ColumnIndex, RowIndex, value);
            sf.Labels.Expression = sf.Labels.Expression;    // update the labels
            sf.StopEditingShapes(true, true, null);
            axMap1.Redraw();
        }

        void frm_2_Sk_sua()
        {
            //axMap1.set_ShapeLayerLineColor(i_layer0, Convert.ToUInt32(System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)));
            axMap1.Redraw();
        }

        private void rasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnVP_Click(object sender, EventArgs e)
        {
            btnVP.Checked = !btnVP.Checked;
            axMap1.CursorMode = tkCursorMode.cmMeasure;
            axMap1.Measuring.MeasuringType = tkMeasuringType.MeasureDistance;
            axMap1.Measuring.ShowLength = false;
            axMap1.MeasuringChanged += AxMap1_MeasuringChanged;           
        }

        private void AxMap1_MeasuringChanged(object sender, _DMapEvents_MeasuringChangedEvent e)
        {
            if (e.action == tkMeasuringAction.PointAdded)
            {

            }
            if (e.action == tkMeasuringAction.MesuringStopped)
            {
                if (btnAnotation.Checked)
                {
                    Shape shp = new Shape();
                    shp.Create(ShpfileType.SHP_POLYGON);
                    //shp_tmp.EditAddShape()
                    double x, y;
                    //Debug.WriteLine("Measured points (in map units.): " + axMap1.Measuring.PointCount);
                    for (int i = 0; i < axMap1.Measuring.PointCount; i++)
                    {
                        if (axMap1.Measuring.get_PointXY(i, out x, out y))
                        {
                            //var c = 0;
                            MapWinGIS.Point ptn = new MapWinGIS.Point();
                            ptn.Set(x, y);
                            shp.InsertPoint(ptn, ref i);
                            //Debug.WriteLine("x={0}; y={1}", x, y);
                        }
                    }
                    tmpLayer.EditAddShape(shp);
                    axMap1.Redraw();
                }
                if(btnVP.Checked)
                {
                    double x, y;
                    axMap1.Measuring.get_PointXY(0, out x, out y);
                    MapWinGIS.Point pt1 = new Point();
                    pt1.Set(x, y);
                    axMap1.Measuring.get_PointXY(1, out x, out y);
                    MapWinGIS.Point pt2 = new Point();
                    pt2.Set(x, y);
                    MapWinGIS.Image DEMImg = axMap1.get_Image(idxLayerRaster);
                    Vertical_Profiling_Form vpf = new Vertical_Profiling_Form(DEMImg, pt1, pt2);
                    vpf.Show(this);
                    axMap1.Redraw();
                }
            }

        }
    }
}
