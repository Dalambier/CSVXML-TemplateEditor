using System;
using System.Windows;
using System.Windows.Threading;

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
        }
        DispatcherTimer timer = new DispatcherTimer();
        private void timerTick(object sender, EventArgs e)
        {
            timer.Stop();
            FormXML xml = new FormXML();
            xml.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProgramSettings lng = new ProgramSettings();
            lng.SettingsIsNullIsNull();
            lng.LanguageChecked();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += timerTick;
            timer.Start();
        }
    }
}
