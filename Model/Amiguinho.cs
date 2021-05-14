using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.Model
{
    public class Amiguinho
    {
        public int id;
        public string nome;
        public string nomeResponsavel;
        public string telefone;
        public string endereco;

        public Amiguinho()
        {
            id = GeradorId.GerarIdAmiguinho();
        }

        public Amiguinho(int idSelecionado)
        {
            id = idSelecionado;
        }


        public string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(nome))
                resultadoValidacao += "o campo nome é obrigatório  \n";

            if (string.IsNullOrEmpty(nomeResponsavel))
                resultadoValidacao += "o campo nome responsável é obrigatorio  \n";

            if (string.IsNullOrEmpty(telefone))
                resultadoValidacao += "o campo telefone é obrigatório  \n";

            if (string.IsNullOrEmpty(endereco))
                resultadoValidacao += "o campo endereço é obrigatório  \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "AMIGO_VALIDO";

            return resultadoValidacao;
        }


        public override bool Equals(object obj)
        {
            Amiguinho amg = (Amiguinho)obj;

            if (id == amg.id)
                return true;
            else
                return false;
        }

    }
}
