using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Speech.Synthesis;

namespace Robotic_Driver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            getcomport();
        }

        private void getcomport()
        {
            string[] port = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(port);
            try {
                comboBox1.Text = port[0].ToString();
                button1.Text = "Found port !";
            }
            catch
            {
                button1.Text = "Not found any port !";
                SpeechSynthesizer mm = new SpeechSynthesizer();
                mm.Speak("Not found any port !");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Prass W , D , A , D and control it ";
            SpeechSynthesizer nn = new SpeechSynthesizer();
            //  nn.Speak("Pass W , D , A , D and control it ");
          
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void KeyDOWN(object sender, KeyEventArgs e) //sdsad
        {
           //  richTextBox1.Text.Length = toolStripStatusLabel5.Text;
            toolStripStatusLabel5.Text = richTextBox1.Text.Length.ToString();
            //    string df = richTextBox1.Text.Length.ToString();
            richlan();
            try {
                if (e.KeyCode == Keys.W)
                {
                    UP.Visible = true;
                    DOWN.Visible = false;
                    LAFT.Visible = false;
                    RIGHT.Visible = false;
                    serialPort1.Write("w");
                    richTextBox1.Text += "Send Serial : W  \n ";
                    richTextBox1.ForeColor = Color.Lime;
                    richlan();
                }
                else if (e.KeyCode == Keys.S)
                {
                    UP.Visible = false;
                    DOWN.Visible = true;
                    LAFT.Visible = false;
                    RIGHT.Visible = false;
                    serialPort1.Write("s");
                    richTextBox1.Text += "Send Serial : S  \n ";
                    richTextBox1.ForeColor = Color.Lime;
                    richlan();
                }
                if (e.KeyCode == Keys.D)
                {
                    UP.Visible = false;
                    DOWN.Visible = false;
                    LAFT.Visible = false;
                    RIGHT.Visible = true;
                    serialPort1.Write("d");
                    richTextBox1.Text += "Send Serial : D \n ";
                    richTextBox1.ForeColor = Color.Lime;
                    richlan();
                }
                else if (e.KeyCode == Keys.A)
                {
                    UP.Visible = false;
                    DOWN.Visible = false;
                    LAFT.Visible = true;
                    RIGHT.Visible = false;
                    serialPort1.Write("a");
                    richTextBox1.Text += "Send Serial : A \n ";
                    richTextBox1.ForeColor = Color.Lime;
                    richlan();
                }
            }
            catch
            {
                richTextBox1.Text += "Connection error ! (down) \n";
                richTextBox1.ForeColor = Color.Red;
                richlan();
            }

        }

        private void richlan()        ///lanth
        {
            toolStripStatusLabel5.Text = richTextBox1.Text.Length.ToString();
            if (richTextBox1.Text.Length > 500)
            {
                richTextBox1.Text = "";
            }
        }

        private void KeyUP(object sender, KeyEventArgs e) /// dasdasd
        {
            UP.Visible = false;
            DOWN.Visible = false;
            LAFT.Visible = false;
            RIGHT.Visible = false;
            richlan();

            try

            {
                if (e.KeyCode == Keys.W)
                {
                    serialPort1.Write("1");
                    richTextBox1.Text += "Send Serial : 1 \n ";
                    richTextBox1.ForeColor = Color.Lime;
                    richlan();
                }
                else if (e.KeyCode == Keys.S)
                {
                    serialPort1.Write("2");
                    richTextBox1.Text += "Send Serial : 2 \n ";
                    richTextBox1.ForeColor = Color.Lime;
                    richlan();

                }
                if (e.KeyCode == Keys.A)
                {
                    serialPort1.Write("4");
                    richTextBox1.Text += "Send Serial : 4 \n ";
                    richTextBox1.ForeColor = Color.Lime;
                    richlan();

                }
                else if (e.KeyCode == Keys.D)
                {
                    serialPort1.Write("4");
                    richTextBox1.Text += "Send Serial : 4 \n ";
                    richTextBox1.ForeColor = Color.Lime;
                    richlan();

                }
            }
            catch
            {
                richTextBox1.Text  += "Connection error ! (up)  \n ";
                richTextBox1.ForeColor = Color.Red;
                toolStripStatusLabel5.Text = richTextBox1.Text.Length.ToString();
                richlan();

                
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
         //   groupBox3.Enabled = false;
            button1.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                checkBox1.Text = "Disconnect";
                richlan();
                richTextBox1.Text = "PortName: " + comboBox1.Text + "\n" + "BuadRate: " + comboBox2.Text+ "\n";
                richTextBox1.ForeColor = Color.Yellow;

                try
                {
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);
                    serialPort1.Open();
                  //  toolStripProgressBar1.Value = 50;
                    groupBox2.Enabled = true;
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                   
                  
                    button1.Enabled = true;
                    UP.Visible = false;
                    DOWN.Visible = false;
                    LAFT.Visible = false;
                    RIGHT.Visible = false;
                    button1.Text = "Your robot is connected ! \n Click here and control the robot ";
                    toolStripProgressBar1.Value = 100;
                    SpeechSynthesizer nn = new SpeechSynthesizer();
                    nn.Speak("Your robot is connected ! ");


                }
                catch (Exception er)
                {
                    checkBox1.Text = "Connect";
                    button1.Text = "Robot not found becouse " + er.Message + " You can reopen this software";
                    SpeechSynthesizer nn = new SpeechSynthesizer();
                    nn.Speak("Robot not found becouse " + er.Message + " You can reopen this software");
                }

            }
            else
            {

                serialPort1.Close();
                checkBox1.Text = "Connect";
                toolStripProgressBar1.Value = 0;
                groupBox2.Enabled = false;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                serialPort1.Write(textBox1.Text);
                richTextBox1.Text += "Send Serial: " + textBox1.Text + "\n";
                richTextBox1.ForeColor = Color.Lime;
                richlan();
                textBox1.Text = "";
            }
            catch
            {
                richTextBox1.Text += "Not send \n";
                richTextBox1.ForeColor = Color.Red;
                richlan();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void restartAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkBox1.Text = "Disconnect";
            richlan();
            richTextBox1.Text = "PortName: " + comboBox1.Text + "\n" + "BuadRate: " + comboBox2.Text + "\n";
            richTextBox1.ForeColor = Color.Yellow;

            try
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);
                serialPort1.Open();
                //  toolStripProgressBar1.Value = 50;
                groupBox2.Enabled = true;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;


                button1.Enabled = true;
                UP.Visible = false;
                DOWN.Visible = false;
                LAFT.Visible = false;
                RIGHT.Visible = false;
                button1.Text = "Your robot is connected ! \n Click here and control the robot ";
                toolStripProgressBar1.Value = 100;
                SpeechSynthesizer nn = new SpeechSynthesizer();
                nn.Speak("Your robot is connected ! ");


            }
            catch (Exception er)
            {
                checkBox1.Text = "Connect";
                button1.Text = "Robot not found becouse " + er.Message + " You can reopen this software";
                SpeechSynthesizer nn = new SpeechSynthesizer();
                nn.Speak("Robot not found becouse " + er.Message + " You can reopen this software");
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            checkBox1.Text = "Connect";
            toolStripProgressBar1.Value = 0;
            groupBox2.Enabled = false;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void arduinoProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 nn = new Form2();
            nn.Show();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About wer = new About();
            wer.ShowDialog();
        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi I'm Tonmoy, if you want to contact with me then you can call me .  Phone : +8801776402271 \n Email : Tonmoygfx56@gmail.com \n fb : fb.com/mohimenul.tonmoy \n ", "Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void connectToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            checkBox1.Text = "Disconnect";
            richlan();
            richTextBox1.Text = "PortName: " + comboBox1.Text + "\n" + "BuadRate: " + comboBox2.Text + "\n";
            richTextBox1.ForeColor = Color.Yellow;

            try
            {
                serialPort1.PortName = comboBox1.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);
                serialPort1.Open();
                //  toolStripProgressBar1.Value = 50;
                groupBox2.Enabled = true;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;


                button1.Enabled = true;
                UP.Visible = false;
                DOWN.Visible = false;
                LAFT.Visible = false;
                RIGHT.Visible = false;
                button1.Text = "Your robot is connected ! \n Click here and control the robot ";
                toolStripProgressBar1.Value = 100;
                SpeechSynthesizer nn = new SpeechSynthesizer();
                nn.Speak("Your robot is connected ! ");


            }
            catch (Exception er)
            {
                checkBox1.Text = "Connect";
                button1.Text = "Robot not found becouse " + er.Message + " You can reopen this software";
                SpeechSynthesizer nn = new SpeechSynthesizer();
                nn.Speak("Robot not found becouse " + er.Message + " You can reopen this software");
            }
        }

        private void disconnectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            checkBox1.Text = "Connect";
            toolStripProgressBar1.Value = 0;
            groupBox2.Enabled = false;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
        }

        private void restartAppToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void arduinoProgramToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 nn = new Form2();
            nn.Show();
        }

        private void aboutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            About wer = new About();
            wer.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void contractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi I'm Tonmoy, if you want to contact with me then you can call me .  Phone : +8801776402271 \n Email : Tonmoygfx56@gmail.com \n fb : fb.com/mohimenul.tonmoy \n ", "Contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                webBrowser1.Visible = true;
                string WebPage = textBox2.Text.Trim();
                webBrowser1.Navigate(WebPage);

                checkBox2.Text = "Disconnect";
            }
            else
            {
                checkBox2.Text = "Connect";
               /// webBrowser1.Navigate("#");
                  webBrowser1.Visible = false;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
    
}
