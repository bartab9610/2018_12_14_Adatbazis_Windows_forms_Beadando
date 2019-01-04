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

                // ----------------------------------- MEGLÉVŐ KÉPESSÉG HIBAKEZELÉS -----------------------------------
                var Letezo_kepesseg = kapcsolodas.CreateCommand();
                Letezo_kepesseg.CommandText = "SELECT COUNT(*) FROM kepessegek WHERE kepesseg_nev = @meglevo_kepesseg_nev";
                Letezo_kepesseg.Parameters.AddWithValue("@meglevo_kepesseg_nev", Kepesseg_nev);
                var darab = (long)Letezo_kepesseg.ExecuteScalar();
                if (darab != 0)
                {
                    MessageBox.Show("Ez a képesség már létezik! Kétszer nem adható hozzá");
                    return;
                }
                // ------------------------------------------------------------------------------------------------------
                var Kepesseg_felvetel = kapcsolodas.CreateCommand();
                Kepesseg_felvetel.CommandText = "INSERT INTO kepessegek (kepesseg_nev, kepesseg_leiras, harcos_id) VALUES (@kepesseg_nev, @kepesseg_leiras, @harcos_id)";
                Kepesseg_felvetel.Parameters.AddWithValue("@kepesseg_nev", Kepesseg_nev);
                Kepesseg_felvetel.Parameters.AddWithValue("@kepesseg_leiras", Kepesseg_leiras);
                Kepesseg_felvetel.Parameters.AddWithValue("@harcos_id", Kivalasztott_harcos_id);
                int valami = Kepesseg_felvetel.ExecuteNonQuery();

                TextBox_kepessegek_leirasa.Text = "";
                TextBox_kepesseg_neve.Text = "";

                Kepesseg_kiiras_harcos_valasztassal();
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
                    int harcos_id = olvasas_listbox_feltoltes.GetInt32("harcos_id");
                    var harcos_nev = olvasas_listbox_feltoltes.GetString("harcos_nev");
                    var harcos_reg_datum = olvasas_listbox_feltoltes.GetDateTime("harcos_datum_letrehozas");
                    ListBox_harcosok.Items.Add(String.Format("{0} - {1} {2}.{3}.{4}", harcos_id, harcos_nev, harcos_reg_datum.Date.Year, harcos_reg_datum.Date.Month, harcos_reg_datum.Date.Day));
                }
            }
        }
        public void Kepesseg_kiiras_harcos_valasztassal()
        {
            string[] Harcos_nev = ListBox_harcosok.GetItemText(ListBox_harcosok.SelectedItem).Split(' ');

            var Kiirando_kepesseg = kapcsolodas.CreateCommand();
            Kiirando_kepesseg.CommandText = "SELECT harcosok.harcos_id, harcosok.harcos_nev, kepesseg_nev FROM kepessegek JOIN harcosok ON harcosok.harcos_id = kepessegek.harcos_id WHERE harcos_nev = '" + Harcos_nev[2] + "'"; // 2 szóköz így a 3. elemet teszi bele
            using (var kepesseg_olvasas = Kiirando_kepesseg.ExecuteReader())
            {
                ListBox_kepessegek.Items.Clear(); // másik harcos választásnál kitörli az előző szöveget és be rakja a kiválasztottét
                TextBox_kepesseg_leirasa.Clear();
                TextBox_kepesseg_leirasa.Enabled = false;
                while (kepesseg_olvasas.Read())
                {
                    var kepesseg_nev = kepesseg_olvasas.GetString("kepesseg_nev");
                    ListBox_kepessegek.Items.Add(String.Format("{0}", kepesseg_nev));
                }
            }
            // COMBOBOX-OS NÉV BEHELYETTESÍTÉS
            string[] Harcos_nev_combobox = ListBox_harcosok.GetItemText(ListBox_harcosok.SelectedItem).Split(' ');

            var Combobox_feltoltes_nevvel = kapcsolodas.CreateCommand();
            Combobox_feltoltes_nevvel.CommandText = "SELECT harcos_id, harcos_nev FROM harcosok WHERE harcos_nev = '" + Harcos_nev[2] + "'"; // 2 szóköz így a 3. elemet teszi bele
            using (var combobox_feltoltes = Combobox_feltoltes_nevvel.ExecuteReader())
            {
                while (combobox_feltoltes.Read())
                {
                    int harcos_id = combobox_feltoltes.GetInt32("harcos_id");
                    string harcos_nev = combobox_feltoltes.GetString("harcos_nev");
                    NumericUpDown_harcos_id.Value = harcos_id; // képesség kiválasztáskor a NumericUpDown száma megegyezik a FOREIGN harcos_id-val
                    ComboBox_harcosok_nevei.Text = harcos_nev; // képesség kiválasztásaokor a harcos nevét betölti a ComboBox-ba
                }
            }
        }
        public void Kepesseg_leiras()
        {
            string Kepesseg_leiras = ListBox_kepessegek.GetItemText(ListBox_kepessegek.SelectedItem);

            var Kiirando_kepesseg_leiras = kapcsolodas.CreateCommand();
            Kiirando_kepesseg_leiras.CommandText = "SELECT harcos_nev, harcosok.harcos_id, kepesseg_leiras FROM kepessegek JOIN harcosok ON harcosok.harcos_id = kepessegek.harcos_id WHERE kepesseg_nev = @kepessegnev";
            Kiirando_kepesseg_leiras.Parameters.AddWithValue("@kepessegnev", Kepesseg_leiras);
            using (var kepesseg_kiolvasas = Kiirando_kepesseg_leiras.ExecuteReader())
            {
                while (kepesseg_kiolvasas.Read())
                {
                    TextBox_kepesseg_leirasa.Enabled = false;
                    int harcos_id = kepesseg_kiolvasas.GetInt32("harcos_id");
                    var harcos_nev = kepesseg_kiolvasas.GetString("harcos_nev");
                    var kepesseg_leiras = kepesseg_kiolvasas.GetString("kepesseg_leiras");
                    // NumericUpDown_harcos_id.Value = harcos_id; // képesség kiválasztáskor a NumericUpDown száma megegyezik a FOREIGN harcos_id-val
                    // ComboBox_harcosok_nevei.Text = harcos_nev; // képesség kiválasztásaokor a harcos nevét betölti a ComboBox-ba
                    TextBox_kepesseg_leirasa.Text = kepesseg_leiras;
                }
            }
        }
        private void Button_modositas_Click(object sender, EventArgs e)
        {
            string Kepesseg_nev = ListBox_kepessegek.GetItemText(ListBox_kepessegek.SelectedItem);
            string Uj_Leiras = TextBox_kepesseg_leirasa.Text;

            if (Kepesseg_nev.Length > 0)
            {
                TextBox_kepesseg_leirasa.Enabled = true;

                var Kepesseg_leiras_modositas = kapcsolodas.CreateCommand();
                Kepesseg_leiras_modositas.CommandText = "UPDATE kepessegek SET kepesseg_leiras = @uj_leiras WHERE kepesseg_nev = @kivalasztott_kepesseg";
                Kepesseg_leiras_modositas.Parameters.AddWithValue("@uj_leiras", Uj_Leiras);
                Kepesseg_leiras_modositas.Parameters.AddWithValue("@kivalasztott_kepesseg", Kepesseg_nev);
                using (var leiras_modositas = Kepesseg_leiras_modositas.ExecuteReader())
                {
                    while (leiras_modositas.Read())
                    {
                        var uj_kepesseg = leiras_modositas.GetString("kepesseg_leiras");
                        TextBox_kepesseg_leirasa.Text = uj_kepesseg;
                        TextBox_kepesseg_leirasa.Enabled = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Hiba!\nNincs kiválasztva képesség, nem tudok módosítani!");
            }
        }
        private void Button_torles_Click(object sender, EventArgs e)
        {
            string Kepesseg_torles = ListBox_kepessegek.GetItemText(ListBox_kepessegek.SelectedItem);

            if (Kepesseg_torles.Length > 0)
            {
                var Kepesseg_torles_kivalasztas = kapcsolodas.CreateCommand();
                Kepesseg_torles_kivalasztas.CommandText = "DELETE FROM kepessegek WHERE kepesseg_nev = '" + Kepesseg_torles + "'";
                using (var torles = Kepesseg_torles_kivalasztas.ExecuteReader())
                {
                    while (torles.Read())
                    {
                        var kepesseg_torles = torles.GetString("kepesseg_nev");
                    }
                }
                Kepesseg_leiras(); // kitörölt képességnél a leírás is üres lesz!
                Kepesseg_kiiras_harcos_valasztassal(); // törlés gomb után elveszi a Listbox_kepessegek-ből a kitöröltet
            }
            else
            {
                MessageBox.Show("Hiba!\nNincs kiválasztott képesség, nem tudok törölni!");
            }
        }
        private void ListBox_harcosok_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kepesseg_kiiras_harcos_valasztassal();
        }
        private void ListBox_kepessegek_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kepesseg_leiras();
        }
        private void TextBox_kepessegek_leirasa_Click(object sender, EventArgs e)
        {
            TextBox_kepessegek_leirasa.Text = "";
        }
    }
}