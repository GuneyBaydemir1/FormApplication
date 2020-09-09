namespace Benzinİstasyonu
{
    partial class Form2
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
            this.txtysifre = new System.Windows.Forms.TextBox();
            this.txtkadi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsifredegistir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtysifre
            // 
            this.txtysifre.Location = new System.Drawing.Point(199, 110);
            this.txtysifre.Name = "txtysifre";
            this.txtysifre.Size = new System.Drawing.Size(201, 20);
            this.txtysifre.TabIndex = 8;
            this.txtysifre.UseSystemPasswordChar = true;
            // 
            // txtkadi
            // 
            this.txtkadi.Location = new System.Drawing.Point(199, 45);
            this.txtkadi.Name = "txtkadi";
            this.txtkadi.Size = new System.Drawing.Size(201, 20);
            this.txtkadi.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(35, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "YENİ ŞİFRENİZ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(35, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "KULLANICI ADI";
            // 
            // txtsifredegistir
            // 
            this.txtsifredegistir.BackColor = System.Drawing.Color.Firebrick;
            this.txtsifredegistir.FlatAppearance.BorderSize = 0;
            this.txtsifredegistir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.txtsifredegistir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Firebrick;
            this.txtsifredegistir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtsifredegistir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtsifredegistir.ForeColor = System.Drawing.Color.White;
            this.txtsifredegistir.Location = new System.Drawing.Point(39, 172);
            this.txtsifredegistir.Name = "txtsifredegistir";
            this.txtsifredegistir.Size = new System.Drawing.Size(165, 48);
            this.txtsifredegistir.TabIndex = 9;
            this.txtsifredegistir.Text = "ŞİFREYİ DEĞİŞTİR";
            this.txtsifredegistir.UseVisualStyleBackColor = false;
            this.txtsifredegistir.Click += new System.EventHandler(this.txtsifredegistir_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(520, 395);
            this.Controls.Add(this.txtsifredegistir);
            this.Controls.Add(this.txtysifre);
            this.Controls.Add(this.txtkadi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "ŞİFRE BELİRLEME";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtysifre;
        private System.Windows.Forms.TextBox txtkadi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button txtsifredegistir;
    }
}