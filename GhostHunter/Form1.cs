using GhostHunter.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GhostHunter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string filepath = @"C:\Users\Student\workspace\darya-taraban-side-projects\GhostHunter\A-Haunted-House-in-Ohio.jpg";
            //read image
            Bitmap bmp = new Bitmap(filepath);

            //load original image in picturebox1
            pictureBox1.Image = Image.FromFile(filepath);

            bmp = GhostMaker.MakeGreyscale(bmp);
            

            //load grayscale image in picturebox2
            pictureBox2.Image = bmp;

            GhostMaker ghostMaker = new GhostMaker(bmp, @"C:\Users\Student\workspace\darya-taraban-side-projects\GhostHunter\ghost.bmp");
            pictureBox3.Image = ghostMaker.AddGhosts();
            //write the grayscale image
            bmp.Save(@"C:\Users\Student\workspace\darya-taraban-side-projects\GhostHunter\Taj_gray.bmp");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
