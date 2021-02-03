using System.Windows;

namespace CSVXML_TemplateEditor
{
    /// <summary>
    /// Логика взаимодействия для FormAboutProgram.xaml
    /// </summary>
    public partial class FormAboutProgram : Window
    {
        public FormAboutProgram()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = ProgramSettings.Menu_AboutProgram;
            Developer.Text = ProgramSettings.Developer;
            Teacher_txt.Text = ProgramSettings.Teacher;
            Version.Text = ProgramSettings.Version;
            DeveloperName.Text = ProgramSettings.Developer_Name;
            TeacherName.Text = ProgramSettings.Teacher_Name;
        }
    }
}
