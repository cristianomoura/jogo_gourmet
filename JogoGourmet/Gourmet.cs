using System;

namespace JogoGourmet
{
    class Gourmet
    {
        public const string INICIO = "Pense em um prato que gosta.";
        public const string PERGUNTA_PADRAO = "O prato que você pensou é";
        public Prato prato = null;

        public Gourmet()
        {
            Console.WriteLine(@"  _____                                 _   ");
            Console.WriteLine(@" / ____|                               | |  ");
            Console.WriteLine(@"| |  __  ___  _   _ _ __ _ __ ___   ___| |_ ");
            Console.WriteLine(@"| | |_ |/ _ \| | | | '__| '_ ` _ \ / _ \ __|");
            Console.WriteLine(@"| |__| | (_) | |_| | |  | | | | | |  __/ |_ ");
            Console.WriteLine(@" \_____|\___/ \__,_|_|  |_| |_| |_|\___|\__|");

     
            prato = new Prato();
            Configurar();
        }

        public void Configurar() {
            
            prato.valor.Add(new AtributosPrato { nome = "Massa", massa = true, inicio = true, descarta = false });
            prato.valor.Add(new AtributosPrato { nome = "Bolo de Chocolate", massa = false, descarta = false });
            prato.valor.Add(new AtributosPrato { nome = "Lasanha",  massa = true, descarta = false });
  
        }

        public void Reseta() {
            foreach (var item in prato.valor)
                item.descarta = false;
        }

        public void Iniciar() {
            Console.CursorTop += 2;
            Console.WriteLine(INICIO);
           
        }

        public bool Perguntar(String prato = "" ) {
            Console.WriteLine(String.Format("{0} {1}?", PERGUNTA_PADRAO, prato));
            return Console.ReadLine().ToUpper().Equals("S");
        }

        public void Desiste(bool bMassa, String ultimoPrato) {
            Console.WriteLine("Desisto!");
            Console.WriteLine("Qual o Prato que você Pensou?");

            String novo_prato = Console.ReadLine();

            prato.valor.Add(new AtributosPrato { nome = novo_prato, massa = bMassa });

            Console.WriteLine(String.Format("{0} é __________ mas {1} não.", novo_prato, ultimoPrato));

            novo_prato = Console.ReadLine();

            prato.valor.Add(new AtributosPrato { nome = novo_prato, massa = bMassa });

        }

    }
}
