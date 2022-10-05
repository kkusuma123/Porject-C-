using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    public partial class Form3 : Form
    {
        Form5 f3 = new Form5(); 
        Form6 f6 = new Form6();
        private MySqlConnection databaseConnection()
        {
            //Connection String สำหรับใช้เชื่อมต่อฐานข้อมูล โดยระบุชื่อ Host,Port,Username,Password และชื่อ database
            string connectionString = "host=localhost;user=root;password=;database=userandlogin";

            //สร้างตัวแปลชื่อ conn เพื่อใช้เก็บการเชื่อมต่อฐานข้อมูล โดยใส่ค่า conncetionstring เข้าไป
            MySqlConnection conn = new MySqlConnection(connectionString);

            //ส่งค่าการเชื่อมต่อฐานข้อมูลกลับไปยังที่ที่เรียกใช้งาน Method
            return conn;
        }

       
        ListViewItem itm;  /*เก็บค่าlistviewไว้ในตัวแปรitm*/
        String[] arl = new String[4];     /*สร้างตัวแปรอารเรย์เป็นค่าว่างstring arl*/
        Form1 form1 = new Form1();
        

        public Form3()
        {
            
            InitializeComponent();

            listView1.View = View.Details;      /*เปิดใช้งานตารางตารางlistview*/
            listView1.GridLines = true;          /*เป็นการประกาศให้มีเส้นตาราง*/
            listView1.FullRowSelect = true;      /* เป็นการเปิดใช้การเลือกแถว*/
        }
        string product = "";
        int num = 0, money = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            int m = 79;
            arl[0] = "ต่างหู สีชมพูซากุระ";  
            arl[1] = numericUpDown1.Value.ToString(); 

            product += $"ต่างหู สีชมพูซากุระ[{numericUpDown1.Value}]\n ";
            num += Convert.ToInt32(numericUpDown1.Value);
            money += 79 * Convert.ToInt32(numericUpDown1.Value);

            arl[2] = 79 + " "; 
            if (numericUpDown1.Value == 0)
            {
                MessageBox.Show("สินค้าหมด");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                con.Open();
                String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label1.Text}','{numericUpDown1.Value}','{m}')";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                int rows1 = cmd1.ExecuteNonQuery();
                con.Close();

                numericUpDown1.Maximum = numericUpDown1.Maximum - numericUpDown1.Value; 
                itm = new ListViewItem(arl);  /*นำarlทั้งหมดมาเก็บในตัวแปรitm และนำitmแอดเเข้าไปยังlistviewอีกที*/
                listView1.Items.Add(itm);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            showEquipment();
            if(Form1.globaluser != "adminbam" && Form1.globalpassword != "12345")
            {
                button24.Visible = false;
                button25.Visible = false;  
                button26.Visible = false;
                button28.Visible = false;
            }
            else
            {
                button24.Visible = true;
                button25.Visible = true;  
                button26.Visible = true;
                button28.Visible = true;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
            this.Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            int m = 79;
            arl[0] = "ต่างหู สีม่วงลาเวนเดอร์";
            arl[1] = numericUpDown2.Value.ToString();

            product += $"ต่างหู สีม่วงลาเวนเดอร์[{numericUpDown2.Value}]\n ";
            num += Convert.ToInt32(numericUpDown2.Value);
            money += 79 * Convert.ToInt32(numericUpDown2.Value);

            arl[2] = 79 + " ";
            if (numericUpDown2.Value == 0)
            {
                MessageBox.Show("สินค้าหมด");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                con.Open();
                String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label3.Text}','{numericUpDown2.Value}','{m}')";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                int rows1 = cmd1.ExecuteNonQuery();
                con.Close();

                numericUpDown2.Maximum = numericUpDown2.Maximum - numericUpDown2.Value;
                itm = new ListViewItem(arl); 
                listView1.Items.Add(itm);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int m = 79;
            arl[0] = "ต่างหู สีม่วงขาวไข่มุก";
            arl[1] = numericUpDown3.Value.ToString();

            product += $"ต่างหู สีม่วงขาวไข่มุก[{numericUpDown3.Value}]\n ";
            num += Convert.ToInt32(numericUpDown3.Value);
            money += 79 * Convert.ToInt32(numericUpDown3.Value);

            arl[2] = 79 + " ";
            if (numericUpDown3.Value == 0)
            {
                MessageBox.Show("สินค้าหมด");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                con.Open();
                String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label5.Text}','{numericUpDown3.Value}','{m}')";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                int rows1 = cmd1.ExecuteNonQuery();
                con.Close();

                numericUpDown3.Maximum = numericUpDown3.Maximum - numericUpDown3.Value;
                itm = new ListViewItem(arl);
                listView1.Items.Add(itm);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int m = 79;
            arl[0] = "ต่างหู สีฟ้าสดใส";
            arl[1] = numericUpDown4.Value.ToString();

            product += $"ต่างหู สีฟ้าสดใส[{numericUpDown4.Value}]\n ";
            num += Convert.ToInt32(numericUpDown4.Value);
            money += 79 * Convert.ToInt32(numericUpDown4.Value);

            arl[2] = 79 + " ";
            if (numericUpDown4.Value == 0)
            {
                MessageBox.Show("สินค้าหมด");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                con.Open();
                String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label7.Text}','{numericUpDown4.Value}','{m}')";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                int rows1 = cmd1.ExecuteNonQuery();
                con.Close();

                numericUpDown4.Maximum = numericUpDown4.Maximum - numericUpDown4.Value;
                itm = new ListViewItem(arl);
                listView1.Items.Add(itm);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int m = 99;
            arl[0] = "สร้อย สีชมพูซากุระ";
            arl[1] = numericUpDown5.Value.ToString();

            product += $"สร้อย สีชมพูซากุระ[{numericUpDown5.Value}]\n ";
            num += Convert.ToInt32(numericUpDown5.Value);
            money += 99 * Convert.ToInt32(numericUpDown5.Value);

            arl[2] = 99 + " ";
            if (numericUpDown5.Value == 0)
            {
                MessageBox.Show("สินค้าหมด");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                con.Open();
                String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label9.Text}','{numericUpDown5.Value}','{m}')";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                int rows1 = cmd1.ExecuteNonQuery();
                con.Close();

                numericUpDown5.Maximum = numericUpDown5.Maximum - numericUpDown5.Value;
                itm = new ListViewItem(arl);
                listView1.Items.Add(itm);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int m = 99;
            arl[0] = "สร้อย สีฟ้าสดใส";
            arl[1] = numericUpDown6.Value.ToString();

            product += $"สร้อย สีฟ้าสดใส[{numericUpDown6.Value}]\n ";
            num += Convert.ToInt32(numericUpDown6.Value);
            money += 99 * Convert.ToInt32(numericUpDown6.Value);

            arl[2] = 99 + " ";
            if (numericUpDown6.Value == 0)
            {
                MessageBox.Show("สินค้าหมด");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                con.Open();
                String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label11.Text}','{numericUpDown6.Value}','{m}')";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                int rows1 = cmd1.ExecuteNonQuery();
                con.Close();

                numericUpDown6.Maximum = numericUpDown6.Maximum - numericUpDown6.Value;
                itm = new ListViewItem(arl);
                listView1.Items.Add(itm);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int m = 99;
            arl[0] = "สร้อย สีม่วงลาเวนเดอร์";
            arl[1] = numericUpDown7.Value.ToString();

            product += $"สร้อย สีม่วงลาเวนเดอร์[{numericUpDown7.Value}]\n ";
            num += Convert.ToInt32(numericUpDown7.Value);
            money += 99 * Convert.ToInt32(numericUpDown7.Value);

            arl[2] = 99 + " ";
            if (numericUpDown7.Value == 0)
            {
                MessageBox.Show("สินค้าหมด");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                con.Open();
                String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label13.Text}','{numericUpDown7.Value}','{m}')";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                int rows1 = cmd1.ExecuteNonQuery();
                con.Close();

                numericUpDown7.Maximum = numericUpDown7.Maximum - numericUpDown7.Value;
                itm = new ListViewItem(arl);
                listView1.Items.Add(itm);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int m = 99;
            arl[0] = "สร้อย สีขาวไข่มุก";
            arl[1] = numericUpDown8.Value.ToString();

            product += $"สร้อย สีขาวไข่มุก[{numericUpDown8.Value}]\n ";
            num += Convert.ToInt32(numericUpDown8.Value);
            money += 99 * Convert.ToInt32(numericUpDown8.Value);

            arl[2] = 99 + " ";
            if (numericUpDown8.Value == 0)
            {
                MessageBox.Show("สินค้าหมด");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                con.Open();
                String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label15.Text}','{numericUpDown8.Value}','{m}')";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                int rows1 = cmd1.ExecuteNonQuery();
                con.Close();

                numericUpDown8.Maximum = numericUpDown8.Maximum - numericUpDown8.Value;
                itm = new ListViewItem(arl);
                listView1.Items.Add(itm);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int m = 169;
            arl[0] = "เซ็ต สีม่วงลาเวนเดอร์";
            arl[1] = numericUpDown9.Value.ToString();

            product += $"เซ็ต สีม่วงลาเวนเดอร์[{numericUpDown9.Value}]\n ";
            num += Convert.ToInt32(numericUpDown9.Value);
            money += 169 * Convert.ToInt32(numericUpDown9.Value);

            arl[2] = 169 + " ";
            if (numericUpDown9.Value == 0)
            {
                MessageBox.Show("สินค้าหมด");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                con.Open();
                String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label17.Text}','{numericUpDown9.Value}','{m}')";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                int rows1 = cmd1.ExecuteNonQuery();
                con.Close();

                numericUpDown9.Maximum = numericUpDown9.Maximum - numericUpDown9.Value;
                itm = new ListViewItem(arl);
                listView1.Items.Add(itm);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int m = 169;
            arl[0] = "เซ็ต สีฟ้าสดใส";
            arl[1] = numericUpDown10.Value.ToString();

            product += $"เซ็ต สีฟ้าสดใส[{numericUpDown10.Value}]\n ";
            num += Convert.ToInt32(numericUpDown10.Value);
            money += 169 * Convert.ToInt32(numericUpDown10.Value);

            arl[2] = 169 + " ";
            if (numericUpDown10.Value == 0)
            {
                MessageBox.Show("สินค้าหมด");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                con.Open();
                String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label19.Text}','{numericUpDown10.Value}','{m}')";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                int rows1 = cmd1.ExecuteNonQuery();
                con.Close();

                numericUpDown10.Maximum = numericUpDown10.Maximum - numericUpDown10.Value;
                itm = new ListViewItem(arl);
                listView1.Items.Add(itm);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int m = 169;
            arl[0] = "เซ็ต สีขาวไข่มุก";
            arl[1] = numericUpDown11.Value.ToString();

            product += $"เซ็ต สีขาวไข่มุก[{numericUpDown11.Value}]\n ";
            num += Convert.ToInt32(numericUpDown11.Value);
            money += 79 * Convert.ToInt32(numericUpDown11.Value);

            arl[2] = 169 + " ";
            if (numericUpDown11.Value == 0)
            {
                MessageBox.Show("สินค้าหมด");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                con.Open();
                String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label21.Text}','{numericUpDown11.Value}','{m}')";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                int rows1 = cmd1.ExecuteNonQuery();
                con.Close();

                numericUpDown11.Maximum = numericUpDown11.Maximum - numericUpDown11.Value;
                itm = new ListViewItem(arl);
                listView1.Items.Add(itm);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int m = 169;
            arl[0] = "เซ็ต สีชมพูซากุระ";
            arl[1] = numericUpDown12.Value.ToString();

            product += $"เซ็ต สีชมพูซากุระ[{numericUpDown12.Value}]\n ";
            num += Convert.ToInt32(numericUpDown12.Value);
            money += 169 * Convert.ToInt32(numericUpDown12.Value);

            arl[2] = 169 + " ";
            if (numericUpDown12.Value == 0)
            {
                MessageBox.Show("สินค้าหมด");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                con.Open();
                String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label23.Text}','{numericUpDown12.Value}','{m}')";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                int rows1 = cmd1.ExecuteNonQuery();
                con.Close();

                numericUpDown12.Maximum = numericUpDown12.Maximum - numericUpDown12.Value;
                itm = new ListViewItem(arl);
                listView1.Items.Add(itm);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int m = 99;
            arl[0] = "สร้อยข้อมือ สีม่วงฟ้า";
            arl[1] = numericUpDown13.Value.ToString();

            product += $"สร้อยข้อมือ สีม่วงฟ้า[{numericUpDown13.Value}]\n ";
            num += Convert.ToInt32(numericUpDown13.Value);
            money += 99 * Convert.ToInt32(numericUpDown13.Value);

            arl[2] = 99 + " ";
            if (numericUpDown13.Value == 0)
            {
                MessageBox.Show("สินค้าหมด");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                con.Open();
                String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label25.Text}','{numericUpDown13.Value}','{m}')";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                int rows1 = cmd1.ExecuteNonQuery();
                con.Close();

                numericUpDown13.Maximum = numericUpDown13.Maximum - numericUpDown13.Value;
                itm = new ListViewItem(arl);
                listView1.Items.Add(itm);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int m = 99;
            arl[0] = "สร้อยข้อมือ สีม่วง";
            arl[1] = numericUpDown14.Value.ToString();

            product += $"สร้อยข้อมือ สีม่วง[{numericUpDown14.Value}]\n ";
            num += Convert.ToInt32(numericUpDown14.Value);
            money += 99 * Convert.ToInt32(numericUpDown14.Value);

            arl[2] = 99 + " ";
            if (numericUpDown14.Value == 0)
            {
                MessageBox.Show("สินค้าหมด");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                con.Open();
                String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label27.Text}','{numericUpDown14.Value}','{m}')";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                int rows1 = cmd1.ExecuteNonQuery();
                con.Close();

                numericUpDown14.Maximum = numericUpDown14.Maximum - numericUpDown14.Value;
                itm = new ListViewItem(arl);
                listView1.Items.Add(itm);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int m = 99;
            arl[0] = "สร้อยข้อมือ สีโรสโกล";
            arl[1] = numericUpDown15.Value.ToString();

            product += $"สร้อยข้อมือ สีโรสโกล[{numericUpDown15.Value}]\n ";
            num += Convert.ToInt32(numericUpDown15.Value);
            money += 99 * Convert.ToInt32(numericUpDown15.Value);

            arl[2] = 99 + " ";
            if (numericUpDown15.Value == 0)
            {
                MessageBox.Show("สินค้าหมด");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                con.Open();
                String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label29.Text}','{numericUpDown15.Value}','{m}')";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                int rows1 = cmd1.ExecuteNonQuery();
                con.Close();

                numericUpDown15.Maximum = numericUpDown15.Maximum - numericUpDown15.Value;
                itm = new ListViewItem(arl);
                listView1.Items.Add(itm);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int m = 99;
            arl[0] = "สร้อยข้อมือ สีทอง";
            arl[1] = numericUpDown16.Value.ToString();

            product += $"สร้อยข้อมือ สีทอง[{numericUpDown16.Value}]\n ";
            num += Convert.ToInt32(numericUpDown16.Value);
            money += 99 * Convert.ToInt32(numericUpDown16.Value);

            arl[2] = 99 + " ";
            if (numericUpDown16.Value == 0)
            {
                MessageBox.Show("สินค้าหมด");
            }
            else
            {
                MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                con.Open();
                String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label31.Text}','{numericUpDown16.Value}','{m}')";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                int rows1 = cmd1.ExecuteNonQuery();
                con.Close();

                numericUpDown16.Maximum = numericUpDown16.Maximum - numericUpDown16.Value;
                itm = new ListViewItem(arl);
                listView1.Items.Add(itm);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "Size")
            {
                int m = 79;
                arl[0] = "แหวนเงิน สีม่วง";
                arl[1] = numericUpDown17.Value.ToString();

                product += $"แหวนเงิน สีม่วง[{comboBox1.Text}][{numericUpDown17.Value}]\n ";
                num += Convert.ToInt32(numericUpDown17.Value);
                money += 79 * Convert.ToInt32(numericUpDown17.Value);

                arl[2] = 79 + " ";

                if (numericUpDown17.Value == 0)
                {
                    MessageBox.Show("สินค้าหมด");
                }
                else
                {
                    MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                    con.Open();
                    String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label33.Text}','{numericUpDown17.Value}','{m}')";
                    MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                    int rows1 = cmd1.ExecuteNonQuery();
                    con.Close();

                    numericUpDown17.Maximum = numericUpDown17.Maximum - numericUpDown17.Value;
                    itm = new ListViewItem(arl);
                    listView1.Items.Add(itm);
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกไซส์แหวน");
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "Size")
            {
                int m = 79;
                arl[0] = "แหวนสีเงิน";
                arl[1] = numericUpDown18.Value.ToString();

                product += $"แหวนสีเงิน[{comboBox2.Text}][{numericUpDown18.Value}]\n ";
                num += Convert.ToInt32(numericUpDown18.Value);
                money += 79 * Convert.ToInt32(numericUpDown18.Value);

                arl[2] = 79 + " ";
                if (numericUpDown18.Value == 0)
                {
                    MessageBox.Show("สินค้าหมด");
                }
                else
                {
                    MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                    con.Open();
                    String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label35.Text}','{numericUpDown18.Value}','{m}')";
                    MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                    int rows1 = cmd1.ExecuteNonQuery();
                    con.Close();

                    numericUpDown18.Maximum = numericUpDown18.Maximum - numericUpDown18.Value;
                    itm = new ListViewItem(arl);
                    listView1.Items.Add(itm);
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกไซส์แหวน");
            }
                
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text != "Size")
            {
                int m = 79;
                arl[0] = "แหวนสีทอง";
                arl[1] = numericUpDown19.Value.ToString();

                product += $"แหวนสีทอง[{comboBox3.Text}][{numericUpDown19.Value}]\n ";
                num += Convert.ToInt32(numericUpDown19.Value);
                money += 79 * Convert.ToInt32(numericUpDown19.Value);

                arl[2] = 79 + " ";
                if (numericUpDown19.Value == 0)
                {
                    MessageBox.Show("สินค้าหมด");
                }
                else
                {
                    MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                    con.Open();
                    String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label37.Text}','{numericUpDown19.Value}','{m}')";
                    MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                    int rows1 = cmd1.ExecuteNonQuery();
                    con.Close();

                    numericUpDown19.Maximum = numericUpDown19.Maximum - numericUpDown19.Value;
                    itm = new ListViewItem(arl);
                    listView1.Items.Add(itm);
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกไซส์แหวน");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text != "Size")
            {
                int m = 79;
                arl[0] = "แหวนทอง สีม่วง";
                arl[1] = numericUpDown20.Value.ToString();

                product += $"แหวนทอง สีม่วง[{comboBox4.Text}][{numericUpDown20.Value}]\n ";
                num += Convert.ToInt32(numericUpDown20.Value);
                money += 79 * Convert.ToInt32(numericUpDown20.Value);

                arl[2] = 79 + " ";
                if (numericUpDown20.Value == 0)
                {
                    MessageBox.Show("สินค้าหมด");
                }
                else
                {
                    MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
                    con.Open();
                    String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{label39.Text}','{numericUpDown20.Value}','{m}')";
                    MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                    int rows1 = cmd1.ExecuteNonQuery();
                    con.Close();

                    numericUpDown20.Maximum = numericUpDown20.Maximum - numericUpDown20.Value;
                    itm = new ListViewItem(arl);
                    listView1.Items.Add(itm);
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกไซส์แหวน");
            }
        }

        //คำนวณราคา

        private void button22_Click(object sender, EventArgs e)
        {
            decimal gtotal = 0;
            foreach (ListViewItem lstItem in listView1.Items)   
            {
                gtotal += decimal.Parse(lstItem.SubItems[1].Text) * decimal.Parse(lstItem.SubItems[2].Text);
            }
            label42.Text = Convert.ToString(gtotal);
            textBox1.Text = label42.Text;
        }
        public static string sss;
        public static string qr;
        private void button21_Click(object sender, EventArgs e)
        {
            qr = textBox1.Text;
            MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin;");
            con.Open();
            String sql = $"INSERT INTO productorder (product,productcount,price) VALUES ('{product}','{num}','{money}')";
            sss = product;
            MySqlCommand cmd = new MySqlCommand(sql, con);
            int rows = cmd.ExecuteNonQuery();
            if (rows >= 0)
            {
                MessageBox.Show("สั่งสินค้าเรียบร้อยแล้ว");
            }
            {
                f3.Show();
                f3.qr.Text = textBox1.Text;
            }
        }

        //ลบรายการ

        private void button23_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(listView1.SelectedItems[0].Text);

            if(listView1.SelectedItems[0].Text== "ต่างหู สีชมพูซากุระ")
            {
                product = product.Replace($"ต่างหู สีชมพูซากุระ[{numericUpDown1.Value}]\n ", "");  /*จะถูกแทนที่ด้วยค่าว่าง*/
                num -= Convert.ToInt32(numericUpDown1.Value);      
                money -= 79 * Convert.ToInt32(numericUpDown1.Value);
            }
            else if (listView1.SelectedItems[0].Text == "ต่างหู สีม่วงลาเวนเดอร์")
            {
                product = product.Replace($"ต่างหู สีม่วงลาเวนเดอร์[{ numericUpDown2.Value}]\n ", "");
                num -= Convert.ToInt32(numericUpDown2.Value);
                money -= 79 * Convert.ToInt32(numericUpDown2.Value);
            }
            else if (listView1.SelectedItems[0].Text == "ต่างหู สีขาวไข่มุก")
            {
                product = product.Replace($"ต่างหู สีขาวไข่มุก[{numericUpDown3.Value}]\n ", "");
                num -= Convert.ToInt32(numericUpDown3.Value);
                money -= 79 * Convert.ToInt32(numericUpDown3.Value);
            }
            else if (listView1.SelectedItems[0].Text == "ต่างหู สีฟ้าสดใส")
            {
                product = product.Replace($"ต่างหู สีฟ้าสดใส[{numericUpDown4.Value}]\n ", "");
                num -= Convert.ToInt32(numericUpDown4.Value);
                money -= 79 * Convert.ToInt32(numericUpDown4.Value);
            }
            else if (listView1.SelectedItems[0].Text == "สร้อย สีชมพูซากุระ")
            {
                product = product.Replace($"สร้อย สีชมพูซากุระ[{numericUpDown5.Value}]\n ", "");
                num -= Convert.ToInt32(numericUpDown5.Value);
                money -= 99 * Convert.ToInt32(numericUpDown5.Value);
            }
            else if (listView1.SelectedItems[0].Text == "สร้อย สีฟ้าสดใส")
            {
                product = product.Replace($"สร้อย สีฟ้าสดใส[{numericUpDown6.Value}]\n ", "");
                num -= Convert.ToInt32(numericUpDown6.Value);
                money -= 99 * Convert.ToInt32(numericUpDown6.Value);
            }
            else if (listView1.SelectedItems[0].Text == "สร้อย สีม่วงลาเวนเดอร์")
            {
                product = product.Replace($"สร้อย สีม่วงลาเวนเดอร์[{numericUpDown7.Value}]\n ", "");
                num -= Convert.ToInt32(numericUpDown7.Value);
                money -= 99 * Convert.ToInt32(numericUpDown7.Value);
            }
            else if (listView1.SelectedItems[0].Text == "สร้อย สีขาวไข่มุก")
            {
                product = product.Replace($"สร้อย สีขาวไข่มุก[{numericUpDown8.Value}]\n ", "");
                num -= Convert.ToInt32(numericUpDown8.Value);
                money -= 99 * Convert.ToInt32(numericUpDown8.Value);
            }
            else if (listView1.SelectedItems[0].Text == "เซ็ต สีม่วงลาเวนเดอร์")
            {
                product = product.Replace($"เซ็ต สีม่วงลาเวนเดอร์[{numericUpDown9.Value}]\n ", "");
                num -= Convert.ToInt32(numericUpDown9.Value);
                money -= 169 * Convert.ToInt32(numericUpDown9.Value);
            }
            else if (listView1.SelectedItems[0].Text == "เซ็ต สีฟ้าสดใส")
            {
                product = product.Replace($"เซ็ต สีฟ้าสดใส[{numericUpDown10.Value}]\n ", "");
                num -= Convert.ToInt32(numericUpDown10.Value);
                money -= 169 * Convert.ToInt32(numericUpDown10.Value);
            }
            else if (listView1.SelectedItems[0].Text == "เซ็ต สีขาวไข่มุก")
            {
                product = product.Replace($"เซ็ต สีขาวไข่มุก[{numericUpDown11.Value}]\n ", "");
                num -= Convert.ToInt32(numericUpDown11.Value);
                money -= 169 * Convert.ToInt32(numericUpDown11.Value);
            }
            else if (listView1.SelectedItems[0].Text == "สร้อยข้อมือ สีม่วงฟ้า")
            {
                product = product.Replace($"สร้อยข้อมือ สีม่วงฟ้า[{numericUpDown12.Value}]\n ", "");
                num -= Convert.ToInt32(numericUpDown12.Value);
                money -= 99 * Convert.ToInt32(numericUpDown12.Value);
            }
            else if (listView1.SelectedItems[0].Text == "สร้อยข้อมือ สีม่วง")
            {
                product = product.Replace($"สร้อยข้อมือ สีม่วง[{numericUpDown13.Value}]\n ", "");
                num -= Convert.ToInt32(numericUpDown13.Value);
                money -= 99 * Convert.ToInt32(numericUpDown13.Value);
            }
            else if (listView1.SelectedItems[0].Text == "สร้อยข้อมือ สีโรสโกล")
            {
                product = product.Replace($"สร้อยข้อมือ สีโรสโกล[{numericUpDown14.Value}]\n ", "");
                num -= Convert.ToInt32(numericUpDown14.Value);
                money -= 99 * Convert.ToInt32(numericUpDown14.Value);
            }
            else if (listView1.SelectedItems[0].Text == "สร้อยข้อมือ สีทอง")
            {
                product = product.Replace($"สร้อยข้อมือ สีทอง[{numericUpDown15.Value}]\n ", "");
                num -= Convert.ToInt32(numericUpDown15.Value);
                money -= 99 * Convert.ToInt32(numericUpDown15.Value);
            }
            else if (listView1.SelectedItems[0].Text == "แหวนเงิน สีม่วง")
            {
                product = product.Replace($"แหวนเงิน สีม่วง[{numericUpDown16.Value}]\n ", "");
                num -= Convert.ToInt32(numericUpDown16.Value);
                money -= 169 * Convert.ToInt32(numericUpDown16.Value);
            }
            else if (listView1.SelectedItems[0].Text == "แหวนสีเงิน")
            {
                product = product.Replace($"แหวนสีเงิน[{numericUpDown17.Value}]\n ", "");
                num -= Convert.ToInt32(numericUpDown17.Value);
                money -= 169 * Convert.ToInt32(numericUpDown17.Value);
            }
            else if (listView1.SelectedItems[0].Text == "แหวนสีทอง")
            {
                product = product.Replace($"แหวนสีทอง[{numericUpDown18.Value}]\n ", "");
                num -= Convert.ToInt32(numericUpDown18.Value);
                money -= 169 * Convert.ToInt32(numericUpDown18.Value);
            }
            else if (listView1.SelectedItems[0].Text == "แหวนสีทอง")
            {
                product = product.Replace($"แหวนสีทอง[{numericUpDown19.Value}]\n ", "");
                num -= Convert.ToInt32(numericUpDown19.Value);
                money -= 169 * Convert.ToInt32(numericUpDown19.Value);
            }
            else if (listView1.SelectedItems[0].Text == "แหวนทอง สีม่วง")
            {
                product = product.Replace($"แหวนทอง สีม่วง[{numericUpDown20.Value}]\n ", "");
                num -= Convert.ToInt32(numericUpDown20.Value);
                money -= 169 * Convert.ToInt32(numericUpDown20.Value);
            }
            MessageBox.Show(product);

            listView1.Items.Remove(listView1.SelectedItems[0]);
        }
        private void showEquipment()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;

            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM stock";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();

            dataGridView1.DataSource = ds.Tables[0].DefaultView;  

        }
        private void Add(string pathimage, string name, int price)
        {
            //  MessageBox.Show("P==> " + pathimage);
            string newFileName = pathimage.Replace("\\", "\\\\");
            MySqlConnection conn = databaseConnection();
            string sql = $"INSERT INTO stock (orders,amount,price,image) VALUES (' {name} ',' { amount.Text} ',' {price}','{newFileName}')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();

            int rows = cmd.ExecuteNonQuery();
            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("เพิ่มสินค้าเรียบร้อย");
                resetdata();
                showEquipment();
            }
        }
        private void resetdata()
        {
            txtname.Clear();
            txtprice.Clear();
            txtpath.Text = "";
            pictureBox1.Image = null;
        }
        private void Edit(string pathimage, string name, int price)
        {

            int selectedRow = dataGridView1.CurrentCell.RowIndex;
            int editId = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["id"].Value);
            string newFileName = pathimage.Replace("\\", "\\\\");
            MySqlConnection conn = databaseConnection();
            string sql = "UPDATE stock SET orders = '" + name + "',price = '" + price + "',amount = '" + amount.Text + "',image = '" + newFileName + "' WHERE id = '" + editId + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();

            int rows = cmd.ExecuteNonQuery();
            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("แก้ไขสินค้าเสร็จแล้วค่ะ");
                resetdata();
                showEquipment();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Shown(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            string pathimage = "C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_product\\" + Path.GetFileName(txtpath.Text);
            string name = txtname.Text;
            int price = Convert.ToInt32(txtprice.Text);
            Add(pathimage, name, price);
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.png; *.jpg; *.jpeg; *.gif; *.bmp)| *.png; *.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox21.Image = new Bitmap(open.FileName);
                txtpath.Text = open.FileName;
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string pathimage = "C:\\Users\\Lenovo\\OneDrive\\Desktop\\add_product\\" + Path.GetFileName(txtpath.Text);
            string name = txtname.Text;
            int price = Convert.ToInt32(txtprice.Text);
            Edit(pathimage, name, price);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.CurrentCell.RowIndex;    /* เมื่อคลิกรายการสินค้า ก็จะนำค่า id มาเก็บไว้ในตัวแปร deleteid */
            int deleteId = Convert.ToInt32(dataGridView1.Rows[selectedRow].Cells["id"].Value);

            MySqlConnection conn = databaseConnection();  

            String sql = "DELETE FROM stock WHERE id = '" + deleteId + "'";  /* เมื่อกดลบ ก็จะลบจาก stock ตำแหน่งที่ id ที่เราเลือกรายการนั้น */

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("ลบข้อมูลสำเร็จ");

                showEquipment();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 MForm = new Form9();
            MForm.ShowDialog();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 MForm = new Form1();
            MForm.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;  /*ตอนที่เราคลิกแถวในหัวdataGridView1 ตารางต่างๆก็จะมาโชว์ที่ textbox ต่างๆ*/
            string pathimage = @"C:\Users\Lenovo\OneDrive\Desktop\add_product\" + Path.GetFileName(txtpath.Text);
            txtpath.Text = dataGridView1.Rows[e.RowIndex].Cells["image"].FormattedValue.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells["orders"].FormattedValue.ToString();
            txtprice.Text = dataGridView1.Rows[e.RowIndex].Cells["price"].FormattedValue.ToString();
            amount.Text = dataGridView1.Rows[e.RowIndex].Cells["amount"].FormattedValue.ToString();


            if (Path.GetFileName(txtpath.Text) != "")
            {
                string newFileName = txtpath.Text;  /* เราจะเช็คว่า ถ้า txtpath ไม่เท่ากับค่าว่าง ก็นำค่าที่อยู่ในtxtpath ไปไว้ใน newFileName*/
                pictureBox21.Image = new Bitmap(newFileName); /* pictureBox ก็จะแสดงภาพขึ้นมา จาก newFileName*/
            }
        }
       //ซื้อสินค้าใหม่
        private void button27_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(txtprice.Text);
            arl[2] = a * numericUpDown21.Value + "";
            arl[0] = txtname.Text;
            arl[1] = numericUpDown21.Value.ToString();

            product += txtname.Text + "\n";
            num += Convert.ToInt32(numericUpDown21.Value);
            money += Convert.ToInt32(txtprice.Text);

            string p = a * numericUpDown21.Value + " ฿";
            
            {
                MySqlConnection con = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=userandlogin");
                con.Open();
                
                String sql1 = $"INSERT INTO shoppingclass (name,amount,price) VALUES ('{txtname.Text}','{numericUpDown21.Value}','{p}')";
                MySqlCommand cmd1 = new MySqlCommand(sql1, con);
                int rows1 = cmd1.ExecuteNonQuery();

                con.Close();
                itm = new ListViewItem(arl);
                listView1.Items.Add(itm);
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form = new Form4(); /*จะเด้งไปหน้าวิธีการสั่งซื้อสินค้า*/
            form.ShowDialog();
            this.Close();
        }
    }
}
