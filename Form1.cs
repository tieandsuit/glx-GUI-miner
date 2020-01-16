using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace launcher


{
    public partial class Form1 : Form
       
    {
        PerformanceCounter perfCPUCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total"); // get CPU usage % 

        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);

        private static string[] MiningURL = { " Galaxia.MainNet" }; // Nodes to connect miner 

        private static string[] Executables = { "xi-miner.exe" }; // Launch miner 

        private static Process CPUMiner;
        private static Timer T;
        private static Boolean FirstTime;


        public Form1()
        {
            InitializeComponent();

            Text += " v" + Application.ProductVersion;
            
            T = new Timer();
            
            T.Interval = 60000;

            FirstTime = false;

            comboBox1.SelectedIndex = Config.ConfigData.Location;
            textBox2.Text = Config.ConfigData.WorkerName;
            comboBox2.SelectedIndex = Config.ConfigData.Extension;
            numericUpDown1.Value = Config.ConfigData.Threads;
        }


       


        private void button1_Click(object sender, EventArgs e)
        {
            if (CPUMiner != null)
            {
                // stop miner
                CPUMiner.Kill();
                CPUMiner.Close();
                CPUMiner = null;

                ResetButtonText();
                return;
            }
            
            

            button1.Text = "Please wait...";
            button1.Update();

            string Worker = textBox2.Text.Trim();


            string FileName = "" + Executables[comboBox2.SelectedIndex];

            string CommandLine = " -r -i 30  --network " + MiningURL[comboBox1.SelectedIndex] + " -a " + Worker + " -t " + numericUpDown1.Value.ToString(); // miner launcher with commands ./xel_miner.exe -o <node> -P "<secret_phrase>" -t <num_threads>


            CPUMiner = Process.Start(FileName, CommandLine);
            CPUMiner.EnableRaisingEvents = true;
            CPUMiner.Exited += CPUMiner_Exited;

            if (!FirstTime)
            {
                T.Start();
                FirstTime = true;
            }

            Config.ConfigData.WorkerName = textBox2.Text.Trim();
            Config.ConfigData.Location = comboBox1.SelectedIndex;
            Config.ConfigData.Threads = decimal.ToInt32(numericUpDown1.Value);
            Config.ConfigData.Extension = comboBox2.SelectedIndex;
            Config.Commit();

            button1.Text = "Stop";
        }

        
        private void CPUMiner_Exited(object sender, EventArgs e)
        {
            CPUMiner.Close();
            CPUMiner = null;

            ResetButtonText();
        }


        delegate void ResetButtonTextCallback();

        private void ResetButtonText()
        {
            if (this.button1.InvokeRequired)
            {
                ResetButtonTextCallback d = new ResetButtonTextCallback(ResetButtonText);
                this.Invoke(d, new object[] { });
            }
            else
            {
                this.button1.Text = "Start";
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.github.com");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void rectangleShape2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/tieandsuit/gxi-GUI-miner");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/Galaxia_GLX");
       
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.co/wC1slvsmAB?amp=1");
       
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/tieandsuit/gxi-GUI-miner");
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://gitlab.com/galaxia-project/app/pywallet/-/tags");
        }

        private void explorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://galaxia.hopto.org/");
        }

        private void twiterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/Galaxia_GLX");
        }

        private void discordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://chat.galaxia-project.com/");
        }

        private void bitcoinTalkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://bitcointalk.org/index.php?topic=5172572");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            float fcpu = pCPU.NextValue();
            ProgressBarCPU.Value = (int)fcpu;
            lblCPU.Text = string.Format("{0:0.00}%", fcpu);
        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void CPU_Click(object sender, EventArgs e)
        {

        }
    }
}
