namespace CalisanYonetimSistemi
{
    partial class PerformansDegerlendirmeleri
    {
           private System.ComponentModel.IContainer components = null;

            protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

            private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewPerformansDegerlendirmeleri = new System.Windows.Forms.DataGridView();
            this.buttonSil = new System.Windows.Forms.Button();
            this.buttonYenile = new System.Windows.Forms.Button();
            this.buttonKaydet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPerformansDegerlendirmeleri)).BeginInit();
            this.SuspendLayout();
                                                this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(145, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 31);
            this.label1.TabIndex = 24;
            this.label1.Text = "Performans Degerlendirmeleri";
                                                this.dataGridViewPerformansDegerlendirmeleri.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPerformansDegerlendirmeleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPerformansDegerlendirmeleri.Location = new System.Drawing.Point(12, 68);
            this.dataGridViewPerformansDegerlendirmeleri.Name = "dataGridViewPerformansDegerlendirmeleri";
            this.dataGridViewPerformansDegerlendirmeleri.RowTemplate.Height = 24;
            this.dataGridViewPerformansDegerlendirmeleri.Size = new System.Drawing.Size(621, 345);
            this.dataGridViewPerformansDegerlendirmeleri.TabIndex = 20;
                                                this.buttonSil.BackgroundImage = global::CalisanYonetimSistemi.Properties.Resources.icon_delete;
            this.buttonSil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSil.Location = new System.Drawing.Point(12, 12);
            this.buttonSil.Name = "buttonSil";
            this.buttonSil.Size = new System.Drawing.Size(50, 50);
            this.buttonSil.TabIndex = 21;
            this.buttonSil.UseVisualStyleBackColor = true;
                                                this.buttonYenile.BackgroundImage = global::CalisanYonetimSistemi.Properties.Resources.refresh;
            this.buttonYenile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonYenile.Location = new System.Drawing.Point(68, 12);
            this.buttonYenile.Name = "buttonYenile";
            this.buttonYenile.Size = new System.Drawing.Size(50, 50);
            this.buttonYenile.TabIndex = 22;
            this.buttonYenile.UseVisualStyleBackColor = true;
                                                this.buttonKaydet.BackgroundImage = global::CalisanYonetimSistemi.Properties.Resources.save;
            this.buttonKaydet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonKaydet.Location = new System.Drawing.Point(583, 12);
            this.buttonKaydet.Name = "buttonKaydet";
            this.buttonKaydet.Size = new System.Drawing.Size(50, 50);
            this.buttonKaydet.TabIndex = 23;
            this.buttonKaydet.UseVisualStyleBackColor = true;
                                                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 421);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSil);
            this.Controls.Add(this.buttonYenile);
            this.Controls.Add(this.buttonKaydet);
            this.Controls.Add(this.dataGridViewPerformansDegerlendirmeleri);
            this.Name = "PerformansDegerlendirmeleri";
            this.Text = "Performans Degerlendirmeleri";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPerformansDegerlendirmeleri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSil;
        private System.Windows.Forms.Button buttonYenile;
        private System.Windows.Forms.Button buttonKaydet;
        private System.Windows.Forms.DataGridView dataGridViewPerformansDegerlendirmeleri;
    }
}