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
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace OpenRtssText
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        static uint positionX = 0;
        static uint positionY = 0;
        static string TEXT = "";

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        private void loadSetting()
        {
            string settingText = System.IO.File.ReadAllText(@"setting.json");
            JObject setting = JObject.Parse(settingText);
            positionX = (uint)setting["x"];
            positionY = (uint)setting["y"];
            TEXT = (string)setting["text"];
        }
        private void saveSetting()
        {
            string settingText = System.IO.File.ReadAllText(@"setting.json");
            JObject setting = JObject.Parse(settingText);
            setting["x"] = positionX;
            setting["y"] = positionY;
            setting["text"] = TEXT;
            System.IO.File.WriteAllText("setting.json",JsonConvert.SerializeObject(setting));
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            RTSSHandler.RunRTSS();
            loadSetting();
            updateRTSS();
        }
        private static void updateRTSS()
        {
            RTSSHandler.Print(TEXT);
            RTSSHandler.Update(positionX,positionY);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RTSSHandler.Print("");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadSetting();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // x--
            positionX--;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //x++
            positionX++;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //y--
            positionY--;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //y++
            positionY++;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            saveSetting();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            updateRTSS();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //x-10
            positionX = positionX - 10;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //x+10
            positionX = positionX + 10;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //y-10
            positionY = positionY - 10;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //y+10
            positionY = positionY + 10;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TEXT = textBox1.Text;
        }
    }
}
