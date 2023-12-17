using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder; //Downloaded


namespace QR_Scanning
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)// Generate 
        {
            QRCodeGenerator QR = new QRCodeGenerator();
            
            QRCodeData data = QR.CreateQrCode(textBox1.Text, QRCodeGenerator.ECCLevel.Q); // for giving the data tho the QR code first parameter is the info i want to give to the QR code ECCL level is the level accept error
            
            QRCode code = new QRCode(data);// passing the data we want to the QRCode  we created

            pictureBox1.Image = code.GetGraphic(5); // get graphics is used to show the image, the 5 is the qulaity of the image
        }

        private void button2_Click(object sender, EventArgs e)// save button
        {
            if(pictureBox1.Image != null) { 
            String savePath = @"C:\Users\Zxshx\OneDrive\Documents\Imagesss\savedQR.png";
            pictureBox1.Image.Save(savePath);
            }
            else
            {
                MessageBox.Show("error");
            }
        }

        private void button3_Click(object sender, EventArgs e)//color
        {
            QRCodeGenerator QR = new QRCodeGenerator();

            QRCodeData data = QR.CreateQrCode(textBox1.Text, QRCodeGenerator.ECCLevel.Q);  

            QRCode code = new QRCode(data);

            Bitmap QRImage = code.GetGraphic(20,Color.Red, Color.Green, true);//  1- color of QR code, 2 color of the border, true is for multy color

            pictureBox1.Image = QRImage;
        }

        private void button4_Click(object sender, EventArgs e) // logo button 
        {
            QRCodeGenerator QR = new QRCodeGenerator();

            QRCodeData data = QR.CreateQrCode(textBox1.Text, QRCodeGenerator.ECCLevel.Q);

            QRCode code = new QRCode(data);

            string path = @"C:\Users\Zxshx\OneDrive\Documents\Pictures\Screenshots\Screenshot 2023-09-18 102631.png"; 
         
            Bitmap QRImage = code.GetGraphic(20, Color.Red, Color.Green,(Bitmap) Bitmap.FromFile(path)); // type casting adn then pass the image it self

            pictureBox1.Image = QRImage;
        }
    }
}
