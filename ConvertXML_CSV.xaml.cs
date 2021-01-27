using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace CSVXML_TemplateEditor
{
    public partial class ConvertXML_CSV : Window
    {
        public ConvertXML_CSV()
        {
            InitializeComponent();
            FormXML FormXML = new FormXML();
            row.Text = File.ReadLines(FormXML.XmlCsvPatch).Skip(1).First();
        }

        private void EnterButton(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(TextFieldColumns.Text == "")
            {
                MessageBox.Show("The input field is empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    FormXML FormXML = new FormXML();

                    FileStream fn = new FileStream(FormXML.XmlCsvPatch, FileMode.Open, FileAccess.Read);
                    StreamReader fon = new StreamReader(fn);
                    string str = fon.ReadToEnd(); //считали в переменную содержимое файла
                    fon.Close();
                    fn.Close();

                    str = str.Replace("ThisTextWillThenBeColumns", TextFieldColumns.Text); //заменили что нужно

                    fn = new FileStream(FormXML.XmlCsvPatch, FileMode.Create, FileAccess.Write);
                    StreamWriter fin = new StreamWriter(fn, Encoding.UTF8);
                    fin.Write(str); //записали обрано
                    fin.Close();
                    fn.Close();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Unable to specify columns for the file!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
