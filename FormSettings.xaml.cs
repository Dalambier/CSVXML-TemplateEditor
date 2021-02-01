using System.Windows;
using System.Windows.Input;

namespace CSVXML_TemplateEditor
{
    /// <summary>
    /// Логика взаимодействия для FormSettings.xaml
    /// </summary>
    public partial class FormSettings : Window
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void DefaultsettingsButton(object sender, MouseButtonEventArgs e)
        {
            Properties.Settings.Default.Language = "English";
            Properties.Settings.Default.Delimiter = ";";
            Properties.Settings.Default.MainElementXML = "user";
            Properties.Settings.Default.SecondaryElementXML = "users";
            Properties.Settings.Default.Save();
            ProgramSettings lg = new ProgramSettings();
            lg.LanguageChecked();
            SetLanguage();
            MessageBox.Show(ProgramSettings.Settings_DefaultMessage, ProgramSettings.Done, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void AcceptSettingsButton(object sender, MouseButtonEventArgs e)
        {
            Properties.Settings.Default.MainElementXML = MainXMLElementField.Text;
            Properties.Settings.Default.SecondaryElementXML = SecondaryXMLElementField.Text;
            Properties.Settings.Default.Delimiter = DelimiterField.Text;
            if (LanguageBox.SelectedIndex == 0)
            {
                Properties.Settings.Default.Language = "English";
            }
            else if (LanguageBox.SelectedIndex == 1)
            {
                Properties.Settings.Default.Language = "Russian";
            }
            Properties.Settings.Default.Save();
            ProgramSettings lg = new ProgramSettings();
            lg.LanguageChecked();
            SetLanguage();
            MessageBox.Show(ProgramSettings.Settings_AcceptMessage, ProgramSettings.Done, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Fields
            MainXMLElementField.Text = Properties.Settings.Default.MainElementXML;
            SecondaryXMLElementField.Text = Properties.Settings.Default.SecondaryElementXML;
            DelimiterField.Text = Properties.Settings.Default.Delimiter;
            if (Properties.Settings.Default.Language == "English")
            {
                LanguageBox.SelectedIndex = 0;
            }
            else if (Properties.Settings.Default.Language == "Russian")
            {
                LanguageBox.SelectedIndex = 1;
            }
            SetLanguage();
        }
        private void SetLanguage()
        {
            SettingsTitle.Text = ProgramSettings.Settings_Title;
            LanguageText.Text = ProgramSettings.Settings_Language;
            Delimiter.Text = ProgramSettings.Settings_Delimiter;
            MainXMLElementText.Text = ProgramSettings.Settings_MainXMLElement;
            SecondaryXMLElement.Text = ProgramSettings.Settings_SecondaryXMLElement;
            AcceptSettings.Text = ProgramSettings.Settings_AcceptButton;
            DefaultSettings.Text = ProgramSettings.Settings_DefaultButton;
            this.Title = ProgramSettings.Settings_Title;
        }
    }
}
