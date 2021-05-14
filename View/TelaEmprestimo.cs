using ClubeDoLivro.Controller;
using ClubeDoLivro.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.View
{
    public class TelaEmprestimo : TelaBase, ICadastro
    {
        private ControladorEmprestimo controladorEmprestimo;
        private ControladorRevista controladorRevista;
        private ControladorAmiguinho controladorAmiguinho;
        private TelaRevista telaRevista;
        private TelaAmiguinho telaAmiguinho;
        public TelaEmprestimo(ControladorEmprestimo controlador, ControladorRevista ctrlRevista, ControladorAmiguinho ctrlAmiguinho, TelaRevista tlRevista, TelaAmiguinho tlAmiguinho) : base("TelaEmprestimo")
        {
            controladorEmprestimo = controlador;
            controladorRevista = ctrlRevista;
            controladorAmiguinho = ctrlAmiguinho;
            telaRevista = tlRevista;
            telaAmiguinho = tlAmiguinho;
        }

        public void EditarRegistro()
        {

        }

        public void ExcluirRegistro()
        {
            ConfigurarTela("Finalizando um Registro...");

            VisualizarRegistros();


            Console.WriteLine();

            Console.Write("Digite o número do emprestimo que deseja finalizar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorEmprestimo.ExcluirEmprestimo(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Emprestimo finalizado com sucesso");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Erro ao finalizar emprestimo, tente novamente");
                Console.ReadLine();
                ExcluirRegistro();
            }
        }

        public void InserirNovoRegistro()
        {

            ConfigurarTela("Inserindo novo Registro");

            bool consegueGravar = RegistraEmprestimo(0);

            if (consegueGravar)
            {
                Console.WriteLine("emprestimo registrado com sucesso");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Erro ao registrar emprestimo");
                Console.ReadLine();
                
            }


        }

        public string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir novo emprestimo");
            Console.WriteLine("Digite 2 para visualizar emprestimo");
            Console.WriteLine("Digite 4 para finalizar um emprestimo");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public bool VisualizarRegistros()
        {
            ConfigurarTela("Visualizando emprestimos");

            string configuracaColunasTabela = "{0,-10} | {1,-17} | {2,-27} | {3,-37} | {4,-47}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Emprestimo[] emprestimos = controladorEmprestimo.SelecionarTodosOsEmprestimos();

            if (emprestimos.Length == 0)
            {
                Console.WriteLine("Nehum emprestimo registrado");
                Console.ReadLine();
                return false;
            }

            for (int i = 0; i < emprestimos.Length; i++)
            {



                if (emprestimos[i].dataDevolucao > DateTime.Now)
                {
                    Console.WriteLine(configuracaColunasTabela,
                   emprestimos[i].id, emprestimos[i].amiguinho.nome, emprestimos[i].revista.colecao, emprestimos[i].dataDevolucao.ToString("dd/MM/yyyy"), emprestimos[i].statusEmprestimo);

                }
                else
                {
                    Console.WriteLine(configuracaColunasTabela,
                   emprestimos[i].id, emprestimos[i].amiguinho, emprestimos[i].revista.colecao, emprestimos[i].dataDevolucao, "DATA EXPIRADA");

                }



            }

            return true;
        }

        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "ID", "AMIGUINHO", "REVISTA", "DATA DEVOLUÇÃO", "STATUS DEVOLUÇÃO");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private bool RegistraEmprestimo(int id)
        {


            string resultadoValidacao;
            bool conseguiuGravar = false;

            if (telaAmiguinho.VisualizarRegistros())
            {



                Console.Write("Informe o id do solicitante do emprestimo: ");
                int idSolicitante = Convert.ToInt32(Console.ReadLine());

                if (telaRevista.VisualizarRegistros()){

                    Console.Write("Informe o id da revista para o emprestimo: ");
                    int idRevista = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Informe a data de devolução: ");
                    DateTime dataDevolucao = Convert.ToDateTime(Console.ReadLine());

                    DateTime dataRegistro = DateTime.Now;

                    string statusEmprestimo = "DATA_VALIDA";

                    resultadoValidacao = controladorEmprestimo.RegistrarRevista(id, idSolicitante, idRevista, dataRegistro, dataDevolucao, statusEmprestimo);
                    if (resultadoValidacao != "EMPRESTIMO_VALIDO")
                    {
                        Console.WriteLine(resultadoValidacao);
                        Console.ReadLine();
                        conseguiuGravar = false;
                    }

                    conseguiuGravar = true;
                }
            }
            return conseguiuGravar;
        }
    }
}

