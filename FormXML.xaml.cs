using Microsoft.Win32;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;

namespace CSVXML_TemplateEditor
{
    public partial class FormXML : Window
    {
        public FormXML()
        {
            InitializeComponent();
        }

        public string PatchOpenFile; //Сохранение пути открываемого файла
        public string ExtensionOpenFile; //Сохранение расширения файла

        private void LoadFileMouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Documents(*.XML;*.CSV)|*.XML;*.CSV";

            if (myDialog.ShowDialog() == true)
            {
                PatchOpenFile = myDialog.FileName;
                ExtensionOpenFile = myDialog.FileName.Substring(myDialog.FileName.LastIndexOf('.'));
                if (ExtensionOpenFile == ".xml")
                {
                    myDialog.FileName = myDialog.FileName;
                    DataSet dataset = new DataSet();
                    dataset.ReadXml(myDialog.FileName);
                    XMLTable.ItemsSource = dataset.Tables[0].DefaultView;
                }
                else if (ExtensionOpenFile == ".csv")
                {
                    SomeFunctions smf = new SomeFunctions();
                    smf.CSV_XML(PatchOpenFile, "tempfile.xml", "users", "user");

                    DataSet dataset = new DataSet();
                    dataset.ReadXml("tempfile.xml");
                    XMLTable.ItemsSource = dataset.Tables[0].DefaultView;
                    File.Delete("tempfile.xml");
                }
            }
        }

        private void SaveFileMouseDown(object sender, MouseButtonEventArgs e)
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



        private void LoadFileMouseEnter(object sender, MouseEventArgs e)
        {
            LoadFileButton.Background = new SolidColorBrush(Color.FromRgb(30, 34, 52));
        }

        private void LoadFileMouseLeave(object sender, MouseEventArgs e)
        {
            LoadFileButton.Background = new SolidColorBrush(Color.FromRgb(15, 17, 26));
        }

        private void SaveFileMouseEnter(object sender, MouseEventArgs e)
        {
            SaveFileButton.Background = new SolidColorBrush(Color.FromRgb(30, 34, 52));
        }

        private void SaveFileMouseLeave(object sender, MouseEventArgs e)
        {
            SaveFileButton.Background = new SolidColorBrush(Color.FromRgb(15, 17, 26));
        }
    }
}
