using System;
using System.Collections.Generic;
using System.IO;

namespace InstaDev.Models
{
    public class InstaDevBase
    {
        Random randomNum = new Random();
        List<int> ListaId = new List<int>();
        public void CriarPastaEArquivo(string _caminho)
        {
            string pasta = _caminho.Split("/")[0];
            string arquivo = _caminho.Split("/")[1];

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }
            if (!File.Exists(_caminho))
            {
                File.Create(_caminho).Close();
            }
        }
        public List<string> LerTodasLinhasCSV(string _caminho)
        {
            List<string> linhas = new List<string>();

            using (StreamReader file = new StreamReader(_caminho))
            {
                string linha;
                while ((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;
        }
        public void ReescreverCSV(string _caminho, List<string> linhas)
        {
            using (StreamWriter output = new StreamWriter(_caminho))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }
        public int GerarId(List<int> listaId)
        {
            int idGerado = randomNum.Next(1, 1000000);

            if (listaId.Contains(idGerado))
            {
                do
                {
                    idGerado = randomNum.Next(1, 1000000);
                } while (ListaId.Contains(idGerado));
            }
            
            return idGerado;
            
        }
    }
}