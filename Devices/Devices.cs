using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivi.Visa.Interop;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using TVCLib;
namespace DevicesLib
{
    public class Devices
    {
       private ResourceManager rm;
       public FormattedIO488 Device { private set; get; }
       public string Name { get; private set; }
       public string Model { get; private set; } 
       public string SerialNumber { get; private set; }
       public string Adress { get; private set; }
       public virtual string Initial(string Adress)
       {
           try
           {
               this.Adress = Adress;
               rm = new ResourceManager();
               Device = new FormattedIO488();
               Device.IO = (IMessage)rm.Open(Adress, AccessMode.NO_LOCK, 2000, "");
               Device.IO.Clear();
               Device.WriteString("*IDN?");
               string RD =Device.ReadString();
               Name = RD;
               Model = Name.Split(',')[1];
               SerialNumber=RD;
               if (Model == "U2000A")
               {
                   //Device.WriteString("CAL:ZERO:TYPE INT");
                   //Device.WriteString("CAL:ALL");
                   //Device.WriteString("*OPC?");
                   //int i = 0;
                   //while(Conversion.Val(Device.ReadString())==0)
                   //{
                   //    i++;
                   //    if (i > 10000000) break;
                   //}
                   Device.WriteString("UNIT:POW W");
               }
               return "Ok_" + RD;

           }
           catch (Exception ex)
           {
               return ex.Message;
           }
            
       }
       public string[] FindUSBDevices() 
       {
           ResourceManager rm = new ResourceManager();
           string[] addresses = rm.FindRsrc("USB?*INSTR");
          //rm.
           return addresses;
       }
    }
    public class PowerMeter : Devices
    {
       
        
        public string MeasurePower(string Chanel="Ch1")
        {
            string N0 = Chanel.Substring(2,1);
            Device.WriteString("FETC" + 1 + ":POW:AC?");
            try
            {
                return Device.ReadString().Replace("\n", ""); 
            }
            catch (Exception ex)
            {
                return "Err_" + ex.Message;
            }
        }
        public double MeasurePower(int Chanel )
        {
            //string N0 = Chanel.Substring(2, 1);
            
            
            try
            {
                Device.WriteString("FETC" + Chanel.ToString() + ":POW:AC?");
                return Conversion.Val(Device.ReadString().Replace("\n", ""));
            }
            catch 
            {
                return 0.0;
            }
        }
        public void Unlock()
        {
           Device.WriteString("INIT:CONT OFF");
           Device.WriteString("SYST:LOC");
        }
    }
    public class DigitalMultimeter:Devices
    {
        public string  MeasureVoltage()
        {
            return "Fdfsdf";
        }
    }
    public class Oscilloscope : Devices
    {
        public override string Initial(string Adress)
        {

            TVCLib.Tvc OScope = new TVCLib.Tvc();
            OScope.Descriptor = "Adress";
            // Dim g = 8

            //string AcquireState=""; 
            object arrWF = "";
            double xinc = 0;
            int trigpos = 0;
            string vUnits = "";
            string hUnits = "";

            //Oscilloscope.Timeout = 5000;
            // TekForm.TvcB.WriteString("ACQUIRE:STATE?")
            // B_AcquireState = TekForm.TvcB.ReadString()
            // TekForm.TvcB.WriteString("ACQUIRE:STATE STOP")
            //AcquireState = 1;
            //OScope.GetWaveform()
            OScope.GetWaveform(TVCLib.CHANNEL.CH1, ref arrWF, ref xinc, ref  trigpos, ref vUnits, ref hUnits);

            return "sd";
            //return base.Initial(Adress);
        }
    }
}
