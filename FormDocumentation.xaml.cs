using System.Windows;
using System.Windows.Input;

namespace CSVXML_TemplateEditor
{
    /// <summary>
    /// Логика взаимодействия для FormDocumentation.xaml
    /// </summary>
    public partial class FormDocumentation : Window
    {
        public FormDocumentation()
        {
            InitializeComponent();
        }

        private void introduction(object sender, MouseButtonEventArgs e)
        {
            Field.Text = ProgramSettings.Document_introduction_text;
        }

        private void Open(object sender, MouseButtonEventArgs e)
        {
            Field.Text = ProgramSettings.Document_Open_text;
        }

        private void Save(object sender, MouseButtonEventArgs e)
        {
            Field.Text = ProgramSettings.Document_Save_text;
        }

        private void Edit(object sender, MouseButtonEventArgs e)
        {
            Field.Text = ProgramSettings.Document_Edit_text;
        }

        private void Convert(object sender, MouseButtonEventArgs e)
        {
            Field.Text = ProgramSettings.Document_Convert_text;
        }

        private void Crypt(object sender, MouseButtonEventArgs e)
        {
            Field.Text = ProgramSettings.Document_Crypt_text;
        }

        private void Settings(object sender, MouseButtonEventArgs e)
        {
            Field.Text = ProgramSettings.Document_Settings_text;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MinHeight = 470;
            MinWidth = 500;
            this.Title = ProgramSettings.Menu_Documentation;

            Field.Text = ProgramSettings.Document_introduction_text;
            DocTitle.Text = ProgramSettings.Menu_Documentation;
            Title_intdrod.Text = ProgramSettings.Document_introduction;
            Title_Open.Text = ProgramSettings.Document_Open;
            Title_Save.Text = ProgramSettings.Document_Save;
            Title_Edit.Text = ProgramSettings.Document_Edit;
            Title_Settings.Text = ProgramSettings.Document_Settings;
            Title_Convert.Text = ProgramSettings.Document_Convert;
            Title_Crypt.Text = ProgramSettings.Document_Crypt;
        }
    }
}
