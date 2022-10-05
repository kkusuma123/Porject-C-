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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string ssss;
        public static string globaluser;     /*ประกาศตัวแปรไว้ใช้เกี่ยวกับการเข้าสู่ระบบของแอดมิน*/
        public static string globalpassword;
        private void button1_Click(object sender, EventArgs e)
        {
            globaluser = user.Text;  
            globalpassword = password.Text;
            ssss = user.Text;
            if (user.Text == "adminbam" && password.Text == "12345")   
            {
                new Form7().Show();
                this.Hide();
            }
            else
            {
                MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;charset=utf8;");
                MySqlDataAdapter login = new MySqlDataAdapter("SELECT COUNT(*) FROM login WHERE user='" + user.Text + "' AND password='" + password.Text + "'", con);

                DataTable gg = new DataTable();
                login.Fill(gg);
                if (gg.Rows[0][0].ToString() == "1")
                {

                    MessageBox.Show("เข้าสู่ระบบเรียบร้อย");
                    this.Hide();
                    Form3 MForm = new Form3();
                    MForm.ShowDialog();
                    this.Close();
                }
                else
                    MessageBox.Show("รหัสหรือชื่อผู้ใช้งานผิด");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 MForm = new Form2();
            MForm.ShowDialog();
        }
    }
}
