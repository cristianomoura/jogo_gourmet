using System;
using System.Linq;

namespace JogoGourmet
{
    class Program
    {
    
        static Gourmet jogo = null;
        static bool bMassa = true;

        static void Main(string[] args)
        {
            String linha;
            jogo = new Gourmet();
            jogo.Iniciar();
            String ultimoPrato = string.Empty;

            //será executado infinitamente
            while ((linha = Console.ReadLine()) != null)
            {
                bMassa = true;

                int n = 0;
                bool bAdivinhou = false;
                var listaPratos = jogo.prato.valor.Where(x => x.massa.Equals(bMassa)).ToList();

                while (!bAdivinhou)
                {

                    if (listaPratos.Count <= 1)
                    {
                        n = 0;
                        ultimoPrato = listaPratos[n].nome;
                    }

                    bool bResp = jogo.Perguntar(listaPratos[n].nome);

                    if (bResp && !listaPratos[n].inicio)
                    {
                        bAdivinhou = true;
                        Console.WriteLine("Acertei de Novo!");
                        Console.ReadLine();
                        jogo.Reseta();
                        jogo.Iniciar();
                        bMassa = true;
                        n = -1;
                    }
                    else
                    {
                        //verifica se a resposta da primeira pergunta foi S e se ela era a inicial (isso define se estamos pensando em Massa)
                        if (!bResp && listaPratos[n].inicio)
                            bMassa = false;

                        //marca o prato para não utilizar na mesma rodada
                        jogo.prato.valor.Where(x => x.nome.Equals(listaPratos[n].nome)).FirstOrDefault().descarta = true;
                        //atualiza a lista com os pratos que não foram desctartados
                        listaPratos = jogo.prato.valor.Where(x => x.massa.Equals(bMassa) && x.descarta.Equals(false)).ToList();
                        //reseta o contador
                        n = -1;
                    }

                    //se não temos mais opções, desistimos
                    if (listaPratos.Count == 0)
                    {
                        //ao desistir, iremos guardar o prato para usar como tentativa
                        jogo.Desiste(bMassa, ultimoPrato);
                        jogo.Reseta();
                        jogo.Iniciar();
                        bMassa = true;
                        n = -1;
                        Console.ReadLine();
                        //recarrega a lista com todos os pratos.
                        listaPratos = jogo.prato.valor.Where(x => x.massa.Equals(bMassa) && x.descarta.Equals(false)).ToList();
                    }

                    n++;
                }

            }

            jogo = null;
        }
    }
}
