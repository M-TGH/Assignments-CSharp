using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TGH_Toets_CSharp_Blok1
{
    public partial class Form1 : Form
    {
        //Declare globals:
        Station Eelde = new Station("Eelde", "280", Directory.GetCurrentDirectory() + "\\etmgeg_280.txt" );
        Station Maastricht = new Station("Maastricht", "380", Directory.GetCurrentDirectory() + "\\etmgeg_380.txt");
        String selectedStation;

        public Form1()
        {
            InitializeComponent();
        }

        private void butMaths_Click(object sender, EventArgs e)
        {
            try
            {
                //Check whether a station is selected
                if (comboBoxStations.Text == "")
                {
                    throw new NullReferenceException();
                }
                else 
                {
                    //Get dates
                    DateTime minDate = datePickerFrom.Value;
                    String minyyyymmdd = minDate.ToString("yyyyMMdd");
                    DateTime maxDate = datePickerTill.Value;
                    String maxyyyymmdd = maxDate.ToString("yyyyMMdd");

                    String[] dataArray = {""};
                    if(selectedStation == "Eelde"){
                        dataArray = Eelde.getData();
                    } else if(selectedStation == "Maastricht"){
                        dataArray = Maastricht.getData();
                    }
                    //Read from fromDate till tillDate to lists
                    bool passedFrom = false;
                    bool passedTill = false;
                    List<int> TG = new List<int>();
                    List<int> RH = new List<int>();
                    foreach(String line in dataArray){
                        if(line.Contains(minyyyymmdd)){
                            passedFrom = true;
                        }
                        if (line.Contains(maxyyyymmdd))
                        {
                            passedTill = true;
                        }
                        if(passedFrom){
                            if(!passedTill){
                                String[] lineData = line.Split(',');
                                if (!(lineData[11].Trim() == "")){
                                    TG.Add(int.Parse(lineData[11].Trim()) / 10);
                                } 
                                if(!(lineData[22].Trim() == "")){
                                    if(lineData[22].Trim() == "-1")
                                        lineData[22] = "0";
                                    RH.Add(int.Parse(lineData[22].Trim()) / 10);
                                }
                            }
                        }
                    }
                    //Write results
                    textTempMid.Text = Math.Round(TG.Average(), 3).ToString();
                    textRainTotal.Text = RH.Sum().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fatal error:" + ex.ToString());
            }
        }

        private void butToXMLFile_Click(object sender, EventArgs e)
        {
            //Check whether a station is selected
            try{
                if(comboBoxStations.Text == ""){
                    throw new NullReferenceException();
                }
                Station selectedStat = Eelde;
                //Construct saveFileDialog
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                if (selectedStation == Eelde.getStationName())
                {
                    selectedStat = Eelde;
                }
                else if (selectedStation == Maastricht.getStationName())
                {
                    selectedStat = Maastricht;
                }
                saveFileDialog1.FileName = selectedStat.getStationName() + "-" + selectedStat.getCode() + "-weer";

                saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
                saveFileDialog1.FilterIndex = 0;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.DefaultExt = ".xml";

                DateTime startDate = datePickerFrom.Value;
                DateTime endDate = datePickerTill.Value;

                //Write XML
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                    {
                        sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                        sw.WriteLine("<weer>");
                        sw.WriteLine("\t<station>");
                        sw.WriteLine("\t\t<naam>"+selectedStat.getStationName()+"</naam>");
                        sw.WriteLine("\t\t<code>"+selectedStat.getCode()+"</code>");
                        sw.WriteLine("\t</station>");
                        sw.WriteLine("\t<datum>");
                        sw.WriteLine("\t\t<start>"+startDate.ToString("yyyyMMdd")+"</start>");
                        sw.WriteLine("\t\t<einde>"+endDate.ToString("yyyyMMdd")+"</einde>");
                        sw.WriteLine("");
                        sw.WriteLine("\t</datum>");
                        //Decided to pick from textbox as otherwise they have no reason for being textboxes and should be labels *cough* *cough*
                        sw.WriteLine("\t<tg>"+textTempMid.Text+"</tg>");
                        sw.WriteLine("\t<rh>"+textRainTotal.Text+"</rh>");
                        sw.WriteLine("</weer>");
                    }
                }
            }catch(Exception ex){
                MessageBox.Show("Fatal error:" + ex.ToString());
            }
        }

        private void comboBoxStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedStation = comboBoxStations.Text;
            String path;
            String[] dataArray = {""};
            //Get right path and data
            if(selectedStation == Eelde.getStationName()){
                path = Eelde.getPath();
                Eelde.setData(File.ReadAllLines(path));
                dataArray = Eelde.getData();
            } else if(selectedStation == Maastricht.getStationName()){
                path = Maastricht.getPath();
                Maastricht.setData(File.ReadAllLines(path));
                dataArray = Maastricht.getData();
            }

            //Get Dates
            String minDate = dataArray[50].Split(',')[1];
            String maxDate = dataArray[dataArray.Count() - 1].Split(',')[1];
            DateTime _minDate = new DateTime(int.Parse(minDate.Substring(0, 4)), int.Parse(minDate.Substring(4, 2)), int.Parse(minDate.Substring(6, 2)));
            DateTime _maxDate = new DateTime(int.Parse(maxDate.Substring(0, 4)), int.Parse(maxDate.Substring(4, 2)), int.Parse(maxDate.Substring(6, 2)));
            datePickerFrom.MaxDate = _maxDate;
            datePickerFrom.MinDate = _minDate;
            datePickerFrom.Value = _minDate;

            datePickerTill.MaxDate = _maxDate;
            datePickerTill.MinDate = _minDate;
            datePickerTill.Value = _maxDate;

        }
    }
}
