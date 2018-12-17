using System;
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
                                                        )"; // JAVA-ban 1 SQL utasításban csak egy CREATE lehet vagy más!!!!!!!!!!!!!!!!!
        MySqlConnection kapcsolodas;

        public Form_harcos_adatbazis()
        {
            InitializeComponent();
            try
            {
                kapcsolodas = new MySqlConnection("Server=localhost;Database=;Uid=root;Pwd=;"); // SQL-es adatbázis létrehozásnál a csatlakozásnál üres a Database!!!
                kapcsolodas.Open();
                var letrehozas = kapcsolodas.CreateCommand();
                letrehozas.CommandText = Adatbazis_letrehozasa_SQL;
                letrehozas.ExecuteNonQuery();

                Harcosok_listazas_combobox();
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
        }
        private void Harcosok_listazas_combobox()
        {
            // -.----------------------------------------- LISTÁZÁS --------------------------------------------
            var Kiirando_harcosok = kapcsolodas.CreateCommand();
            Kiirando_harcosok.CommandText = "SELECT harcos_nev FROM harcosok";
            using (var olvaso = Kiirando_harcosok.ExecuteReader())
            {
                ComboBox_harcosok_nevei.Items.Clear();
                while (olvaso.Read())
                {
                    var nev = olvaso.GetString("harcos_nev");
                    ComboBox_harcosok_nevei.Items.Add(String.Format("{0}", nev));
                    ComboBox_harcosok_nevei.Text = String.Format("{0}", nev); // Gomb utána hozzáadás
                }
            }
            // -------------------------------------------------------------------------------------------------
        }
    }
}
