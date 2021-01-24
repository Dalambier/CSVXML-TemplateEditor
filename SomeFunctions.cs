using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml;

namespace CSVXML_TemplateEditor
{
    public class SomeFunctions
    {
        public bool ClipBoardTextisClear = true;
        public string ClipBoardTextDefault;

        public void CheckClipBoard()
        {
            if (Clipboard.ContainsText() == true)
            {
                ClipBoardTextDefault = Clipboard.GetText();
                ClipBoardTextisClear = false;
            }
        }
        public void PasteToClipBoard()
        {
            if (ClipBoardTextisClear == false)
            {
                Clipboard.Clear();
                Clipboard.SetText(ClipBoardTextDefault);
            }
        }
        public void CSV_XML(string patch, string XMLFileName, string MainElement, string SecondaryElement, char Delimiter = ';')
        {
            var CsvText = File.ReadAllLines(patch, Encoding.GetEncoding(1251)).Select(line => line.Split(Delimiter).ToArray()).ToArray();


            int delimiter_i = 0, csv_columns = 1, csv_rows = CsvText.GetUpperBound(0) + 1;//Переменные для поиска столбцов + расчёт строк
            string delimiter_p = Delimiter.ToString(), column_checker = File.ReadLines(patch).Skip(1).First(); //Переменные для поиска столбцов
            while ((delimiter_i = column_checker.IndexOf(delimiter_p, delimiter_i)) != -1) { ++csv_columns; delimiter_i += delimiter_p.Length; }

            //MessageBox.Show("row" + csv_rows + "col" + csv_columns);

            XmlWriterSettings XmlSettings = new XmlWriterSettings();
            XmlSettings.Indent = true;
            XmlWriter xmlWriter = XmlWriter.Create(XMLFileName, XmlSettings);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement(MainElement);
            for (int i = 1; i < csv_rows; i++)
            {
                xmlWriter.WriteStartElement(SecondaryElement);
                for (int ii = 0; ii < csv_columns; ii++)
                {
                    xmlWriter.WriteStartElement(CsvText[0][ii]);
                    xmlWriter.WriteString(CsvText[i][ii]);
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }
        public void TableToCSV(string patch, string Delimiter = ";")
        {
            string ResultClipBoardCopy = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            File.AppendAllText(patch, ResultClipBoardCopy, UnicodeEncoding.UTF8);
            var CSVLines = File.ReadAllLines(patch);
            File.WriteAllLines(patch, CSVLines.Take(CSVLines.Length - 1).ToArray(), UnicodeEncoding.UTF8);
            if (Delimiter != ",")
            {
                string text = File.ReadAllText(patch, UnicodeEncoding.UTF8);
                text = text.Replace(",", Delimiter);
                File.WriteAllText(patch, text, UnicodeEncoding.UTF8);
            }
        }
    }
}
