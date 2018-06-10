using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace consulta
{
    
    class FILEController
    {
        public static List<ModelFile> GetLstInfo()
        {
            List<ModelFile> lstFile = new List<ModelFile>();
            try
            {
                var dirFile = Directory.GetParent(@"../../../") + @"\file.xlsx";
                //var dirFile = Directory.GetCurrentDirectory() + @"\file.xlsx";
                Console.WriteLine(dirFile);
                using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(dirFile.ToString())))
                {
                    var myWorksheet = xlPackage.Workbook.Worksheets.First(); //select sheet here
                    var totalRows = myWorksheet.Dimension.End.Row;
                    var totalColumns = myWorksheet.Dimension.End.Column;

                    for (int rowNum = 2; rowNum <= totalRows; rowNum++) //selet starting row here
                    {
                        ModelFile file = new ModelFile();
                        var row = myWorksheet.Cells[rowNum, 1, rowNum, totalColumns].Select(c => c.Value == null ? string.Empty : c.Value.ToString());

                        var f = string.Join(",", row);
                        f = f.Replace("/", " ");
                        string[] a = f.Split(',');
                        int size = a.Length;
                        file.bairro = a[size - 3];
                        file.cidade = a[size - 2];
                        file.uf = a[size - 1];

                        lstFile.Add(file);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Tente o arquivo com o NOME: file.xlsx");
                Console.WriteLine("\nCaso tenha esse arquivo na pasta. Consulte o desenvolvedor, ele esqueceu do TRY e CATCH.");
                Console.WriteLine("\nSegue o erro: "+ ex);
            }
            return lstFile;
        }
        public static void Insert(List<string> lst)
        {
            try
            {
                string path = Directory.GetParent(@"../../../") + @"\lista.txt";
                //string path = Directory.GetCurrentDirectory() + @"\lista.txt";
                System.IO.File.WriteAllLines(path, lst);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Deu erro. Quando fui inserir no arquivo.");
                Console.WriteLine("Não perdi as informações, elas estão aqui.");
                foreach (string i in lst)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine("Error: ", ex);
            }


        }
    }
}
