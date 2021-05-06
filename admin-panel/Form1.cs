using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace admin_panel
{
    public partial class Form1 : Form
    {
        #region db_connection




        #endregion
        string str;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image (*.jpg; *.png; *.gif) | *jpg; *.png; *.gif)";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
                str = opf.FileName;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            MySqlConnection con;
            string host = "localhost";
            string db = "db_images";
            string port = "3306";
            string user = "root"; // maybe changed
            string pass = ""; // maybe changed
            string constring = "datasource =" + host + "; database =" + db + "; port =" + port + ";username =" + user + "; password =" + pass + "; SslMode=none";
            con = new MySqlConnection(constring);

            string sql = "INSERT INTO `myimages`(`Image`) VALUES (@file)";

            con.Open();
            using (var cmd = new MySqlCommand(sql,con))
            {
                cmd.Parameters.AddWithValue("@file", File.ReadAllBytes(str));
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
    }
}
