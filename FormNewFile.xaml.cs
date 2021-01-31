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
            MinWidth = 485;
            MinHeight = 200;
        }
        public int ColumnValue = 1;
        public string NewTableString;

        private void NextColumnMouseDown(object sender, MouseButtonEventArgs e)
        {
            ColumnValue++;
            ColumTitle.Text = ProgramSettings.EnterText + ColumnValue + ProgramSettings.OnColumn;
            NewTableString += TextFieldColumn.Text + Properties.Settings.Default.Delimiter[0];
            TextFieldColumn.Text = "";
        }

        private void CompleteMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ColumnValue < 3)
            {
                MessageBox.Show(ProgramSettings.Dont1Column, ProgramSettings.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                SomeFunctions smf = new SomeFunctions();
                NewTableString = NewTableString.Remove(NewTableString.Length - 1);
                string RowTable = Properties.Settings.Default.Delimiter;


                SaveFileDialog myDialog = new SaveFileDialog();
                myDialog.Filter = "XML-" + ProgramSettings.Documents + " (*.xml)|*.xml|CSV-" + ProgramSettings.Documents + " (*.csv)|*.csv";
                if (myDialog.ShowDialog() == true)
                {
                    FormXML.NewFilePatch = myDialog.FileName;
                    string ExtensionOpenFile = myDialog.FileName.Substring(myDialog.FileName.LastIndexOf('.'));
                    if (ExtensionOpenFile == ".xml")
                    {
                        for (int i = 0; i < ColumnValue - 3; i++)
                        {
                            RowTable += Properties.Settings.Default.Delimiter;
                        }
                        StreamWriter file = new StreamWriter("tempfile.csv", true, Encoding.UTF8);
                        file.WriteLine(NewTableString);
                        file.WriteLine(RowTable);
                        file.Close();
                        smf.CSV_XML("tempfile.csv", myDialog.FileName, Properties.Settings.Default.MainElementXML, Properties.Settings.Default.SecondaryElementXML, Properties.Settings.Default.Delimiter[0]);
                        File.Delete("tempfile.csv");
                    }
                    else if (ExtensionOpenFile == ".csv")
                    {
                        for (int i = 0; i < ColumnValue - 3; i++)
                        {
                            RowTable += Properties.Settings.Default.Delimiter;
                        }
                        StreamWriter file = new StreamWriter(myDialog.FileName, true, Encoding.UTF8);
                        file.WriteLine(NewTableString);
                        file.WriteLine(RowTable);
                        file.Close();
                    }
                    this.Close();
                }
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ColumTitle.Text = ProgramSettings.NewFileTitle;
            CompleteButtonText.Text = ProgramSettings.CompleteButton;
            NextColumnText.Text = ProgramSettings.NextColumnButton;
        }
    }
}