using GhostHunter.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GhostHunter
{
    public partial class Form2 : Form
    {

        protected Image myImage;

        Random rand = new Random();
        List<PictureBox> items = new List<PictureBox>();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }



        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            // Show the Open File dialog. If the user clicks OK, load the
            // picture that the user chose.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                myImage= Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = myImage;

                pictureBox1.Visible = true;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clear the picture.
            pictureBox1.Image = null;
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            // Show the color dialog box. If the user clicks OK, change the
            // PictureBox control's background to the color the user chose.
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //close the form
            this.Close();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // If the user selects the Stretch check box, 
            // change the PictureBox's
            // SizeMode property to "Stretch". If the user clears 
            // the check box, change it to "Normal".
            if (checkBox1.Checked)
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void greyscaleButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = GhostMaker.MakeGreyscale((Bitmap)myImage);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void findGhostsButton_Click(object sender, EventArgs e)
        {
            GhostMaker ghostMaker = new GhostMaker((Bitmap)myImage, @"C:\Users\Student\workspace\darya-taraban-side-projects\GhostHunter\ghost.bmp");

            pictureBox1.Image = ghostMaker.AddGhosts();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void MakePictureBox()
        {
            PictureBox newPic = new PictureBox();
            newPic.Height = 50;
            newPic.Width = 50;
            newPic.BackColor = Color.White;
            int x = rand.Next(10, this.ClientSize.Width - newPic.Width);
            int y = rand.Next(10, this.ClientSize.Height - newPic.Height);
            newPic.Location = new Point(x, y);
            newPic.Click += NewPic_Click;
            items.Add(newPic);
            this.Controls.Add(newPic);
        }
        private void NewPic_Click(object sender, EventArgs e)
        {
            PictureBox temPic = sender as PictureBox;
            items.Remove(temPic);
            this.Controls.Remove(temPic);
            lblItemCount.Text = "Items: " + items.Count();
        }
        private void TimerEvent(object sender, EventArgs e)
        {
            MakePictureBox();
            lblItemCount.Text = "Items: " + items.Count();
        }

        private void huntGhostsButton_Click(object sender, EventArgs e)
        {
            GameTimer.Enabled = true;
            GameTimer.Start();
            lblItemCount.Visible = true;
            this.Controls.Remove(tableLayoutPanel1);
            //tableLayoutPanel1.Enabled = false;
            this.BackgroundImage = myImage;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Visible = false;
        }
    }
}
