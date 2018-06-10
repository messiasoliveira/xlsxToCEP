using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
namespace consultaStreetToCEP
{
    public class Program
    {
        static void Main(string[] args)
        {
            try{
                List<File> lstInfoLineFile = FILEController.GetLstInfo();
                List<string> lstCep = CEPController.Get(lstInfoLineFile);
                FILEController.Insert(lstCep);
                Console.WriteLine("CEP inseridos no arquivo LISTA.TXT");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        
    }
}
