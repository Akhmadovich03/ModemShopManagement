namespace kurs_ishi_modemlar
{
    partial class Bosh_menyu
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
            this.label1 = new System.Windows.Forms.Label();
            this.jadvallar_btn = new System.Windows.Forms.Button();
            this.sorov_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(128, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(722, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "KERAKLI BO\'LIMNI TANLANG";
            // 
            // jadvallar_btn
            // 
            this.jadvallar_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.jadvallar_btn.Font = new System.Drawing.Font("Times New Roman", 25.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.jadvallar_btn.Location = new System.Drawing.Point(90, 297);
            this.jadvallar_btn.Name = "jadvallar_btn";
            this.jadvallar_btn.Size = new System.Drawing.Size(303, 107);
            this.jadvallar_btn.TabIndex = 1;
            this.jadvallar_btn.Text = "JADVALLAR";
            this.jadvallar_btn.UseVisualStyleBackColor = true;
            this.jadvallar_btn.Click += new System.EventHandler(this.jadvallar_btn_Click);
            // 
            // sorov_btn
            // 
            this.sorov_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.sorov_btn.Font = new System.Drawing.Font("Times New Roman", 25.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sorov_btn.Location = new System.Drawing.Point(572, 297);
            this.sorov_btn.Name = "sorov_btn";
            this.sorov_btn.Size = new System.Drawing.Size(303, 107);
            this.sorov_btn.TabIndex = 2;
            this.sorov_btn.Text = "SO\'ROVLAR";
            this.sorov_btn.UseVisualStyleBackColor = true;
            // 
            // Bosh_menyu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::kurs_ishi_modemlar.Properties.Resources.wifi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.sorov_btn);
            this.Controls.Add(this.jadvallar_btn);
            this.Controls.Add(this.label1);
            this.Name = "Bosh_menyu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bosh_menyu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bosh_menyu_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button jadvallar_btn;
        private Button sorov_btn;
    }
}