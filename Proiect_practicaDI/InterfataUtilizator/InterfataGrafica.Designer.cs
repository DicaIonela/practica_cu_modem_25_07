namespace InterfataUtilizator
{
    partial class InterfataGrafica
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
            this.btnCitire = new System.Windows.Forms.Button();
            this.btnAfisare = new System.Windows.Forms.Button();
            this.btnCautare = new System.Windows.Forms.Button();
            this.btnSterge = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMAC = new System.Windows.Forms.Label();
            this.txtCautare = new System.Windows.Forms.TextBox();
            this.dGUtilizatori = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnModifica = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGUtilizatori)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(303, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "PAGINA PRINCIPALA";
            // 
            // btnCitire
            // 
            this.btnCitire.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCitire.Location = new System.Drawing.Point(552, 213);
            this.btnCitire.Name = "btnCitire";
            this.btnCitire.Size = new System.Drawing.Size(250, 50);
            this.btnCitire.TabIndex = 1;
            this.btnCitire.Text = "Adauga utilizator";
            this.btnCitire.UseVisualStyleBackColor = true;
            this.btnCitire.Click += new System.EventHandler(this.btnCitire_Click);
            this.btnCitire.MouseEnter += new System.EventHandler(this.btnCitire_MouseEnter);
            this.btnCitire.MouseLeave += new System.EventHandler(this.btnCitire_MouseLeave);
            // 
            // btnAfisare
            // 
            this.btnAfisare.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAfisare.Location = new System.Drawing.Point(552, 348);
            this.btnAfisare.Name = "btnAfisare";
            this.btnAfisare.Size = new System.Drawing.Size(250, 50);
            this.btnAfisare.TabIndex = 3;
            this.btnAfisare.Text = "Afisare utilizatori salvati";
            this.btnAfisare.UseVisualStyleBackColor = true;
            this.btnAfisare.Click += new System.EventHandler(this.btnAfisare_Click);
            this.btnAfisare.MouseEnter += new System.EventHandler(this.btnAfisare_MouseEnter);
            this.btnAfisare.MouseLeave += new System.EventHandler(this.btnAfisare_MouseLeave);
            // 
            // btnCautare
            // 
            this.btnCautare.Font = new System.Drawing.Font("Nirmala UI", 8F);
            this.btnCautare.Location = new System.Drawing.Point(449, 99);
            this.btnCautare.Name = "btnCautare";
            this.btnCautare.Size = new System.Drawing.Size(72, 20);
            this.btnCautare.TabIndex = 4;
            this.btnCautare.Text = "Cautare";
            this.btnCautare.UseVisualStyleBackColor = true;
            this.btnCautare.Click += new System.EventHandler(this.btnCautare_Click);
            // 
            // btnSterge
            // 
            this.btnSterge.Font = new System.Drawing.Font("Nirmala UI", 10F);
            this.btnSterge.Location = new System.Drawing.Point(388, 496);
            this.btnSterge.Name = "btnSterge";
            this.btnSterge.Size = new System.Drawing.Size(141, 30);
            this.btnSterge.TabIndex = 6;
            this.btnSterge.Text = "Sterge utilizator";
            this.btnSterge.UseVisualStyleBackColor = true;
            this.btnSterge.Click += new System.EventHandler(this.btnSterge_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(547, 557);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Adresa MAC a acestui PC:";
            // 
            // lblMAC
            // 
            this.lblMAC.AutoSize = true;
            this.lblMAC.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMAC.Location = new System.Drawing.Point(705, 557);
            this.lblMAC.Name = "lblMAC";
            this.lblMAC.Size = new System.Drawing.Size(12, 17);
            this.lblMAC.TabIndex = 9;
            this.lblMAC.Text = " ";
            // 
            // txtCautare
            // 
            this.txtCautare.Location = new System.Drawing.Point(12, 99);
            this.txtCautare.Name = "txtCautare";
            this.txtCautare.Size = new System.Drawing.Size(431, 20);
            this.txtCautare.TabIndex = 10;
            // 
            // dGUtilizatori
            // 
            this.dGUtilizatori.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGUtilizatori.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGUtilizatori.Location = new System.Drawing.Point(12, 125);
            this.dGUtilizatori.Name = "dGUtilizatori";
            this.dGUtilizatori.RowHeadersWidth = 30;
            this.dGUtilizatori.Size = new System.Drawing.Size(516, 354);
            this.dGUtilizatori.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.BackgroundImage = global::InterfataUtilizator.Properties.Resources.B;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(838, 574);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnModifica
            // 
            this.btnModifica.Font = new System.Drawing.Font("Nirmala UI", 10F);
            this.btnModifica.Location = new System.Drawing.Point(388, 528);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(141, 30);
            this.btnModifica.TabIndex = 11;
            this.btnModifica.Text = "Modifica utilizator";
            this.btnModifica.UseVisualStyleBackColor = true;
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(9, 480);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(472, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "*Pentru stergerea sau modificarea unui utilizator se va selecta intreg randul (cl" +
    "ick pe prima coloana)";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Location = new System.Drawing.Point(-3, 0);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(35, 13);
            this.lblDateTime.TabIndex = 13;
            this.lblDateTime.Text = "label4";
            // 
            // InterfataGrafica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 574);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnModifica);
            this.Controls.Add(this.dGUtilizatori);
            this.Controls.Add(this.txtCautare);
            this.Controls.Add(this.lblMAC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSterge);
            this.Controls.Add(this.btnCautare);
            this.Controls.Add(this.btnAfisare);
            this.Controls.Add(this.btnCitire);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "InterfataGrafica";
            this.Text = "Interfata Grafica";
            ((System.ComponentModel.ISupportInitialize)(this.dGUtilizatori)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCitire;
        private System.Windows.Forms.Button btnAfisare;
        private System.Windows.Forms.Button btnCautare;
        private System.Windows.Forms.Button btnSterge;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMAC;
        private System.Windows.Forms.TextBox txtCautare;
        private System.Windows.Forms.DataGridView dGUtilizatori;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDateTime;
    }
}

