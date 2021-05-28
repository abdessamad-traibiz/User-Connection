using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Connection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //data biding :Récuperer les données
            string userLogin = Login.Text;
            string userPassword = Password.Text;

            //Se connecter à la base données
            string connexionstring;
            SqlConnection connexion;
            connexionstring = @"Data Source=DELL;Initial Catalog=bankdb;Integrated Security=True";
            connexion = new SqlConnection(connexionstring);
            connexion.Open();

            //Récupérer les données depuis la base de données 
            SqlCommand command;
            string sql, dblogin = "", dbpassword = "";
            SqlDataReader dataReader;

            sql = "Select Login,Password from login"; //On stock notre requête select 
            command = new SqlCommand(sql, connexion);//Ajouter une commande 
            dataReader = command.ExecuteReader();//Éxécuter la requête 

            //On teste si le login et le password est les mêmes que dans notre base de données 
            while (dataReader.Read())
            {

                dblogin = dataReader.GetValue(0).ToString();
                dbpassword = dataReader.GetValue(1).ToString();

                if (dblogin == userLogin && dbpassword == userPassword)
                {
                    MessageBox.Show(" Connected !!");
                }
                else
                {
                    MessageBox.Show("Invalid Login or password try again !!");
                }
            }

            connexion.Close();
        }
    }
}
