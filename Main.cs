using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;
using Npgsql;
using System.Threading;
using FreeSql.DataAnnotations;
using System.Linq.Expressions;
using O2Micro.Cobra.Communication;


namespace WindowsFormsApp1
{
    public partial class Main : Form
    {

        //netcore代码
        DataTable dataTbale = new DataTable();
        public string sql = "select * from test ";
        NpgsqlConnection con = new NpgsqlConnection("Host=localhost;port=5432;User Id = noah.liu;Password=123456;Database=TEST;timeout=300;CommandTimeout=300;KeepAlive = 300;");
        public int id;
        public string name = "name";
        public DateTime date = DateTime.Now;
        public int num;
        public int i;
        public int x = 10;
        public int offsetIndex = 100;
        public int offsetIndexY ;       
        List<double> StdIndex = new List<double>();
        List<double> StdTime = new List<double>();
        List<double> StdMode = new List<double>();
        List<double> StdCurrent = new List<double>();
        List<double> StdVoltage = new List<double>();
        List<double> StdTemperature = new List<double>();
        List<double> StdCapacity = new List<double>();
        List<double> StdTotalCapacity = new List<double>();
        List<double> StdStatus = new List<double>();
        List<List<double>> header = new List<List<double>>();
        public static string constr = "Host=localhost;port=5432;User Id = noah.liu;Password=123456;Database=TEST;timeout=300;CommandTimeout=300;KeepAlive = 300";
        public static IFreeSql fsql = new FreeSql.FreeSqlBuilder().UseConnectionString(FreeSql.DataType.PostgreSQL, constr).UseAutoSyncStructure(true).Build();
        List<test> index = fsql.Select<test>().ToList();
        List<string> read = new List<string>();
        public System.Timers.Timer timer = new System.Timers.Timer(10000);

        public Main()
        {
            InitializeComponent();           
            //netcore代码
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
            da.Fill(dataTbale);
            this.dataGridView.DataSource = dataTbale;
            con.Close();
            search.Items.Add(dataTbale.Columns[0].ColumnName);
            search.Items.Add(dataTbale.Columns[1].ColumnName);
            search.Items.Add(dataTbale.Columns[2].ColumnName);
            search.Items.Add(dataTbale.Columns[3].ColumnName);
            search.Items.Add(dataTbale.Columns[4].ColumnName);
            search.Items.Add(dataTbale.Columns[5].ColumnName);
            search.Items.Add(dataTbale.Columns[6].ColumnName);
            search.Items.Add(dataTbale.Columns[7].ColumnName);
            search.Items.Add(dataTbale.Columns[8].ColumnName);
            header.Add(StdIndex);
            header.Add(StdTime);
            header.Add(StdMode);
            header.Add(StdCurrent);
            header.Add(StdVoltage);
            header.Add(StdTemperature);
            header.Add(StdCapacity);
            header.Add(StdTotalCapacity);
            header.Add(StdStatus);
        }

        public void Xseries_Setting() 
        {
            chart.ChartAreas[0].AxisX.Title = "Time(mS)";
            //chart1.ChartAreas[0].AxisX.ScaleView.Size = StdTime.Count();
            chart.ChartAreas[0].AxisX.MajorGrid.Interval = 600;
            chart.ChartAreas[0].AxisX.MajorTickMark.Interval = 1200;
            chart.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            chart.ChartAreas[0].AxisX.LabelStyle.Interval = 1200;
            chart.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = true;
            chart.ChartAreas[0].AxisX.LabelAutoFitMinFontSize = 5;

        }

        public void Yseries_Setting() 
        {
            Series seriesY = new Series(YcomboBox.Text);
            seriesY.XValueType = ChartValueType.String;
            seriesY.Points.Clear();
            seriesY.ChartType = SeriesChartType.Line;
            seriesY.YValueType = ChartValueType.Int32;
            seriesY.IsValueShownAsLabel = false;
            seriesY.BorderWidth = 1;
            seriesY.Color = Color.Blue;
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Silver;
            chart.ChartAreas[0].AxisY.ArrowStyle = AxisArrowStyle.Lines;
            chart.ChartAreas[0].AxisY.Title = "Voltage(mV)";
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Silver;
            chart.ChartAreas[0].AxisY.MinorTickMark.Enabled = true;
            chart.ChartAreas[0].AxisY.MinorTickMark.TickMarkStyle = TickMarkStyle.OutsideArea;
            chart.ChartAreas[0].AxisY.MinorTickMark.LineDashStyle = ChartDashStyle.Dash;
            chart.ChartAreas[0].BackColor = Color.GhostWhite;
            chart.Series.Add(seriesY);
            for (int i = 0; i < index.Count; i++)
            {
                seriesY.Points.AddXY(i, index[i].Voltage);
            }
        }
        
        public void Y2series_Setting() 
        {
            Series seriesY2 = new Series(Y2comboBox.Text);
            seriesY2.Points.Clear();
            seriesY2.ChartType = SeriesChartType.Line;
            seriesY2.YValueType = ChartValueType.Int32;
            seriesY2.IsValueShownAsLabel = false;
            seriesY2.BorderWidth = 1;
            seriesY2.Color = Color.Green;
            chart.ChartAreas[0].AxisY2.ArrowStyle = AxisArrowStyle.Lines;
            chart.ChartAreas[0].AxisY2.MajorGrid.LineColor = Color.Silver;
            chart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            chart.Series.Add(seriesY2);
            chart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chart.ChartAreas[0].AxisY2.Title = "Current(mA)";
            seriesY2.YAxisType = AxisType.Secondary;
            for (int i = 0; i < index.Count; i++)
            {

                seriesY2.Points.AddXY(i, index[i].Current);

            }
        }


        private void main_Load(object sender, EventArgs e)
        {
            chart.Series.Clear();
            Y2comboBox.Text = "";
            for (int i = 0; i < dataTbale.Columns.Count; i++)
            {
                YcomboBox.Items.Add(dataTbale.Columns[i].ColumnName);
                Y2comboBox.Items.Add(dataTbale.Columns[i].ColumnName);
            }

            Xseries_Setting();
            Yseries_Setting();
            Y2series_Setting();

        }


        private void YcomboBox_TextChanged(object sender, EventArgs e)
        {
            chart.Series.Clear();
            Y2comboBox.Text = "";
            Series seriesY = new Series(YcomboBox.Text);
            //seriesY.XValueType = ChartValueType.String;
            //seriesY.Points.Clear();
            //seriesY.ChartType = SeriesChartType.Line;
            //seriesY.YValueType = ChartValueType.Int32;
            //seriesY.IsValueShownAsLabel = false;
            //seriesY.BorderWidth = 1;
            //seriesY.Color = Color.Blue;
            //chart.ChartAreas[0].AxisY.Title = YcomboBox.Text;
            //chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Silver;
            //chart.ChartAreas[0].AxisY.ArrowStyle = AxisArrowStyle.Lines;
            //chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Silver;
            //chart.ChartAreas[0].AxisY.MinorTickMark.Enabled = true;
            //chart.ChartAreas[0].AxisY.MinorTickMark.TickMarkStyle = TickMarkStyle.OutsideArea;
            //chart.ChartAreas[0].AxisY.MinorTickMark.LineDashStyle = ChartDashStyle.Dash;
            //chart.ChartAreas[0].BackColor = Color.GhostWhite;
            //chart.Series.Add(seriesY);
            Yseries_Setting();
           


            if (YcomboBox.Text != "")
            {
                if (YcomboBox.Text == "Capacity(mAh)")
                {
                    chart.ChartAreas[0].AxisY.Maximum = fsql.Select<test>().Max(index => index.Capacity);
                    chart.ChartAreas[0].AxisY.Minimum = fsql.Select<test>().Min(index => index.Capacity);
                    for (int i = 0; i < index.Count; i++)
                    {
                        seriesY.Points.AddXY(i, index[i].Capacity);
                    }
                }
                else if (YcomboBox.Text == "Current(mA)")
                {
                    for (int i = 0; i < index.Count; i++)
                    {
                        seriesY.Points.AddXY(i, index[i].Current);
                    }
                    chart.ChartAreas[0].AxisY.Maximum = fsql.Select<test>().Max(index => index.Current);
                    chart.ChartAreas[0].AxisY.Minimum = fsql.Select<test>().Min(index => index.Current);                  
                }
                else if (YcomboBox.Text == "Voltage(mV)")
                {
                    for (int i = 0; i < index.Count; i++)
                    {
                        seriesY.Points.AddXY(i, index[i].Voltage);
                    }
                    chart.ChartAreas[0].AxisY.Maximum = fsql.Select<test>().Max(index => index.Voltage);
                    chart.ChartAreas[0].AxisY.Minimum = fsql.Select<test>().Min(index => index.Voltage);                  
                }
                else if (YcomboBox.Text == "Temperature(degC)")
                {
                    for (int i = 0; i < index.Count; i++)
                    {
                        seriesY.Points.AddXY(i, index[i].Temperature);
                    }
                    chart.ChartAreas[0].AxisY.Maximum = fsql.Select<test>().Max(index => index.Temperature);
                    chart.ChartAreas[0].AxisY.Minimum = fsql.Select<test>().Min(index => index.Temperature);                
                }
                else if (YcomboBox.Text == "Total Capacity(mAh)")
                {
                    for (int i = 0; i < index.Count; i++)
                    {
                        seriesY.Points.AddXY(i, index[i].TotalCapacity);
                    }
                    chart.ChartAreas[0].AxisY.Maximum = fsql.Select<test>().Max(index => index.TotalCapacity);
                    chart.ChartAreas[0].AxisY.Minimum = fsql.Select<test>().Min(index => index.TotalCapacity);
                }
            }
        }

        private void Y2comboBox_TextChanged(object sender, EventArgs e)
        {
            Random random = new Random();
            Series seriesY2 = new Series(Y2comboBox.Text);           
            //seriesY2.Points.Clear();
            //seriesY2.ChartType = SeriesChartType.Line;
            //seriesY2.YValueType = ChartValueType.Int32;
            //seriesY2.IsValueShownAsLabel = false;
            //seriesY2.BorderWidth = 1;
            //seriesY2.Color = Color.Green;
            //chart.ChartAreas[0].AxisY2.ArrowStyle = AxisArrowStyle.Lines;
            //chart.ChartAreas[0].AxisY2.MajorGrid.LineColor = Color.Silver;
            //chart.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            //chart.Series.Add(seriesY2);
            //chart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            //chart.ChartAreas[0].AxisY2.Title = Y2comboBox.Text;
            //seriesY2.YAxisType = AxisType.Secondary;
            Y2series_Setting();



            if (Y2comboBox.Text != "")
            {
                if (Y2comboBox.Text == "Capacity(mAh)")
                {
                    for (int i = 0; i < index.Count; i++)
                    {
                        seriesY2.Points.AddXY(i, index[i].Capacity);
                    }
                    chart.ChartAreas[0].AxisY2.Maximum = fsql.Select<test>().Max(index => index.Capacity);
                    chart.ChartAreas[0].AxisY2.Minimum = fsql.Select<test>().Min(index => index.Capacity);

                }
                else if (Y2comboBox.Text == "Current(mA)")
                {
                    for (int i = 0; i < index.Count; i++)
                    {
                        seriesY2.Points.AddXY(i, index[i].Current);
                    }
                    chart.ChartAreas[0].AxisY2.Maximum = fsql.Select<test>().Max(index => index.Current);
                    chart.ChartAreas[0].AxisY2.Minimum = fsql.Select<test>().Min(index => index.Current);
                }
                else if (Y2comboBox.Text == "Voltage(mV)")
                {
                    for (int i = 0; i < index.Count; i++)
                    {
                        seriesY2.Points.AddXY(i, index[i].Voltage);
                    }
                    chart.ChartAreas[0].AxisY2.Maximum = fsql.Select<test>().Max(index => index.Voltage);
                    chart.ChartAreas[0].AxisY2.Minimum = fsql.Select<test>().Min(index => index.Voltage);
                }
                else if (Y2comboBox.Text == "Temperature(degC)")
                {
                    for (int i = 0; i < index.Count; i++)
                    {
                        seriesY2.Points.AddXY(i, index[i].Temperature);
                    }
                    chart.ChartAreas[0].AxisY2.Maximum = fsql.Select<test>().Max(index => index.Temperature);
                    chart.ChartAreas[0].AxisY2.Minimum = fsql.Select<test>().Min(index => index.Temperature);
                }
                else if (Y2comboBox.Text == "Total Capacity(mAh)")
                {
                    for (int i = 0; i < index.Count; i++)
                    {
                        seriesY2.Points.AddXY(i, index[i].TotalCapacity);
                    }
                    chart.ChartAreas[0].AxisY2.Maximum = fsql.Select<test>().Max(index => index.TotalCapacity);
                    chart.ChartAreas[0].AxisY2.Minimum = fsql.Select<test>().Min(index => index.TotalCapacity);
                }
            }

        }


        private void Commit_Click(object sender, EventArgs e)
        {
            edit form = new edit(id, name, date, num);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                //dataGridView1.Rows.Add(form2.n,form2.a);

                string addSql = "insert into test (name,date,num) values (" + "'" + form.a + "'" + "," + "'" + form.d + "'" + "," + form.n + ");";
                NpgsqlCommand addCommand = new NpgsqlCommand(addSql, con);
                con.Open();
                addCommand.ExecuteNonQuery();
                string countSql = "select count(*) from test";
                NpgsqlCommand countCommand = new NpgsqlCommand(countSql, con);

                NpgsqlDataReader reader = countCommand.ExecuteReader();
                while (reader.Read())
                {
                    x = reader.GetInt32(reader.GetOrdinal("count"));
                }
                con.Close();
                con.Open();


                string selectSql = "select * from test order by id asc limit 10 offset " + "'" + (x - 10) + "'" + "";
                dataTbale.Clear();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(selectSql, con);
                da.Fill(dataTbale);
                dataTbale.AcceptChanges();
                con.Close();
                //Refres();


            }

        }





        private void Edit_Click(object sender, EventArgs e)
        {

            i = dataGridView.CurrentRow.Index;
            id = Convert.ToInt32(dataGridView.Rows[i].Cells[0].Value);
            name = dataGridView.Rows[i].Cells[1].Value.ToString();
            date = Convert.ToDateTime(dataGridView.Rows[i].Cells[2].Value);
            num = Convert.ToInt32(dataGridView.Rows[i].Cells[3].Value);
            edit form = new edit(id, name, date, num);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {


                string updateSql = "update test set name = " + "'" + form.a + "'" + "where id = " + Convert.ToInt32(dataGridView.CurrentCell.Value);
                NpgsqlCommand updateCommand = new NpgsqlCommand(updateSql, con);
                con.Open();
                updateCommand.ExecuteNonQuery();

                Refres();

            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Remove(dataGridView1.CurrentRow);



            if (MessageBox.Show("delete?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string deleteSql = "delete from test where id = " + "'" + dataGridView.CurrentCell.Value.ToString() + "'";
                NpgsqlCommand deleteCommand = new NpgsqlCommand(deleteSql, con);
                con.Open();
                deleteCommand.ExecuteNonQuery();

                Refres();
            }


        }

        private void Export_Click(object sender, EventArgs e)
        {
            Thread threadexport;
            threadexport = new Thread(exportThread);
            threadexport.Start();

        }

        private void Import_Click(object sender, EventArgs e)
        {
            OpenFileDialog importFile = new OpenFileDialog();
            importFile.Filter = "csv files (*.csv)|*.csv";
            importFile.ShowDialog();
            var reader = new StreamReader(importFile.FileName);

            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            reader.ReadLine();
            con.Open();
            i = 0;

            DateTime befo = System.DateTime.Now;
            string copySql = "copy test from " + "'" + importFile.FileName + "'" + "with csv header";
            NpgsqlCommand copyCommand = new NpgsqlCommand(copySql, con);
            copyCommand.ExecuteNonQuery();
            con.Close();
            DateTime after = System.DateTime.Now;
            TimeSpan ts = after.Subtract(befo);
            MessageBox.Show("导入完成,耗时" + ts.TotalMilliseconds + "ms");
            dataTbale.Clear();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
            da.Fill(dataTbale);
        }
        public void exportThread()
        {
            i = dataTbale.Rows.Count;

            if (MessageBox.Show("是否导出", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                DateTime befo = System.DateTime.Now;
                var text = File.Create(@"D:\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv");
                text.Close();
                string exp = "copy (select * from test order by id asc) to" + "'" + text.Name + "'" + " with csv header";
                NpgsqlCommand exportCommand = new NpgsqlCommand(exp, con);
                con.Open();
                exportCommand.ExecuteNonQuery();
                con.Close();
                DateTime after = System.DateTime.Now;
                TimeSpan ts = after.Subtract(befo);
                MessageBox.Show("导出完成,耗时" + ts.TotalMilliseconds + "ms");
                dataTbale.AcceptChanges();
            }
        }

        public void Refres()
        {
            dataTbale.Clear();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
            da.Fill(dataTbale);
            dataTbale.AcceptChanges();
            con.Close();
        }
        private void dataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            DataTable dataTabletemp = new DataTable();
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                if (searchtextBox.Text == "")
                {                 
                    if (e.NewValue + dataGridView.DisplayedRowCount(false) == dataGridView.Rows.Count)
                    {                       
                        MessageBox.Show("Loading next page");
                        string selectSql = " select * from test order by id asc limit 100 offset " + "'" + offsetIndex + "'" + "";
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(selectSql, con);
                        da.Fill(dataTabletemp);
                        dataTbale.Merge(dataTabletemp);                      
                        dataTabletemp.Clear();
                        if (offsetIndex > 100)
                        {
                            for (int i = 0; i < 100; i++)
                            {
                                dataTbale.Rows[i].Delete();
                            }
                        }
                
                        dataTbale.AcceptChanges();
                        this.dataGridView.DataSource = dataTbale;
                        offsetIndexY = offsetIndex -200;
                        offsetIndex = offsetIndex + 100;
                        
                        int index = e.NewValue;

                        //dataGridView1.FirstDisplayedScrollingRowIndex = index-1;

                        if (offsetIndex <= 200)
                        {
                            dataGridView.FirstDisplayedScrollingRowIndex = index;
                        }
                        else
                        {
                            dataGridView.FirstDisplayedScrollingRowIndex = index-100;
                        }

                    }
                    else if (e.NewValue == 0)
                    {                       
                        string sql = " select * from test order by id asc limit 100 offset " + "'" + offsetIndexY + "'" + "";
                        MessageBox.Show("到头了，向上刷新");
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
                        //dataTbale.Clear();
                        da.Fill(dataTabletemp);
                        dataTabletemp.Merge(dataTbale);

                        if (offsetIndex > 100)
                        {
                            for (int i = 199; i < 299  ; i++)
                            {
                                dataTabletemp.Rows[i].Delete();
                            }
                            offsetIndex = offsetIndex - 100;
                        }

                        dataTabletemp.AcceptChanges();
                        this.dataGridView.DataSource = dataTabletemp;                     
                        offsetIndexY = offsetIndexY - 100;                      
                        dataGridView.FirstDisplayedScrollingRowIndex = 100;
                        dataTbale = dataTabletemp.Copy();

                    }
                }
                else
                {

                    if (e.NewValue + dataGridView.DisplayedRowCount(false) == dataGridView.Rows.Count)
                    {
                        MessageBox.Show("Loading next page");
                        string selectSql = "select * from test" + " where " + search.Text + " :: text like  '%" + searchtextBox.Text + "%'  order by id asc limit 100 offset " + "'" + offsetIndex + "'" + "";
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(selectSql, con);
                        da.Fill(dataTabletemp);
                        dataTbale.Merge(dataTabletemp);
                        dataTabletemp.Clear();
                        dataTbale.AcceptChanges();
                        offsetIndex = offsetIndex + 100;
                        int rowindex = e.NewValue;
                        dataGridView.FirstDisplayedScrollingRowIndex = rowindex;

                    }

                }
            }
        }

        private void searchtextBox_TextChanged(object sender, EventArgs e)
        {
            string select = @"select * from test" + " where \""  + search.Text +  " :: text like  '%" + searchtextBox.Text + "%'  order by id asc limit 100 ";
            
            if (searchtextBox.Text != null)
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(select, con);
                dataTbale.Clear();
                da.Fill(dataTbale);
            }
            else if (searchtextBox.Text == null)
            {

            }
            dataTbale.AcceptChanges();
        }

        private void openfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "csv files (*.csv)|*.csv";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                chart.Series.Clear();
                YcomboBox.Items.Clear();
                Y2comboBox.Items.Clear();
                filepathtextBox.Text = openFile.FileName;
                StdIndex.Clear();
                StdTime.Clear();
                StdMode.Clear();
                StdCurrent.Clear();
                StdVoltage.Clear();
                StdTemperature.Clear();
                StdCapacity.Clear();
                StdTotalCapacity.Clear();
                StdStatus.Clear();
                var reader = new StreamReader(openFile.FileName);
                var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var stdindex = csv.GetField<double>("Index");
                    var stdtime = csv.GetField<double>("Time(mS)");
                    var stdmode = csv.GetField<double>("Mode");
                    var stdcurrent = csv.GetField<double>("Current(mA)");
                    var stdvoltage = csv.GetField<double>("Voltage(mV)");
                    var stdtemperature = csv.GetField<double>("Temperature(degC)");
                    var stdcapacity = csv.GetField<double>("Capacity(mAh)");
                    var stdtotalcapacity = csv.GetField<double>("Total Capacity(mAh)");
                    var stdstatus = csv.GetField<double>("Status");
                    StdIndex.Add(stdindex);
                    StdTime.Add(stdtime);
                    StdMode.Add(stdmode);
                    StdCurrent.Add(stdcurrent);
                    StdVoltage.Add(stdvoltage);
                    StdTemperature.Add(stdtemperature);
                    StdCapacity.Add(stdcapacity);
                    StdTotalCapacity.Add(stdtotalcapacity);
                    StdStatus.Add(stdstatus);


                }
                for (int i = 0; i < csv.HeaderRecord.Length; i++)
                {
                    YcomboBox.Items.Add(csv.HeaderRecord[i]);
                
                }

                for (int i = 0; i < csv.HeaderRecord.Length; i++)
                {
                    Y2comboBox.Items.Add(csv.HeaderRecord[i]);
                }

                YcomboBox.Text = "";
                Y2comboBox.Text = "";

             
            }
        }



        private void chart_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                int i = e.HitTestResult.PointIndex;
                DataPoint dp = e.HitTestResult.Series.Points[i];
                e.Text = string.Format("{1:F3}", dp.XValue, dp.YValues[0]);
            }
        }

        private CCommunicateManager a = null;

        private void OpenI2C_Click(object sender, EventArgs e)
        {

            UInt32 u32myVer = 0;
            UInt32 u32Frequece = 100;
            UInt32 u32Error = 0;
            string strError;
            a = new CCommunicateManager();
            if (a != null)
            {
                a.OpenI2CAdapter();
                a.GetVersion(ref u32myVer);
                MessageBox.Show("连接成功");
                messagetextBox.Text = string.Format("Load COM successfully. Frequence = {0:d}, Version = 0x{1:X8}", u32Frequece, u32myVer);
                return;
            }
        }

        private void Read_Click(object sender, EventArgs e)
        {
        
            timer.Elapsed += new System.Timers.ElapsedEventHandler(i2c_read);
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
        }

        public void i2c_read(object sender ,System.Timers.ElapsedEventArgs e) 
        {
            byte[] yDataIn = new byte[3];
            byte[] yDataOut = new byte[3];
            UInt16 uOutLength = 0;
            UInt16 uReadLength = 2;
            byte yTemp = 0;
            UInt32 u32Error = 0;
            string strError;

            yTemp = 0;
            if (!byte.TryParse(I2ctextBox.Text, System.Globalization.NumberStyles.HexNumber, null, out yTemp))
            {
                MessageBox.Show("Error value on I2C address");
                return;
            }
            yDataIn[0] = yTemp;
            yTemp = 0;
            if (!byte.TryParse(indextextBox.Text, System.Globalization.NumberStyles.HexNumber, null, out yTemp))
            {
                MessageBox.Show("Error value on Register index");
                return;
            }
            yDataIn[1] = yTemp;

            //if (chkPeC.IsChecked == true)
            //{
            //    uReadLength += 1;
            //}
            if (a != null)
            {
                if (a.ReadDevice(yDataIn, ref yDataOut, ref uOutLength, uReadLength, 1))
                {
                    readtextBox.Text = string.Format("{0:X} {1:X}", yDataOut[0], yDataOut[1]);
                    messagetextBox.Text = string.Format("Read data from Device successfully.");

                    read.Add(readtextBox.Text);
                }
                else
                {
                    //textBox3.Text = string.Format("Read data failed.");
                    strError = a.GetLastErrorCode(ref u32Error);
                    read.Add(strError);
                    //readtextBox.Text = "afddf";
                    //MessageBox.Show(strError);
                  
              
                }
            }
            else
            {
                messagetextBox.Text = string.Format("DLL handler Error!");
            }


        }



        private void close_Click(object sender, EventArgs e)
        {

            timer.Elapsed -= new System.Timers.ElapsedEventHandler(i2c_read);
            timer.Enabled = false;
            timer.Stop();

        }
    }







}


public class stddate 
{
    public double StdIndex { get; set; }
    public double StdTime { get; set; }
    public double StdMode { get; set; }
    public double StdCurrent { get; set; }
    public double StdVoltage { get; set; }
    public double StdTemperature { get; set; }
    public double StdCapacity { get; set; }
    public double StdTotalCapacity { get; set; }
    public double StdStatus { get; set; }


}

public class test 
{
    [Column(IsIdentity = true)]
    public int Index { get; set; }

    [Column(Name = "Time(mS)")]
    public double Time { get; set; }

    public int Mode { get; set; }

    [Column(Name = "Current(mA)")]
    public double Current { get; set; }

    [Column(Name = "Voltage(mV)")]
    public double Voltage { get; set; }

    [Column(Name = "Temperature(degC)")]
    public double Temperature { get; set; }

    [Column(Name = "Capacity(mAh)")]
    public double Capacity { get; set; }

    [Column(Name = "Total Capacity(mAh)")]
    public double TotalCapacity { get; set; }

    public int Status { get; set; }



}





