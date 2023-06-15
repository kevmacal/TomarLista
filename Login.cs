using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TomarLista
{
    public partial class Login : Form
    {
        private Main main;
        private SqlConnection connection;
        private bool correctLogin = false;
        String userID;
        public Login()
        {
            InitializeComponent();
        }

        public Login(Main main, SqlConnection connection)
        {
            InitializeComponent();
            this.main = main;
            this.connection = connection;
            this.Closed += Login_Closed;
        }

        private void Login_Closed(object sender, EventArgs e)
        {
            if (correctLogin == false)
            {
                main.CloseConnection(connection);
                this.main.Dispose();                
            }
            //main.CloseConnection(connection);
            this.main.Enabled = true;
            this.Dispose();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Login_Closed(sender,e);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {            
            string tableName = "[User]";
            string username = this.tbUser.Text;
            string passwordCN = this.tbPass.Text;
            SqlCommand command;
            SqlDataReader reader;


            // Regular expression pattern to match alphanumeric characters
            string pattern = @"^[a-zA-Z0-9]+$";

            // Check if the textbox value matches the pattern
            bool isAlphanumeric = Regex.IsMatch(username, pattern);

            if (isAlphanumeric)
            {
                string query = $"SELECT * FROM {tableName} where username='{username}'";

                command = new SqlCommand(query, connection);
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string passMD5 = GetMd5Hash(passwordCN);
                    if (passMD5== reader["password"].ToString())
                    {
                        userID = reader["id"].ToString();
                        main.changeLoginState(1); //El numero depende del tipo de usuario
                        correctLogin = true;                        
                    }
                }

                reader.Close();
            }            
            if (correctLogin)
            {
                string queryProf = $"SELECT * FROM profesor where id='{userID}'";
                SqlCommand commandProf = new SqlCommand(queryProf, connection);
                SqlDataReader readerProf = commandProf.ExecuteReader();
                while (readerProf.Read())
                {
                    this.main.profesor = new Profesor(readerProf["id"].ToString(), readerProf["apellidos"].ToString(), readerProf["nombres"].ToString());
                }
                readerProf.Close();
                Login_Closed(sender, e);
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos, por favor revisar.", "Ingreso incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        static string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
