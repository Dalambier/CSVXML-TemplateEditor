using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CSVXML_TemplateEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MinWidth = 500;
            MinHeight = 250;
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Button_1.Background = new SolidColorBrush(Color.FromRgb(38, 50, 56));
        }

        private void Button_1_MouseLeave(object sender, MouseEventArgs e)
        {
            Button_1.Background = new SolidColorBrush(Color.FromRgb(15, 17, 26));
        }

        private void XMLFormCreate(object sender, MouseButtonEventArgs e)
        {
            FormXML xml = new FormXML();
            xml.Show();
            this.Close();
        }
    }
}
