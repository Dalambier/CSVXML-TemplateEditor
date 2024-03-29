﻿using Microsoft.Win32;
using System;
using System.Data;
using System.IO;
using System.Linq;
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
            MinHeight = 200;
        }

        readonly SomeFunctions smf = new SomeFunctions();

        public string PatchOpenFile; //Сохранение пути открываемого файла
        public string ExtensionOpenFile; //Сохранение расширения файла
        public static string NewFilePatch;
        public static string XmlCsvPatch;
        public static object CSVFileData;
        public static string MD5Text;

        private string DragAndDropPatchFile;


        private void NewFile(object sender, RoutedEventArgs e)
        {
            NewFile();
        }

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFile();
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
            SaveFileDialog myDialog = new SaveFileDialog
            {
                Filter = "XML-" + ProgramSettings.Documents + "(*.xml)|*.xml|CSV-" + ProgramSettings.Documents + " (*.csv)|*.csv"
            };
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
            OpenFileDialog myDialog = new OpenFileDialog
            {
                Filter = ProgramSettings.Documents + "(*.xml;*.csv)|*.XML;*.csv"
            };

            if (myDialog.ShowDialog() == true)
            {
                ConvertFile(myDialog.FileName);
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
            OpenFileDialog myDialog = new OpenFileDialog
            {
                Filter = ProgramSettings.Documents + "(*.xml;*.csv)|*.XML;*.csv"
            };
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

        private void Base64Coding(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog
            {
                Filter = ProgramSettings.Documents + "(*.xml;*.csv)|*.XML;*.csv"
            };
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
            OpenFileDialog myDialog = new OpenFileDialog
            {
                Filter = ProgramSettings.Documents + "(*.xml;*.csv)|*.XML;*.csv"
            };
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
            SetLanguage();
        }

        private void AddRowContextMenu(object sender, RoutedEventArgs e)
        {
            if (ExtensionOpenFile == ".csv")
            {
                AddRow(true);
            }
            else if (ExtensionOpenFile == ".xml")
            {
                AddRow(false);
            }
        }

        private void AddRowMenu(object sender, RoutedEventArgs e)
        {
            if (ExtensionOpenFile == ".csv")
            {
                AddRow(true);
            }
            else if (ExtensionOpenFile == ".xml")
            {
                AddRow(false);
            }
        }

        private void AddColumnwMenu(object sender, RoutedEventArgs e)
        {
            if (ExtensionOpenFile == ".csv")
            {
                AddColumn(true);
            }
            else if (ExtensionOpenFile == ".xml")
            {
                AddColumn(false);
            }
        }

        private void AddColumnContextMenu(object sender, RoutedEventArgs e)
        {
            if (ExtensionOpenFile == ".xml")
            {
                AddColumn(false);
            }
            else if (ExtensionOpenFile == ".csv")
            {
                AddColumn(true);
            }
        }

        private void OpenDragAndDrop(object sender, MouseButtonEventArgs e)
        {
            ExtensionOpenFile = DragAndDropPatchFile.Substring(DragAndDropPatchFile.LastIndexOf('.'));
            if (ExtensionOpenFile == ".xml")
            {
                PatchOpenFile = DragAndDropPatchFile;
                OpenXMLFile();
            }
            else if (ExtensionOpenFile == ".csv")
            {
                PatchOpenFile = DragAndDropPatchFile;
                OpenCSVFile();
            }
            else
            {
                DragAndDropField.Visibility = Visibility.Hidden;
            }
            DragAndDropField.Visibility = Visibility.Hidden;
        }

        private void ConvertFileDragAndDrop(object sender, MouseButtonEventArgs e)
        {
            ExtensionOpenFile = DragAndDropPatchFile.Substring(DragAndDropPatchFile.LastIndexOf('.'));
            ConvertFile(DragAndDropPatchFile);
            DragAndDropField.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetLanguage();
        }

        private void AboutProgram(object sender, RoutedEventArgs e)
        {
            FormAboutProgram AbtFrm = new FormAboutProgram();
            AbtFrm.Show();
        }

        private void OpenDocumntation(object sender, RoutedEventArgs e)
        {
            FormDocumentation document = new FormDocumentation();
            document.Show();
        }


        //Functions
        private void SetLanguage()
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
            Menu_AddRow.Header = ProgramSettings.AddRow;
            Menu_Settings.Header = ProgramSettings.Menu_Settings;

            Menu_Help.Header = ProgramSettings.Menu_Help;
            Menu_Github.Header = ProgramSettings.Menu_GithubPage;
            Menu_AboutProgram.Header = ProgramSettings.Menu_AboutProgram;
            Menu_Documentation.Header = ProgramSettings.Menu_Documentation;

            OpenContextMenuText.Text = ProgramSettings.Menu_Open;
            ConvertContextMenuText.Text = ProgramSettings.Menu_Convert;

            ContextMenuAddRow.Header = ProgramSettings.AddRow;
            ContextMenuAddColumn.Header = ProgramSettings.Menu_AddColumn;
        }

        private void NewFile()
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

        private void OpenFile()
        {
            OpenFileDialog myDialog = new OpenFileDialog
            {
                Filter = ProgramSettings.Documents + "(*.xml;*.csv)|*.XML;*.csv"
            };

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

        private void AddRow(bool ItsCSV)
        {
            string Filepatch;
            if (ItsCSV == true)
            {
                SaveCSVFile(false);
                Filepatch = PatchOpenFile;
            }
            else
            {
                XMLTable.SelectAllCells();
                XMLTable.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, XMLTable);
                XMLTable.UnselectAll();
                Filepatch = "tempfile.csv";
                smf.TableToCSV(Filepatch, Properties.Settings.Default.Delimiter);
            }
            int i = 0, count = 0; string NewRow = "";
            while ((i = File.ReadLines(Filepatch).Skip(1).First().IndexOf(Properties.Settings.Default.Delimiter, i)) != -1)
            { ++count; i += Properties.Settings.Default.Delimiter.Length; } //Просчёт сколько делимитеров

            for (int NewRowI = 0; NewRowI < count; NewRowI++)
            {
                NewRow += Properties.Settings.Default.Delimiter; //Заполнение строки делимитерами
            }

            using (StreamWriter file = new StreamWriter(Filepatch, true, Encoding.UTF8))
            {
                file.WriteLine(NewRow); //Добавление строки в файл
            }
            if (ItsCSV == true)
                OpenCSVFile();
            else
            {
                smf.CSV_XML(Filepatch, PatchOpenFile, Properties.Settings.Default.MainElementXML, Properties.Settings.Default.SecondaryElementXML, Properties.Settings.Default.Delimiter[0]);
                File.Delete(Filepatch);
                OpenXMLFile();
            }
        }

        private void AddColumn(bool ItsCSV)
        {
            FormNewColumn frmclm = new FormNewColumn();
            frmclm.ShowDialog();

            string Filepatch;
            if (ItsCSV == true)
            {
                SaveCSVFile(false);
                Filepatch = PatchOpenFile;
            }
            else
            {
                XMLTable.SelectAllCells();
                XMLTable.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
                ApplicationCommands.Copy.Execute(null, XMLTable);
                XMLTable.UnselectAll();
                Filepatch = "tempfile.csv";
                smf.TableToCSV(Filepatch, Properties.Settings.Default.Delimiter);
            }


            var inputLines = File.ReadAllLines(Filepatch, Encoding.UTF8);
            for (int i = 0; i < inputLines.Length; i++)
            {
                if (i == 0)
                    inputLines[i] = inputLines[i] + Properties.Settings.Default.Delimiter + frmclm.ShowColumn();
                else
                    inputLines[i] = inputLines[i] + Properties.Settings.Default.Delimiter;
            }
            File.WriteAllLines(Filepatch, inputLines, Encoding.UTF8);


            if (ItsCSV == true)
                OpenCSVFile();
            else
            {
                smf.CSV_XML(Filepatch, PatchOpenFile, Properties.Settings.Default.MainElementXML, Properties.Settings.Default.SecondaryElementXML, Properties.Settings.Default.Delimiter[0]);
                File.Delete(Filepatch);
                OpenXMLFile();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.N)
                NewFile();

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.O)
                OpenFile();

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.S)
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


            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.K)
            {
                if (ExtensionOpenFile == ".csv")
                {
                    AddColumn(true);
                }
                else if (ExtensionOpenFile == ".xml")
                {
                    AddColumn(false);
                }
            }


            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.L)
            {
                if (ExtensionOpenFile == ".csv")
                {
                    AddRow(true);
                }
                else if (ExtensionOpenFile == ".xml")
                {
                    AddRow(false);
                }
            }


            if (e.Key == Key.F3)
            {
                FormSettings settingsfrm = new FormSettings();
                settingsfrm.ShowDialog();
                SetLanguage();
            }


            if (e.Key == Key.F2)
            {
                FormAboutProgram abtfrm = new FormAboutProgram();
                abtfrm.Show();
            }

            if (e.Key == Key.F1)
            {
                FormDocumentation document = new FormDocumentation();
                document.Show();
            }
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            DragAndDropField.Visibility = Visibility.Visible;
            string[] patch = (string[])e.Data.GetData(DataFormats.FileDrop);
            DragAndDropPatchFile = patch[0];
        }

        private void ConvertFile(string Patch)
        {
            ExtensionOpenFile = Patch.Substring(Patch.LastIndexOf('.'));
            if (ExtensionOpenFile == ".xml")
            {
                try
                {
                    string PatchFileNotExtension = Patch.Split('.')[0];
                    XElement DataElement = XElement.Parse(File.ReadAllText(Patch));
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
                    string PatchFileNotExtension = Patch.Split('.')[0];
                    smf.CSV_XML(PatchOpenFile, PatchFileNotExtension + "(xml).xml", Properties.Settings.Default.MainElementXML, Properties.Settings.Default.SecondaryElementXML, Properties.Settings.Default.Delimiter[0]);
                }
                catch { }
            }
        }
    }
}
