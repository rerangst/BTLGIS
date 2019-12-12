namespace MapWinGIS
{
    partial class Remove_form
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
            this.cbb_remove = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_remove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbb_remove
            // 
            this.cbb_remove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_remove.FormattingEnabled = true;
            this.cbb_remove.Location = new System.Drawing.Point(109, 24);
            this.cbb_remove.Name = "cbb_remove";
            this.cbb_remove.Size = new System.Drawing.Size(265, 24);
            this.cbb_remove.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chon Truong";
            // 
            // btn_remove
            // 
            this.btn_remove.Location = new System.Drawing.Point(109, 68);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(103, 39);
            this.btn_remove.TabIndex = 2;
            this.btn_remove.Text = "Xoa";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // Remove_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 122);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbb_remove);
            this.Name = "Remove_form";
            this.Text = "Remove_form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb_remove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_remove;
    }
}