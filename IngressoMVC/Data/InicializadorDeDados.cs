using IngressoMVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngressoMVC.Data
{
    public class InicializadorDeDados
    {
        public static void Inicializar(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<IngressoDbContext>();
                context.Database.EnsureCreated();

                if (!context.Cinemas.Any())
                {
                    //instanciar novos cinemas
                    //Nome,descrição,imagemURL
                    context.Cinemas.Add(new Cinema("Cinemark", "Texto descrição", "https://logospng.org/wp-content/uploads/cinemark.png"));
                    
                }
                context.SaveChanges();

                if (!context.Atores.Any())
                {
                    //instanciar novos atores
                    //
                    context.Atores.AddRange(new List<Ator>()
                    {
                        new Ator("Robert Downey Jr.","Desc biografia","https://www.themoviedb.org/t/p/w300_and_h450_bestv2/5qHNjhtjMD4YWH3UP0rm4tKwxCL.jpg"),
                        new Ator("Benedict Cumberbatch","Desc biografia","https://www.themoviedb.org/t/p/w300_and_h450_bestv2/fBEucxECxGLKVHBznO0qHtCGiMO.jpg"),
                        new Ator("Tom Holland","Desc biografia","https://www.themoviedb.org/t/p/w300_and_h450_bestv2/bBRlrpJm9XkNSg0YT5LCaxqoFMX.jpg"),
                        new Ator("Paul Rudd","Desc biografia","https://www.themoviedb.org/t/p/w300_and_h450_bestv2/8eTtJ7XVXY0BnEeUaSiTAraTIXd.jpg"),
                        

                    });
                    context.SaveChanges();
                }   
                
                //Kevin Feige

                if (!context.Produtores.Any())
                {
                    //instanciar novos atores
                    //
                    context.Produtores.AddRange(new List<Produtor>()
                    {
                        new Produtor("Kevin Feige","Desc biografia","https://www.themoviedb.org/t/p/w300_and_h450_bestv2/kCBqXZ5PT5udYGEj2wfTSFbLMvT.jpg"),
                        new Produtor("Tim Burton","Desc biografia","https://www.themoviedb.org/t/p/w300_and_h450_bestv2/gRM4lGpiBINAyiXaxEeJFDKzmge.jpg"),
                        new Produtor("Vince Gilligan","Desc biografia","https://www.themoviedb.org/t/p/w300_and_h450_bestv2/uFh3OrBvkwKSU3N5y0XnXOhqBJz.jpg")
                    });
                    context.SaveChanges();
                }

                if (!context.Categorias.Any())
                {
                    //instanciar novas categorias
                    //
                    context.Categorias.AddRange(new List<Categoria>()
                    {
                        new Categoria("Ficção científica"),//1
                        new Categoria("Comédia"),//2
                        new Categoria("Comédia dramática"),//3
                        new Categoria("Histórico"),//4
                        new Categoria("Drama"),//5
                        new Categoria("Fantasia"),//6
                        new Categoria("Ação"),//7
                        new Categoria("Aventura") //8
                    });
                    context.SaveChanges();
                }


                if (!context.Filmes.Any())
                {
                    //instanciar novas categorias
                    //
                    context.Filmes.AddRange(new List<Filme>()
                    {
                        new Filme("Liga da Justiça","Impulsionado pela restauração de sua fé na humanidade e inspirado pelo ato altruísta do Superman, Bruce Wayne convoca sua nova aliada Diana Prince para o combate contra um inimigo ainda maior, recém-despertado. Juntos, Batman e Mulher-Maravilha buscam e recrutam com agilidade um time de meta-humanos, mas mesmo com a formação da liga de heróis sem precedentes o ataque ao planeta ainda pode ser catastrófico",12,"https://www.themoviedb.org/t/p/w300_and_h450_bestv2/geyu6rplpbp7OUeOfB2uRVf1LpG.jpg",1,2),
                        new Filme("Vingadores: Guerra Infinita","Homem de Ferro, Thor, Hulk e os Vingadores se unem para combater seu inimigo mais poderoso, o maligno Thanos. Em uma missão para coletar todas as seis pedras infinitas, Thanos planeja usá-las para infligir sua vontade maléfica sobre a realidade.",24,"https://www.themoviedb.org/t/p/w300_and_h450_bestv2/89QTZmn34iwXYeCpVxhC9UrT8sX.jpg",1,1)
                    });
                    context.SaveChanges();
                }

                if (!context.FilmesCategorias.Any())
                {
                    context.FilmesCategorias.AddRange(new List<FilmeCategoria>()
                    {
                        new FilmeCategoria(1,1),
                        new FilmeCategoria(1,6),
                        new FilmeCategoria(1,7),
                        new FilmeCategoria(1,8),
                        new FilmeCategoria(2,1),
                        new FilmeCategoria(2,6),
                        new FilmeCategoria(2,7),
                        new FilmeCategoria(2,8)

                    });
                    context.SaveChanges();
                }

                if (!context.AtoresFilmes.Any())
                {
                    context.AtoresFilmes.AddRange(new List<AtorFilme>()
                    {
                        new AtorFilme(1,2),
                        new AtorFilme(2,2),
                        new AtorFilme(3,2),
                        new AtorFilme(4,1)
                    });
                    context.SaveChanges();
                }



            }

        }
    }
}
