namespace Tool_SqlInjectionBlind_Dvwa
{
    partial class ViewProcess
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
            this.rtxt_View = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtxt_View
            // 
            this.rtxt_View.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_View.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxt_View.Location = new System.Drawing.Point(0, 0);
            this.rtxt_View.Name = "rtxt_View";
            this.rtxt_View.Size = new System.Drawing.Size(557, 452);
            this.rtxt_View.TabIndex = 0;
            this.rtxt_View.Text = "";
            this.rtxt_View.TextChanged += new System.EventHandler(this.rtxt_View_TextChanged);
            // 
            // ViewProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(557, 452);
            this.ControlBox = false;
            this.Controls.Add(this.rtxt_View);
            this.Name = "ViewProcess";
            this.Text = "ViewProcess";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox rtxt_View;
    }
}