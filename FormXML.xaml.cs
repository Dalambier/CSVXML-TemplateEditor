using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Linq;
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

        public string PatchOpenFile; //Сохранение пути открываемого файла
        public string ExtensionOpenFile; //Сохранение расширения файла

        private void NewFile(object sender, RoutedEventArgs e)
        {
            FormNewFile newfile = new FormNewFile();
            newfile.Show();
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
                    try
                    {
                        DataSet dataset = new DataSet();
                        dataset.ReadXml(myDialog.FileName);
                        XMLTable.ItemsSource = dataset.Tables[0].DefaultView;
                    }
                    catch
                    {
                        MessageBox.Show("Incorrerct File!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if (ExtensionOpenFile == ".csv")
                {
                    try
                    {
                        SomeFunctions smf = new SomeFunctions();
                        smf.CSV_XML(PatchOpenFile, "tempfile.xml", "users", "user");
                        DataSet dataset = new DataSet();
                        dataset.ReadXml("tempfile.xml");
                        XMLTable.ItemsSource = dataset.Tables[0].DefaultView;
                        File.Delete("tempfile.xml");
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            SomeFunctions smf = new SomeFunctions();
            smf.CheckClipBoard();
            if (ExtensionOpenFile == ".xml")
            {
                File.Delete(PatchOpenFile);
                XMLTable.SelectAllCells();
                XMLTable.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, XMLTable);
                XMLTable.UnselectAll();
                smf.TableToCSV("tempfile.csv");
                smf.CSV_XML("tempfile.csv", PatchOpenFile, "users", "user");
                File.Delete("tempfile.csv");
            }
            else if (ExtensionOpenFile == ".csv")
            {
                File.Delete(PatchOpenFile);
                XMLTable.SelectAllCells();
                XMLTable.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, XMLTable);
                XMLTable.UnselectAll();
                smf.TableToCSV(PatchOpenFile);
            }
            smf.PasteToClipBoard();
        }

        private void SaveAsFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog myDialog = new SaveFileDialog();
            myDialog.Filter = "XML-Document (*.xml)|*.xml|CSV-Document (*.csv)|*.csv";
            if (myDialog.ShowDialog() == true)
            {
                SomeFunctions smf = new SomeFunctions();
                smf.CheckClipBoard();
                PatchOpenFile = myDialog.FileName;
                ExtensionOpenFile = myDialog.FileName.Substring(myDialog.FileName.LastIndexOf('.'));
                if (ExtensionOpenFile == ".xml")
                {
                    XMLTable.SelectAllCells();
                    XMLTable.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                    ApplicationCommands.Copy.Execute(null, XMLTable);
                    XMLTable.UnselectAll();
                    smf.TableToCSV("tempfile.csv");
                    smf.CSV_XML("tempfile.csv", PatchOpenFile, "users", "user");
                    File.Delete("tempfile.csv");
                }
                else if (ExtensionOpenFile == ".csv")
                {
                    XMLTable.SelectAllCells();
                    XMLTable.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                    ApplicationCommands.Copy.Execute(null, XMLTable);
                    XMLTable.UnselectAll();
                    smf.TableToCSV(PatchOpenFile);
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
                SomeFunctions smf = new SomeFunctions();
                PatchOpenFile = myDialog.FileName;
                ExtensionOpenFile = myDialog.FileName.Substring(myDialog.FileName.LastIndexOf('.'));
                if (ExtensionOpenFile == ".xml")
                {
                    string PatchFileNotExtension = myDialog.FileName.Split('.')[0];
                    XElement DataElement = XElement.Parse(File.ReadAllText(myDialog.FileName));
                    var csvData = SomeFunctions.CSV_XML(DataElement);
                    File.WriteAllText(PatchFileNotExtension + "(csv).csv", (string)csvData);

                }
                else if (ExtensionOpenFile == ".csv")
                {
                    try
                    {
                        string PatchFileNotExtension = myDialog.FileName.Split('.')[0];
                        smf.CSV_XML(PatchOpenFile, PatchFileNotExtension + "(xml).xml", "users", "user");
                    }
                    catch
                    {

                    }
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
    }
}
