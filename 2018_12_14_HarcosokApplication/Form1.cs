﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _2018_12_14_HarcosokApplication
{
    public partial class Form_harcos_adatbazis : System.Windows.Forms.Form
    {
        const string Adatbazis_letrehozasa_SQL = @"CREATE DATABASE IF NOT EXISTS cs_harcosok CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
                                                USE cs_harcosok;
                                                CREATE TABLE IF NOT EXISTS harcosok
                                                        (
                                                            harcos_id INTEGER AUTO_INCREMENT PRIMARY KEY,
                                                            harcos_nev VARCHAR(64) NOT NULL UNIQUE,
                                                            harcos_datum_letrehozas DATE NOT NULL
                                                        );
                                                 CREATE TABLE IF NOT EXISTS kepessegek
                                                        (
                                                            kepesseg_id INTEGER AUTO_INCREMENT PRIMARY KEY,
                                                            kepesseg_nev VARCHAR(64) NOT NULL,
                                                            kepesseg_leiras TEXT NOT NULL,
                                                            harcos_id INTEGER NOT NULL,
                                                            FOREIGN KEY(harcos_id) REFERENCES harcosok(harcos_id)
                                                        )"; // JAVA-ban 1 SQL utasításban csak egy @ lehet vagy más!!!!!!!!!!!!!!!!!
        MySqlConnection kapcsolodas;

        public Form_harcos_adatbazis()
        {
            InitializeComponent();
            try
            {
                kapcsolodas = new MySqlConnection("Server=localhost;Database=;Uid=root;Pwd=;"); // SQL-es adatbázis létrehozásnál a csatlakozásnál üres a Database!!!!!
                kapcsolodas.Open();
                var letrehozas = kapcsolodas.CreateCommand();
                letrehozas.CommandText = Adatbazis_letrehozasa_SQL;
                letrehozas.ExecuteNonQuery();

                Harcosok_listazas_combobox();
                Harcosok_listazas_listbox();
            }
            catch (MySqlException MySQLEx)
            {
                MessageBox.Show("Adatbázis hiba: " + MySQLEx.Message);
                this.Close();
            }
        }
        private void Button_harcos_letrehozas_Click(object sender, EventArgs e)
        {
            string Harcos_nev = TextBox_harcos_nev.Text;
            DateTime Harcos_Regisztralt_datum = DateTime.Now;
            // ------------------------------------- HIBAKEZELÉS - Meglévő harcos ------------------------------
            if (TextBox_harcos_nev.Text == "") // Üres textbox hibakezelés
            {
                MessageBox.Show("Hiba!\nKötelező a harcos név megadása!");
                return; // return nélkül felveszi az üres Textbox mezőt
            }
            var Meglevo_harcos_nev_ellenorzes = kapcsolodas.CreateCommand();
            Meglevo_harcos_nev_ellenorzes.CommandText = "SELECT COUNT(*) FROM harcosok WHERE harcos_nev = @meglevo_harcos_nev";
            Meglevo_harcos_nev_ellenorzes.Parameters.AddWithValue("@meglevo_harcos_nev", Harcos_nev);
            var darab = (long)Meglevo_harcos_nev_ellenorzes.ExecuteScalar();
            if (darab != 0)
            {
                MessageBox.Show("Ez a harcos már fel van véve az adatbázisban!");
                return;
            }
            // -------------------------------------------------------------------------------------------------
            // ---------------------------------------- HARCOS FELVÉTEL ----------------------------------------
            var Harcos_felvetel = kapcsolodas.CreateCommand();
            Harcos_felvetel.CommandText = "INSERT INTO harcosok (harcos_nev, harcos_datum_letrehozas) VALUES (@nev, @regdatum)";
            Harcos_felvetel.Parameters.AddWithValue("@nev", Harcos_nev);
            Harcos_felvetel.Parameters.AddWithValue("@regdatum", Harcos_Regisztralt_datum);
            int valami = Harcos_felvetel.ExecuteNonQuery();
            // -------------------------------------------------------------------------------------------------

            Harcosok_listazas_combobox();
            Harcosok_listazas_listbox();
        }
        private void Harcosok_listazas_combobox()
        {
            // ------------------------------------------- LISTÁZÁS --------------------------------------------
            var Kiirando_harcosok = kapcsolodas.CreateCommand();
            Kiirando_harcosok.CommandText = "SELECT harcos_nev FROM harcosok";
            using (var olvaso = Kiirando_harcosok.ExecuteReader())
            {
                ComboBox_harcosok_nevei.Items.Clear();
                while (olvaso.Read())
                {
                    var nev = olvaso.GetString("harcos_nev");
                    ComboBox_harcosok_nevei.Items.Add(String.Format("{0}", nev));
                    ComboBox_harcosok_nevei.Text = String.Format("{0}", nev); // Létrehozás utáni hozzáadás + látszódnak a hozzáadott harcosok
                }
            }
            // -------------------------------------------------------------------------------------------------
        }
        private void Button_kepesseg_hozza_adas_Click(object sender, EventArgs e)
        {
            if (TextBox_kepessegek_leirasa.Text != "" && TextBox_kepessegek_leirasa.Text != "Leírás:")
            {
                string Kepesseg_nev = TextBox_kepesseg_neve.Text;
                string Kepesseg_leiras = TextBox_kepessegek_leirasa.Text;
                int Kivalasztott_harcos_id = (int)NumericUpDown_harcos_id.Value;
                // int Kivalasztott_harcos_id = ComboBox_harcosok_nevei.SelectedIndex + 1; // SelectedIndex + 1 -> alapból 0-től indul

                var Kepesseg_felvetel = kapcsolodas.CreateCommand();
                Kepesseg_felvetel.CommandText = "INSERT INTO kepessegek (kepesseg_nev, kepesseg_leiras, harcos_id) VALUES (@kepesseg_nev, @kepesseg_leiras, @harcos_id)";
                Kepesseg_felvetel.Parameters.AddWithValue("@kepesseg_nev", Kepesseg_nev);
                Kepesseg_felvetel.Parameters.AddWithValue("@kepesseg_leiras", Kepesseg_leiras);
                Kepesseg_felvetel.Parameters.AddWithValue("@harcos_id", Kivalasztott_harcos_id);
                int valami = Kepesseg_felvetel.ExecuteNonQuery();

                TextBox_kepessegek_leirasa.Text = "";
            }
            else
            {
                MessageBox.Show("Hiba!\nKötelező megadni a leírást!");
                return;
            }
        }
        public void Harcosok_listazas_listbox()
        {
            var Kiirando_harcosok = kapcsolodas.CreateCommand();
            Kiirando_harcosok.CommandText = "SELECT harcos_id, harcos_nev, harcos_datum_letrehozas FROM harcosok";
            using (var olvasas_listbox_feltoltes = Kiirando_harcosok.ExecuteReader())
            {
                ListBox_harcosok.Items.Clear();
                while (olvasas_listbox_feltoltes.Read())
                {
                    int harcos_id = olvasas_listbox_feltoltes.GetInt16("harcos_id");
                    var harcos_nev = olvasas_listbox_feltoltes.GetString("harcos_nev");
                    var harcos_reg_datum = olvasas_listbox_feltoltes.GetDateTime("harcos_datum_letrehozas");
                    ListBox_harcosok.Items.Add(String.Format("{0} - {1} - {2}.{3}.{4}", harcos_id, harcos_nev, harcos_reg_datum.Date.Year, harcos_reg_datum.Date.Month, harcos_reg_datum.Date.Day));
                }
            }
        } // C1-es feladat van!
        private void TextBox_kepessegek_leirasa_Click(object sender, EventArgs e)
        {
            TextBox_kepessegek_leirasa.Text = "";
        }
    }
}