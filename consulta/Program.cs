using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.IO;
using consulta;

namespace consultaStreetToCEP
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<ModelFile> lstInfoLineFile = FILEController.GetLstInfo();
                List<string> lstCep = CEPController.Get(lstInfoLineFile);
                if (lstCep.Count > 0)
                {
                    FILEController.Insert(lstCep);
                    Console.WriteLine("CEP inseridos no arquivo LISTA.TXT");
                }
                else
                {
                    Console.WriteLine("Não tem CEP e por isso não inseri no arquivo.");
                }

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }

        }

    }
}
