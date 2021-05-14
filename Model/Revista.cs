using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.Model
{
    public class Revista
    {
        public int id;
        public int numeroEdicao;
        public DateTime ano;
        public Caixa caixa;
        public string colecao;

       

        public Revista()
        {
            id = GeradorId.GerarIdRevista();
        }

        public Revista(int idSelecionado)
        {
            id = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(colecao))
                resultadoValidacao += "o campo coleção é obrigatório  \n";

            if (string.IsNullOrEmpty(numeroEdicao.ToString()))
                resultadoValidacao += "o campo numero da edição é obrigatorio  \n";

            if (string.IsNullOrEmpty(ano.ToString()))
                resultadoValidacao += "o campo ano da edição é obrigatorio  \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "REVISTA_VALIDA";

            return resultadoValidacao;
        }



        public override bool Equals(object obj)
        {
            Revista revista = (Revista)obj;

            if (id == revista.id)
                return true;
            else
                return false;
        }


    }
}
