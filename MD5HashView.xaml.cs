using System.Windows;
using System.Windows.Controls;

namespace CSVXML_TemplateEditor
{
    /// <summary>
    /// Логика взаимодействия для MD5HashView.xaml
    /// </summary>
    public partial class MD5HashView : Window
    {
        public MD5HashView()
        {
            InitializeComponent();
            MinWidth = 400;
            MinHeight = 220;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MD5FileHashText.Text = FormXML.MD5Text;
        }

        private void MD5FileHashTextCheck_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (MD5FileHashText.Text.Length == MD5FileHashTextCheck.Text.Length)
            {
                if (MD5FileHashText.Text == MD5FileHashTextCheck.Text)
                    MessageBox.Show(ProgramSettings.TheValuesMatch, ProgramSettings.Done, MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show(ProgramSettings.TheValuesDontMatch, ProgramSettings.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
