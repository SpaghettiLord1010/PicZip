using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PicZip
{
    public partial class Form1 : Form
    {

        String ZipPath = "ZipPath";
        String PicPath = "PicPath";
        String ZipPickPath = "ZipPickPath";


        public Form1()
        {
            InitializeComponent();
            //check if Button should be enabled
            if (ZipPath != "ZipPath" & PicPath != "PicPath")
            {
                button3.Enabled = true;
                Console.Write("Button Enabled!");
            }
            else
            {
                button3.Enabled = false;
                Console.Write("Button Disabled!");
            }
            pictureBox1.ImageLocation = PicPath;
        }

        public void EnableButton()
            {
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Please Select a Picture File!";
            openFileDialog1.ShowDialog();
            PicPath = openFileDialog1.FileName;


//check if Button should be enabled
            if (ZipPath != "ZipPath" & PicPath != "PicPath")
            {
                button3.Enabled = true;
                Console.Write("Button Enabled!");
            }
            else
            {
                button3.Enabled = false;
                Console.Write("Button Disabled!");
            }
            pictureBox1.ImageLocation = PicPath;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Please Select a ZIP-File!";
            openFileDialog1.ShowDialog();
            ZipPath = openFileDialog1.FileName;
            Console.WriteLine("wooorks");

//check if Button should be enabled
            if (ZipPath != "ZipPath" & PicPath != "PicPath")
            {
                button3.Enabled = true;
                Console.Write("Button Enabled!");
            }
            else
            {
                button3.Enabled = false;
                Console.Write("Button Disabled!");
            }
            pictureBox1.ImageLocation = PicPath;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            String PicExtension = "";
            PicExtension = Path.GetExtension(PicPath);
            saveFileDialog1.Title = "Please select the output directory and name - Save with the extension "+PicExtension+"!";
            saveFileDialog1.ShowDialog();
            saveFileDialog1.DefaultExt = PicExtension;
            ZipPickPath = saveFileDialog1.FileName;
            

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C copy /b "+PicPath+" + "+ ZipPath+" "+ZipPickPath;
            Console.WriteLine(startInfo.Arguments);
            process.StartInfo = startInfo;
            process.Start();


        }
    }
}
