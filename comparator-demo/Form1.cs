using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comparator_demo
{
    public partial class Form1 : Form
    {
        #region properties
        // List with path to images
        List<string> pathImage = new List<string>
        {
            "../../City/rivne1.png",
            "../../City/rivne2.png",
            "../../City/rivne3.png",
            "../../City/rivne4.png"
        };
        int index = 1;
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand command;
        MySqlDataAdapter da;
        #endregion

        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            String selectQuery = "SELECT * FROM db_images.myimages WHERE ID = '" + numericUpDown1.Value + "'";
            command = new MySqlCommand(selectQuery, connection);
            da = new MySqlDataAdapter(command);

            DataTable table = new DataTable();

            da.Fill(table);

            byte[] img = (byte[])table.Rows[0][3]; // ????

            MemoryStream ms = new MemoryStream(img);

            pictureBox1.Image = Image.FromStream(ms);

            da.Dispose();

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(pathImage.Last());
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            index++;
            pictureBox1.Image = Image.FromFile(pathImage[index]);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            index--;
            pictureBox1.Image = Image.FromFile(pathImage[index]);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            trbLike.Value++;
            lblLike.Text = "";
            lblLike.Text += trbLike.Value;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            trbDislike.Value++;
            lblDislike.Text = "";
            lblDislike.Text += trbDislike.Value;
        }
 
        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
    }
}
