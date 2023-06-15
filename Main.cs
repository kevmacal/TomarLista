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
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace TomarLista
{
    public partial class Main : Form
    {
        private static string connectionString = "Server=Server;Database=attendance;User Id=attendance;Password=pass;";
        private SqlConnection connection = new SqlConnection(connectionString);
        List<ParesString> paralelosMaterias = new List<ParesString>();
        public Profesor profesor = new Profesor();
        String selectedParalelo = "";
        String selectedMateria = "";

        private static int loginState;
        public Main()
        {
            InitializeComponent();
            this.Load += MainForm_Load; // Add the Load event handler
            this.Activated += MainForm_Enabled;
            cbParalelo.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cbMateria.SelectedIndexChanged += ComboBox_Change;
            this.Closed += MainForm_Closed;
            loginState = 0;
            OpenConnection(connection);            

        }

        public void changeLoginState(int state)
        {
            loginState = state;
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

        static void OpenConnection(SqlConnection connection)
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection opened.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error opening connection: " + ex.Message);
            }
        }

        public void CloseConnection(SqlConnection connection)
        {
            try
            {
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error closing connection: " + ex.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Create and show an instance of the secondary form
            Login lg = new Login(this, connection);
            this.Enabled = false;
            lg.StartPosition = FormStartPosition.CenterScreen; // Center the form on the display
            lg.Show();
        }

        private void MainForm_Closed(object sender, EventArgs e)
        {

            CloseConnection(this.connection);
        }

        private void MainForm_Enabled(object sender, EventArgs e)
        {
            switch (loginState)
            {
                case 1:
                    clasesToolStripMenuItem.Visible = true;
                    lProfesor.Text=profesor.Nombres+" "+profesor.Apellidos;
                    break;
                default:
                    break;
            }
            // Update and refresh all form components
            this.Update();
            this.Refresh();
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Perform your desired action here
            // This code will be executed whenever the selected item changes
            cbMateria.Items.Clear();
            btnSave.Enabled = false;
            foreach (ParesString par in paralelosMaterias)
            {
                if (cbParalelo.SelectedItem.ToString() == par.Par1)
                {
                    cbMateria.Items.Add(par.Par2);
                }
            }
        }

        private void ComboBox_Change(object sender, EventArgs e)
        {
            btnSave.Enabled = false;            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int i = 0;
            int rowsAffected;
            SqlCommand commandTmp;
            string queryTmp = $"insert into clase (titulo, created_at, paralelomateria_id) " +
                $"select 'Titulo',  CONVERT(varchar(20), GETDATE(), 120), (SELECT paralelomateria.id " +
                $"FROM paralelo " +
                $"INNER JOIN paralelomateria ON paralelo.id = paralelomateria.paralelo_id " +
                $"INNER JOIN materia ON paralelomateria.materia_id = materia.id " +
                $"where paralelo.nombre = '" + cbParalelo.Text + "' " +
                $"and materia.nombre = '" + cbMateria.Text + "');";
            commandTmp = new SqlCommand(queryTmp, connection);
            rowsAffected = commandTmp.ExecuteNonQuery();

            foreach (Control control in flpMain.Controls)
            {
                if (i!=0)
                {
                    queryTmp = $"INSERT into estudianteparalelomateriaregistroasistencia (estudianteparalelomateria_id, clase_id, estado) " +
                        $"select(SELECT estudianteparalelomateria.id " +
                        $"FROM paralelomateria " +
                        $"INNER JOIN estudianteparalelomateria ON paralelomateria.id = estudianteparalelomateria.paralelomateria_id " +
                        $"INNER JOIN estudiante ON estudianteparalelomateria.estudiante_id = estudiante.id " +
                        $"WHERE paralelomateria.materia_id = (select id from materia where materia.nombre = '"+cbMateria.Text+"') " +
                        $"AND paralelomateria.paralelo_id = (select id from paralelo where paralelo.nombre = '"+cbParalelo.Text+"') " +
                        $"AND apellidos = '"+control.Controls[1].Text+"' AND nombres = '"+control.Controls[2].Text+"'), " +
                        $"(select id from clase " +
                        $"where created_at = CONVERT(varchar(20), GETDATE(), 120) " +
                        $"and paralelomateria_id = (SELECT paralelomateria.id " +
                        $"FROM paralelo " +
                        $"INNER JOIN paralelomateria ON paralelo.id = paralelomateria.paralelo_id " +
                        $"INNER JOIN materia ON paralelomateria.materia_id = materia.id " +
                        $"where paralelo.nombre = '"+cbParalelo.Text+"' " +
                        $"and materia.nombre = '"+cbMateria.Text+"')), " +
                        $"'"+ control.Controls[3].Text + "'; ";
                    commandTmp = new SqlCommand(queryTmp, connection);
                    rowsAffected = commandTmp.ExecuteNonQuery();
                    control.Controls[3].Enabled = false;
                }
                i++;
            }            

            btnSave.Enabled = false;
            MessageBox.Show("La clase se creo correctamente y se registra la asistencia de sus estudiantes", "Asistencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void nuevaClaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cbMateria.Visible = true;
            cbParalelo.Visible = true;
            btnNewClass.Visible = true;
            btnSave.Visible = true;
            btnSave.Enabled = false;
            List<String> idsparalelomateria = new List<String>();        
            

            //Lectura de paralelos y materia
            string queryProf = $"select * from profesorparalelomateria where profesor_id="+profesor.Id+";";
            SqlCommand commandProf = new SqlCommand(queryProf, connection);
            SqlDataReader readerProf = commandProf.ExecuteReader();
            while (readerProf.Read())
            {
                idsparalelomateria.Add(readerProf["paralelomateria_id"].ToString());

            }
            readerProf.Close();

            foreach (String id in idsparalelomateria){
                //Seleccion paralelos
                string queryTmp = $"SELECT paralelo.nombre, materia.nombre " +
                    $"FROM paralelo " +
                    $"INNER JOIN paralelomateria ON paralelo.id = paralelomateria.paralelo_id " +
                    $"INNER JOIN materia ON paralelomateria.materia_id = materia.id " +
                    $"WHERE paralelomateria.id = "+id+"; ";
                SqlCommand commandTmp = new SqlCommand(queryTmp, connection);
                SqlDataReader readerTmp = commandTmp.ExecuteReader();
                while (readerTmp.Read())
                {
                    ParesString psTmp = new ParesString(readerTmp[0].ToString(), readerTmp[1].ToString());
                    paralelosMaterias.Add(psTmp);
                    String newItem = readerTmp[0].ToString();

                    // Check if the item is already present in the ComboBox
                    if (!cbParalelo.Items.Contains(newItem))
                    {
                        // Add the item to the ComboBox
                        cbParalelo.Items.Add(newItem);
                    }
                }
                readerTmp.Close();
            }            

        }

        private void btnNewClass_Click(object sender, EventArgs e)
        {
            selectedParalelo = cbParalelo.Text;
            selectedMateria = cbMateria.Text;
            flpMain.Controls.Clear();
            Boolean ok = true;
            FlowLayoutPanel flowLayoutPanelTmp = new FlowLayoutPanel();
            Label numero= new Label();
            Label apellidos = new Label();
            Label nombres = new Label();
            Label asistencia = new Label();
            int i = 0;
            string queryTmp = $"select * from clase " +
                $"where created_at = CONVERT(varchar(20), GETDATE(), 120) " +
                $"and paralelomateria_id = (SELECT paralelomateria.id " +
                $"FROM paralelo " +
                $"INNER JOIN paralelomateria ON paralelo.id = paralelomateria.paralelo_id " +
                $"INNER JOIN materia ON paralelomateria.materia_id = materia.id " +
                $"where paralelo.nombre = '"+cbParalelo.Text+"' " +
                $"and materia.nombre = '"+cbMateria.Text+"');";
            SqlCommand commandTmp = new SqlCommand(queryTmp, connection);
            SqlDataReader readerTmp = commandTmp.ExecuteReader();
            while (readerTmp.Read())
            {
                ok = false;
            }
            readerTmp.Close();
            if (ok)
            {
                btnSave.Enabled = false;
                if (cbParalelo.Text != "" && cbMateria.Text != "")
                {
                    flowLayoutPanelTmp.Width = flpMain.Width;
                    flowLayoutPanelTmp.Height = btnSave.Height;
                    flowLayoutPanelTmp.BackColor = Color.DarkBlue;
                    numero.Text = "#";
                    apellidos.Text = "Apellidos";
                    nombres.Text = "Nombres";
                    asistencia.Text = "Asistencia";
                    numero.ForeColor = Color.White;
                    apellidos.ForeColor = Color.White;
                    nombres.ForeColor = Color.White;
                    asistencia.ForeColor = Color.White;
                    numero.Width = (int)(flowLayoutPanelTmp.Width * 0.1);
                    apellidos.Width = (int)(flowLayoutPanelTmp.Width * 0.2);
                    nombres.Width = (int)(flowLayoutPanelTmp.Width * 0.2);
                    asistencia.Width = (int)(flowLayoutPanelTmp.Width * 0.45);
                    flowLayoutPanelTmp.Controls.Add(numero);
                    flowLayoutPanelTmp.Controls.Add(apellidos);
                    flowLayoutPanelTmp.Controls.Add(nombres);
                    flowLayoutPanelTmp.Controls.Add(asistencia);
                    flpMain.Controls.Add(flowLayoutPanelTmp);
                    queryTmp = $"SELECT apellidos, nombres FROM paralelomateria " +
                        $"INNER JOIN estudianteparalelomateria ON paralelomateria.id = estudianteparalelomateria.paralelomateria_id " +
                        $"INNER JOIN estudiante ON estudianteparalelomateria.estudiante_id = estudiante.id " +
                        $"WHERE paralelomateria.materia_id = (select id from materia where materia.nombre = '" + cbMateria.Text + "') " +
                        $"AND paralelomateria.paralelo_id = (select id from paralelo where paralelo.nombre = '" + cbParalelo.Text + "') " +
                        "ORDER by apellidos ASC;";
                    commandTmp = new SqlCommand(queryTmp, connection);
                    readerTmp = commandTmp.ExecuteReader();
                    while (readerTmp.Read())
                    {
                        flowLayoutPanelTmp = new FlowLayoutPanel();
                        flowLayoutPanelTmp.Width = flpMain.Width;
                        flowLayoutPanelTmp.Height = btnSave.Height;
                        numero = new Label();
                        apellidos = new Label();
                        nombres = new Label();
                        ComboBox cbAsistencia = new ComboBox();
                        if (i % 2 == 0)
                        {
                            flowLayoutPanelTmp.BackColor = Color.AntiqueWhite;
                        }
                        numero.Text = "" + (i + 1) + "";
                        apellidos.Text = readerTmp[0].ToString();
                        nombres.Text = readerTmp[1].ToString();
                        cbAsistencia.DropDownStyle = ComboBoxStyle.DropDownList;
                        cbAsistencia.Items.Add("Presente");
                        cbAsistencia.Items.Add("Atraso");
                        cbAsistencia.Items.Add("Falta");
                        cbAsistencia.SelectedIndex = 0;
                        numero.Width = (int)(flowLayoutPanelTmp.Width * 0.1);
                        apellidos.Width = (int)(flowLayoutPanelTmp.Width * 0.3);
                        nombres.Width = (int)(flowLayoutPanelTmp.Width * 0.3);
                        cbAsistencia.Width = (int)(flowLayoutPanelTmp.Width * 0.27);
                        flowLayoutPanelTmp.Controls.Add(numero);
                        flowLayoutPanelTmp.Controls.Add(apellidos);
                        flowLayoutPanelTmp.Controls.Add(nombres);
                        flowLayoutPanelTmp.Controls.Add(cbAsistencia);
                        flpMain.Controls.Add(flowLayoutPanelTmp);
                        i++;
                    }
                    readerTmp.Close();
                }
            }
            else
            {
                MessageBox.Show("La clase no se puede crear porque ya existe y se ha tomado asistencia", "Clase Existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (i != 0)
            {
                btnSave.Enabled = true;
            }
        }
    }
}
