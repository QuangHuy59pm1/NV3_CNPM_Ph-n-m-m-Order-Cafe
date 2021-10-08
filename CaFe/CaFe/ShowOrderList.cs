using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaFe
{
    public partial class ShowOrderList : Form
    {
        private string Note, NumberTable;
        public ShowBills()
        {
            InitializeComponent();
            hienthi();
        }

 

        public ShowOrderList(string note, string ntable)
        {
            InitializeComponent();
            this.Note = note;
            this.NumberTable = ntable;
        }

        public void hienthi()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=NGUYENQUANGHUY;Initial Catalog=QLCafe;Integrated Security=True");
            conn.Open();
            SqlCommand cdm = new SqlCommand("Select tendo from oderlist where SoBan='"+NumberTable+"'", conn);
            SqlDataReader rd = cdm.ExecuteReader();
            while(rd.Read())
            {
                dataGridView1.Rows.Add(rd[0].ToString());
            }    

            conn.Close();
        }

        private void ShowOrderList_Load(object sender, EventArgs e)
        {
            hienthi();
            label2.Text = Note;
            label1.Text = NumberTable;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
