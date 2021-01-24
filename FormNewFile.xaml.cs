using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CSVXML_TemplateEditor
{
    public partial class FormNewFile : Window
    {
        public FormNewFile()
        {
            InitializeComponent();
            MinWidth = 400;
            MinHeight = 200;
        }
        public int ColumnValue = 1;
        public string NewTableString;

        private void NextColumnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ColumnValue++;
            ColumTitle.Text = "Enter text of " + ColumnValue + " column";
            NewTableString += TextFieldColumn.Text + ';';
            TextFieldColumn.Text = "";
        }

        private void CompleteMouseDown(object sender, MouseButtonEventArgs e)
        {
            SomeFunctions smf = new SomeFunctions();
            NewTableString = NewTableString.Remove(NewTableString.Length - 1);
            string RowTable = ";";


            SaveFileDialog myDialog = new SaveFileDialog();
            myDialog.Filter = "XML-Document (*.xml)|*.xml|CSV-Document (*.csv)|*.csv";
            if (myDialog.ShowDialog() == true)
            {
                smf.CheckClipBoard();
                string ExtensionOpenFile = myDialog.FileName.Substring(myDialog.FileName.LastIndexOf('.'));
                if (ExtensionOpenFile == ".xml")
                {
                    for (int i = 0; i < ColumnValue - 3; i++)
                    {
                        RowTable += ";";
                    }
                    StreamWriter file = new StreamWriter("tempfile.csv", true, Encoding.UTF8);
                    file.WriteLine(NewTableString);
                    file.WriteLine(RowTable);
                    file.Close();
                    smf.CSV_XML("tempfile.csv", myDialog.FileName, "users", "user");
                    File.Delete("tempfile.csv");
                }
                else if (ExtensionOpenFile == ".csv")
                {
                    for (int i = 0; i < ColumnValue - 3; i++)
                    {
                        RowTable += ";";
                    }
                    StreamWriter file = new StreamWriter(myDialog.FileName, true, Encoding.UTF8);
                    file.WriteLine(NewTableString);
                    file.WriteLine(RowTable);
                    file.Close();
                }
                this.Close();
            }
        }

        private void NextColumnMouseEnter(object sender, MouseEventArgs e)
        {
            NextColumnButton.Background = new SolidColorBrush(Color.FromRgb(38, 50, 56));
        }

        private void NextColumnMouseLeave(object sender, MouseEventArgs e)
        {
            NextColumnButton.Background = new SolidColorBrush(Color.FromRgb(15, 17, 26));
        }

        private void CompleteMouseEnter(object sender, MouseEventArgs e)
        {
            CompleteButton.Background = new SolidColorBrush(Color.FromRgb(38, 50, 56));
        }

        private void CompleteMouseLeave(object sender, MouseEventArgs e)
        {
            CompleteButton.Background = new SolidColorBrush(Color.FromRgb(15, 17, 26));
        }
    }
}