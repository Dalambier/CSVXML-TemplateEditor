using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace CSVXML_TemplateEditor
{
    public partial class FormXML : Window
    {
        public FormXML()
        {
            InitializeComponent();
            MinWidth = 300;
            MinHeight = 150;
        }

        SomeFunctions smf = new SomeFunctions();

        public string PatchOpenFile; //Сохранение пути открываемого файла
        public string ExtensionOpenFile; //Сохранение расширения файла
        public static string NewFilePatch;
        public static string XmlCsvPatch;
        public static object CSVFileData;
        public static string MD5Text;

        private void NewFile(object sender, RoutedEventArgs e)
        {
            FormNewFile newfile = new FormNewFile();
            newfile.ShowDialog();
            if (NewFilePatch != null)
            {
                PatchOpenFile = NewFilePatch;
                NewFilePatch = null;
                ExtensionOpenFile = PatchOpenFile.Substring(PatchOpenFile.LastIndexOf('.'));
                if (ExtensionOpenFile == ".xml")
                {
                    OpenXMLFile();
                }
                else if (ExtensionOpenFile == ".csv")
                {
                    OpenCSVFile();
                }
            }

        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Documents(*.xml;*.csv)|*.XML;*.csv";

            if (myDialog.ShowDialog() == true)
            {
                PatchOpenFile = myDialog.FileName;
                ExtensionOpenFile = myDialog.FileName.Substring(myDialog.FileName.LastIndexOf('.'));
                if (ExtensionOpenFile == ".xml")
                {
                    OpenXMLFile();
                }
                else if (ExtensionOpenFile == ".csv")
                {
                    OpenCSVFile();
                }
            }
        }

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            smf.CheckClipBoard();
            if (ExtensionOpenFile == ".xml")
            {
                SaveXMLFile(false);
            }
            else if (ExtensionOpenFile == ".csv")
            {
                SaveCSVFile(false);
            }
            smf.PasteToClipBoard();
        }

        private void SaveAsFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog myDialog = new SaveFileDialog();
            myDialog.Filter = "XML-Document (*.xml)|*.xml|CSV-Document (*.csv)|*.csv";
            if (myDialog.ShowDialog() == true)
            {
                smf.CheckClipBoard();
                PatchOpenFile = myDialog.FileName;
                ExtensionOpenFile = myDialog.FileName.Substring(myDialog.FileName.LastIndexOf('.'));
                if (ExtensionOpenFile == ".xml")
                {
                    SaveXMLFile(true);
                }
                else if (ExtensionOpenFile == ".csv")
                {
                    SaveCSVFile(true);
                }
                smf.PasteToClipBoard();
            }
        }

        private void ConvertFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Documents(*.xml;*.csv)|*.XML;*.csv";

            if (myDialog.ShowDialog() == true)
            {
                PatchOpenFile = myDialog.FileName;
                ExtensionOpenFile = myDialog.FileName.Substring(myDialog.FileName.LastIndexOf('.'));
                if (ExtensionOpenFile == ".xml")
                {
                    string PatchFileNotExtension = myDialog.FileName.Split('.')[0];
                    XElement DataElement = XElement.Parse(File.ReadAllText(myDialog.FileName));
                    var csvData = SomeFunctions.XML_CSV(DataElement, ";");
                    XmlCsvPatch = PatchFileNotExtension + "(csv).csv";
                    File.WriteAllText(XmlCsvPatch, "ThisTextWillThenBeColumns\n", Encoding.UTF8);
                    File.AppendAllText(XmlCsvPatch, (string)csvData, Encoding.UTF8);
                    CSVFileData = csvData;
                    ConvertXML_CSV xmlcsv = new ConvertXML_CSV();
                    xmlcsv.ShowDialog();
                }
                else if (ExtensionOpenFile == ".csv")
                {
                    try
                    {
                        string PatchFileNotExtension = myDialog.FileName.Split('.')[0];
                        smf.CSV_XML(PatchOpenFile, PatchFileNotExtension + "(xml).xml", "users", "user");
                    }
                    catch { }
                }
            }
        }

        private void ExitProrgam(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GitHubPage(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Dalambier/CSVXML-TemplateEditor");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void OpenCSVFile()
        {
            try
            {
                smf.CSV_XML(PatchOpenFile, "tempfile.xml", "users", "user");
                DataSet dataset = new DataSet();
                dataset.ReadXml("tempfile.xml");
                XMLTable.ItemsSource = dataset.Tables[0].DefaultView;
                File.Delete("tempfile.xml");
            }
            catch { }
        }
        private void SaveCSVFile(bool SaveAs)
        {
            if (SaveAs == false)
                File.Delete(PatchOpenFile);
            XMLTable.SelectAllCells();
            XMLTable.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, XMLTable);
            XMLTable.UnselectAll();
            smf.TableToCSV(PatchOpenFile);
        }
        private void OpenXMLFile()
        {
            try
            {
                DataSet dataset = new DataSet();
                dataset.ReadXml(PatchOpenFile);
                XMLTable.ItemsSource = dataset.Tables[0].DefaultView;
            }
            catch
            {
                MessageBox.Show("Incorrerct File!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void SaveXMLFile(bool SaveAs)
        {
            if (SaveAs == false)
                File.Delete(PatchOpenFile);
            XMLTable.SelectAllCells();
            XMLTable.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, XMLTable);
            XMLTable.UnselectAll();
            smf.TableToCSV("tempfile.csv");
            smf.CSV_XML("tempfile.csv", PatchOpenFile, "users", "user");
            File.Delete("tempfile.csv");
        }
        private void MD5HashFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Documents(*.xml;*.csv)|*.XML;*.csv";
            if (myDialog.ShowDialog() == true)
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(myDialog.FileName))
                    {
                        MD5Text = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                        MD5HashView md5view = new MD5HashView();
                        md5view.ShowDialog();
                    }
                }
            }
        }
    }
}
