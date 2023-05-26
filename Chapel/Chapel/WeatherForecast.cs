using Chapel.Entity;
using Tower;

namespace Chapel
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public class HelloServiceCollection
    {
        public static void FirstView()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<Animal>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var animalInstance = serviceProvider.GetService<Animal>();
            var flyAnimcal = serviceProvider.GetService<IFlying>();
            var buildNestAnimcal = serviceProvider.GetService<IBuildNest>();
        }
    }

    public class HelloDbContext
    {
        public static void FirstView()
        {
            var dbcontext = new ChapelContext();
            var author = new AuthorEntity { AuthorName = "Jack" };
            dbcontext.Add(author);

            var contact = new ContactEntity { Email = "Jack@gmail.com" };
            dbcontext.Add(contact);

            var authors = new List<AuthorEntity> {
                new AuthorEntity { AuthorName = "Jim"  },
                new AuthorEntity { AuthorName = "Lucy"  },
                new AuthorEntity { AuthorName = "Hally"  }
            };
            dbcontext.AddRange(authors);
            dbcontext.SaveChanges();
        }

        public static void SecondView(IServiceProvider serviceProvider)
        {
            var dbcontext = serviceProvider.GetService<ChapelContext>();
            var author = new AuthorEntity { AuthorName = "Jack" };
            dbcontext.Add(author);

            var contact = new ContactEntity { Email = "Jack@gmail.com" };
            dbcontext.Add(contact);

            var authors = new List<AuthorEntity> {
            new AuthorEntity { AuthorName = "Jim"  },
            new AuthorEntity { AuthorName = "Lucy"  },
            new AuthorEntity { AuthorName = "Hally"  }
};
            dbcontext.AddRange(authors);
            dbcontext.SaveChanges();
        }
    }
}