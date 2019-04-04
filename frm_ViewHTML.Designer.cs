namespace Tool_SqlInjectionBlind_Dvwa
{
    partial class frm_ViewHTML
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
            this.rtxt_ContentHTML = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtxt_ContentHTML
            // 
            this.rtxt_ContentHTML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_ContentHTML.Location = new System.Drawing.Point(0, 0);
            this.rtxt_ContentHTML.Name = "rtxt_ContentHTML";
            this.rtxt_ContentHTML.Size = new System.Drawing.Size(774, 489);
            this.rtxt_ContentHTML.TabIndex = 0;
            this.rtxt_ContentHTML.Text = "";
            // 
            // frm_ViewHTML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 489);
            this.Controls.Add(this.rtxt_ContentHTML);
            this.Name = "frm_ViewHTML";
            this.Text = "frm_ViewHTML";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxt_ContentHTML;
    }
}