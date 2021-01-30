namespace CSVXML_TemplateEditor
{
    class ProgramSettings
    {
        public static string Done;
        public static string Error;
        public static string IncorrerctFile;


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


        public static string Settings_Title;
        public static string Settings_Language;
        public static string Settings_Delimiter;
        public static string Settings_MainXMLElement;
        public static string Settings_SecondaryXMLElement;
        public static string Settings_AcceptButton;
        public static string Settings_DefaultButton;
        public static string Settings_AcceptMessage;
        public static string Settings_DefaultMessage;
        public static string Settings_Changed;


        public static string Documents;


        public void LanguageChecked()
        {
            if (Properties.Settings.Default.Language == "English")
            {
                //Messages
                Done = "Done";
                Error = "Error";
                IncorrerctFile = "Incorrerct File";
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

                //Settings form
                Settings_Title = "Settings";
                Settings_Language = "Language";
                Settings_Delimiter = "Delimiter";
                Settings_MainXMLElement = "Main XML Element";
                Settings_SecondaryXMLElement = "Secondary XML Element";
                Settings_AcceptButton = "Accept";
                Settings_DefaultButton = "Default";
                Settings_AcceptMessage = "The settings have been applied, to change the language completely, restart this software!";
                Settings_DefaultMessage = "The settings are set by default, to change the language completely, restart this software!";
                Settings_Changed = "Settings Changed";

                //FileWork
                Documents = "Documents";
            }
            else if (Properties.Settings.Default.Language == "Russian")
            {
                //Messages
                Error = "Ошибка";
                Done = "Выполнено";
                IncorrerctFile = "Некорректный файл";

                //Main menu program
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

                //Settings form
                Settings_Title = "Настройки";
                Settings_Language = "Язык";
                Settings_Delimiter = "Делимитер";
                Settings_MainXMLElement = "Основной XML элемент";
                Settings_SecondaryXMLElement = "Вторичный XML элемент";
                Settings_AcceptButton = "Применить";
                Settings_DefaultButton = "По умолчанию";
                Settings_AcceptMessage = "Настройки применены, для полного изменения языка, перезапустите данное программное обеспечение";
                Settings_DefaultMessage = "Настройки поставлены по умолчанию, для полного изменения языка, перезапустите данное программное обеспечение";
                Settings_Changed = "Настройки изменены";

                //FileWork
                Documents = "Документы";
            }
        }
        public void SettingsIsNullIsNull()
        {
            if (Properties.Settings.Default.Language == "")
                Properties.Settings.Default.Language = "English";

            if (Properties.Settings.Default.Delimiter == "")
                Properties.Settings.Default.Delimiter = ";";

            if (Properties.Settings.Default.MainElementXML == "")
                Properties.Settings.Default.MainElementXML = "user";

            if (Properties.Settings.Default.SecondaryElementXML == "")
                Properties.Settings.Default.SecondaryElementXML = "users";
        }
    }
}