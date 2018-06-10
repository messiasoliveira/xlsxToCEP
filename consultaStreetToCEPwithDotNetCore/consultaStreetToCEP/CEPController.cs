using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace consultaStreetToCEP
{
    class CEPController
    {
        public static List<string> Get(List<File> lstFile)
        {
            List<string> lstCep = new List<string>();
            List<string> lst = new List<string>();
            foreach (File f in lstFile)
            {
                string uf = f.uf;
                string city = f.cidade;
                string region = f.bairro;
                lst = GetListCEP(uf, city, region);
                foreach(string l in lst)
                {
                    foreach(string c in lstCep)
                    {
                        if (c == l)
                        {
                            continue;
                        }
                    }
                    lstCep.Add(l);
                }
            }
             return lstCep;
        }
        private static List<string> GetListCEP(string uf, string city, string region)
        {
            string result = ViaCep(uf, city, region);
            List<string> arrCep = BuildArrCep(result);
            if (arrCep.Count == 0)
            {
                arrCep.Add(uf+"/"+ city +"/"+ region);
            }
            return arrCep;
        }
        private static List<string> BuildArrCep(String response)
        {
            var lstInfo = JsonConvert.DeserializeObject<List<InfoCEP>>(response);
            List<string> lstCep = new List<string>();
            foreach (var info in lstInfo)
            {
                lstCep.Add(info.Cep);
            }
            return lstCep;
        }
        private static string ViaCep(string uf, string city, string region)
        {
            string url = "https://viacep.com.br/ws/" + uf + "/" + city + "/" + region + "/json/";
            WebClient client = new WebClient();

            String response = null;
            try
            {
                response = client.DownloadString(url);
                if (response != null)
                {
                    Console.WriteLine("Possible to ViaCep");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Don't possible to ViaCep");
                Console.WriteLine("Error: {0}", ex);
            }
            return response;
        }
    }
}
