namespace kurs_ishi_modemlar
{
    partial class Kirish
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.enter_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 49.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(215, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(523, 94);
            this.label1.TabIndex = 0;
            this.label1.Text = "MODEMLAR";
            // 
            // enter_btn
            // 
            this.enter_btn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.enter_btn.BackgroundImage = global::kurs_ishi_modemlar.Properties.Resources._1681109678_pictures_pibig_info_p_risunok_strelka_vpravo_pinterest_2;
            this.enter_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.enter_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.enter_btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.enter_btn.Location = new System.Drawing.Point(788, 503);
            this.enter_btn.Name = "enter_btn";
            this.enter_btn.Size = new System.Drawing.Size(104, 38);
            this.enter_btn.TabIndex = 5;
            this.enter_btn.UseVisualStyleBackColor = false;
            this.enter_btn.Click += new System.EventHandler(this.enter_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(736, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 110);
            this.label2.TabIndex = 6;
            this.label2.Text = "YO\'NALISH : KIDT\r\nGURUH : 2102\r\nBAJARDI : ABDULLAYEV\r\nRO\'ZIMUHAMMAD\r\n\r\n";
            // 
            // Kirish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::kurs_ishi_modemlar.Properties.Resources.istockphoto_691430076_170667a;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.enter_btn);
            this.Controls.Add(this.label1);
            this.Name = "Kirish";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kirish";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Kirish_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button enter_btn;
        private Label label2;
    }
}