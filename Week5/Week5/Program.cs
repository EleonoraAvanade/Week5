using System;
using Week5.Repos;

namespace Week5
{
    class Program
    {
        static void Main(string[] args)
        {
            RepoEsame Esame = new RepoEsame(); ;
            RepoStudente Studente = new RepoStudente();
            while (true)
            {
                Console.WriteLine("Scegli l'operazione da fare: \n" +
                    "1 - Vedere tutti gli studenti\n" +
                    "2 - Registrare un esame\n" +
                    "3 - Mostrare gli esami\n" +
                    "4 - Aggiungere un nuovo studente" +
                    "5 - Exit \n");
                int repl = 0;
                Int32.TryParse(Console.ReadLine(), out repl);
                switch (repl)
                {
                    case 1:
                        Studente.GetAll();
                        break;
                    case 2:
                        Esame.Add();
                        break;
                    case 3:
                        Esame.GetAll();
                        break;
                    case 4:
                        Studente.Add();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Immetti un numero tra 1 e 5\n");
                        break;
                }
            }
        }
    }
}
