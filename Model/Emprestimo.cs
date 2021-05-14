using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.Model
{
    public class Emprestimo 
    {
        public int id;
        public Amiguinho amiguinho;
        public Revista revista;
        public DateTime dataEmprestimo;
        public DateTime dataDevolucao;
        public string statusEmprestimo;

        public Emprestimo()
        {
            id = GeradorId.GerarIdEmprestimo();
        }

        public Emprestimo(int idSelecionado)
        {
            id = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(amiguinho.nome.ToString()))
                resultadoValidacao += "o campo amiguinho obrigatório  \n";

            if (string.IsNullOrEmpty(revista.colecao.ToString()))
                resultadoValidacao += "o campo revista é obrigatorio  \n";

            if (string.IsNullOrEmpty(dataDevolucao.ToString()))
                resultadoValidacao += "o campo data devolução é obrigatorio \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "EMPRESTIMO_VALIDO";

            return resultadoValidacao;
        }
        

        public override bool Equals(object obj)
        {
            Emprestimo emprestimo = (Emprestimo)obj;

            if (id == emprestimo.id)
                return true;
            else
                return false;
        }



    }
}
