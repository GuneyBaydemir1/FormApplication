namespace Benzinİstasyonu
{
    partial class Form3
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
            this.personel = new System.Windows.Forms.Button();
            this.musteri = new System.Windows.Forms.Button();
            this.akaryatiksatis = new System.Windows.Forms.Button();
            this.akaryakit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // personel
            // 
            this.personel.BackgroundImage = global::Benzinİstasyonu.Properties.Resources.logo4;
            this.personel.FlatAppearance.BorderSize = 0;
            this.personel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.personel.Location = new System.Drawing.Point(58, 464);
            this.personel.Name = "personel";
            this.personel.Size = new System.Drawing.Size(235, 61);
            this.personel.TabIndex = 3;
            this.personel.UseVisualStyleBackColor = true;
            this.personel.Click += new System.EventHandler(this.personel_Click);
            // 
            // musteri
            // 
            this.musteri.BackgroundImage = global::Benzinİstasyonu.Properties.Resources.logo3;
            this.musteri.FlatAppearance.BorderSize = 0;
            this.musteri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.musteri.Location = new System.Drawing.Point(58, 319);
            this.musteri.Name = "musteri";
            this.musteri.Size = new System.Drawing.Size(235, 61);
            this.musteri.TabIndex = 2;
            this.musteri.UseVisualStyleBackColor = true;
            this.musteri.Click += new System.EventHandler(this.musteri_Click);
            // 
            // akaryatiksatis
            // 
            this.akaryatiksatis.BackgroundImage = global::Benzinİstasyonu.Properties.Resources.logo2;
            this.akaryatiksatis.FlatAppearance.BorderSize = 0;
            this.akaryatiksatis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.akaryatiksatis.Location = new System.Drawing.Point(58, 171);
            this.akaryatiksatis.Name = "akaryatiksatis";
            this.akaryatiksatis.Size = new System.Drawing.Size(235, 66);
            this.akaryatiksatis.TabIndex = 1;
            this.akaryatiksatis.UseVisualStyleBackColor = true;
            this.akaryatiksatis.Click += new System.EventHandler(this.akaryatiksatis_Click);
            // 
            // akaryakit
            // 
            this.akaryakit.BackgroundImage = global::Benzinİstasyonu.Properties.Resources.logo1;
            this.akaryakit.FlatAppearance.BorderSize = 0;
            this.akaryakit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.akaryakit.Location = new System.Drawing.Point(58, 44);
            this.akaryakit.Name = "akaryakit";
            this.akaryakit.Size = new System.Drawing.Size(235, 61);
            this.akaryakit.TabIndex = 0;
            this.akaryakit.UseVisualStyleBackColor = true;
            this.akaryakit.Click += new System.EventHandler(this.akaryakit_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(450, 578);
            this.Controls.Add(this.personel);
            this.Controls.Add(this.musteri);
            this.Controls.Add(this.akaryatiksatis);
            this.Controls.Add(this.akaryakit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.Text = "MENÜ";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button akaryakit;
        private System.Windows.Forms.Button akaryatiksatis;
        private System.Windows.Forms.Button musteri;
        private System.Windows.Forms.Button personel;

    }
}