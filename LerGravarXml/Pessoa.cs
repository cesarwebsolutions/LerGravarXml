using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerGravarXml
{
    public class Pessoa
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public string ENDERECO { get; set; }
        public string EMAIL { get; set; }
        public string SENHA { get; set; }
        public string CPF { get; set;}

        public Pessoa(string nome, string cpf)
        {
            NOME = nome;
            CPF = cpf;
        }

        public Pessoa() { }
    }
}
