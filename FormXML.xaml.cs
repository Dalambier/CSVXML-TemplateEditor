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
            myDialog.Filter = ProgramSettings.Documents + "(*.xml;*.csv)|*.XML;*.csv";

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
            myDialog.Filter = "XML-" + ProgramSettings.Documents + "(*.xml)|*.xml|CSV-" + ProgramSettings.Documents + " (*.csv)|*.csv";
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
            myDialog.Filter = ProgramSettings.Documents  + "(*.xml;*.csv)|*.XML;*.csv";

            if (myDialog.ShowDialog() == true)
            {
                PatchOpenFile = myDialog.FileName;
                ExtensionOpenFile = myDialog.FileName.Substring(myDialog.FileName.LastIndexOf('.'));
                if (ExtensionOpenFile == ".xml")
                {
                    try
                    {
                        string PatchFileNotExtension = myDialog.FileName.Split('.')[0];
                        XElement DataElement = XElement.Parse(File.ReadAllText(myDialog.FileName));
                        var csvData = SomeFunctions.XML_CSV(DataElement, Properties.Settings.Default.Delimiter);
                        XmlCsvPatch = PatchFileNotExtension + "(csv).csv";
                        File.WriteAllText(XmlCsvPatch, "ThisTextWillThenBeColumns\n", Encoding.UTF8);
                        File.AppendAllText(XmlCsvPatch, (string)csvData, Encoding.UTF8);
                        CSVFileData = csvData;
                        ConvertXML_CSV xmlcsv = new ConvertXML_CSV();
                        xmlcsv.ShowDialog();
                    }
                    catch
                    {
                        smf.IncorrectFile();
                    }
                }
                else if (ExtensionOpenFile == ".csv")
                {
                    try
                    {
                        string PatchFileNotExtension = myDialog.FileName.Split('.')[0];
                        smf.CSV_XML(PatchOpenFile, PatchFileNotExtension + "(xml).xml", Properties.Settings.Default.MainElementXML, Properties.Settings.Default.SecondaryElementXML, Properties.Settings.Default.Delimiter[0]);
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

        private void MD5HashFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = ProgramSettings.Documents + "(*.xml;*.csv)|*.XML;*.csv";
            if (myDialog.ShowDialog() == true)
            {
                try
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
                catch
                {
                    smf.IncorrectFile();
                }
            }
        }

        private void Base64Coding(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = ProgramSettings.Documents + "(*.xml;*.csv)|*.XML;*.csv";
            if (myDialog.ShowDialog() == true)
            {
                try
                {
                    Byte[] bytes = File.ReadAllBytes(myDialog.FileName);
                    String file = Convert.ToBase64String(bytes);
                    byte[] bytes2 = Encoding.ASCII.GetBytes(file);
                    File.WriteAllBytes(myDialog.FileName, bytes2);
                }
                catch
                {
                    smf.IncorrectFile();
                }
            }
        }

        private void Base64Encoding(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = ProgramSettings.Documents + "(*.xml;*.csv)|*.XML;*.csv";
            if (myDialog.ShowDialog() == true)
            {
                try
                {
                    string text = Encoding.UTF8.GetString(Convert.FromBase64String(File.ReadAllText(myDialog.FileName)));
                    File.WriteAllText(myDialog.FileName, text);
                }
                catch
                {
                    smf.IncorrectFile();
                }
            }
        }

        private void OpenSettings(object sender, RoutedEventArgs e)
        {
            FormSettings settingsfrm = new FormSettings();
            settingsfrm.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Menu_File.Header = ProgramSettings.Menu_File;
            Menu_New.Header = ProgramSettings.Menu_New;
            Menu_Open.Header = ProgramSettings.Menu_Open;
            Menu_Save.Header = ProgramSettings.Menu_Save;
            Menu_SaveAs.Header = ProgramSettings.Menu_SaveAs;
            Menu_Convert.Header = ProgramSettings.Menu_Convert;
            Menu_Exit.Header = ProgramSettings.Menu_Exit;

            Menu_Edit.Header = ProgramSettings.Menu_Edit;
            Menu_Encryption.Header = ProgramSettings.Menu_Encryption;
            Menu_Encoding.Header = ProgramSettings.Menu_Encoding;
            Menu_Decoding.Header = ProgramSettings.Menu_Decoding;
            Menu_AddColumn.Header = ProgramSettings.Menu_AddColumn;
            Menu_Settings.Header = ProgramSettings.Menu_Settings;

            Menu_Help.Header = ProgramSettings.Menu_Help;
            Menu_Github.Header = ProgramSettings.Menu_GithubPage;
            Menu_AboutProgram.Header = ProgramSettings.Menu_AboutProgram;
            Menu_Documentation.Header = ProgramSettings.Menu_Documentation;
        }



        //Functions
        private void OpenCSVFile()
        {
            try
            {
                smf.CSV_XML(PatchOpenFile, "tempfile.xml", Properties.Settings.Default.MainElementXML, Properties.Settings.Default.SecondaryElementXML, Properties.Settings.Default.Delimiter[0]);
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
            smf.TableToCSV(PatchOpenFile, Properties.Settings.Default.Delimiter);
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
                smf.IncorrectFile();
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
            smf.TableToCSV("tempfile.csv", Properties.Settings.Default.Delimiter);
            smf.CSV_XML("tempfile.csv", PatchOpenFile, Properties.Settings.Default.MainElementXML, Properties.Settings.Default.SecondaryElementXML, Properties.Settings.Default.Delimiter[0]);
            File.Delete("tempfile.csv");
        }
    }
}
