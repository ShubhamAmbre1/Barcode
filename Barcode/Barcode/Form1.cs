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
using System.IO;
using System.Drawing.Imaging;


namespace Barcode
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-0IUBBGV9\\SQLEXPRESS;Initial Catalog=npb;Persist Security Info=True;User ID=sa;Password=sa@1234");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string barcode = textBox1.Text;
            Bitmap bitmap = new Bitmap(barcode.Length * 40, 150);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Font ofont = new System.Drawing.Font("IDAHC39M Code 39 Barcode", 20);
                PointF point = new PointF(2f, 2f);
                SolidBrush black = new SolidBrush(Color.Black);
                SolidBrush white = new SolidBrush(Color.White);
                graphics.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
                graphics.DrawString("*" + barcode + "*", ofont, black, point);

            }
            using(MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                pictureBox1.Image = bitmap;
                pictureBox1.Height = bitmap.Height;
                pictureBox1.Width = bitmap.Width;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "JPEG(*.JPEG)|*.xlsx" })
            {
                if (pictureBox1 == null)
                    return;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(saveFileDialog.FileName);
                }
            }
        }
    }
}
