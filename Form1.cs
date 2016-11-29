using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public partial class Form1 : Form
    {
        int count;// คือตัวแปรลำดับ
        int result1;//คือตัวแปรราคา
        int result2;//คือตัวแปรคงเหลือ
        public Form1()
        {
            InitializeComponent();//คำสั่งคอมดพเน้น
            result1 = 0;//ค่าเริ่มต้นของราคาคือ 0 
            result2 = 0;//ค่าเริ่มต้นของค่าคงเหลือคือ 0
            count = 1;//ค่าเริ่มต้นของลำดับคือ 1 
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int s1 = int.Parse(textBox1.Text);// s1 คือราคาสินค้าที่รับค่ามาจาก TextBox1
                int p1 = int.Parse(textBox2.Text);//p1 คือส่วนลดที่รับค่ามาจาก TextBox2
                int sum = s1 - (s1 * p1) / 100;//sumคือ ผลรวมทั้งหมด คือ = เอาs1คือราคามาลบกับสูตรการหาเปอร์เซ็น
                textBox3.Text = "" + sum;//จะแสดงผลรวมของ sum

                result1 = result1 + s1;//นำราคาสินค้ามาบวกกันแล้วนำค่าไปเก็บไว้ใน result1
                result2 = result2 + sum;//นำผลรวมมาบวกกันแล้วเอาไปเก็บไว้ที่ result2
                if (count == 1)//ลำดับจะเท่ากับ 1
                {
                    dataGridView1.Rows.Add(count, s1, p1, sum);//คือตัวแอดหรือเพิ่มค่าเข้าไป
                }
                else
                {
                    dataGridView1.Rows.Insert(count-1, count, s1, p1, sum);//คือตัวแทรกค่าเข้าไป
                    dataGridView1.Rows.RemoveAt(count);//คือนำค่าออกจากโปรแกรม
                }
                dataGridView1.Rows.Add("รวม", result1, "", result2);// แสดงผลรวมที่บวกกัน

                if (s1 < p1) { MessageBox.Show("ราคาสินค้าต้องมากกว่าเปอร์เซ็น"); textBox3.Text = " "; }//ราคาสินค้าต้องไม่น้อยกว่าส่วนลด
                if (p1 > 100) { MessageBox.Show("เปอร์เซ็นต้องไม่เกิน 100"); textBox3.Text = " "; }//เปอร์เซ็นต้องไม่เกิน 100
                if (s1 < 0) { MessageBox.Show("ราคาสินค้าไม่น้อยกว่า 0 "); textBox3.Text = " "; }// ราาสินค้าต้องไม่น้อยดว่า 0
                if (p1 < 0) { MessageBox.Show("เปอร์เซ็นต้องไม่น้อยกว่า 0 "); textBox3.Text = " "; }// เปอร์เซ็นต้องไม่น้อยกว่า 0
                count++; 
            } catch (Exception)//ป้องกันความผิดพลด

            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้อง"); // ถ้าข้อมูลไม่ถูกต้องหรือผิดพลาดก็จะมาแสดงผตรงนี้
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
