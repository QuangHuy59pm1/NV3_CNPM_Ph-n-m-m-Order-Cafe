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

namespace CaFe
{
    public partial class fOder : Form
    {
        private string table;
        public fOder()
        {
            InitializeComponent();
        }
        public  fOder(string table)
        {
            InitializeComponent();
            this.table = table;
        }

        public void hienthi()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=NGUYENQUANGHUY;Initial Catalog=QLCafe;Integrated Security=True");
            conn.Open();
            SqlCommand cdm = new SqlCommand("Select * from oderlist", conn);
            SqlDataReader rd = cdm.ExecuteReader();
            
             
            conn.Close();
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            /*SqlConnection conn = new SqlConnection(@"Data Source=NGUYENQUANGHUY;Initial Catalog=QLCafe;Integrated Security=True");
            conn.Open*/
            if (checkBox1.Checked == true)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=NGUYENQUANGHUY;Initial Catalog=QLCafe;Integrated Security=True");
                conn.Open();
                ListViewItem item = new ListViewItem();
                item.Text = checkBox1.Text;
                listView1.Items.Add(item);

                ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem(item, label1.Text);
                item.SubItems.Add(subitem);
                checkBox1.Checked = false;
                SqlCommand cdm = new SqlCommand("insert into oderlist(SoBan, tendo, note) values (N'"+table+"',N'" + checkBox1.Text+"',N'"+textBox1.Text+"')", conn);
                cdm.ExecuteReader();
                conn.Close();
            }
            if (checkBox2.Checked == true)
            {
               SqlConnection conn = new SqlConnection(@"Data Source=NGUYENQUANGHUY;Initial Catalog=QLCafe;Integrated Security=True");
                conn.Open();
                ListViewItem item = new ListViewItem();
                item.Text = checkBox2.Text;
                listView1.Items.Add(item);

                ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem(item, label2.Text);
                item.SubItems.Add(subitem);
                checkBox1.Checked = false;
                SqlCommand cdm = new SqlCommand("insert into oderlist(SoBan, tendo, note) values (N'" + table + "',N'" + checkBox2.Text + "',N'" + textBox1.Text + "')", conn);
                cdm.ExecuteReader();
                conn.Close();
            }
            if (checkBox3.Checked == true)
            {
               SqlConnection conn = new SqlConnection(@"Data Source=NGUYENQUANGHUY;Initial Catalog=QLCafe;Integrated Security=True");
                conn.Open();
                ListViewItem item = new ListViewItem();
                item.Text = checkBox3.Text;
                listView1.Items.Add(item);

                ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem(item, label3.Text);
                item.SubItems.Add(subitem);
                checkBox1.Checked = false;
                SqlCommand cdm = new SqlCommand("insert into oderlist(SoBan, tendo, note) values (N'" + table + "',N'" + checkBox3.Text + "',N'" + textBox1.Text + "')", conn);
                cdm.ExecuteReader();
                conn.Close();
            }
            if (checkBox4.Checked == true)
            {
               SqlConnection conn = new SqlConnection(@"Data Source=NGUYENQUANGHUY;Initial Catalog=QLCafe;Integrated Security=True");
                conn.Open();
                ListViewItem item = new ListViewItem();
                item.Text = checkBox4.Text;
                listView1.Items.Add(item);

                ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem(item, label4.Text);
                item.SubItems.Add(subitem);
                checkBox1.Checked = false;
                SqlCommand cdm = new SqlCommand("insert into oderlist(SoBan, tendo, note) values (N'" + table + "',N'" + checkBox4.Text + "',N'" + textBox1.Text + "')", conn);
                cdm.ExecuteReader();
                conn.Close();
            }
            if (checkBox5.Checked == true)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=NGUYENQUANGHUY;Initial Catalog=QLCafe;Integrated Security=True");
                conn.Open();
                ListViewItem item = new ListViewItem();
                item.Text = checkBox5.Text;
                listView1.Items.Add(item);

                ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem(item, label5.Text);
                item.SubItems.Add(subitem);
                checkBox1.Checked = false; 
                SqlCommand cdm = new SqlCommand("insert into oderlist(SoBan, tendo, note) values (N'" + table + "',N'" + checkBox5.Text + "',N'" + textBox1.Text + "')", conn);
                cdm.ExecuteReader();
                conn.Close();
            }
            /*if (checkBox6.Checked == true)
            {
                listBox2.Items.Add(checkBox1.Text);
            }*/
            


        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            ShowOrderList ShowList = new ShowOrderList(textBox1.Text, table);
            ShowList.ShowDialog();
            
            
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
