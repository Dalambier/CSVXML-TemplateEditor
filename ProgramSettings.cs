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


        public static string NewFileTitle;
        public static string CompleteButton;
        public static string NextColumnButton;
        public static string Dont1Column;
        public static string EnterText;
        public static string OnColumn;
        public static string AddRow;


        public static string Documents;
        public static string TheInputFieldIsEmpty;
        public static string UnableToSpecifyColumnsForTheFile;
        public static string Enter;
        public static string EnterColumnsForCsvFile;
        public static string TheValuesMatch;
        public static string TheValuesDontMatch;


        public static string EnterColumnName;
        public static string ZeroField;


        public static string Developer;
        public static string Teacher;
        public static string Version;
        public static string Developer_Name;
        public static string Teacher_Name;


        public static string Document_introduction;
        public static string Document_Open;
        public static string Document_Save;
        public static string Document_Crypt;
        public static string Document_Edit;
        public static string Document_Convert;
        public static string Document_Settings;
        public static string Document_introduction_text;
        public static string Document_Open_text;
        public static string Document_Save_text;
        public static string Document_Crypt_text;
        public static string Document_Edit_text;
        public static string Document_Convert_text;
        public static string Document_Settings_text;


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
                Settings_AcceptMessage = "The settings have been applied";
                Settings_DefaultMessage = "The settings are set by default";
                Settings_Changed = "Settings Changed";

                //New File
                NewFileTitle = "Enter text of 1 column";
                CompleteButton = "Colmplete";
                NextColumnButton = "Next column";
                Dont1Column = "Minimum column = 2";
                EnterText = "Enter text of ";
                OnColumn = " column";

                //FileWork
                Documents = "Documents";
                TheInputFieldIsEmpty = "The input field is empty!";
                UnableToSpecifyColumnsForTheFile = "Unable to specify columns for the file";
                Enter = "Enter";
                EnterColumnsForCsvFile = "Enter columns for csv file";
                TheValuesMatch = "The values match";
                TheValuesDontMatch = "The values don't match";
                EnterColumnName = "Enter column name";
                ZeroField = "The field cannot be empty";
                AddRow = "Add row";

                //About
                Developer = "Developer";
                Teacher = "Teacher";
                Version = "Version";
                Developer_Name = "Grishin Danil Vitalievich";
                Teacher_Name = "Sedov Artem Viktorovich";

                //Document
                Document_introduction = "Introduction";
                Document_Open = "Open";
                Document_Save = "Save";
                Document_Crypt = "Crypt";
                Document_Edit = "Edit";
                Document_Convert = "Convert";
                Document_Settings = "Settings";
                Document_introduction_text = "";
                Document_Open_text = "Introduction" +
                "\n     This software is designed to quickly edit / convert CSV and XML files, change the delimiter in CSV files, change the names of XML elements, and other operations." +
                "\n     If there is a low performance of the application, you need to increase the amount of RAM." +
                "\n     When processing (converting, saving, opening, encrypting) large files, it is not recommended to use a computer to avoid loss of file processing speed and various errors.";
                Document_Save_text = "Open" +
                "\n     In order to work with a file, you need to either create it or open it." +
                "\n     The file is created by pressing Ctrl+N or by clicking on [NEW] in the top menu. You need to write the column names for the file. It is worth remembering that it is not desirable to name the column names with numbers and create less than two columns for the file.." +
                "\n     Opening a file allows you to open a file in the form of a table in the program to view and change information in it. To open it, you must either transfer the desired file to the program using the Drag system&Drop and click on the [Open] button, or click in the top menu [Open]" +
                "\n     It is worth remembering that to open a CSV file, you need to set the correct delimiter in the settings to read the file correctly.";
                Document_Crypt_text = "Crypt" +
                "\n     The file can be encrypted and decrypted using base64 technology by selecting in the menu in the [Edit] tab next [encryption] and in base64 you can select the desired action." +
                "\n     You can check the hash of the file by going to the [Edit] tab and selecting MD5 Hash File. After that, a form will open in which the hash of the file will be written and you can compare it with another hash that the user has. The program will write whether the hash sums match or not..";
                Document_Edit_text = "Edit" +
                "\n     After successfully opening the file, it is possible to interact with the file data." +
                "\n     Features: Add a row by right-clicking on the table, calling the context menu, from which you can select the operation [Add row], you can also add a column from the same context menu, it is worth remembering that the column names should preferably be without numbers. These actions are also available from the menu, in the [Edit] tab." +
                "\n     To delete a line, click on the element of the unnecessary line and press the [Delete] key on the keyboard." +
                "\n     The contents of the cells in the table can be edited by clicking on the element and writing the desired value.";
                Document_Convert_text = "Convert" +
                "\n     It is possible to quickly convert the file, without interacting with the visual table. For this action, you need to drag the file into the program by the Drag system&Drop or click on [Convert] in the program menu." +
                "\n     After the conversion, another c file appears next to the file with the signature in which format it was converted." +
                "\n     When converting from XML to CSV, you must specify the column names for the new file, based on the data shown in the table in the form.";
                Document_Settings_text = "Settings" +
                "\n     To change the settings of this software, the user needs to go to the [Edit] tab, then click on [Settings]." +
                "\n     In the settings, you can change the software language to English and Russian, change the delimiter for CSV files, and change the names of the secondary and main XML elements. When you hover over the input fields, hints are displayed." +
                "\n     If, for example, the delimiter [;] is specified in the settings, but the user tries to open a CSV file with the delimiter [,], the program will not be able to read the file." +
                "\n     You can open the file and change the delimiter in the settings and save it to change all the delimiters in the file.";
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
                Settings_AcceptMessage = "Настройки применены";
                Settings_DefaultMessage = "Настройки поставлены по умолчанию";
                Settings_Changed = "Настройки изменены";

                //New File
                NewFileTitle = "Введите текст в 1 столбец";
                CompleteButton = "Завершить";
                NextColumnButton = "Следующий";
                Dont1Column = "Минимальное количество столбцов в файле = 2";
                EnterText = "Введите текст в ";
                OnColumn = " столбец";

                //FileWork
                Documents = "Документы";
                TheInputFieldIsEmpty = "Поле ввода пустое!";
                UnableToSpecifyColumnsForTheFile = "Невозможно указать столбцы для файла";
                Enter = "Ввод";
                EnterColumnsForCsvFile = "Введите столбцы для csv-файла";
                TheValuesMatch = "Значения совпадают";
                TheValuesDontMatch = "Значения не совпадают";
                EnterColumnName = "Введите название столбца";
                ZeroField = "Поле не может быть пустым";
                AddRow = "Добавить строку";

                //About
                Developer = "Разработчик";
                Teacher = "Преподаватель";
                Version = "Версия";
                Developer_Name = "Гришин Данил Витальевич";
                Teacher_Name = "Седов Артём Викторович";

                //Document
                Document_introduction = "Введение";
                Document_Open = "Открытие";
                Document_Save = "Сохранение";
                Document_Crypt = "Шифрование";
                Document_Edit = "Редактирование";
                Document_Convert = "Конвертация";
                Document_Settings = "Настройки";
                Document_introduction_text = "Введение" +
                "\n     Данное программное обеспечение предназначено для быстрого редактирования/конвертирования SCV и XML файлов, изменения делимитера в CSV файлах, изменения названий XML-элементов и других операций." +
                "\n     При возникновении низкой работоспособности приложения, необходимо повысить объём оперативной памяти." +
                "\n     Во время обработки (конвертации, сохранения, открытия, шифрования) больших файлов, не рекомендуется использовать компьютер, для избежания потери скорости обработки файла и различных ошибок.";
                Document_Open_text = "Открытие" +
                "\n     Для того чтобы работать с файлом, его нужно либо создать, либо открыть." +
                "\n     Создание файла происходит с помощью нажатия клавиши Ctrl+N или нажатия на [Создать] в верхнем меню. Необходимо написать названия столбцов для файла. Стоит помнить, что названия столбцов не желательно называть цифрами и создавть менее двух столбцов для файла." +
                "\n     Открытие файла позволяет открыть файл в виде таблицы в программе для просмотра и изменения в ней информации. Для открытия необходимо либо перенести нужный файл в программу с помощью системы Drag&Drop и нажать на кнопку [Открыть], либо нажать в верхнем меню [Открыть]" +
                "\n     Стоит помнить что для открытия CSV-файла, необходимо задать в настройках правильный делимитер для корректного чтения файла.";
                Document_Save_text = "Сохранение" +
                "\n     После работы с файлом, его можно сохранить на свой носитель информации. Программа включает в себя 2 вида сохранения файла -[Сохранение как] и [Сохранение]." +
                "\n     [Сохранение] работает после нажатия на сочетание клавиш Ctrl+S или нажатие на клавишу [Сохранить] в главном меню. В этом случае файл, который был открыт -перезаписывается. В данном случае расширение остаётся таким же, каким и было." +
                "\n     [Сохранение как] позволяет не менять открытый файл, сохраняя изменения в новый, в данном случае можно задать расширения для сохраняемого файла. Для совершения данной операции, необходимо нажать на [Сохранить как] в верхнем меню." +
                "\n     Можно открыть файл и в настройках поменять делимитер и XML-элементы и сохранить файл с новыми параметрами.";
                Document_Crypt_text = "Шифрование" +
                "\n     Файл можно зашифровать и дешифровать с помощью технологии base64, выбрав в меню в вкладке [Правка] дальше [шифрование] и в base64 можно выбрать нужное действие." +
                "\n     Можно проверить хеш файла, зайдя в вкладку [Правка] и выбрав MD5Hash File. После чего откровется форма, в которой будет написан хеш файла и можно будет сравнить с другим хешем, который есть у пользователя. Программа напишет -совпадают ли хеш-суммы или нет.";
                Document_Edit_text = "Редактирование" +
                "\n     После успешного открытия файла, открывается возможно взаимодействовать с данными файла." +
                "\n     Возможности: Добавить строку нажатием правой клавишей мыши на таблицу, вызвав контексное меню, из которого можно выбрать операцию [Добавить строку], так же можно добавить столбец, из этого же контекстного меню, стоит помнить, что названия столбцов должны быть желательно без цифр. Данные действия так же доступны из меню, во вкладке [Правка]." +
                "\n     Для удаления строки, необходимо кликнуть на элемент ненужной строки и нажать на клавиатуре клавишу [Delete]" +
                "\n     Содержимое ячеек в таблице можно редактировать, кликнув по элементу и написав нужное значение.";
                Document_Convert_text = "Конвертация" +
                "\n     Есть возможность быстрой конвертации файла, без взаимодействия с визуальной таблицей. Для данного действия необходимо перетащить файл в программу системой Drag&Drop или нажать на [Конвертировать] в меню программы." +
                "\n     После конвертации, рядом с файлом появляется другой с файл с подписью в какой формат был сконвертирован." +
                "\n     При конвертации из XML в CSV, необходимо указать названия столбцов для нового файла, на основе показанных данных с таблице в форме.";
                Document_Settings_text = "Настройки" +
                "\n     Чтобы изменить настройки данного ПО, пользователю необходимо зайти в вкладку [Правка], там же нажать на [Настройки]." +
                "\n     В настройках можно менять язык ПО на английский и русский, изменять делимитер для CSV файлов и менять названия второстепенного и основного элементов XML. При наведении на поля ввода, показываются подсказки." +
                "\n     Если например в настройках указан делимитер [;], но пользователь пытается открыть CSV-файл с делимитером [,], программа не сможет читать файл." +
                "\n     Можно открыть файл и поменять делимитер в настрйоках и сохранить для изменения всех делимитеров в файле.";
            }
        }
        public void SettingsIsNullIsNull()
        {
            if (Properties.Settings.Default.Language == "")
                Properties.Settings.Default.Language = "English";

            if (Properties.Settings.Default.Delimiter == "")
                Properties.Settings.Default.Delimiter = ";";

            if (Properties.Settings.Default.MainElementXML == "")
                Properties.Settings.Default.MainElementXML = "users";

            if (Properties.Settings.Default.SecondaryElementXML == "")
                Properties.Settings.Default.SecondaryElementXML = "user";
        }
    }
}