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

namespace Homework
{
    public partial class Form1 : Form 
    {
        float[] array; 
        int razmer;
        readonly string mydocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        FileStream file = null;

        float[,] array2;
        int n;
        int l;
        private char[] tempString;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            razmer = int.Parse(textBox1.Text);  
            array = new float[razmer]; 
            Random rnd = new Random(); 
            for (int i = 0; i < razmer; i++) 
            {
                array[i] = rnd.Next(0, 100); 
                output.Text += array[i].ToString() + " "; 
            }

        }      
        private void button2_Click(object sender, EventArgs e)
        {
            output.Text = null; 
            array = null; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            n = int.Parse(textBox2.Text);
            l = int.Parse(textBox3.Text);
            array2 = new float[n,l];
            Random rnd2 = new Random();

            file = new FileStream(mydocs + @"\Array2.txt", FileMode.OpenOrCreate);


            for (int i = 0; i < n; ++i)
            {
                string str;
                str = "";
                Process.Start(mydocs + @"\Array2.txt");
                for (int j = 0; j < l; ++j)
                {
                    array2[i, j] = rnd2.Next(0, 100);
                    str += array2[i, j].ToString() + " " ;
                }
                str += "\r\n";
                output2.Text += str;
                byte[] tempBytes = Encoding.Default.GetBytes(str);
                file.Write(tempBytes, 0, tempBytes.Length);
            }
            if (file != null)
                file.Close();
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            output2.Text = null;
            array2 = null;
           
          
            file = new FileStream(mydocs + @"\Array2.txt", FileMode.OpenOrCreate);
            file.SetLength(0);
            array2 = null;
            Process.Start(mydocs + @"\Array2.txt");
            if (file != null)
            file.Close();
           
        }

    }
}
