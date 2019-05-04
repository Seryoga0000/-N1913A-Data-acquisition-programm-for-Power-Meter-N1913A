using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ivi.Visa.Interop;
using BisnesWorkLib;
//using Keysight.KtRFPowerMeter.Interop;

namespace DevicesLib
{
    public partial class Setting : Form
    {
        WorkLogic WKL;
        public Setting(WorkLogic WKL)
        {
            InitializeComponent();
            this.WKL = WKL;
            WKL.PreName= PTB_PreFileName.Text;
            WKL.Max_number = Convert.ToInt32(NUD_max_number.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DeviceList.Items.Clear();
                ResourceManager rm = new ResourceManager();
                string[] addresses = rm.FindRsrc("USB?*INSTR");

                foreach (string adr in addresses)
                {
                    DeviceList.Items.Add(adr);
                }


                if (addresses.Length > 0)
                {
                    DeviceList.Text = addresses[0];
                    MemoryFormSettingParam.Device = DeviceList.Text;
                }
                DeviceList.DroppedDown = true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Неудалось найти приборы");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DeviceList.Items.Count < 1) { return; }

            if (WKL.IniN1913A(DeviceList.Text) == 1)
            {

                label1.Text = "Driver Initialized:";

                label2.Text = WKL.GetInformation();

                 
                label3.Text ="Current Value:  "+ WKL.GetDataString();

            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public decimal max_number
        {
            get
            {
                return NUD_max_number.Value;
            }
        }

        public decimal ResolData
        {
            get
            {
                return PNUD_ResolData.Value;
            }
        }
        private void Setting_Load(object sender, EventArgs e)
        {
            //DeviceList.Text = MemoryFormSettingParam.Device;
            //label1.Text = MemoryFormSettingParam.LB1;

            //// Print a few IIviDriverIdentity properties
            //label2.Text = MemoryFormSettingParam.LB2;
            //label3.Text = MemoryFormSettingParam.LB3;
            //label4.Text = MemoryFormSettingParam.LB4;
            //label5.Text = MemoryFormSettingParam.LB5;
            //label6.Text = MemoryFormSettingParam.LB6;
            //label7.Text = MemoryFormSettingParam.LB7;
            //label8.Text = MemoryFormSettingParam.LB8;
            //label9.Text = MemoryFormSettingParam.LB9;

        }

        private void Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            this.Hide();
        }

        private void NUD_max_number_ValueChanged(object sender, EventArgs e)
        {
            WKL.Max_number = Convert.ToInt32(NUD_max_number.Value);
        }

        private void PTB_PreFileName_TextChanged(object sender, EventArgs e)
        {
            WKL.PreName = PTB_PreFileName.Text;
        }
        public event Action<bool> SplineChange;
        private void PCB_Spline_CheckedChanged(object sender, EventArgs e)
        {
            if (SplineChange != null) SplineChange(PCB_Spline.Checked);
        }
        public event Action<int> ResolChange; 
        private void PNUD_ResolData_ValueChanged(object sender, EventArgs e)
        {
            if (ResolChange != null) ResolChange((int)PNUD_ResolData.Value);
        }
    }
}
