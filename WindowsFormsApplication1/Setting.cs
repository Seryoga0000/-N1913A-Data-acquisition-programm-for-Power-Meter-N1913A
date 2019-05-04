using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ivi.Visa.Interop;
using Keysight.KtRFPowerMeter.Interop;

namespace ReadDataFromN1913A
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
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
                
                
                if (addresses.Length>0)
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
            if (DeviceList.Items.Count>0)
            {
                
                PMainForm PMF = this.Owner as PMainForm;

                
                if (PMF.IniN1913A(DeviceList.Text)==1)
                {

                    MemoryFormSettingParam.LB1=label1.Text = "Driver Initialized";

                    // Print a few IIviDriverIdentity properties
                    MemoryFormSettingParam.LB2 = label2.Text = "Identifier:   " + PMF.N1913A.Identity.Identifier;
                    MemoryFormSettingParam.LB3 = label3.Text = "Revision:     " + PMF.N1913A.Identity.Revision;
                    MemoryFormSettingParam.LB4 = label4.Text = "Vendor:       " + PMF.N1913A.Identity.Vendor;
                    MemoryFormSettingParam.LB5 = label5.Text = "Description:  " + PMF.N1913A.Identity.Description;
                    MemoryFormSettingParam.LB6 = label6.Text = "Model:        " + PMF.N1913A.Identity.InstrumentModel;
                    MemoryFormSettingParam.LB7 = label7.Text = "FirmwareRev:  " + PMF.N1913A.Identity.InstrumentFirmwareRevision;
                    MemoryFormSettingParam.LB8 = label8.Text = "Serial #:     " + PMF.N1913A.System.SerialNumber;
                   try
                   {

                       MemoryFormSettingParam.LB9 = label9.Text = "Current Value ChanelA:  " + PMF.N1913A.Measurements.get_Item("1").Fetch(50000).ToString();
                       //Console.WriteLine("\nSimulate:    {0}\n", driver.DriverOperation.Simulate);
                   }
                   catch
                   {
                       MemoryFormSettingParam.LB9 = label9.Text = "Current Value ChanelA:" + "-----";
                   }
                   if (PMF != null)
                   {
                       //string s = main.textBox1.Text;
                       PMF.EnableStartButton();
                   }
                    //PMF
                   //try
                   //{

                   //    label10.Text = "Current Value ChanelB:  " + PMF.N1913A.Measurements.get_Item("3").Fetch(50000).ToString();
                   //    //Console.WriteLine("\nSimulate:    {0}\n", driver.DriverOperation.Simulate);
                   //}
                   //catch
                   //{
                   //    label10.Text = "Current Value ChanelB:  " + "-----";
                   //}
                  }
                

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
        private void Setting_Load(object sender, EventArgs e)
        {
            DeviceList.Text=MemoryFormSettingParam.Device ;
                  label1.Text =MemoryFormSettingParam.LB1;

                    // Print a few IIviDriverIdentity properties
                  label2.Text = MemoryFormSettingParam.LB2; 
                  label3.Text = MemoryFormSettingParam.LB3;
                  label4.Text = MemoryFormSettingParam.LB4;
                  label5.Text = MemoryFormSettingParam.LB5;
                  label6.Text = MemoryFormSettingParam.LB6;
                  label7.Text = MemoryFormSettingParam.LB7;
                  label8.Text = MemoryFormSettingParam.LB8;
                  label9.Text = MemoryFormSettingParam.LB9;
                   
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

        }
    }
}
