using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevicesLib;
using System.Windows.Forms;
using WriteDataToFileLib;
using System.IO;
//using Microsoft.Office.Interop.Excel;
namespace BisnesWorkLib
{
    public class WorkLogic
    {
        private WriteDataToFile WDTF;
        PowerMeter Pwr;
        Timer GlobalTime;
        Timer MeasTimer;
        Timer MeasCountTimer;
        string preName="";
        //int measTimeInterval = 1000;
        private bool flagMeasOnOff = true;
        private bool flagPauseOnOff = false;
        public string PreName
        {
            get {return preName;}
            set {preName = value;}   
        }
        int сountInterval = 0;
        //public int CountInterval 
        //{
        //    get { return сountInterval; }
        //    set { сountInterval = value; } 
        //}
        private int countIteraton = 0;
        private int countIteratonMult = 1;
        private int max_number = 1000000;
        public int Max_number
        {
            get { return max_number; }
            set { max_number =value; } 
        }

        public int CountIteraton
        {
            get { return countIteraton; }
        }

        public string MeasTimeInterval
        {
            get { return MeasTimer.Interval.ToString(); }
            set 
            { 
                MeasTimer.Interval =  IntervalConverter(value);
                сountInterval = MeasTimer.Interval / 1000;
            }   
        }
        private string nameFile = "C:\\Data.txt";
        public string NameFile
        {
            get { return nameFile; }
        }
        public delegate void GlobalTimeStateHandler(DateTime NowTime);
        public event GlobalTimeStateHandler GlobalTimeTicTac;
        public event Action<int> MeasCountTimerEvent;
        public event Action<DateTime,double,int>ActionEvent;

        public event Action InitEvent;
        public event Action StartEvent;
        public event Action StopEvent;
        public event Action PauseEvent; 
        private string folderPath="C:\\";
        public string FolderPath
        {
            get { return folderPath; }
        }
        public WorkLogic(string FolderPath)
        {
            folderPath = FolderPath;
            MeasTimer = new Timer() { Interval = 1000 };
            MeasTimer.Tick += new EventHandler(MeasTimer_Tick);
            MeasCountTimer = new Timer() { Interval = 1000 };
            MeasCountTimer.Tick+=new EventHandler(MeasCountTimer_Tick);
            GlobalTime = new Timer();
            GlobalTime.Interval = 1000;
            GlobalTime.Start();
            GlobalTime.Tick += new EventHandler(GTTicTac);
            WDTF=new WriteDataToFile();
        }
        private void GTTicTac(Object myObject, EventArgs myEventArgs)
        {
            if (GlobalTimeTicTac != null) { GlobalTimeTicTac(DateTime.Now); }
        }
        public int IniN1913A(string adr)
        {
            Pwr = new PowerMeter();
            string answ = Pwr.Initial(adr);
            if (answ.Substring(0, 2) == "Ok")
            {
                if (InitEvent != null) InitEvent();

                return 1;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Неудалось подключится к прибору \n" + answ);
                return 0;
            }
        }
        public string GetInformation()
        {
            return "Information:  " + Pwr.Name;
        }
        public string GetDataString()
        {
            return Pwr.MeasurePower();
        }
        public void StartMeasurement(string interv)
        {
            //measTimeInterval = IntervalConverter(interv);
            if (StartEvent != null) StartEvent();

            flagMeasOnOff = true;

            if (!flagPauseOnOff)
            {
                Directory.CreateDirectory(folderPath + "\\Data");
                nameFile ="Data\\" + PreName + DateTime.Now.ToString("dd/MM/yyyy HH_mm_ss") +".txt";
                WDTF.ChooseFile(nameFile);
                if (WDTF.OpenFile() != 1) { PStop(); return; }
            }
            flagPauseOnOff = false;
            MeasTimer.Interval = IntervalConverter(interv);
            MeasTimer.Start();
            сountInterval = MeasTimer.Interval/ 1000;
            
            MeasCountTimer.Start();
        }
       
        private void MeasTimer_Tick(Object myObject, EventArgs myEventArgs)
       {
            //MeasTimer.Interval = PPause(PCB_Pause.Text);
          
           сountInterval = MeasTimer.Interval / 1000;
           //MeasCountTimer.Start();
           if (!flagMeasOnOff)
            {
                MeasTimer.Stop();
                MeasCountTimer.Stop();
            }
           if (!flagPauseOnOff && flagMeasOnOff) { PAction(); }
        }

        private void MeasCountTimer_Tick(Object myObject, EventArgs myEventArgs)
        {
            //PMeas_timer.Interval = PPause(PCB_Pause.Text);
            //CountInterval = MeasTimer.Interval / 1000;
            //PMeas_timerSec.Start();
            сountInterval -= 1;
            if (!flagPauseOnOff) 
            {
                if (MeasCountTimerEvent != null) MeasCountTimerEvent(сountInterval);
                 
            }
        }
        private int IntervalConverter(string ps)
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

        private void PAction()
        {
            DateTime PTime = DateTime.Now;
            countIteraton += 1;
            double PData = Pwr.MeasurePower(1);

            if (countIteraton > countIteratonMult * max_number)
            {
                countIteratonMult += 1;
                WDTF.CloseFile();
                //NameFile = NameFile + PreName;
                WDTF.ChooseFile(nameFile.Substring(0,nameFile.Length-4) + "#" + (int)Math.Floor((double)(countIteraton / max_number)) + ".txt");
                if (WDTF.OpenFile() != 1)
                {
                    PStop();
                    return;
                }
            }
            WDTF.WriteToFile(PTime.ToString() + "_" + PData);



            if (ActionEvent != null) ActionEvent(PTime, PData, countIteraton);
        }
        const int iTimeColumn = 0;
        const int idataColumn = 1;
        public void PStop()
        {
            if (StopEvent != null) StopEvent();

            flagMeasOnOff = false;
            flagPauseOnOff = false;     
            WDTF.CloseFile();
            countIteraton = 0;
            countIteratonMult = 1;
        }
        public void PPause()
        {
            if (PauseEvent != null) PauseEvent();
            
            flagPauseOnOff = true;
            Pwr.Unlock();
        }
        public void SaveToFile(DataGridViewRowCollection DataRows)
        {
            //WKL.SaveToFile();
            WriteDataToFile WDTF1 = new WriteDataToFile();
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (SFD.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = SFD.FileName;
            WDTF1.ChooseFile(filename);
            WDTF1.OpenFile();

            foreach (DataGridViewRow Zl in DataRows)
            {
                if (Zl.Cells[iTimeColumn].Value != null)
                {
                    WDTF1.WriteToFile(Zl.Cells[iTimeColumn].Value + "_" + Zl.Cells[idataColumn].Value);
                }
                else
                {
                    WDTF1.WriteToFile("");
                }
            }
            WDTF1.CloseFile();
        }
        //private enum MCEType 
        //{
        //    msoElementChartTitleNone = 0,
        //    msoElementChartTitleCenteredOverlay = 1,
        //    msoElementChartTitleAboveChart = 2,
        //    msoElementLegendNone = 100,
        //    msoElementLegendRight = 101,
        //    msoElementLegendTop = 102,
        //    msoElementLegendLeft = 103,
        //    msoElementLegendBottom = 104,
        //    msoElementLegendRightOverlay = 105,
        //    msoElementLegendLeftOverlay = 106,
        //    msoElementDataLabelNone = 200,
        //    msoElementDataLabelShow = 201,
        //    msoElementDataLabelCenter = 202,
        //    msoElementDataLabelInsideEnd = 203,
        //    msoElementDataLabelInsideBase = 204,
        //    msoElementDataLabelOutSideEnd = 205,
        //    msoElementDataLabelLeft = 206,
        //    msoElementDataLabelRight = 207,
        //    msoElementDataLabelTop = 208,
        //    msoElementDataLabelBottom = 209,
        //    msoElementDataLabelBestFit = 210,
        //    msoElementPrimaryCategoryAxisTitleNone = 300,
        //    msoElementPrimaryCategoryAxisTitleAdjacentToAxis = 301,
        //    msoElementPrimaryCategoryAxisTitleBelowAxis = 302,
        //    msoElementPrimaryCategoryAxisTitleRotated = 303,
        //    msoElementPrimaryCategoryAxisTitleVertical = 304,
        //    msoElementPrimaryCategoryAxisTitleHorizontal = 305,
        //    msoElementPrimaryValueAxisTitleNone = 306,
        //    msoElementPrimaryValueAxisTitleAdjacentToAxis = 306,
        //    msoElementPrimaryValueAxisTitleBelowAxis = 308,
        //    msoElementPrimaryValueAxisTitleRotated = 309,
        //    msoElementPrimaryValueAxisTitleVertical = 310,
        //    msoElementPrimaryValueAxisTitleHorizontal = 311,
        //    msoElementSecondaryCategoryAxisTitleNone = 312,
        //    msoElementSecondaryCategoryAxisTitleAdjacentToAxis = 313,
        //    msoElementSecondaryCategoryAxisTitleBelowAxis = 314,
        //    msoElementSecondaryCategoryAxisTitleRotated = 315,
        //    msoElementSecondaryCategoryAxisTitleVertical = 316,
        //    msoElementSecondaryCategoryAxisTitleHorizontal = 317,
        //    msoElementSecondaryValueAxisTitleNone = 318,
        //    msoElementSecondaryValueAxisTitleAdjacentToAxis = 319,
        //    msoElementSecondaryValueAxisTitleBelowAxis = 320,
        //    msoElementSecondaryValueAxisTitleRotated = 321,
        //    msoElementSecondaryValueAxisTitleVertical = 322,
        //    msoElementSecondaryValueAxisTitleHorizontal = 323,
        //    msoElementSeriesAxisTitleNone = 324,
        //    msoElementSeriesAxisTitleRotated = 325,
        //    msoElementSeriesAxisTitleVertical = 326,
        //    msoElementSeriesAxisTitleHorizontal = 327,
        //    msoElementPrimaryValueGridLinesNone = 328,
        //    msoElementPrimaryValueGridLinesMinor = 329,
        //    msoElementPrimaryValueGridLinesMajor = 330,
        //    msoElementPrimaryValueGridLinesMinorMajor = 331,
        //    msoElementPrimaryCategoryGridLinesNone = 332,
        //    msoElementPrimaryCategoryGridLinesMinor = 333,
        //    msoElementPrimaryCategoryGridLinesMajor = 334,
        //    msoElementPrimaryCategoryGridLinesMinorMajor = 335,
        //    msoElementSecondaryValueGridLinesNone = 336,
        //    msoElementSecondaryValueGridLinesMinor = 337,
        //    msoElementSecondaryValueGridLinesMajor = 338,
        //    msoElementSecondaryValueGridLinesMinorMajor = 339,
        //    msoElementSecondaryCategoryGridLinesNone = 340,
        //    msoElementSecondaryCategoryGridLinesMinor = 341,
        //    msoElementSecondaryCategoryGridLinesMajor = 342,
        //    msoElementSecondaryCategoryGridLinesMinorMajor = 343,
        //    msoElementSeriesAxisGridLinesNone = 344,
        //    msoElementSeriesAxisGridLinesMinor = 345,
        //    msoElementSeriesAxisGridLinesMajor = 346,
        //    msoElementSeriesAxisGridLinesMinorMajor = 347,
        //    msoElementPrimaryCategoryAxisNone = 348,
        //    msoElementPrimaryCategoryAxisShow = 349,
        //    msoElementPrimaryCategoryAxisWithoutLabels = 350,
        //    msoElementPrimaryCategoryAxisReverse = 351,
        //    msoElementPrimaryValueAxisNone = 352,
        //    msoElementPrimaryValueAxisShow = 353,
        //    msoElementPrimaryValueAxisThousands = 354,
        //    msoElementPrimaryValueAxisMillions = 355,
        //    msoElementPrimaryValueAxisBillions = 356,
        //    msoElementPrimaryValueAxisLogScale = 357,
        //    msoElementSecondaryCategoryAxisNone = 358,
        //    msoElementSecondaryCategoryAxisShow = 359,
        //    msoElementSecondaryCategoryAxisWithoutLabels = 360,
        //    msoElementSecondaryCategoryAxisReverse = 361,
        //    msoElementSecondaryValueAxisNone = 362,
        //    msoElementSecondaryValueAxisShow = 363,
        //    msoElementSecondaryValueAxisThousands = 364,
        //    msoElementSecondaryValueAxisMillions = 365,
        //    msoElementSecondaryValueAxisBillions = 366,
        //    msoElementSecondaryValueAxisLogScale = 367,
        //    msoElementSeriesAxisNone = 368,
        //    msoElementSeriesAxisShow = 369,
        //    msoElementSeriesAxisWithoutLabeling = 370,
        //    msoElementSeriesAxisReverse = 371,
        //    msoElementPrimaryCategoryAxisThousands = 372,
        //    msoElementPrimaryCategoryAxisMillions = 373,
        //    msoElementPrimaryCategoryAxisBillions = 374,
        //    msoElementPrimaryCategoryAxisLogScale = 375,
        //    msoElementSecondaryCategoryAxisThousands = 376,
        //    msoElementSecondaryCategoryAxisMillions = 377,
        //    msoElementSecondaryCategoryAxisBillions = 378,
        //    msoElementSecondaryCategoryAxisLogScale = 379,
        //    msoElementDataTableNone = 500,
        //    msoElementDataTableShow = 501,
        //    msoElementDataTableWithLegendKeys = 502,
        //    msoElementTrendlineNone = 600,
        //    msoElementTrendlineAddLinear = 601,
        //    msoElementTrendlineAddExponential = 602,
        //    msoElementTrendlineAddLinearForecast = 603,
        //    msoElementTrendlineAddTwoPeriodMovingAverage = 604,
        //    msoElementErrorBarNone = 700,
        //    msoElementErrorBarStandardError = 701,
        //    msoElementErrorBarPercentage = 702,
        //    msoElementErrorBarStandardDeviation = 703,
        //    msoElementLineNone = 800,
        //    msoElementLineDropLine = 801,
        //    msoElementLineHiLoLine = 802,
        //    msoElementLineSeriesLine = 803,
        //    msoElementLineDropHiLoLine = 804,
        //    msoElementUpDownBarsNone = 900,
        //    msoElementUpDownBarsShow = 901,
        //    msoElementPlotAreaNone = 1000,
        //    msoElementPlotAreaShow = 1001,
        //    msoElementChartWallNone = 1100,
        //    msoElementChartWallShow = 1101,
        //    msoElementChartFloorNone = 1200,
        //    msoElementChartFloorShow = 1201,
        //}
        public void FileToExcel(DataGridViewRowCollection DataRows)
        {
            Microsoft.Office.Interop.Excel.Application app;
            Microsoft.Office.Interop.Excel.Workbook wb;
            Microsoft.Office.Interop.Excel.Worksheet ws;
            app = new Microsoft.Office.Interop.Excel.Application() { DisplayAlerts = false };
            int er = 0;
            try
            {
                WriteDataToFile WDTF1 = new WriteDataToFile();
                //SaveFileDialog SFD = new SaveFileDialog();
                //SFD.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                //if (SFD.ShowDialog() == DialogResult.Cancel)
                //    return;
                Directory.CreateDirectory(folderPath + "\\Data" + "\\ForExcel");
                string filename = folderPath + "\\Data" + "\\ForExcel" + nameFile.Substring(4, nameFile.Length - 4) ;
                WDTF1.ChooseFile(filename);
                WDTF1.OpenFile(false);
                int N=DataRows.Count;
                foreach (DataGridViewRow Zl in DataRows)
                {
                    if (Zl.Cells[iTimeColumn].Value != null)
                    {
                        WDTF1.WriteToFile(Zl.Cells[iTimeColumn].Value + "_" + Zl.Cells[idataColumn].Value);
                    }
                    else
                    {
                        WDTF1.WriteToFile("");
                    }
                }
                WDTF1.CloseFile();


                wb = app.Workbooks.Open(filename);
                ws = wb.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;

                ws.Columns["A:A"].TextToColumns(Destination: ws.Range["A1"],
                            DataType: Microsoft.Office.Interop.Excel.XlTextParsingType.xlDelimited,
                            TextQualifier: Microsoft.Office.Interop.Excel.XlTextQualifier.xlTextQualifierDoubleQuote,
                            ConsecutiveDelimiter: false, Tab: true, Semicolon: false,
                            Comma: false, Space: false, Other: true, OtherChar: "_",
                            FieldInfo: new int[,] { { 1, 1 }, { 2, 1 } },
                            TrailingMinusNumbers: true);
                ws.Columns.AutoFit();
                //ws.Range["A1"].Insert(ro
                ws.Rows["1:1"].Insert (Shift:Microsoft.Office.Interop.Excel.XlDirection.xlDown, CopyOrigin:Microsoft.Office.Interop.Excel.XlInsertFormatOrigin.xlFormatFromLeftOrAbove);
                er = 1;
                Microsoft.Office.Interop.Excel.ChartObject ExcelDataChart = (Microsoft.Office.Interop.Excel.ChartObject) ws.ChartObjects().Add(150, 10, 500, 350);
                er = 2;
                ExcelDataChart.Chart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlXYScatterSmoothNoMarkers;
                er = 3;
                ws.Range["B1"].Value2 = "Данные";
                er = 4;
                ExcelDataChart.Chart.SeriesCollection().Add(Source: ws.Range["B2:B" + (N + 1).ToString()]);
                er = 41;
                Microsoft.Office.Interop.Excel.Series ser = (Microsoft.Office.Interop.Excel.Series)ExcelDataChart.Chart.SeriesCollection()[1];
                er = 5;
                ws.Range["A1"].Value2 = "Дата/Время";
                er = 6;
                ser.XValues = ws.Range["A2:A" + (N + 1).ToString()];
                er = 7;
                //ser.Format.Line.Weight = 2;
                //er = 8;
                //chB.Chart.SeriesCollection(1).Name = "Канал 1"

                //ExcelDataChart.Chart.SetElement(Microsoft.Office.Core.MsoChartElementType.msoElementPrimaryCategoryGridLinesMajor);
                //ExcelDataChart.Chart.SetElement(Microsoft.Office.Core.MsoChartElementType.msoElementPrimaryValueGridLinesMajor);
                ExcelDataChart.Chart.Legend.Delete();
                er = 9;
                //ExcelDataChart.Chart.SetElement (Microsoft.Office.Core.MsoChartElementType.msoElementChartTitleAboveChart);
                //ExcelDataChart.Chart.ChartTitle.Text = nameFile.Substring(5, nameFile.Length - 5);
                ExcelDataChart.Chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory).TickLabelPosition = Microsoft.Office.Interop.Excel.XlTickLabelPosition.xlTickLabelPositionLow;
                er = 10;
                //ExcelDataChart.Chart.SetElement (Microsoft.Office.Core.MsoChartElementType.msoElementPrimaryValueAxisTitleRotated);
                //ExcelDataChart.Chart.SetElement (Microsoft.Office.Core.MsoChartElementType.msoElementPrimaryCategoryAxisTitleAdjacentToAxis);
                ExcelDataChart.Chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlValue).TickLabelPosition = Microsoft.Office.Interop.Excel.XlTickLabelPosition.xlTickLabelPositionLow;
                er = 11;
                //ExcelDataChart.Chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory).AxisTitle.Text = "Время";
                //ExcelDataChart.Chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlValue).AxisTitle.Text = "Данные";
                //ExcelDataChart.Chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlValue).TickLabelPosition =  Microsoft.Office.Interop.Excel.XlTickLabelPosition.xlTickLabelPositionLow;
                ExcelDataChart.Chart.Axes(Microsoft.Office.Interop.Excel.XlAxisType.xlCategory).TickLabels.Orientation = 45;
                er = 12;
                app.Visible = true;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Неудалось открыть Excel"+er.ToString());
                return;
            }

        }

    }
}
