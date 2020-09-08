using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DocumentFormat.OpenXml;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Spreadsheet;
using System.Globalization;
using System.IO;
//using OfficeOpenXml;

namespace UFO.Utilities
{
    public static class ExportHelper
    {
        public static DataTable ListToDataTable<T>(IList<T> data, HashSet<string> outputColums = null)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();

            foreach (PropertyDescriptor prop in properties)
            {
                if (outputColums != null)
                {
                    if (!outputColums.Contains(prop.Name))
                    {
                        continue;
                    }
                }
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyDescriptor pdt in properties)
                {
                    if (outputColums != null)
                    {
                        if (!outputColums.Contains(pdt.Name))
                        {
                            continue;
                        }
                    }
                    row[pdt.Name] = pdt.GetValue(item) ?? DBNull.Value;
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
        

        //public static void GenerateExcelCOM(DataTable DtIN, string title=null, HashSet<string> outputColums = null)
        //{
        //    try
        //    {
        //        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        //        excel.DisplayAlerts = false;
        //        //excel.Visible = false;
        //        Microsoft.Office.Interop.Excel.Workbook workBook = excel.Workbooks.Add(Type.Missing);
        //        Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.ActiveSheet;
        //        //workSheet.Name = "LearningExcel";
        //        DataTable tempDt = DtIN;
        //        //dgExcel.ItemsSource = tempDt.DefaultView;
        //        workSheet.Cells.Font.Size = 11;

        //        int tabColumns = 1; //отступ слева (в столбцах) 
        //        int rowcount = 1;
        //        if (!String.IsNullOrEmpty(title))
        //        {
        //            workSheet.Cells[rowcount, 1 + tabColumns] = title;
        //            rowcount += 2;
        //        }


        //        int j = 1;
        //        for (int i = 1; i <= tempDt.Columns.Count; i++) //taking care of Headers.  
        //        {                    
        //            if (outputColums != null)
        //            {
        //                if(outputColums.Contains(tempDt.Columns[i-1].ColumnName))
        //                {
        //                    workSheet.Cells[rowcount, j + tabColumns] = convertColumnName(tempDt.Columns[i - 1].ColumnName);
        //                    j++;
        //                }
        //            }
        //            else
        //                workSheet.Cells[rowcount, i + tabColumns] = convertColumnName(tempDt.Columns[i - 1].ColumnName);
        //        }

        //        foreach (DataRow row in tempDt.Rows) //taking care of each Row  
        //        {
        //            rowcount += 1;
        //            j = 0;
        //            for (int i = 0; i < tempDt.Columns.Count; i++) //taking care of each column  
        //            {
        //                if (outputColums != null)
        //                {
        //                    if (outputColums.Contains(tempDt.Columns[i].ColumnName))
        //                    {
        //                        if (row[i] is DateTime)
        //                        {
        //                            workSheet.Cells[rowcount, j + 1 + tabColumns] = row[i];
        //                        }                                    
        //                        else
        //                        {
        //                            workSheet.Cells[rowcount, j + 1 + tabColumns] = row[i].ToString();
        //                        }
        //                        j++;
        //                    }
        //                }
        //                else
        //                    workSheet.Cells[rowcount, i + 1 + tabColumns] = row[i].ToString();
        //            }
        //        }
        //        Microsoft.Office.Interop.Excel.Range cellRange = workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[rowcount, tempDt.Columns.Count]];
        //        cellRange.EntireColumn.AutoFit();

        //        excel.Visible = true;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public static void GenerateExcelToFile(string filePath, DataTable dataTable, HashSet<string> outputColums = null)
        //{
        //    // Create a spreadsheet document by supplying the filepath.
        //    // By default, AutoSave = true, Editable = true, and Type = xlsx.
        //    SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook);

        //    // Add a WorkbookPart to the document.
        //    WorkbookPart workbookpart = spreadsheetDocument.AddWorkbookPart();
        //    workbookpart.Workbook = new Workbook();

        //    // Add a WorksheetPart to the WorkbookPart.
        //    WorksheetPart worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
        //    SheetData sheetData = new SheetData();
        //    worksheetPart.Worksheet = new Worksheet(sheetData);

        //    // Add Sheets to the Workbook.
        //    Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

        //    // Append a new worksheet and associate it with the workbook.
        //    Sheet sheet = new Sheet()
        //    {
        //        Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
        //        SheetId = 1,
        //        Name = "Лист1"
        //    };
        //    sheets.Append(sheet);


        //    NumberingFormats numberingFormats = new NumberingFormats();

        //    NumberingFormat dateTimeNumberingFormat = new NumberingFormat();
        //    dateTimeNumberingFormat.NumberFormatId = 165;
        //    dateTimeNumberingFormat.FormatCode = "dd.mm.yyyy\\ h:mm:ss";
        //    numberingFormats.Append(dateTimeNumberingFormat);

        //    var stylesPart = workbookpart.AddNewPart<WorkbookStylesPart>();
        //    stylesPart.Stylesheet = new Stylesheet
        //    {
        //        Fonts = new Fonts(new Font()),
        //        Fills = new Fills(new Fill()),
        //        Borders = new Borders(new Border()),
        //        NumberingFormats = numberingFormats,
        //        CellStyleFormats = new CellStyleFormats(new CellFormat()),
        //        CellFormats = //new CellFormats()
        //            new CellFormats(
        //                new CellFormat(),
        //                new CellFormat
        //                {
        //                    NumberFormatId = 165,
        //                    ApplyNumberFormat = true
        //                })
        //    };


        //    //Add Header Row.
        //    //отступ
        //    sheetData.AppendChild(new Row());

        //    var headerRow = new Row();
        //    //отступ
        //    headerRow.AppendChild(new Cell());

        //    foreach (DataColumn column in dataTable.Columns)
        //    {
        //        var cell = new Cell
        //        {
        //            DataType = CellValues.String,
        //            CellValue = new CellValue(convertColumnName(column.ColumnName))
        //        };

        //        if (outputColums != null)
        //        {
        //            if (!outputColums.Contains(column.ColumnName))
        //            {
        //                continue;
        //            }
        //        }

        //        headerRow.AppendChild(cell);

        //    }
        //    sheetData.AppendChild(headerRow);

        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        var newRow = new Row();
        //        //отступ
        //        newRow.AppendChild(new Cell());
        //        foreach (DataColumn column in dataTable.Columns)
        //        {
        //            var cell = new Cell();
        //            //var cell = new Cell
        //            //{
        //            //    DataType = values,
        //            //    CellValue = new CellValue(row[column].ToString())
        //            //};

        //            if (row[column] is DateTime)
        //            {
        //                DateTime dateTime = DateTime.Parse(row[column].ToString());
        //                double oaValue = dateTime.ToOADate();
        //                cell.CellValue = new CellValue(oaValue.ToString(CultureInfo.InvariantCulture));
        //                cell.DataType = new EnumValue<CellValues>(CellValues.Number);
        //                //cell.StyleIndex = Convert.ToUInt32(dateStyleIndex);
        //                cell.StyleIndex = 1;

        //            }
        //            else if (row[column] is Boolean)
        //            {

        //                cell.CellValue = new CellValue(Convert.ToByte(row[column]).ToString());
        //                cell.DataType = new EnumValue<CellValues>(CellValues.Boolean);
        //            }
        //            else
        //            {
        //                cell.CellValue = new CellValue(row[column].ToString());
        //                cell.DataType = CellValues.String;
        //            }

        //            if (outputColums != null)
        //            {
        //                if (!outputColums.Contains(column.ColumnName))
        //                {
        //                    continue;
        //                }
        //            }
        //            newRow.AppendChild(cell);
        //        }

        //        sheetData.AppendChild(newRow);
        //    }

        //    workbookpart.Workbook.Save();

        //    // Close the document.
        //    spreadsheetDocument.Close();
        //}

        /*
        public static void GenerateExcelToFile(string filePath, DataTable dataTable, HashSet<string> outputColums = null)
        {
            using (var package = new ExcelPackage())
            {
                // Add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Лист1");

                //отступы 
                int firstRow = 2;
                int firstColumn = 2;
                int rowCount = firstRow;
                int columnCount = firstColumn;

                foreach (DataColumn column in dataTable.Columns)
                {
                    if (outputColums != null)
                    {
                        if (!outputColums.Contains(column.ColumnName))
                        {
                            continue;
                        }
                    }
                    worksheet.Cells[rowCount, columnCount].Value = convertColumnName(column.ColumnName);
                    columnCount++;
                }
                worksheet.Cells[rowCount, firstColumn, rowCount, columnCount].Style.Font.Bold = true;
                rowCount++;
                columnCount = firstColumn;

                foreach (DataRow row in dataTable.Rows)
                {                    
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        if (outputColums != null)
                        {
                            if (!outputColums.Contains(column.ColumnName))
                            {
                                continue;
                            }
                        }
                        if (row[column] is DateTime)
                        {
                            worksheet.Cells[rowCount, columnCount].Value = Convert.ToDateTime(row[column]);
                            worksheet.Cells[rowCount, columnCount].Style.Numberformat.Format = "dd.mm.yyyy\\ h:mm:ss";
                        }
                        else if (row[column] is Boolean)
                        {
                            worksheet.Cells[rowCount, columnCount].Value = Convert.ToBoolean(row[column]);                            
                        }
                        else
                        {
                            worksheet.Cells[rowCount, columnCount].Value = row[column].ToString();
                        }
                        columnCount++;
                    }
                    rowCount++;
                    columnCount = firstColumn;
                }
                worksheet.Cells.AutoFitColumns(0);  //Autofit columns for all cells
                // lets set the header text 
                worksheet.HeaderFooter.OddHeader.CenteredText = "&14&\"Arial,Regular Bold\" " + Path.GetFileNameWithoutExtension(filePath);
                // add the page number to the footer plus the total number of pages
                worksheet.HeaderFooter.OddFooter.RightAlignedText =
                    string.Format("Страница {0} из {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);

                worksheet.PrinterSettings.RepeatRows = worksheet.Cells[firstRow.ToString() + ":" + firstRow.ToString()];
                //worksheet.PrinterSettings.RepeatColumns = worksheet.Cells["A:G"];

                // Change the sheet view to show it in page layout mode
                //worksheet.View.PageLayoutView = true;

                //var xlFile = Utils.GetFileInfo("sample1.xlsx");
                var xlFile = new FileInfo(filePath);
                // save our new workbook in the output directory and we are done!
                package.SaveAs(xlFile);
                //return xlFile.FullName;
            }
        }
        */
        public static void GenerateCsvFile(string filePath, DataTable dataTable, string title = null, HashSet<string> outputColums = null)
        {
            //using (StreamWriter sw = new StreamWriter(filePath,false, System.Text.Encoding.Default))
            //{
                string delimiter = ";";

            //sw.WriteLine("Дозапись");
            //sw.Write(4.5);
            
            StringBuilder sb = new StringBuilder();     
            
                            
            foreach (DataColumn column in dataTable.Columns)
            {
                if (outputColums != null)
                {
                    if (!outputColums.Contains(column.ColumnName))
                    {
                        continue;
                    }
                }
                sb.Append(convertColumnName(column.ColumnName)).Append(delimiter);

            }
            sb.AppendLine();

            string value;
            foreach (DataRow row in dataTable.Rows)
            {
                   
                foreach (DataColumn column in dataTable.Columns)
                {
                    if (outputColums != null)
                    {
                        if (!outputColums.Contains(column.ColumnName))
                        {
                            continue;
                        }
                    }

                    if(row[column] is Boolean)
                    {
                        value = (bool)row[column] == true ? "Да" : "Нет";
                    }
                    else
                    {
                        value = row[column].ToString();
                    }

                    //sb.Append(string.Join(delimiter, row[column].ToString()));
                    sb.Append(value).Append(delimiter);
                }

                sb.AppendLine();
            }
            File.WriteAllText(filePath, sb.ToString(), System.Text.Encoding.Default);
        }

        private static string convertColumnName(string name)
        {
            string new_name = name;
            switch(name)
            {
                case ("Name"):
                    new_name = "Название";
                    break;
                case ("ID"):
                    new_name = "Номер";
                    break;
                case ("Date"):
                    new_name = "Дата";
                    break;
                case ("Event"):
                    new_name = "Событие";
                    break;
                case ("Person"):
                    new_name = "Сотрудник";
                    break;
                case ("FullName"):
                    new_name = "ФИО";
                    break;
                case ("Department"):
                    new_name = "Отдел";
                    break;
                case ("Nc32kName"):
                    new_name = "Точка доступа";
                    break;
                case ("Card"):
                    new_name = "Карта";
                    break;
                case ("PersonID"):
                    new_name = "ID сотрудника";
                    break;
                case ("Expired"):
                    new_name = "Срок действия карты";
                    break;
                case ("IsLocked"):
                    new_name = "Заблокирован";
                    break;
                case ("IsApb"):
                    new_name = "Двойной проход запрещен";
                    break;
                case ("Description"):
                    new_name = "Описание";
                    break;
                case ("Type"):
                    new_name = "Тип";
                    break;
                case ("CardFull"):
                    new_name = "Номер карты";
                    break;
                case ("Information"):
                    new_name = "Информация";
                    break;

            }
            return new_name;
        }
    }
}
