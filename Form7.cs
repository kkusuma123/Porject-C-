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
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Final_Project
{
    public partial class Form7 : Form
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

            dataEquipment.DataSource = ds.Tables[0].DefaultView;  

        }
        public Form7()
        {
            InitializeComponent();
            showEquipment();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ee = new Form1();
            ee.ShowDialog();
        }
        private void showdatabase()
        {
            MySqlConnection conn_ = databaseConnection();
            DataSet ds_ = new DataSet();
            conn_.Open();

            MySqlCommand cmd_;

            cmd_ = conn_.CreateCommand();
            cmd_.CommandText = "SELECT * FROM productorder";

            MySqlDataAdapter adapter_ = new MySqlDataAdapter(cmd_);
            adapter_.Fill(ds_);

            conn_.Close();

            dataEquipment.DataSource = ds_.Tables[0].DefaultView;
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            showEquipment();
            showdatabase();
            searchData("");
        }
        MySqlConnection connection = new MySqlConnection("datasource=localhost;user=root;password=;database=userandlogin");

        public void searchData(string valueToFind)
        {                                                                   /*ค้นหาข้อมูลจากcolum*/
            string searchQuery = "SELECT * FROM productorder WHERE CONCAT(product,productcount,price,user,address) LIKE '%" + valueToFind + "%'";
            MySqlDataAdapter adapter3 = new MySqlDataAdapter(searchQuery, connection);
            DataTable table = new DataTable();
            adapter3.Fill(table);          /*เป็นการสร้าง teble เพื่อให้เราค้นหาข้อมูลใน dataEquipment ได้*/
            dataEquipment.DataSource = table;      /*เพื่อที่จะโชว์ในdataGridView1*/
        }
        private void Form7_TextChanged(object sender, EventArgs e)
        {
            searchData(textBox1.Text);  /*เพื่อที่จะเราพิมพ์ข้อมูลที่ต้องการจะค้นหา*/
        }

        private void dataEquipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataEquipment.CurrentRow.Selected = true;  /*ตอนที่เราคลิ๊กแถวในหัวdataEquipment ตารางต่างๆก็จะมาโชว์ที่ textbox ต่างๆ*/
            string pathimage = @"C:\Users\Lenovo\OneDrive\Desktop\add_Qr\" + Path.GetFileName(textBox2.Text);
            textBox2.Text = dataEquipment.Rows[e.RowIndex].Cells["qrimage"].FormattedValue.ToString();
            textBox3.Text = dataEquipment.Rows[e.RowIndex].Cells["status"].FormattedValue.ToString();
            yyy = Convert.ToInt32(dataEquipment.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString());  
            //ค่าที่อยู่ในcoium id จะถูกนำมา convert เป็น int แล้วเก็บไว้ใน yyy

            if (Path.GetFileName(textBox2.Text) != "")
            {
                string newFileName = textBox2.Text;     /* เราจะเช็คว่า ถ้า textBox2 ไม่เท่ากับค่าว่าง ก็นำค่าที่อยู่ใน textBox2 ไปไว้ใน newFileName*/
                pictureBox1.Image = new Bitmap(newFileName);   /* pictureBox ก็จะแสดงภาพขึ้นมา จาก newFileName*/
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public static string a;
        int yyy;
        private void button2_Click(object sender, EventArgs e)
        {
            a = textBox3.Text;  
            MySqlConnection con_ = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
            con_.Open();
            String sql_ = $"UPDATE `productorder` SET `status` = '{a}' WHERE `id` = {yyy};";
            MySqlCommand cmd_ = new MySqlCommand(sql_, con_);
            int rows_ = cmd_.ExecuteNonQuery();
            con_.Close();

            if (rows_ >= 0)
            {
                MessageBox.Show("อัพเดตสินค้าเรียบร้อยแล้ว");
            }
            showEquipment();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
