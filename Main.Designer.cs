
namespace WindowsFormsApp1
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.searchtextBox = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.ComboBox();
            this.commit = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.export = new System.Windows.Forms.Button();
            this.import = new System.Windows.Forms.Button();
            this.YcomboBox = new System.Windows.Forms.ComboBox();
            this.Y2comboBox = new System.Windows.Forms.ComboBox();
            this.openfile = new System.Windows.Forms.Button();
            this.filepathtextBox = new System.Windows.Forms.TextBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OpenI2C = new System.Windows.Forms.Button();
            this.Read = new System.Windows.Forms.Button();
            this.messagetextBox = new System.Windows.Forms.TextBox();
            this.I2ctextBox = new System.Windows.Forms.TextBox();
            this.indextextBox = new System.Windows.Forms.TextBox();
            this.readtextBox = new System.Windows.Forms.TextBox();
            this.close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(66, 38);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(403, 591);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridView_Scroll);
            // 
            // searchtextBox
            // 
            this.searchtextBox.Location = new System.Drawing.Point(496, 64);
            this.searchtextBox.Name = "searchtextBox";
            this.searchtextBox.Size = new System.Drawing.Size(121, 21);
            this.searchtextBox.TabIndex = 2;
            this.searchtextBox.TextChanged += new System.EventHandler(this.searchtextBox_TextChanged);
            // 
            // search
            // 
            this.search.FormattingEnabled = true;
            this.search.Location = new System.Drawing.Point(496, 38);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(121, 20);
            this.search.TabIndex = 3;
            // 
            // commit
            // 
            this.commit.Location = new System.Drawing.Point(66, 655);
            this.commit.Name = "commit";
            this.commit.Size = new System.Drawing.Size(75, 23);
            this.commit.TabIndex = 4;
            this.commit.Text = "commit";
            this.commit.UseVisualStyleBackColor = true;
            this.commit.Click += new System.EventHandler(this.Commit_Click);
            // 
            // edit
            // 
            this.edit.Location = new System.Drawing.Point(147, 655);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(75, 23);
            this.edit.TabIndex = 5;
            this.edit.Text = "edit";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.Edit_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(228, 655);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 6;
            this.delete.Text = "delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(309, 655);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(75, 23);
            this.export.TabIndex = 7;
            this.export.Text = "export";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.Export_Click);
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(390, 655);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(75, 23);
            this.import.TabIndex = 8;
            this.import.Text = "import";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.Import_Click);
            // 
            // YcomboBox
            // 
            this.YcomboBox.FormattingEnabled = true;
            this.YcomboBox.Location = new System.Drawing.Point(1115, 38);
            this.YcomboBox.Name = "YcomboBox";
            this.YcomboBox.Size = new System.Drawing.Size(121, 20);
            this.YcomboBox.TabIndex = 9;
            this.YcomboBox.TextChanged += new System.EventHandler(this.YcomboBox_TextChanged);
            // 
            // Y2comboBox
            // 
            this.Y2comboBox.FormattingEnabled = true;
            this.Y2comboBox.Location = new System.Drawing.Point(1115, 64);
            this.Y2comboBox.Name = "Y2comboBox";
            this.Y2comboBox.Size = new System.Drawing.Size(121, 20);
            this.Y2comboBox.TabIndex = 10;
            this.Y2comboBox.TextChanged += new System.EventHandler(this.Y2comboBox_TextChanged);
            // 
            // openfile
            // 
            this.openfile.Location = new System.Drawing.Point(683, 64);
            this.openfile.Name = "openfile";
            this.openfile.Size = new System.Drawing.Size(75, 23);
            this.openfile.TabIndex = 11;
            this.openfile.Text = "openfile";
            this.openfile.UseVisualStyleBackColor = true;
            this.openfile.Click += new System.EventHandler(this.openfile_Click);
            // 
            // filepathtextBox
            // 
            this.filepathtextBox.Location = new System.Drawing.Point(683, 36);
            this.filepathtextBox.Name = "filepathtextBox";
            this.filepathtextBox.Size = new System.Drawing.Size(340, 21);
            this.filepathtextBox.TabIndex = 12;
            // 
            // chart
            // 
            chartArea1.BorderColor = System.Drawing.Color.DarkOrange;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(496, 297);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(572, 332);
            this.chart.TabIndex = 13;
            this.chart.Text = "chart1";
            this.chart.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chart_GetToolTipText);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(636, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "文件名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1062, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "Y轴";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1062, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "辅助Y轴";
            // 
            // OpenI2C
            // 
            this.OpenI2C.Location = new System.Drawing.Point(801, 63);
            this.OpenI2C.Name = "OpenI2C";
            this.OpenI2C.Size = new System.Drawing.Size(75, 23);
            this.OpenI2C.TabIndex = 17;
            this.OpenI2C.Text = "OpenI2C";
            this.OpenI2C.UseVisualStyleBackColor = true;
            this.OpenI2C.Click += new System.EventHandler(this.OpenI2C_Click);
            // 
            // Read
            // 
            this.Read.Location = new System.Drawing.Point(898, 64);
            this.Read.Name = "Read";
            this.Read.Size = new System.Drawing.Size(75, 23);
            this.Read.TabIndex = 18;
            this.Read.Text = "Read";
            this.Read.UseVisualStyleBackColor = true;
            this.Read.Click += new System.EventHandler(this.Read_Click);
            // 
            // messagetextBox
            // 
            this.messagetextBox.Location = new System.Drawing.Point(527, 109);
            this.messagetextBox.Name = "messagetextBox";
            this.messagetextBox.Size = new System.Drawing.Size(432, 21);
            this.messagetextBox.TabIndex = 19;
            // 
            // I2ctextBox
            // 
            this.I2ctextBox.Location = new System.Drawing.Point(527, 161);
            this.I2ctextBox.Name = "I2ctextBox";
            this.I2ctextBox.Size = new System.Drawing.Size(100, 21);
            this.I2ctextBox.TabIndex = 20;
            // 
            // indextextBox
            // 
            this.indextextBox.Location = new System.Drawing.Point(527, 199);
            this.indextextBox.Name = "indextextBox";
            this.indextextBox.Size = new System.Drawing.Size(100, 21);
            this.indextextBox.TabIndex = 21;
            // 
            // readtextBox
            // 
            this.readtextBox.Location = new System.Drawing.Point(981, 109);
            this.readtextBox.Multiline = true;
            this.readtextBox.Name = "readtextBox";
            this.readtextBox.Size = new System.Drawing.Size(143, 182);
            this.readtextBox.TabIndex = 22;
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(981, 64);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 23;
            this.close.Text = "close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 679);
            this.Controls.Add(this.close);
            this.Controls.Add(this.readtextBox);
            this.Controls.Add(this.indextextBox);
            this.Controls.Add(this.I2ctextBox);
            this.Controls.Add(this.messagetextBox);
            this.Controls.Add(this.Read);
            this.Controls.Add(this.OpenI2C);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.filepathtextBox);
            this.Controls.Add(this.openfile);
            this.Controls.Add(this.Y2comboBox);
            this.Controls.Add(this.YcomboBox);
            this.Controls.Add(this.import);
            this.Controls.Add(this.export);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.commit);
            this.Controls.Add(this.search);
            this.Controls.Add(this.searchtextBox);
            this.Controls.Add(this.dataGridView);
            this.Name = "Main";
            this.Text = "main";
            this.Load += new System.EventHandler(this.main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox searchtextBox;
        private System.Windows.Forms.ComboBox search;
        private System.Windows.Forms.Button commit;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.ComboBox YcomboBox;
        private System.Windows.Forms.ComboBox Y2comboBox;
        private System.Windows.Forms.Button openfile;
        private System.Windows.Forms.TextBox filepathtextBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OpenI2C;
        private System.Windows.Forms.Button Read;
        private System.Windows.Forms.TextBox messagetextBox;
        private System.Windows.Forms.TextBox I2ctextBox;
        private System.Windows.Forms.TextBox indextextBox;
        private System.Windows.Forms.TextBox readtextBox;
        private System.Windows.Forms.Button close;
    }
}

