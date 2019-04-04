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
            this.pnl_Process = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_ViewHTHL = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_Header.SuspendLayout();
            this.pnl_Brower.SuspendLayout();
            this.pnl_Process.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Header
            // 
            this.pnl_Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnl_Header.Controls.Add(this.btn_Power);
            this.pnl_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Header.Location = new System.Drawing.Point(0, 0);
            this.pnl_Header.Name = "pnl_Header";
            this.pnl_Header.Size = new System.Drawing.Size(1014, 33);
            this.pnl_Header.TabIndex = 0;
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
            this.pnl_Brower.Size = new System.Drawing.Size(535, 586);
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
            // pnl_Process
            // 
            this.pnl_Process.Controls.Add(this.label1);
            this.pnl_Process.Controls.Add(this.button1);
            this.pnl_Process.Controls.Add(this.textBox1);
            this.pnl_Process.Controls.Add(this.btn_ViewHTHL);
            this.pnl_Process.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_Process.Location = new System.Drawing.Point(538, 33);
            this.pnl_Process.Name = "pnl_Process";
            this.pnl_Process.Size = new System.Drawing.Size(476, 586);
            this.pnl_Process.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(152, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 147);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(369, 229);
            this.textBox1.TabIndex = 1;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Text:";
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 619);
            this.Controls.Add(this.pnl_Process);
            this.Controls.Add(this.pnl_Brower);
            this.Controls.Add(this.pnl_Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Main";
            this.Text = "Form1";
            this.pnl_Header.ResumeLayout(false);
            this.pnl_Brower.ResumeLayout(false);
            this.pnl_Brower.PerformLayout();
            this.pnl_Process.ResumeLayout(false);
            this.pnl_Process.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Header;
        private System.Windows.Forms.Button btn_Power;
        private System.Windows.Forms.Panel pnl_Brower;
        private System.Windows.Forms.WebBrowser wbro_Brower;
        private System.Windows.Forms.Button btn_Go;
        private System.Windows.Forms.TextBox txt_Url;
        private System.Windows.Forms.Panel pnl_Process;
        private System.Windows.Forms.Button btn_ViewHTHL;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

