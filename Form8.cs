using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Final_Project
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        private void resetdata()
        {
            pictureBox1.Image = null; /*เท่ากับค่าว่าง*/
        }
        private void showEquipment()
        {
            MySqlConnection conn = databaseConnection();
            DataTable valami = new DataTable();
            conn.Open();                                  
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM productorder ";  
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(valami);
            conn.Close();
            var row_c = valami.Rows.Count;
            if (row_c == 0)
            {
                MessageBox.Show("ไม่พบข้อมูล");
            }
        }
        string x; 
        private void Add_food(string pathimage)
        {
            string sql = "SELECT * FROM productorder ";
            MySqlConnection con = databaseConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                x = reader.GetString(7);        /*เราจะใช้ลูป while มาอ่านค่า id ล่าสุดในดาต้าเบส productorder*/
            }
            con.Close();
            
            string newFileName = pathimage.Replace("\\", "\\\\");
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            string sql_ = "UPDATE productorder SET qrimage = '" + newFileName + "' WHERE id = '" + x + "'";
            MySqlCommand cmd_ = new MySqlCommand(sql_, conn); /*ทำการอัพเดตพาดรูป ในดาต้าเบส productorder ตำแหน่งที่ไอดีล่าสุดที่เราอ่านค่ามาล่าสุด*/
            conn.Open(); 

            int rows = cmd_.ExecuteNonQuery();
            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("ส่งสลีปเรียบร้อยเเล้วค่ะ");
                resetdata();
                showEquipment();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.png; *.jpg; *.jpeg; *.gif; *.bmp)| *.png; *.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)    /*เป็นที่ที่เราคลิ๊กเพื่อเปิดโฟลเดอร์รูปภาพ ตามประเภทต่างๆของไฟล์ภาพ*/
            {
                pictureBox1.Image = new Bitmap(open.FileName);
                lab_path.Text = open.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
             string[] files = Directory.GetFiles(@"C:\Users\Lenovo\OneDrive\Desktop\add_Qr\");
             for (int i = 0; i < files.Length; i++)
             {
                FileInfo file1 = new FileInfo(files[i]);     /* เมื่อกดคลิ๊กปุ่มนี้ มันก็จะส่งค่าพาดรูปไปยัง addfood */
             }
             string pathimage = "C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_Qr\\" + Path.GetFileName(lab_path.Text);
             Add_food(pathimage);    
            

            this.Hide();
            Form6 MForm = new Form6();
            MForm.ShowDialog();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}
