namespace kurs_ishi_modemlar
{
    partial class Jadvallar
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
            this.firmalar_btn = new System.Windows.Forms.Button();
            this.switchlar_btn = new System.Windows.Forms.Button();
            this.routerlar_btn = new System.Windows.Forms.Button();
            this.modemlar_btn = new System.Windows.Forms.Button();
            this.orqaga_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 49.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(226, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(514, 94);
            this.label1.TabIndex = 0;
            this.label1.Text = "JADVALLAR";
            // 
            // firmalar_btn
            // 
            this.firmalar_btn.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.firmalar_btn.Location = new System.Drawing.Point(63, 163);
            this.firmalar_btn.Name = "firmalar_btn";
            this.firmalar_btn.Size = new System.Drawing.Size(300, 100);
            this.firmalar_btn.TabIndex = 1;
            this.firmalar_btn.Text = "FIRMALAR";
            this.firmalar_btn.UseVisualStyleBackColor = true;
            this.firmalar_btn.Click += new System.EventHandler(this.firmalar_btn_Click);
            // 
            // switchlar_btn
            // 
            this.switchlar_btn.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.switchlar_btn.Location = new System.Drawing.Point(625, 278);
            this.switchlar_btn.Name = "switchlar_btn";
            this.switchlar_btn.Size = new System.Drawing.Size(300, 100);
            this.switchlar_btn.TabIndex = 2;
            this.switchlar_btn.Text = "SWITCHLAR";
            this.switchlar_btn.UseVisualStyleBackColor = true;
            this.switchlar_btn.Click += new System.EventHandler(this.switchlar_btn_Click);
            // 
            // routerlar_btn
            // 
            this.routerlar_btn.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.routerlar_btn.Location = new System.Drawing.Point(625, 163);
            this.routerlar_btn.Name = "routerlar_btn";
            this.routerlar_btn.Size = new System.Drawing.Size(300, 100);
            this.routerlar_btn.TabIndex = 3;
            this.routerlar_btn.Text = "ROUTERLAR";
            this.routerlar_btn.UseVisualStyleBackColor = true;
            this.routerlar_btn.Click += new System.EventHandler(this.routerlar_btn_Click);
            // 
            // modemlar_btn
            // 
            this.modemlar_btn.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.modemlar_btn.Location = new System.Drawing.Point(63, 278);
            this.modemlar_btn.Name = "modemlar_btn";
            this.modemlar_btn.Size = new System.Drawing.Size(300, 100);
            this.modemlar_btn.TabIndex = 4;
            this.modemlar_btn.Text = "MODEMLAR";
            this.modemlar_btn.UseVisualStyleBackColor = true;
            this.modemlar_btn.Click += new System.EventHandler(this.modemlar_btn_Click);
            // 
            // orqaga_btn
            // 
            this.orqaga_btn.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.orqaga_btn.Location = new System.Drawing.Point(344, 395);
            this.orqaga_btn.Name = "orqaga_btn";
            this.orqaga_btn.Size = new System.Drawing.Size(300, 100);
            this.orqaga_btn.TabIndex = 5;
            this.orqaga_btn.Text = "ORQAGA";
            this.orqaga_btn.UseVisualStyleBackColor = true;
            this.orqaga_btn.Click += new System.EventHandler(this.orqaga_btn_Click);
            // 
            // Jadvallar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::kurs_ishi_modemlar.Properties.Resources.Modern_background_blue_with_element_Graphics_23272362_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.orqaga_btn);
            this.Controls.Add(this.modemlar_btn);
            this.Controls.Add(this.routerlar_btn);
            this.Controls.Add(this.switchlar_btn);
            this.Controls.Add(this.firmalar_btn);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Jadvallar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jadvallar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Jadvallar_FormClosing);
            this.Load += new System.EventHandler(this.Jadvallar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button firmalar_btn;
        private Button switchlar_btn;
        private Button routerlar_btn;
        private Button modemlar_btn;
        private Button orqaga_btn;
    }
}