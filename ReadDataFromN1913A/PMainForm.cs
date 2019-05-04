

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Keysight.KtRFPowerMeter.Interop;
using System.Threading;
using Microsoft.VisualBasic;
using System.Reflection;
namespace DevicesLib
{

    public partial class PMainForm : Form
    {
        public KtRFPowerMeter N1913A;
        private WriteDataToFile WDTF;
        public PMainForm()
        {
            InitializeComponent();
        }

        private void PMainForm_Load(object sender, EventArgs e)
        {
            WDTF=new WriteDataToFile();
            sett = new Setting();
            timer1.Start();
        }
        Setting sett;
        private void P_TSB_SET_Click(object sender, EventArgs e)
        {

            sett.Owner = this;
            sett.Show();
        }
        public int IniN1913A(string adr)
        {
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
                N1913A = new KtRFPowerMeter();
                N1913A.Initialize(adr, idQuery, reset, standardInitOptions + "," + driverSetupOptions);
                return 1;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Неудалось подключится к прибору");
                return 0;
            }

        }
        int CountIteraton = 0;
        int CountIteratonMult = 1;
        //int CountIteraton2 = 0;
        private void P_TSB_GO_Click(object sender, EventArgs e)
        {
            StopMeas = false;
            
            PMeasIndicate.Value = 1;
            P_TSB_STOP.Enabled = true;
            P_TSB_Pause.Enabled = true;
            //while (KeepMeas)
            //{
            //    Thread.Sleep(PPause(PCB_Pause.Text));
            //    System.Windows.Forms.MessageBox.Show(")))");
            //}
            //PAction();

            if (!pausemeas)
            {
                PNameFile = DateTime.Now.ToString("dd/MM/yyyy HH_mm_ss");
                WDTF.ChooseFile(PNameFile + ".txt");
                if (WDTF.OpenFile() != 1)
                {
                    PStop();
                    return;
                }
                
                
            }
            PMeas_timer.Start();
            P_TSB_GO.Enabled = false;
            pausemeas = false;
        }
        string PNameFile = "###";
        const int iTimeColumn = 0;
        const int idataColumn = 1;
        //int 
        private void PAction()
        {
            DateTime PTime = DateTime.Now;
            CountIteraton += 1;
            double PData = N1913A.Measurements.get_Item("1").Fetch(50000);
           
            PDataChart.Series[0].Points.AddXY(PTime, PData);
           
            PDataTable.Rows.Add();
            int NumberRows = PDataTable.Rows.Count;
            int NumberPoints = PDataChart.Series[0].Points.Count;
            DataGridViewRow CurrentRow = PDataTable.Rows[NumberRows - 2];
            CurrentRow.Cells[iTimeColumn].Value = PTime;
            CurrentRow.Cells[idataColumn].Value = PData;
            CountControl();
            //string PPath =Assembly.GetExecutingAssembly().Location;
            //string PPath = Application.StartupPath;

            if (CountIteraton > CountIteratonMult*sett.max_number)
            {
                CountIteratonMult += 1;
                WDTF.CloseFile();
                WDTF.ChooseFile(PNameFile + "#" + (int)(CountIteraton / sett.max_number) + ".txt");
                if (WDTF.OpenFile() != 1)
                {
                    PStop();
                    return;
                }
            }
            WDTF.WriteToFile(PTime.ToString()+"_" + PData);


            if (PTableAutoScroll.Checked && PDataTable.Rows.Count>1) { PDataTable.CurrentCell = CurrentRow.Cells[iTimeColumn]; }

        }

        private int PPause(string ps)
        {
            string timeRange = ps.Substring(ps.Length - 4, 4);
            int timevalue;
            int.TryParse(ps.Substring(0, ps.Length - 5), out timevalue);
            switch (timeRange)
            {
                case "сек.":
                    timevalue = timevalue * 1000;
                    break;
                case "мин.":
                    timevalue = timevalue * 1000 * 60;
                    break;
                default:
                    timevalue = 5000;
                    break;
            }
            return timevalue;
        }
        bool StopMeas = false;
        private void P_TSB_STOP_Click(object sender, EventArgs e)
        {
            
           PStop();
        }
        private void PStop()
        {
            PDataChart.Series[0].Points.Clear();
            PDataChart.ResetAutoValues(); 
            PDataTable.Rows.Clear();
            P_TSB_STOP.Enabled = false;
            P_TSB_Pause.Enabled = false;
            StopMeas = true;
            pausemeas = false;
            PMeasIndicate.Value = 0;
            P_TSB_GO.Enabled = true;
            WDTF.CloseFile();
            CountIteraton = 0;
            CountIteratonMult = 1;
        }
        private void CountControl()
        {
            if (PDataChart.Series[0].Points.Count >= sett.max_number)
            {
                //int NumberRows = PDataTable.Rows.Count;
                int NumberPoints = PDataChart.Series[0].Points.Count;
                for (int ii = 1; ii <= NumberPoints- sett.max_number; ii++)
                {
                    //PDataChart.ChartAreas[0].AxisX.Minimum = PDataChart.Series[0].Points[0].XValue;
                    //PDataChart.ChartAreas[0].AxisX.Maximum = PDataChart.Series[0].Points[PDataChart.Series[0].Points.Count-1].XValue;
                    
                    PDataChart.Series[0].Points.RemoveAt(0);
                    PDataChart.ResetAutoValues(); 
                    //
                    PDataTable.Rows.RemoveAt(0);
                }
                //for (int i = 1; i <= PDataTable.Rows.Count - sett.max_number; i++)
                //{
                    
                  
                //    PDataTable.Rows.RemoveAt(0);
                //}
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PTimeLabel.Text = DateTime.Now.ToString();
            //P_TSB_GO.Enabled = true;
            //P_TSB_STOP.Enabled = true;
        }

        private void PMeas_timer_Tick(object sender, EventArgs e)
        {
            PMeas_timer.Interval = PPause(PCB_Pause.Text);
            CountInterval = (int)PPause(PCB_Pause.Text) / 1000;
            PMeas_timerSec.Start();

            if (StopMeas)
            {
                PMeas_timer.Stop();
                PMeas_timerSec.Stop();
            }
            if (!pausemeas && !StopMeas) { PAction(); }
        }

        private void PCB_Pause_MouseUp(object sender, MouseEventArgs e)
        {
            //ToolStripComboBox toolstripcombobox =sender as ToolStripComboBox;

            //if (toolstripcombobox.Text.Substring(toolstripcombobox.Text.Length - 5, 5) == " сек." || PCB_Pause.Text.Substring(PCB_Pause.Text.Length - 5, 5) == " мин.")
            //{
            //}
            //else
            //{
            //    toolstripcombobox.Text = "15 сек.";
            //}
        }

        private void PCB_Pause_TextChanged(object sender, EventArgs e)
        {
            ToolStripComboBox toolstripcombobox = sender as ToolStripComboBox;
            if (toolstripcombobox.Text.Length < 5)
            {
                toolstripcombobox.Text = "15 сек.";
                return;
            }
            int timevalue;
            //int.TryParse(ps.Substring(0, ps.Length - 5), out timevalue);
            if (int.TryParse(toolstripcombobox.Text.Substring(0, toolstripcombobox.Text.Length - 5), out timevalue))
            {
                if (timevalue < 2 && toolstripcombobox.Text.Substring(toolstripcombobox.Text.Length - 4, 4) != "мин.")
                {
                    toolstripcombobox.Text = "15 сек.";
                    return;
                }

            }
            else
            {
                toolstripcombobox.Text = "15 сек.";
                return;
            }
            if (toolstripcombobox.Text.Substring(toolstripcombobox.Text.Length - 5, 5) == " сек." || PCB_Pause.Text.Substring(PCB_Pause.Text.Length - 5, 5) == " мин.")
            {
            }
            else
            {
                switch (toolstripcombobox.Text.Substring(toolstripcombobox.Text.Length - 4, 4))
                {
                    case "сек.":

                        toolstripcombobox.Text = "15 сек.";
                        break;
                    case "мин.":
                        toolstripcombobox.Text = "1 мин.";
                        break;
                    default:
                        toolstripcombobox.Text = "15 сек.";
                        break;
                }
            }
        }
        int CountInterval = 0;
        private void PMeas_timerSec_Tick(object sender, EventArgs e)
        {
            CountInterval -= 1;
            if (!pausemeas) { PTSL_CountTime.Text = (CountInterval).ToString(); }
        }

        public void EnableStartButton()
        {
            P_TSB_GO.Enabled = true;
            //P_TSB_STOP.Enabled = true;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void PCB_Pause_Click(object sender, EventArgs e)
        {

        }

        private void PTableAutoScroll_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                CheckBox1.BackgroundImage = Properties.Resources.Image13;
                PDataChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
                PDataChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Transparent;
            }
            else
            {

                CheckBox1.BackgroundImage = Properties.Resources.Image12;
                PDataChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
                PDataChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
            }
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PYstep_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TextBox TB = sender as TextBox;
            if (Conversion.Val(TB.Text) < 0)
            {
                TB.Text = "0";
                return;
            }
            PDataChart.ChartAreas[0].AxisY.MajorGrid.Interval = Conversion.Val(TB.Text);
            PDataChart.ChartAreas[0].AxisY.MajorTickMark.Interval = Conversion.Val(TB.Text);
            PDataChart.ChartAreas[0].AxisY.LabelStyle.Interval = Conversion.Val(TB.Text);
            //double ParseVal = 0;
            //if (double.TryParse(TB.Text, out ParseVal))
            //{

            //    if (ParseVal < 0)
            //    {
            //        TB.Text = "0";
            //        return;
            //    }
            //    PDataChart.ChartAreas[0].AxisX.MajorGrid.Interval = ParseVal;
            //}
            //else
            //{
            //    TB.Text = "0";
            //}

        }





        private void PMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //sett.Owner = this;
            //sett.Close();
        }

        private void PYmin_DoubleClick(object sender, EventArgs e)
        {
            TextBox TB = sender as TextBox;
            //if (Conversion.Val(TB.Text) < 0)
            //{
            //    TB.Text = "0";
            //    return;
            //}
            PDataChart.ChartAreas[0].AxisY.Minimum = Conversion.Val(TB.Text);
            //PDataChart.ChartAreas[0].AxisY.LabelStyle.M = Conversion.Val(TB.Text);
        }

        private void PYmax_DoubleClick(object sender, EventArgs e)
        {
            TextBox TB = sender as TextBox;
            //if (Conversion.Val(TB.Text) < 0)
            //{
            //    TB.Text = "0";
            //    return;
            //}
            PDataChart.ChartAreas[0].AxisY.Maximum = Conversion.Val(TB.Text);
        }

        private void PYstep_TextChanged(object sender, EventArgs e)
        {

        }

        private void PXmax_DoubleClick(object sender, EventArgs e)
        {
            TextBox TB = sender as TextBox;
            if (Conversion.Val(TB.Text) < 0)
            {
                TB.Text = "0";
                return;
            }
            PDataChart.ChartAreas[0].AxisX.MajorGrid.Interval = Conversion.Val(TB.Text);
            PDataChart.ChartAreas[0].AxisX.MajorTickMark.Interval = Conversion.Val(TB.Text);
            PDataChart.ChartAreas[0].AxisX.LabelStyle.Interval = Conversion.Val(TB.Text);
        }

        private void P_TSB_Pause_Click(object sender, EventArgs e)
        {
            PPause();
        }
        bool pausemeas = false;
        private void PPause()
        {
            //PDataChart.Series[0].Points.Clear();
            //PDataChart.ResetAutoValues();
            //PDataTable.Rows.Clear();
            //P_TSB_STOP.Enabled = false;
            P_TSB_Pause.Enabled = false;
            pausemeas = true;
            //PMeasIndicate.Value = 0;
            P_TSB_GO.Enabled = true;
            //WDTF.CloseFile();
            CountIteraton = 0;
            CountIteratonMult = 1;
        }

    }
}
