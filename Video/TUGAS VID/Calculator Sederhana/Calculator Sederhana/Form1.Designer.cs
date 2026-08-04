namespace Calculator_Sederhana
{
    partial class Form1
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
            this.btnTambah = new System.Windows.Forms.Button();
            this.Angka1 = new System.Windows.Forms.TextBox();
            this.lblAngka1 = new System.Windows.Forms.Label();
            this.lblHasil = new System.Windows.Forms.Label();
            this.lblAngka2 = new System.Windows.Forms.Label();
            this.Angka2 = new System.Windows.Forms.TextBox();
            this.lblAksi = new System.Windows.Forms.Label();
            this.lblJudul = new System.Windows.Forms.Label();
            this.btnKurang = new System.Windows.Forms.Button();
            this.btnKali = new System.Windows.Forms.Button();
            this.btnBagi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // btnTambah
            //
            this.btnTambah.Location = new System.Drawing.Point(15, 248);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(395, 35);
            this.btnTambah.TabIndex = 0;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            //
            // Angka1
            //
            this.Angka1.Location = new System.Drawing.Point(12, 92);
            this.Angka1.Name = "Angka1";
            this.Angka1.Size = new System.Drawing.Size(398, 20);
            this.Angka1.TabIndex = 1;
            //
            // lblAngka1
            //
            this.lblAngka1.AutoSize = true;
            this.lblAngka1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAngka1.Location = new System.Drawing.Point(12, 73);
            this.lblAngka1.Name = "lblAngka1";
            this.lblAngka1.Size = new System.Drawing.Size(53, 16);
            this.lblAngka1.TabIndex = 2;
            this.lblAngka1.Text = "Angka1";
            //
            // lblHasil
            //
            this.lblHasil.AutoSize = true;
            this.lblHasil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasil.Location = new System.Drawing.Point(12, 174);
            this.lblHasil.Name = "lblHasil";
            this.lblHasil.Size = new System.Drawing.Size(51, 16);
            this.lblHasil.TabIndex = 4;
            this.lblHasil.Text = "Hasil :";
            //
            // lblAngka2
            //
            this.lblAngka2.AutoSize = true;
            this.lblAngka2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAngka2.Location = new System.Drawing.Point(12, 123);
            this.lblAngka2.Name = "lblAngka2";
            this.lblAngka2.Size = new System.Drawing.Size(53, 16);
            this.lblAngka2.TabIndex = 6;
            this.lblAngka2.Text = "Angka2";
            //
            // Angka2
            //
            this.Angka2.Location = new System.Drawing.Point(12, 142);
            this.Angka2.Name = "Angka2";
            this.Angka2.Size = new System.Drawing.Size(398, 20);
            this.Angka2.TabIndex = 5;
            //
            // lblAksi
            //
            this.lblAksi.AutoSize = true;
            this.lblAksi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAksi.Location = new System.Drawing.Point(192, 223);
            this.lblAksi.Name = "lblAksi";
            this.lblAksi.Size = new System.Drawing.Size(37, 16);
            this.lblAksi.TabIndex = 7;
            this.lblAksi.Text = "Aksi";
            //
            // lblJudul
            //
            this.lblJudul.AutoSize = true;
            this.lblJudul.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudul.Location = new System.Drawing.Point(142, 30);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(157, 16);
            this.lblJudul.TabIndex = 8;
            this.lblJudul.Text = "Calculator Sederhana";
            //
            // btnKurang
            //
            this.btnKurang.Location = new System.Drawing.Point(15, 290);
            this.btnKurang.Name = "btnKurang";
            this.btnKurang.Size = new System.Drawing.Size(395, 35);
            this.btnKurang.TabIndex = 9;
            this.btnKurang.Text = "Kurang";
            this.btnKurang.UseVisualStyleBackColor = true;
            this.btnKurang.Click += new System.EventHandler(this.btnKurang_Click);
            //
            // btnKali
            //
            this.btnKali.Location = new System.Drawing.Point(15, 332);
            this.btnKali.Name = "btnKali";
            this.btnKali.Size = new System.Drawing.Size(395, 35);
            this.btnKali.TabIndex = 10;
            this.btnKali.Text = "Kali";
            this.btnKali.UseVisualStyleBackColor = true;
            this.btnKali.Click += new System.EventHandler(this.btnKali_Click);
            //
            // btnBagi
            //
            this.btnBagi.Location = new System.Drawing.Point(15, 371);
            this.btnBagi.Name = "btnBagi";
            this.btnBagi.Size = new System.Drawing.Size(395, 35);
            this.btnBagi.TabIndex = 11;
            this.btnBagi.Text = "Bagi";
            this.btnBagi.UseVisualStyleBackColor = true;
            this.btnBagi.Click += new System.EventHandler(this.btnBagi_Click);
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 450);
            this.Controls.Add(this.btnBagi);
            this.Controls.Add(this.btnKali);
            this.Controls.Add(this.btnKurang);
            this.Controls.Add(this.lblJudul);
            this.Controls.Add(this.lblAksi);
            this.Controls.Add(this.lblAngka2);
            this.Controls.Add(this.Angka2);
            this.Controls.Add(this.lblHasil);
            this.Controls.Add(this.lblAngka1);
            this.Controls.Add(this.Angka1);
            this.Controls.Add(this.btnTambah);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.TextBox Angka1;
        private System.Windows.Forms.Label lblAngka1;
        private System.Windows.Forms.Label lblHasil;
        private System.Windows.Forms.Label lblAngka2;
        private System.Windows.Forms.TextBox Angka2;
        private System.Windows.Forms.Label lblAksi;
        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Button btnKurang;
        private System.Windows.Forms.Button btnKali;
        private System.Windows.Forms.Button btnBagi;
    }
}
