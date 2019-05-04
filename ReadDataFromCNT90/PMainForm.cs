

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Keysight.KtRFPowerMeter.Interop;
using System.Threading;
using Microsoft.VisualBasic;
using System.Reflection;
using Ivi.Visa.Interop;
using System.Windows.Forms.DataVisualization;
using DevicesLib;
using WriteDataToFileLib;
using BisnesWorkLib;
using System.Windows.Forms.DataVisualization.Charting;
//using Microsoft.Office.Interop;
namespace DevicesLib
{
   
    public partial class PMainForm : Form
    {
        //public KtRFPowerMeter N1913A;
      
        //private ResourceManager rm;
        ////private FormattedIO488 myDmm;
        //public FormattedIO488 myDmm { private set; get; }
        private WorkLogic WKL;
        Setting sett;
        string Resol;
        public PMainForm()

        {
            InitializeComponent(); 
        }

        private void PMainForm_Load(object sender, EventArgs e)
        {
            Resol="######";
            //WDTF=new WriteDataToFile();
            WKL=new WorkLogic(Application.StartupPath);
            sett = new Setting(WKL);
            //timer1.Start();
            WKL.GlobalTimeTicTac +=WKL_GlobalTimeTicTac;
            WKL.InitEvent += () => { P_TSB_GO.Enabled = true; };
            WKL.StartEvent+=WKL_StartEvent;
            WKL.MeasCountTimerEvent += (int CountInt) => PTSL_CountTime.Text = CountInt.ToString();
            WKL.ActionEvent+=WKL_ActionEvent;
            WKL.StopEvent+=WKL_StopEvent;
            WKL.PauseEvent += () => { P_TSB_Pause.Enabled = false; P_TSB_GO.Enabled = true; };
            sett.SplineChange += (bool Sp) => { PDataChart.Series[0].ChartType = Sp ? SeriesChartType.Spline : SeriesChartType.Line; };
            sett.ResolChange += (int Res) => { Resol=MakeString(Res); };
        }
        private void WKL_StartEvent()
        {
            P_TSB_STOP.Enabled = true;
            P_TSB_Pause.Enabled = true;
            P_TSB_GO.Enabled = false;
            PTSB_Save.Enabled = true;
            PExcelSend.Enabled = true;
        }
        private void WKL_GlobalTimeTicTac(DateTime Ntime)
        {
            PTimeLabel.Text = Ntime.ToString();
        }
        private void P_TSB_SET_Click(object sender, EventArgs e)
        {

            sett.Owner = this;
            sett.Show();
        }
      
        //int CountIteraton = 0;
        //int CountIteratonMult = 1;
        //int CountIteraton2 = 0;
        private void P_TSB_GO_Click(object sender, EventArgs e)
        {
            WKL.StartMeasurement(PCB_Pause.Text);
           
        }
        //string PNameFile = "###";
        const int iTimeColumn = 0;
        const int idataColumn = 1;
        //int 
        private void WKL_ActionEvent(DateTime PTime, double PData, int CountIt)
        {
            //string k = "#####";
            PDataChart.Series[0].Points.AddXY(PTime, PData);
            PDataTable.Rows.Add();
            int NumberRows = PDataTable.Rows.Count;
            int NumberPoints = PDataChart.Series[0].Points.Count;
            DataGridViewRow CurrentRow = PDataTable.Rows[NumberRows - 2];
            CurrentRow.Cells[iTimeColumn].Value = PTime;
            
            CurrentRow.Cells[idataColumn].Value = PData.ToString("0." + Resol + "E+00"); ;
            CountControl();
            if (PTableAutoScroll.Checked && PDataTable.Rows.Count > 1) { PDataTable.CurrentCell = CurrentRow.Cells[idataColumn]; }
            PTSL_CountMeas.Text = CountIt.ToString();
        }
        private string MakeString(int Numb)
        {
            string s = "";
            for (int i = 1; i <= Numb; i++)
            { s += "#"; }
            return s;
        }
        private void WKL_StopEvent()
        {
            PDataChart.Series[0].Points.Clear();
            PDataChart.ResetAutoValues();
            PDataTable.Rows.Clear();
            P_TSB_STOP.Enabled = false;
            P_TSB_Pause.Enabled = false;
            P_TSB_GO.Enabled = true;
        }
       
        //bool StopMeas = false;
        private void P_TSB_STOP_Click(object sender, EventArgs e)
        {
           WKL.PStop();
           PTSL_CountMeas.Text = "0";
           PTSB_Save.Enabled = false;
           PExcelSend.Enabled = false;
        }
        
        private void CountControl()
        {
            if (PDataChart.Series[0].Points.Count >= sett.max_number)
            {
                //int NumberRows = PDataTable.Rows.Count;
                int NumberPoints = PDataChart.Series[0].Points.Count;
                for (int ii = 1; ii <= NumberPoints- sett.max_number; ii++)
                {

                    PDataChart.Series[0].Points.RemoveAt(0);
                    PDataChart.ResetAutoValues(); 
                    //
                    PDataTable.Rows.RemoveAt(0);
                }
   
            }
        }

      

     
        private void PCB_Pause_MouseUp(object sender, MouseEventArgs e)
        {
     
        }

        private void PCB_Pause_TextChanged(object sender, EventArgs e)
        {
           
            ToolStripComboBox toolstripcombobox = sender as ToolStripComboBox;
            if (toolstripcombobox.Text.Length < 5)
            {
                toolstripcombobox.Text = "15 сек.";
                WKL.MeasTimeInterval = toolstripcombobox.Text;
              
                return;
            }
            int timevalue;
            //int.TryParse(ps.Substring(0, ps.Length - 5), out timevalue);
            if (int.TryParse(toolstripcombobox.Text.Substring(0, toolstripcombobox.Text.Length - 5), out timevalue))
            {
                if (timevalue < 2 && toolstripcombobox.Text.Substring(toolstripcombobox.Text.Length - 4, 4) != "мин.")
                {
                    toolstripcombobox.Text = "15 сек.";
                    WKL.MeasTimeInterval = toolstripcombobox.Text;
                    return;
                }

            }
            else
            {
                toolstripcombobox.Text = "15 сек.";
                WKL.MeasTimeInterval = toolstripcombobox.Text;
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
            WKL.MeasTimeInterval = toolstripcombobox.Text;
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
          

        }





     

        private void PYmin_DoubleClick(object sender, EventArgs e)
        {
            TextBox TB = sender as TextBox;
       
            PDataChart.ChartAreas[0].AxisY.Minimum = Conversion.Val(TB.Text);
           
        }

        private void PYmax_DoubleClick(object sender, EventArgs e)
        {
            TextBox TB = sender as TextBox;
      
            PDataChart.ChartAreas[0].AxisY.Maximum = Conversion.Val(TB.Text);
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
            WKL.PPause();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void сохранитьToolStripButton_Click(object sender, EventArgs e)
        {
            WKL.SaveToFile(PDataTable.Rows);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            WKL.FileToExcel(PDataTable.Rows);
        }
        //bool pausemeas = false;
       

       

        

    }
}
