using System;
using System.Linq;
using System.Diagnostics;

namespace sakilaconsole
{
    class Program
    {
        static void Main(string[] args)
        {

            // https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core-scaffold-example.html#connector-net-entityframework-core-scaffold-cli

            using (var contexto = new sakila.sakilaContext())
            {
                //retornar nomes do filme, agrupados por categoria e rating,
                var queryNestedGroups = from fl in contexto.FilmLists
                                        group fl by fl.Category into newGroup1Category
                                        from newGroup2Rating in
                                        (from fl1 in newGroup1Category
                                         group fl1 by fl1.Rating)
                                        group newGroup2Rating by newGroup1Category.Key;

                // Three nested foreach loops are required to iterate
                // over all elements of a grouped group. Hover the mouse
                // cursor over the iteration variables to see their actu    al type.
                foreach (var outerGroup in queryNestedGroups)
                {
                    Console.WriteLine($"contexto.FilmList Category = {outerGroup.Key}");
                    foreach (var innerGroup in outerGroup)
                    {
                        Console.WriteLine($"\tRating that begin with: {innerGroup.Key}");
                        foreach (var innerGroupElement in innerGroup)
                        {
                            Console.WriteLine($"\t\t{innerGroupElement.Rating} {innerGroupElement.Title}");
                        }
                    }
                }

                System.Console.WriteLine();
                Console.ReadKey();




                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                var idDoAtor = 1;

                var query = (from fa in contexto.FilmActors
                             join fa2 in contexto.FilmActors
                             on fa.FilmId equals fa2.FilmId
                             where fa.ActorId == idDoAtor && fa.FilmId != fa2.FilmId
                             select fa.FilmId).ToList();

                var result = query.AsParallel();

                var contagem = result.Count();

                result.ForAll(item => System.Console.WriteLine(item));

                stopWatch.Stop(); //2.152 //2.147
                TimeSpan ts = stopWatch.Elapsed;
                System.Console.WriteLine("{0}", stopWatch.ElapsedMilliseconds / 1000.0);


                System.Console.WriteLine("id dos filmes do ator id = 1");

                var nomeDoator = "PENELOPE";

                var actorIds = contexto.Actors
                    .Where(a => a.FirstName == nomeDoator)
                    .Select(a => a.ActorId);

                System.Console.WriteLine("Lista de Ids de atores que contêm nome PENELOPE");
                foreach (var item in actorIds)
                {
                    System.Console.WriteLine(item);
                }

                Console.ReadKey();
                System.Console.WriteLine();

                // var query = from fa in contexto.FilmActors
                //             from f in contexto.Films
                //             join fa2 in contexto.FilmActors
                //             on fa.ActorId equals fa2.ActorId
                //             where actorIds.Contains(fa.ActorId) && fa.FilmId != fa2.FilmId
                //             select new {
                //                 fa.ActorId,
                //                 fa.FilmId,
                //                 f.Title
                //             };

                InformacoesAtorEFilme(contexto, "PENELOPE"); //https://docs.microsoft.com/pt-br/dotnet/csharp/linq/join-by-using-composite-keys

                EnderecoCincoMaioresClientes(contexto);

                DezMaioresLocacoes(contexto);

                ValorTotalDeLocacoes(contexto);

                TresMaioresConsumidores(contexto);

                Paginacao(contexto);

                Console.ReadKey();
            }
        }

        private static void InformacoesAtorEFilme(sakila.sakilaContext contexto, string ator)
        {
            var nomeator = ator;

            var IdsActor = contexto.Actors
                .Where(a => a.FirstName == nomeator)
                .Select(a => a.ActorId);


            var query = from a in contexto.Actors
                        from f in contexto.Films
                        join fa in contexto.FilmActors
                        on new { f.FilmId, a.ActorId } equals new { fa.FilmId, fa.ActorId } into details
                        from d in details
                        where IdsActor.Contains(a.ActorId)
                        select new
                        {
                            a.ActorId,
                            a.FirstName,
                            a.LastName,
                            f.FilmId,
                            f.Title
                        };

            System.Console.WriteLine("Id de ator e Id de Filmes por ator");
            foreach (var item in query)
            {
                System.Console.WriteLine("id Ator:{0}\tator: {1}\tsobrenome: {2}\tid do filme: {3}\tnome do Filme: {4}", item.ActorId, item.FirstName, item.LastName, item.FilmId, item.Title);
            }
            Console.ReadKey();
            System.Console.WriteLine();
        }

        private static void EnderecoCincoMaioresClientes(sakila.sakilaContext contexto)
        {
            var queryEntretabelas = from p in contexto.Payments
                                    join c in contexto.Customers on p.CustomerId equals c.CustomerId
                                    join l in contexto.CustomerLists on p.CustomerId equals l.Id
                                    where !string.IsNullOrEmpty(c.FirstName) || !c.FirstName.Equals("0")
                                    group l by l.Address into agrupado
                                    select new
                                    {
                                        Endereco = agrupado.Key
                                    };

            queryEntretabelas = queryEntretabelas.Take(5);

            System.Console.WriteLine("Enderecos");
            foreach (var item in queryEntretabelas)
            {
                System.Console.WriteLine("Endereco: {0}", item.Endereco);
            }
            System.Console.WriteLine();
            Console.ReadKey();
        }

        private static void DezMaioresLocacoes(sakila.sakilaContext contexto)
        {
            var queryGroupSum = contexto.Payments
                                .GroupBy(p => p.CustomerId)
                                .Select(paymentGroup => new
                                {
                                    id = paymentGroup.Key,
                                    total = paymentGroup.Select(p2 => p2.Amount).Sum()
                                });

            int count = queryGroupSum.Count();
            Console.WriteLine($"Number of groups = {count}");

            queryGroupSum = queryGroupSum.OrderByDescending(c => c.total);

            queryGroupSum = queryGroupSum.Take(10);

            System.Console.WriteLine("Id e valor de gastos dos Dez maiores Clientes");
            foreach (var item in queryGroupSum)
            {
                Console.WriteLine($"  {item.id} Value = {item.total}");
            }
            Console.ReadKey();
        }

        private static void ValorTotalDeLocacoes(sakila.sakilaContext contexto)
        {
            var newQuery = contexto.Payments.Sum(p => p.Amount);

            System.Console.WriteLine("Valor total de locação");
            System.Console.WriteLine(newQuery);
            System.Console.WriteLine();
        }

        private static void TresMaioresConsumidores(sakila.sakilaContext contexto)
        {
            var query = from p in contexto.Payments
                        join c in contexto.Customers on p.CustomerId equals c.CustomerId
                        orderby c.FirstName
                        group c by c.FirstName into agrupado
                        select new
                        {
                            Nome = agrupado.Key,
                            Quantidade = agrupado.Count()
                        };

            System.Console.WriteLine("Os três maiores consumidores e quantidade de locações");

            query = query.OrderByDescending(c => c.Quantidade);
            query = query.Take(3);

            foreach (var item in query)
            {
                System.Console.WriteLine("{0}\t{1}", item.Nome, item.Quantidade);
            }

            Console.ReadLine();
        }

        private static void Paginacao(sakila.sakilaContext contexto)
        {
            Console.WriteLine("Extraindo relatório!");

            int PAGINACAO = 10;
            var quantidade = contexto.Films.Count();
            var numeroDePaginas = Math.Ceiling((double)quantidade / PAGINACAO);
            System.Console.WriteLine("Quantidade de filmes: {0}", quantidade);
            System.Console.WriteLine("Quantidade de páginas: {0}", numeroDePaginas);
            Console.ReadKey();
            for (int i = 1; i <= numeroDePaginas; i++)
            {
                ImprimirPagina(contexto, PAGINACAO, i);
            }
        }

        private static void ImprimirPagina(sakila.sakilaContext contexto, int PAGINACAO, int numeroDaPagina)
        {
            var query = from f in contexto.Films
                        select f;

            var numeroDePulos = Convert.ToInt32((numeroDaPagina - 1) * PAGINACAO);

            query = query.OrderByDescending(f => f.RentalRate);
            query = query.Skip(numeroDePulos);
            query = query.Take(PAGINACAO);


            System.Console.WriteLine("Pagina: {0}", numeroDaPagina);
            foreach (var item in query)
            {
                System.Console.WriteLine("{0}\t{1}\t{2}", item.FilmId, item.Title, item.RentalRate);
            }
        }
    }
}
