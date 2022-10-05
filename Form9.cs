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

namespace Final_Project
{
    public partial class Form9 : Form
    {
        private MySqlConnection databaseConnection()
        {
            //Connection String สำหรับใช้เชื่อมต่อฐานข้อมูล โดยระบุชื่อ Host,Port,Username,Password และชื่อ database
            string connectionString = "host=localhost;user=root;password=;database=userandlogin";

            //สร้างตัวแปลชื่อ conn เพื่อใช้เก็บการเชื่อมต่อฐานข้อมูล โดยใส่ค่า conncetionstring เข้าไป
            MySqlConnection conn = new MySqlConnection(connectionString);

            //ส่งค่าการเชื่อมต่อฐานข้อมูลกลับไปยังที่ที่เรียกใช้งาน Method
            return conn;
        }
        private void showEquipment()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM productorder";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            dataGridView1.DataSource = ds.Tables[0].DefaultView;

        }
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            showEquipment();
            searchData("");
        }

        MySqlConnection connection = new MySqlConnection("datasource=localhost;user=root;password=;database=userandlogin");

        public void searchData(string valueToFind)
        {                                                                 /*ค้นหาข้อมูลจากcolum*/
            string searchQuery = "SELECT * FROM productorder WHERE CONCAT(product,productcount,price,user,address,status) LIKE '%" + valueToFind + "%'";
            MySqlDataAdapter adapter3 = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter3.Fill(table);        /*เป็นการสร้าง teble เพื่อให้เราค้นหาข้อมูลใน dataEquipment ได้*/
            dataGridView1.DataSource = table;    /*เพื่อที่จะโชว์ในdataGridView1*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            searchData(textBox1.Text);   /*เพื่อที่จะเราพิมพ์ข้อมูลที่ต้องการจะค้นหา*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 MForm = new Form3();
            MForm.ShowDialog();
        }
    }
}
