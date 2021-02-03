using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            MinHeight = 470;
            MinWidth = 500;
        }

        private void introduction(object sender, MouseButtonEventArgs e)
        {
            Field.Text = "Введение" +
                "\nДанное программное обеспечение предназначено для быстрого редактирования/конвертирования SCV и XML файлов, изменения делимитера в CSV файлах, изменения названий XML-элементов и других операций." +
                "\nПри возникновении низкой работоспособности приложения, необходимо повысить объём оперативной памяти." +
                "\nВо время обработки (конвертации, сохранения, открытия, шифрования) больших файлов, не рекомендуется использовать компьютер, для избежания потери скорости обработки файла и различных ошибок.";
        }
    }
}
