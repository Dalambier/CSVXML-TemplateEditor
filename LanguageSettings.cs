using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVXML_TemplateEditor
{
    class LanguageSettings
    {
        public static string Menu_File;
        public static string Menu_New;
        public static string Menu_Open;
        public static string Menu_Save;
        public static string Menu_SaveAs;
        public static string Menu_Convert;
        public static string Menu_Exit;

        public static string Menu_Edit;
        public static string Menu_Encryption;
        public static string Menu_Encoding;
        public static string Menu_Decoding;
        public static string Menu_AddColumn;
        public static string Menu_Settings;

        public static string Menu_Help;
        public static string Menu_GithubPage;
        public static string Menu_AboutProgram;
        public static string Menu_Documentation;


        public void LanguageChecked()
        {
            if (Properties.Settings.Default.Language == "English")
            {
                //Main menu of the program
                Menu_File = "File";
                Menu_New = "New";
                Menu_Open = "Open";
                Menu_Save = "Save";
                Menu_SaveAs = "Save as";
                Menu_Convert = "Convert";
                Menu_Exit = "Exit";

                Menu_Edit = "Edit";
                Menu_Encryption = "Encryption";
                Menu_Encoding = "Encoding";
                Menu_Decoding = "Decoding";
                Menu_AddColumn = "Add column";
                Menu_Settings = "Settings";

                Menu_Help = "Help";
                Menu_GithubPage = "Github Page";
                Menu_AboutProgram = "About program";
                Menu_Documentation = "Documentation";
            }
            else if (Properties.Settings.Default.Language == "Russian")
            {
                //Главное меню программы
                Menu_File = "Файл";
                Menu_New = "Создать";
                Menu_Open = "Открыть";
                Menu_Save = "Сохранить";
                Menu_SaveAs = "Сохранить как";
                Menu_Convert = "Конвертировать";
                Menu_Exit = "Выход";

                Menu_Edit = "Правка";
                Menu_Encryption = "Шифрование";
                Menu_Encoding = "Закодировать";
                Menu_Decoding = "Декодировать";
                Menu_AddColumn = "Добавить столбец";
                Menu_Settings = "Настройки";

                Menu_Help = "Справка";
                Menu_GithubPage = "Страница Github";
                Menu_AboutProgram = "О программе";
                Menu_Documentation = "Документация";
            }
        }
        public void SettingsIsNullIsNull()
        {
            if (Properties.Settings.Default.Language == "")
                Properties.Settings.Default.Language = "English";

            if (Properties.Settings.Default.Delimiter == "")
                Properties.Settings.Default.Delimiter = ";";

            if (Properties.Settings.Default.MainElementXML == "")
                Properties.Settings.Default.Delimiter = "user";

            if (Properties.Settings.Default.SecondaryElementXML == "")
                Properties.Settings.Default.Delimiter = "users";
        }
    }
}