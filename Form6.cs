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
    public partial class Form6 : Form
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
        private void showEquiment()
        {
            string sql_ = "SELECT * FROM productorder ";
            MySqlConnection con_ = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
            MySqlCommand cmd_ = new MySqlCommand(sql_, con_);
            con_.Open();
            MySqlDataReader reader = cmd_.ExecuteReader();
            while (reader.Read())
            {
                yyy = reader.GetInt32(7); /*เราจะใช้ลูป while มาอ่านค่า id ล่าสุดในดาต้าเบส productorder*/
            }

            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();    
            cmd.CommandText = $"SELECT * FROM productorder  WHERE `id` = {yyy}";  /*เป็นการนำข้อมูลของไอดีล่าสุดมาแสดงในdataEquipment*/

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            dataEquipment.DataSource = ds.Tables[0].DefaultView;   
        }
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            showEquiment();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            globaluser = txtname.Text;    /*เอาชื่อuserมาปริ้นใบเสร็จ*/
            printPreviewDialog1.Document = printDocument1;    
            Hide();
            printPreviewDialog1.ShowDialog(); /*แสดงใบเสร็จ*/
            

            string sql = "SELECT * FROM productorder ";
            MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
            MySqlCommand cmd = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yyy = reader.GetInt32(7);   /*เราจะใช้ลูป while มาอ่านค่า id ล่าสุดในดาต้าเบส productorder*/
            }

            MySqlConnection conn = databaseConnection();
            conn.Open();
            string sql1 = "DELETE FROM shoppingclass";       
            MySqlCommand cmd1 = new MySqlCommand(sql1, conn);
            int rows1 = cmd1.ExecuteNonQuery();
            conn.Close();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("        Scintilla Jewelry", new Font("Century Gothic", 26, FontStyle.Bold), Brushes.Black, new Point(200, 60));
            e.Graphics.DrawString("Date " + System.DateTime.Now.ToString("dd/MM/yyyy HH : mm : ss น."), new Font("Century Gothic", 14, FontStyle.Regular), Brushes.Black, new PointF(500, 150));
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------", new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(100, 190));
            e.Graphics.DrawString($"{txtname.Text}", new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(100,150));
            e.Graphics.DrawString(" ชื่อสินค้า                          จำนวน                       ราคา", new Font("Century Gothic", 20, FontStyle.Regular), Brushes.Black, new Point(100, 220));
           
            MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
            MySqlCommand cmd = conn.CreateCommand();
            conn.Open();
            cmd.CommandText = $"SELECT name,amount,price FROM shoppingclass";
            MySqlDataReader dr = cmd.ExecuteReader();
            int b = 0;
            while (dr.Read())
            {
                e.Graphics.DrawString(dr.GetString("name"), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(100, 270 + 40 * b));
                e.Graphics.DrawString(dr.GetString("amount"), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(480, 270 + 40 * b));
                e.Graphics.DrawString(dr.GetString("price"), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(680, 270 + 40 * b));
                b++;
            }
            conn.Close();
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------", new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(100, 190));
            int y = 320;
            e.Graphics.DrawString("ราคารวม", new Font("Century Gothic", 12, FontStyle.Regular), Brushes.Black, new Point(100, (y + 500)));
            e.Graphics.DrawString($"{Form3.qr} Bath", new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(600, (y + 500)));
            e.Graphics.DrawString("Scintilla Jewelry               ", new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(120, ((y + 600) + 45) + 45));
            e.Graphics.DrawString("น.ส.กุสุมา ก่อประศาสน์วิทย์           ", new Font("Century Gothic", 16, FontStyle.Regular), Brushes.Black, new Point(80, (((y + 600) + 45) + 45) + 45));
        }
        public static string globaluser;
        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }
        public static string xxx, zzz;
        int yyy = 0; 
        private void button2_Click_1(object sender, EventArgs e)
        {
            xxx = txtname.Text;
            zzz = txtaddress.Text;
            MySqlConnection con_ = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
            con_.Open();
            String sql_ = $"UPDATE `productorder` SET `user` = '{xxx}',`address` = '{zzz}' WHERE `id` = {yyy};";
            MySqlCommand cmd_ = new MySqlCommand(sql_, con_);
            int rows_ = cmd_.ExecuteNonQuery();
            con_.Close();

            if (rows_ >= 0)
            {
                MessageBox.Show("สั่งสินค้าเรียบร้อยแล้ว");
            }
            showEquiment();
        }

        private void dataEquipment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
