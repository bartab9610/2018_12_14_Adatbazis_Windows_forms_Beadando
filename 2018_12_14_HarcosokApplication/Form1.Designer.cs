namespace _2018_12_14_HarcosokApplication
{
    partial class Form_harcos_adatbazis
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
            this.Label_nev = new System.Windows.Forms.Label();
            this.GroupBox_felvetel = new System.Windows.Forms.GroupBox();
            this.Button_harcos_letrehozas = new System.Windows.Forms.Button();
            this.TextBox_harcos_nev = new System.Windows.Forms.TextBox();
            this.GroupBox_kepessegek = new System.Windows.Forms.GroupBox();
            this.TextBox_kepesseg_neve = new System.Windows.Forms.TextBox();
            this.Button_kepesseg_hozza_adas = new System.Windows.Forms.Button();
            this.TextBox_kepessegek_leirasa = new System.Windows.Forms.TextBox();
            this.ComboBox_harcosok_nevei = new System.Windows.Forms.ComboBox();
            this.Label_kepesseg_neve = new System.Windows.Forms.Label();
            this.Label_harcos_neve = new System.Windows.Forms.Label();
            this.GroupBox_harcosok_kepessegek_leirasok = new System.Windows.Forms.GroupBox();
            this.Button_torles = new System.Windows.Forms.Button();
            this.Button_modositas = new System.Windows.Forms.Button();
            this.TextBox_kepesseg_leirasa = new System.Windows.Forms.TextBox();
            this.Label_kepesseg_leirasa = new System.Windows.Forms.Label();
            this.ListBox_kepessegek = new System.Windows.Forms.ListBox();
            this.Label_kepessesek = new System.Windows.Forms.Label();
            this.ListBox_harcosok = new System.Windows.Forms.ListBox();
            this.Label_harcosok = new System.Windows.Forms.Label();
            this.NumericUpDown_harcos_id = new System.Windows.Forms.NumericUpDown();
            this.GroupBox_felvetel.SuspendLayout();
            this.GroupBox_kepessegek.SuspendLayout();
            this.GroupBox_harcosok_kepessegek_leirasok.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_harcos_id)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_nev
            // 
            this.Label_nev.AutoSize = true;
            this.Label_nev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Label_nev.Location = new System.Drawing.Point(23, 34);
            this.Label_nev.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_nev.Name = "Label_nev";
            this.Label_nev.Size = new System.Drawing.Size(41, 17);
            this.Label_nev.TabIndex = 0;
            this.Label_nev.Text = "Név:";
            // 
            // GroupBox_felvetel
            // 
            this.GroupBox_felvetel.Controls.Add(this.Button_harcos_letrehozas);
            this.GroupBox_felvetel.Controls.Add(this.TextBox_harcos_nev);
            this.GroupBox_felvetel.Controls.Add(this.Label_nev);
            this.GroupBox_felvetel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GroupBox_felvetel.Location = new System.Drawing.Point(16, 15);
            this.GroupBox_felvetel.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox_felvetel.Name = "GroupBox_felvetel";
            this.GroupBox_felvetel.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox_felvetel.Size = new System.Drawing.Size(720, 70);
            this.GroupBox_felvetel.TabIndex = 1;
            this.GroupBox_felvetel.TabStop = false;
            this.GroupBox_felvetel.Text = "Harcos felvétele";
            // 
            // Button_harcos_letrehozas
            // 
            this.Button_harcos_letrehozas.Location = new System.Drawing.Point(413, 25);
            this.Button_harcos_letrehozas.Margin = new System.Windows.Forms.Padding(4);
            this.Button_harcos_letrehozas.Name = "Button_harcos_letrehozas";
            this.Button_harcos_letrehozas.Size = new System.Drawing.Size(100, 28);
            this.Button_harcos_letrehozas.TabIndex = 2;
            this.Button_harcos_letrehozas.Text = "Lérehozás";
            this.Button_harcos_letrehozas.UseVisualStyleBackColor = true;
            this.Button_harcos_letrehozas.Click += new System.EventHandler(this.Button_harcos_letrehozas_Click);
            // 
            // TextBox_harcos_nev
            // 
            this.TextBox_harcos_nev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TextBox_harcos_nev.Location = new System.Drawing.Point(83, 31);
            this.TextBox_harcos_nev.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox_harcos_nev.Name = "TextBox_harcos_nev";
            this.TextBox_harcos_nev.Size = new System.Drawing.Size(255, 23);
            this.TextBox_harcos_nev.TabIndex = 1;
            // 
            // GroupBox_kepessegek
            // 
            this.GroupBox_kepessegek.Controls.Add(this.NumericUpDown_harcos_id);
            this.GroupBox_kepessegek.Controls.Add(this.TextBox_kepesseg_neve);
            this.GroupBox_kepessegek.Controls.Add(this.Button_kepesseg_hozza_adas);
            this.GroupBox_kepessegek.Controls.Add(this.TextBox_kepessegek_leirasa);
            this.GroupBox_kepessegek.Controls.Add(this.ComboBox_harcosok_nevei);
            this.GroupBox_kepessegek.Controls.Add(this.Label_kepesseg_neve);
            this.GroupBox_kepessegek.Controls.Add(this.Label_harcos_neve);
            this.GroupBox_kepessegek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GroupBox_kepessegek.ForeColor = System.Drawing.Color.Black;
            this.GroupBox_kepessegek.Location = new System.Drawing.Point(16, 93);
            this.GroupBox_kepessegek.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox_kepessegek.Name = "GroupBox_kepessegek";
            this.GroupBox_kepessegek.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox_kepessegek.Size = new System.Drawing.Size(720, 158);
            this.GroupBox_kepessegek.TabIndex = 2;
            this.GroupBox_kepessegek.TabStop = false;
            this.GroupBox_kepessegek.Text = "Képesség hozzáadás";
            // 
            // TextBox_kepesseg_neve
            // 
            this.TextBox_kepesseg_neve.Location = new System.Drawing.Point(155, 81);
            this.TextBox_kepesseg_neve.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox_kepesseg_neve.Name = "TextBox_kepesseg_neve";
            this.TextBox_kepesseg_neve.Size = new System.Drawing.Size(201, 23);
            this.TextBox_kepesseg_neve.TabIndex = 6;
            // 
            // Button_kepesseg_hozza_adas
            // 
            this.Button_kepesseg_hozza_adas.ForeColor = System.Drawing.Color.Black;
            this.Button_kepesseg_hozza_adas.Location = new System.Drawing.Point(141, 116);
            this.Button_kepesseg_hozza_adas.Margin = new System.Windows.Forms.Padding(4);
            this.Button_kepesseg_hozza_adas.Name = "Button_kepesseg_hozza_adas";
            this.Button_kepesseg_hozza_adas.Size = new System.Drawing.Size(100, 28);
            this.Button_kepesseg_hozza_adas.TabIndex = 5;
            this.Button_kepesseg_hozza_adas.Text = "Hozzádás";
            this.Button_kepesseg_hozza_adas.UseVisualStyleBackColor = true;
            this.Button_kepesseg_hozza_adas.Click += new System.EventHandler(this.Button_kepesseg_hozza_adas_Click);
            // 
            // TextBox_kepessegek_leirasa
            // 
            this.TextBox_kepessegek_leirasa.Location = new System.Drawing.Point(407, 25);
            this.TextBox_kepessegek_leirasa.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox_kepessegek_leirasa.Multiline = true;
            this.TextBox_kepessegek_leirasa.Name = "TextBox_kepessegek_leirasa";
            this.TextBox_kepessegek_leirasa.Size = new System.Drawing.Size(297, 102);
            this.TextBox_kepessegek_leirasa.TabIndex = 4;
            this.TextBox_kepessegek_leirasa.Text = "Leírás:";
            this.TextBox_kepessegek_leirasa.Click += new System.EventHandler(this.TextBox_kepessegek_leirasa_Click);
            // 
            // ComboBox_harcosok_nevei
            // 
            this.ComboBox_harcosok_nevei.FormattingEnabled = true;
            this.ComboBox_harcosok_nevei.Location = new System.Drawing.Point(135, 33);
            this.ComboBox_harcosok_nevei.Margin = new System.Windows.Forms.Padding(4);
            this.ComboBox_harcosok_nevei.Name = "ComboBox_harcosok_nevei";
            this.ComboBox_harcosok_nevei.Size = new System.Drawing.Size(201, 25);
            this.ComboBox_harcosok_nevei.TabIndex = 2;
            // 
            // Label_kepesseg_neve
            // 
            this.Label_kepesseg_neve.AutoSize = true;
            this.Label_kepesseg_neve.ForeColor = System.Drawing.Color.Black;
            this.Label_kepesseg_neve.Location = new System.Drawing.Point(23, 84);
            this.Label_kepesseg_neve.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_kepesseg_neve.Name = "Label_kepesseg_neve";
            this.Label_kepesseg_neve.Size = new System.Drawing.Size(124, 17);
            this.Label_kepesseg_neve.TabIndex = 1;
            this.Label_kepesseg_neve.Text = "Képesség neve:";
            // 
            // Label_harcos_neve
            // 
            this.Label_harcos_neve.AutoSize = true;
            this.Label_harcos_neve.ForeColor = System.Drawing.Color.Black;
            this.Label_harcos_neve.Location = new System.Drawing.Point(23, 41);
            this.Label_harcos_neve.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_harcos_neve.Name = "Label_harcos_neve";
            this.Label_harcos_neve.Size = new System.Drawing.Size(104, 17);
            this.Label_harcos_neve.TabIndex = 0;
            this.Label_harcos_neve.Text = "Harcos neve:";
            // 
            // GroupBox_harcosok_kepessegek_leirasok
            // 
            this.GroupBox_harcosok_kepessegek_leirasok.Controls.Add(this.Button_torles);
            this.GroupBox_harcosok_kepessegek_leirasok.Controls.Add(this.Button_modositas);
            this.GroupBox_harcosok_kepessegek_leirasok.Controls.Add(this.TextBox_kepesseg_leirasa);
            this.GroupBox_harcosok_kepessegek_leirasok.Controls.Add(this.Label_kepesseg_leirasa);
            this.GroupBox_harcosok_kepessegek_leirasok.Controls.Add(this.ListBox_kepessegek);
            this.GroupBox_harcosok_kepessegek_leirasok.Controls.Add(this.Label_kepessesek);
            this.GroupBox_harcosok_kepessegek_leirasok.Controls.Add(this.ListBox_harcosok);
            this.GroupBox_harcosok_kepessegek_leirasok.Controls.Add(this.Label_harcosok);
            this.GroupBox_harcosok_kepessegek_leirasok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GroupBox_harcosok_kepessegek_leirasok.Location = new System.Drawing.Point(16, 259);
            this.GroupBox_harcosok_kepessegek_leirasok.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox_harcosok_kepessegek_leirasok.Name = "GroupBox_harcosok_kepessegek_leirasok";
            this.GroupBox_harcosok_kepessegek_leirasok.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox_harcosok_kepessegek_leirasok.Size = new System.Drawing.Size(720, 321);
            this.GroupBox_harcosok_kepessegek_leirasok.TabIndex = 3;
            this.GroupBox_harcosok_kepessegek_leirasok.TabStop = false;
            this.GroupBox_harcosok_kepessegek_leirasok.Text = "Harcos - Képesség leírása";
            // 
            // Button_torles
            // 
            this.Button_torles.Location = new System.Drawing.Point(517, 266);
            this.Button_torles.Margin = new System.Windows.Forms.Padding(4);
            this.Button_torles.Name = "Button_torles";
            this.Button_torles.Size = new System.Drawing.Size(121, 28);
            this.Button_torles.TabIndex = 7;
            this.Button_torles.Text = "Törlés";
            this.Button_torles.UseVisualStyleBackColor = true;
            // 
            // Button_modositas
            // 
            this.Button_modositas.Location = new System.Drawing.Point(517, 225);
            this.Button_modositas.Margin = new System.Windows.Forms.Padding(4);
            this.Button_modositas.Name = "Button_modositas";
            this.Button_modositas.Size = new System.Drawing.Size(121, 28);
            this.Button_modositas.TabIndex = 6;
            this.Button_modositas.Text = "Módosítás";
            this.Button_modositas.UseVisualStyleBackColor = true;
            // 
            // TextBox_kepesseg_leirasa
            // 
            this.TextBox_kepesseg_leirasa.Location = new System.Drawing.Point(463, 60);
            this.TextBox_kepesseg_leirasa.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox_kepesseg_leirasa.Multiline = true;
            this.TextBox_kepesseg_leirasa.Name = "TextBox_kepesseg_leirasa";
            this.TextBox_kepesseg_leirasa.Size = new System.Drawing.Size(241, 139);
            this.TextBox_kepesseg_leirasa.TabIndex = 5;
            // 
            // Label_kepesseg_leirasa
            // 
            this.Label_kepesseg_leirasa.AutoSize = true;
            this.Label_kepesseg_leirasa.Location = new System.Drawing.Point(499, 32);
            this.Label_kepesseg_leirasa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_kepesseg_leirasa.Name = "Label_kepesseg_leirasa";
            this.Label_kepesseg_leirasa.Size = new System.Drawing.Size(133, 17);
            this.Label_kepesseg_leirasa.TabIndex = 4;
            this.Label_kepesseg_leirasa.Text = "Képesség leírása";
            // 
            // ListBox_kepessegek
            // 
            this.ListBox_kepessegek.FormattingEnabled = true;
            this.ListBox_kepessegek.ItemHeight = 17;
            this.ListBox_kepessegek.Location = new System.Drawing.Point(240, 60);
            this.ListBox_kepessegek.Margin = new System.Windows.Forms.Padding(4);
            this.ListBox_kepessegek.Name = "ListBox_kepessegek";
            this.ListBox_kepessegek.Size = new System.Drawing.Size(207, 242);
            this.ListBox_kepessegek.TabIndex = 3;
            // 
            // Label_kepessesek
            // 
            this.Label_kepessesek.AutoSize = true;
            this.Label_kepessesek.Location = new System.Drawing.Point(276, 32);
            this.Label_kepessesek.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_kepessesek.Name = "Label_kepessesek";
            this.Label_kepessesek.Size = new System.Drawing.Size(96, 17);
            this.Label_kepessesek.TabIndex = 2;
            this.Label_kepessesek.Text = "Képességek";
            // 
            // ListBox_harcosok
            // 
            this.ListBox_harcosok.FormattingEnabled = true;
            this.ListBox_harcosok.ItemHeight = 17;
            this.ListBox_harcosok.Location = new System.Drawing.Point(18, 60);
            this.ListBox_harcosok.Margin = new System.Windows.Forms.Padding(4);
            this.ListBox_harcosok.Name = "ListBox_harcosok";
            this.ListBox_harcosok.Size = new System.Drawing.Size(207, 242);
            this.ListBox_harcosok.TabIndex = 1;
            // 
            // Label_harcosok
            // 
            this.Label_harcosok.AutoSize = true;
            this.Label_harcosok.Location = new System.Drawing.Point(75, 32);
            this.Label_harcosok.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_harcosok.Name = "Label_harcosok";
            this.Label_harcosok.Size = new System.Drawing.Size(76, 17);
            this.Label_harcosok.TabIndex = 0;
            this.Label_harcosok.Text = "Harcosok";
            // 
            // NumericUpDown_harcos_id
            // 
            this.NumericUpDown_harcos_id.Location = new System.Drawing.Point(347, 35);
            this.NumericUpDown_harcos_id.Name = "NumericUpDown_harcos_id";
            this.NumericUpDown_harcos_id.Size = new System.Drawing.Size(50, 23);
            this.NumericUpDown_harcos_id.TabIndex = 7;
            // 
            // Form_harcos_adatbazis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 595);
            this.Controls.Add(this.GroupBox_harcosok_kepessegek_leirasok);
            this.Controls.Add(this.GroupBox_kepessegek);
            this.Controls.Add(this.GroupBox_felvetel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(770, 642);
            this.MinimumSize = new System.Drawing.Size(770, 642);
            this.Name = "Form_harcos_adatbazis";
            this.Text = "Harcosok adatbázis";
            this.GroupBox_felvetel.ResumeLayout(false);
            this.GroupBox_felvetel.PerformLayout();
            this.GroupBox_kepessegek.ResumeLayout(false);
            this.GroupBox_kepessegek.PerformLayout();
            this.GroupBox_harcosok_kepessegek_leirasok.ResumeLayout(false);
            this.GroupBox_harcosok_kepessegek_leirasok.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_harcos_id)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Label_nev;
        private System.Windows.Forms.GroupBox GroupBox_felvetel;
        private System.Windows.Forms.Button Button_harcos_letrehozas;
        private System.Windows.Forms.TextBox TextBox_harcos_nev;
        private System.Windows.Forms.GroupBox GroupBox_kepessegek;
        private System.Windows.Forms.TextBox TextBox_kepessegek_leirasa;
        private System.Windows.Forms.ComboBox ComboBox_harcosok_nevei;
        private System.Windows.Forms.Label Label_kepesseg_neve;
        private System.Windows.Forms.Label Label_harcos_neve;
        private System.Windows.Forms.TextBox TextBox_kepesseg_neve;
        private System.Windows.Forms.Button Button_kepesseg_hozza_adas;
        private System.Windows.Forms.GroupBox GroupBox_harcosok_kepessegek_leirasok;
        private System.Windows.Forms.Label Label_harcosok;
        private System.Windows.Forms.ListBox ListBox_harcosok;
        private System.Windows.Forms.Button Button_torles;
        private System.Windows.Forms.Button Button_modositas;
        private System.Windows.Forms.TextBox TextBox_kepesseg_leirasa;
        private System.Windows.Forms.Label Label_kepesseg_leirasa;
        private System.Windows.Forms.ListBox ListBox_kepessegek;
        private System.Windows.Forms.Label Label_kepessesek;
        private System.Windows.Forms.NumericUpDown NumericUpDown_harcos_id;
    }
}

