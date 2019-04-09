namespace Tool_SqlInjectionBlind_Dvwa
{
    partial class frm_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_Header = new System.Windows.Forms.Panel();
            this.btn_Power = new System.Windows.Forms.Button();
            this.pnl_Brower = new System.Windows.Forms.Panel();
            this.wbro_Brower = new System.Windows.Forms.WebBrowser();
            this.btn_Go = new System.Windows.Forms.Button();
            this.txt_Url = new System.Windows.Forms.TextBox();
            this.btn_ViewHTHL = new System.Windows.Forms.Button();
            this.btn_GetDBName = new System.Windows.Forms.Button();
            this.lbl_Result_DBName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clb_ColsName = new System.Windows.Forms.CheckedListBox();
            this.cmb_Tables = new System.Windows.Forms.ComboBox();
            this.btn_GetData = new System.Windows.Forms.Button();
            this.pnl_Process = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_Count_TBsName = new System.Windows.Forms.Label();
            this.lbl_TBsName = new System.Windows.Forms.Label();
            this.btn_GetTBsName = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Cols_Name = new System.Windows.Forms.ComboBox();
            this.cmb_TbsName = new System.Windows.Forms.ComboBox();
            this.btn_GetColsName = new System.Windows.Forms.Button();
            this.dgv_Data = new System.Windows.Forms.DataGridView();
            this.pnl_Header.SuspendLayout();
            this.pnl_Brower.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_Process.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_Header
            // 
            this.pnl_Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnl_Header.Controls.Add(this.btn_Power);
            this.pnl_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Header.Location = new System.Drawing.Point(0, 0);
            this.pnl_Header.Name = "pnl_Header";
            this.pnl_Header.Size = new System.Drawing.Size(1023, 33);
            this.pnl_Header.TabIndex = 0;
            this.pnl_Header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_Header_MouseDown);
            // 
            // btn_Power
            // 
            this.btn_Power.BackgroundImage = global::Tool_SqlInjectionBlind_Dvwa.resour_img.Exit_32px;
            this.btn_Power.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Power.FlatAppearance.BorderSize = 0;
            this.btn_Power.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Power.Location = new System.Drawing.Point(981, 3);
            this.btn_Power.Name = "btn_Power";
            this.btn_Power.Size = new System.Drawing.Size(25, 26);
            this.btn_Power.TabIndex = 0;
            this.btn_Power.UseVisualStyleBackColor = true;
            this.btn_Power.Click += new System.EventHandler(this.btn_Power_Click);
            // 
            // pnl_Brower
            // 
            this.pnl_Brower.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnl_Brower.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Brower.Controls.Add(this.wbro_Brower);
            this.pnl_Brower.Controls.Add(this.btn_Go);
            this.pnl_Brower.Controls.Add(this.txt_Url);
            this.pnl_Brower.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Brower.Location = new System.Drawing.Point(0, 33);
            this.pnl_Brower.Name = "pnl_Brower";
            this.pnl_Brower.Size = new System.Drawing.Size(535, 642);
            this.pnl_Brower.TabIndex = 1;
            // 
            // wbro_Brower
            // 
            this.wbro_Brower.Location = new System.Drawing.Point(3, 32);
            this.wbro_Brower.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbro_Brower.Name = "wbro_Brower";
            this.wbro_Brower.Size = new System.Drawing.Size(528, 554);
            this.wbro_Brower.TabIndex = 2;
            this.wbro_Brower.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbro_Brower_DocumentCompleted);
            // 
            // btn_Go
            // 
            this.btn_Go.Location = new System.Drawing.Point(488, 4);
            this.btn_Go.Name = "btn_Go";
            this.btn_Go.Size = new System.Drawing.Size(43, 23);
            this.btn_Go.TabIndex = 1;
            this.btn_Go.Text = "Go";
            this.btn_Go.UseVisualStyleBackColor = true;
            this.btn_Go.Click += new System.EventHandler(this.btn_Go_Click);
            // 
            // txt_Url
            // 
            this.txt_Url.Location = new System.Drawing.Point(3, 6);
            this.txt_Url.Name = "txt_Url";
            this.txt_Url.Size = new System.Drawing.Size(479, 20);
            this.txt_Url.TabIndex = 0;
            // 
            // btn_ViewHTHL
            // 
            this.btn_ViewHTHL.FlatAppearance.BorderSize = 0;
            this.btn_ViewHTHL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ViewHTHL.Location = new System.Drawing.Point(14, 7);
            this.btn_ViewHTHL.Name = "btn_ViewHTHL";
            this.btn_ViewHTHL.Size = new System.Drawing.Size(57, 43);
            this.btn_ViewHTHL.TabIndex = 0;
            this.btn_ViewHTHL.Text = "View HTML";
            this.btn_ViewHTHL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_ViewHTHL.UseVisualStyleBackColor = true;
            this.btn_ViewHTHL.Click += new System.EventHandler(this.btn_ViewHTHL_Click);
            // 
            // btn_GetDBName
            // 
            this.btn_GetDBName.Location = new System.Drawing.Point(19, 56);
            this.btn_GetDBName.Name = "btn_GetDBName";
            this.btn_GetDBName.Size = new System.Drawing.Size(86, 31);
            this.btn_GetDBName.TabIndex = 2;
            this.btn_GetDBName.Text = "Get db name";
            this.btn_GetDBName.UseVisualStyleBackColor = true;
            this.btn_GetDBName.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_Result_DBName
            // 
            this.lbl_Result_DBName.AutoSize = true;
            this.lbl_Result_DBName.Location = new System.Drawing.Point(114, 65);
            this.lbl_Result_DBName.Name = "lbl_Result_DBName";
            this.lbl_Result_DBName.Size = new System.Drawing.Size(40, 13);
            this.lbl_Result_DBName.TabIndex = 3;
            this.lbl_Result_DBName.Text = "Result:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgv_Data);
            this.panel1.Controls.Add(this.clb_ColsName);
            this.panel1.Controls.Add(this.cmb_Tables);
            this.panel1.Controls.Add(this.btn_GetData);
            this.panel1.Location = new System.Drawing.Point(3, 237);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 402);
            this.panel1.TabIndex = 10;
            // 
            // clb_ColsName
            // 
            this.clb_ColsName.FormattingEnabled = true;
            this.clb_ColsName.Location = new System.Drawing.Point(279, 12);
            this.clb_ColsName.Name = "clb_ColsName";
            this.clb_ColsName.Size = new System.Drawing.Size(136, 49);
            this.clb_ColsName.TabIndex = 16;
            // 
            // cmb_Tables
            // 
            this.cmb_Tables.FormattingEnabled = true;
            this.cmb_Tables.Location = new System.Drawing.Point(140, 12);
            this.cmb_Tables.Name = "cmb_Tables";
            this.cmb_Tables.Size = new System.Drawing.Size(107, 21);
            this.cmb_Tables.TabIndex = 14;
            this.cmb_Tables.SelectedIndexChanged += new System.EventHandler(this.cmb_Tables_SelectedIndexChanged);
            // 
            // btn_GetData
            // 
            this.btn_GetData.Location = new System.Drawing.Point(16, 6);
            this.btn_GetData.Name = "btn_GetData";
            this.btn_GetData.Size = new System.Drawing.Size(86, 31);
            this.btn_GetData.TabIndex = 13;
            this.btn_GetData.Text = "Get Data";
            this.btn_GetData.UseVisualStyleBackColor = true;
            this.btn_GetData.Click += new System.EventHandler(this.btn_GetData_Click);
            // 
            // pnl_Process
            // 
            this.pnl_Process.Controls.Add(this.panel3);
            this.pnl_Process.Controls.Add(this.panel2);
            this.pnl_Process.Controls.Add(this.panel1);
            this.pnl_Process.Controls.Add(this.lbl_Result_DBName);
            this.pnl_Process.Controls.Add(this.btn_GetDBName);
            this.pnl_Process.Controls.Add(this.btn_ViewHTHL);
            this.pnl_Process.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_Process.Location = new System.Drawing.Point(547, 33);
            this.pnl_Process.Name = "pnl_Process";
            this.pnl_Process.Size = new System.Drawing.Size(476, 642);
            this.pnl_Process.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbl_Count_TBsName);
            this.panel3.Controls.Add(this.lbl_TBsName);
            this.panel3.Controls.Add(this.btn_GetTBsName);
            this.panel3.Location = new System.Drawing.Point(3, 93);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(465, 47);
            this.panel3.TabIndex = 12;
            // 
            // lbl_Count_TBsName
            // 
            this.lbl_Count_TBsName.AutoSize = true;
            this.lbl_Count_TBsName.Location = new System.Drawing.Point(116, 8);
            this.lbl_Count_TBsName.Name = "lbl_Count_TBsName";
            this.lbl_Count_TBsName.Size = new System.Drawing.Size(38, 13);
            this.lbl_Count_TBsName.TabIndex = 9;
            this.lbl_Count_TBsName.Text = "Count:";
            // 
            // lbl_TBsName
            // 
            this.lbl_TBsName.AutoSize = true;
            this.lbl_TBsName.Location = new System.Drawing.Point(116, 26);
            this.lbl_TBsName.Name = "lbl_TBsName";
            this.lbl_TBsName.Size = new System.Drawing.Size(40, 13);
            this.lbl_TBsName.TabIndex = 8;
            this.lbl_TBsName.Text = "Result:";
            // 
            // btn_GetTBsName
            // 
            this.btn_GetTBsName.Location = new System.Drawing.Point(16, 8);
            this.btn_GetTBsName.Name = "btn_GetTBsName";
            this.btn_GetTBsName.Size = new System.Drawing.Size(86, 31);
            this.btn_GetTBsName.TabIndex = 7;
            this.btn_GetTBsName.Text = "Get tbs name";
            this.btn_GetTBsName.UseVisualStyleBackColor = true;
            this.btn_GetTBsName.Click += new System.EventHandler(this.btn_GetTBsName_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmb_Cols_Name);
            this.panel2.Controls.Add(this.cmb_TbsName);
            this.panel2.Controls.Add(this.btn_GetColsName);
            this.panel2.Location = new System.Drawing.Point(3, 145);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(465, 75);
            this.panel2.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Columns";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tables";
            // 
            // cmb_Cols_Name
            // 
            this.cmb_Cols_Name.FormattingEnabled = true;
            this.cmb_Cols_Name.Location = new System.Drawing.Point(341, 28);
            this.cmb_Cols_Name.Name = "cmb_Cols_Name";
            this.cmb_Cols_Name.Size = new System.Drawing.Size(108, 21);
            this.cmb_Cols_Name.TabIndex = 15;
            // 
            // cmb_TbsName
            // 
            this.cmb_TbsName.FormattingEnabled = true;
            this.cmb_TbsName.Location = new System.Drawing.Point(149, 28);
            this.cmb_TbsName.Name = "cmb_TbsName";
            this.cmb_TbsName.Size = new System.Drawing.Size(107, 21);
            this.cmb_TbsName.TabIndex = 14;
            this.cmb_TbsName.SelectedIndexChanged += new System.EventHandler(this.cmb_TbsName_SelectedIndexChanged);
            // 
            // btn_GetColsName
            // 
            this.btn_GetColsName.Location = new System.Drawing.Point(15, 22);
            this.btn_GetColsName.Name = "btn_GetColsName";
            this.btn_GetColsName.Size = new System.Drawing.Size(86, 31);
            this.btn_GetColsName.TabIndex = 13;
            this.btn_GetColsName.Text = "Get cols name";
            this.btn_GetColsName.UseVisualStyleBackColor = true;
            this.btn_GetColsName.Click += new System.EventHandler(this.btn_GetColsName_Click);
            // 
            // dgv_Data
            // 
            this.dgv_Data.AllowUserToAddRows = false;
            this.dgv_Data.AllowUserToDeleteRows = false;
            this.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Data.Location = new System.Drawing.Point(3, 71);
            this.dgv_Data.Name = "dgv_Data";
            this.dgv_Data.ReadOnly = true;
            this.dgv_Data.Size = new System.Drawing.Size(467, 331);
            this.dgv_Data.TabIndex = 17;
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 675);
            this.Controls.Add(this.pnl_Process);
            this.Controls.Add(this.pnl_Brower);
            this.Controls.Add(this.pnl_Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Main";
            this.Text = "Form1";
            this.pnl_Header.ResumeLayout(false);
            this.pnl_Brower.ResumeLayout(false);
            this.pnl_Brower.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.pnl_Process.ResumeLayout(false);
            this.pnl_Process.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Header;
        private System.Windows.Forms.Button btn_Power;
        private System.Windows.Forms.Panel pnl_Brower;
        private System.Windows.Forms.WebBrowser wbro_Brower;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.TextBox txt_Url;
        private System.Windows.Forms.Button btn_ViewHTHL;
        private System.Windows.Forms.Button btn_GetDBName;
        private System.Windows.Forms.Label lbl_Result_DBName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmb_Tables;
        private System.Windows.Forms.Button btn_GetData;
        private System.Windows.Forms.Panel pnl_Process;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_Count_TBsName;
        private System.Windows.Forms.Label lbl_TBsName;
        private System.Windows.Forms.Button btn_GetTBsName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_Cols_Name;
        private System.Windows.Forms.ComboBox cmb_TbsName;
        private System.Windows.Forms.Button btn_GetColsName;
        private ViewProcess vp;
        private System.Windows.Forms.CheckedListBox clb_ColsName;
        private System.Windows.Forms.DataGridView dgv_Data;
    }
}

