using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LerGravarXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static void Escrever()
        {
            List <Pessoa> pessoas = new List <Pessoa>();

            PessoaController controlePessoa = new PessoaController();

            pessoas = controlePessoa.Listar();
            var xml = new XDocument(new XElement("Pessoas",
                pessoas.Select(p => new XElement("Pessoa",
                    new XAttribute("ID", p.ID),
                    new XAttribute("NOME", p.NOME),
                    new XAttribute("ENDERECO", p.ENDERECO),
                    new XAttribute("EMAIL", p.EMAIL),
                    new XAttribute("CPF", p.CPF)
                ))));
            xml.Save("C:\\pessoas.xml");
        }

        public static List<Pessoa> Ler()
        {
            List<Pessoa> pessoas = new List<Pessoa>();
            var xml = XDocument.Load("C:\\pessoas.xml");

            foreach (XElement dadosPessoas in xml.Element("Pessoas").Elements("Pessoa"))
            {
                Pessoa pessoa = new Pessoa();
                pessoa.ID = Convert.ToInt32(dadosPessoas.Attribute("ID").Value);
                pessoa.NOME = Convert.ToString(dadosPessoas.Attribute("NOME").Value);
                pessoa.ENDERECO = Convert.ToString(dadosPessoas.Attribute("ENDERECO").Value);
                pessoa.EMAIL = Convert.ToString(dadosPessoas.Attribute("EMAIL").Value);
                pessoa.CPF = Convert.ToString(dadosPessoas.Attribute("CPF").Value);

                pessoas.Add(pessoa);
            }

            return pessoas;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Pessoa> ListaPessoas = Ler();
            dataGridView1.DataSource = ListaPessoas;
            MessageBox.Show("Arquivo Lido");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Escrever();
        }
    }
}
