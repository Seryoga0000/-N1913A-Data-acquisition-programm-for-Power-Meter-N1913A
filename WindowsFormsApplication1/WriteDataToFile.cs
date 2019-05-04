using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace ReadDataFromN1913A
{
    class WriteDataToFile
    {
        private bool fl = true;
        private string _PathFile ;
        private StreamWriter fstream;
        public void ChooseFile(string PathFile)
        {
            _PathFile = PathFile;
        }

        public int OpenFile()

        {
            fl = true;
            //fw = New StreamWriter(ErrorFile, True, System.Text.Encoding.Default)
            try
            {
                string PPath = Application.StartupPath;
                Directory.CreateDirectory(PPath+"\\Data");
                fstream = new StreamWriter("Data\\"+_PathFile, true, System.Text.Encoding.Default);
                return 1;
            }
            catch
            {
                MessageBox.Show("Неудалось открыть файл");
                return 0;
            }
           }
        
        public void WriteToFile(string PData)
        {
            if (fl) { fstream.WriteLine(PData); }
        }

        public void CloseFile()
        {
            if (fstream != null) { fstream.Dispose(); }
            fl = false;
        }

    }
}
