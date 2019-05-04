using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ivi.Driver.Interop;
using Ivi.PwrMeter.Interop;
//using Keysight.KtRFPowerMeter.Interop;
using Ivi.Visa.Interop;
using Microsoft.VisualBasic;
//using AgN191x_EPM_A_01_03;
//using Agilent.CommandExpert.ScpiNet.AgN191x_EPM_A_01_03;

namespace DevicesLib
{
    //using Agilent.CommandExpert.ScpiNet.AgN191x_EPM_A_01_03;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //public KtRFPowerMeter N1913A;
        private void Form1_Load(object sender, EventArgs e)
        {

            // In order to use the following driver class, you need to reference this assembly : [C:\ProgramData\Keysight\Command Expert\ScpiNetDrivers\AgN191x_EPM_A_01_03.dll]
            //AgN191x_EPM N1913A = new AgN191x_EPM("USB0::0x2A8D::0x5418::MY57190050::0::INSTR");
            //N1913A.SCPI.DISPlay.ENABle.Command(false);
            //N1913A.SCPI.DISPlay.ENABle.Command(true);

            //N1913A = new KtRFPowerMeter();
            //N1913A.Initialize("USB0::0x2A8D::0x5418::MY57190037::0::INSTR", false, false, "");
            //N1913A.Display.Enabled = false;
            //N1913A.Display.Enabled = true;
            //N1913A.Close();
            // If true, this will query the instrument model and fail initialization 
            // if the model is not supported by the driver
            bool idQuery = false;

            // If true, the instrument is reset at initialization
            bool reset = false;

            // Setup IVI-defined initialization options
            string standardInitOptions =
              "Cache=false, InterchangeCheck=false, QueryInstrStatus=true, RangeCheck=false, RecordCoercions=false, Simulate=false";

            // Setup driver-specific initialization options
            string driverSetupOptions =
              "DriverSetup= Model=E4416A, Trace=false";
            //N1913A.Close;
            try
            {
                //N1913A.Initialize("USB0::0x2A8D::0x5418::MY57190037::0::INSTR", idQuery, reset, standardInitOptions + "," + driverSetupOptions);
            }
            catch
            {

            }
        }


        // Driver application code here...

        //N1913A.Close();




        private void button2_Click(object sender, EventArgs e)
        {
            //N1913A.Display.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //N1913A.Display.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //double retval = N1913A.Measurements.get_Item("1").Fetch(50000);
            //KtRFPowerMeterMeasurement Measurement = null;
            //Measurement = N1913A.Measurements2.get_Item2("1");
            //N1913A.Measurements.Initiate();
            //double m= Measurement.Read(500);
            // m = Measurement.Measure(500);
            //textBox1.Text = retval.ToString();
            //N1913A.Measurements
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResourceManager rm = new ResourceManager();
            var addresses = rm.FindRsrc("USB?*INSTR");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ResourceManager rm;
            FormattedIO488 myDmm;
            rm = new ResourceManager();
            myDmm = new FormattedIO488();
            string DutAddr = "USB0::0x2A8D::0x5418::MY57190037::0::INSTR";
            myDmm.IO = (IMessage)rm.Open(DutAddr, AccessMode.NO_LOCK, 2000, "");
            myDmm.IO.Clear();

            myDmm.WriteString("FETC1:POW:AC?");
            string Pow;
            Pow = "gdfdg";
            Pow = Pow + " ";
            Pow = myDmm.ReadString();
            double d;
            d = Conversion.Val(Pow);
            string k;
            k = "ghg";
            k = d.ToString("0.##E+0");
            textBox1.Text = k;
        }
    }
}
