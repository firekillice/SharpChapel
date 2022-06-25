using Chapel;
using Chapel.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ChapelContext>(options => builder.Configuration.GetConnectionString("Main"));

var app = builder.Build();

var appcontext = new ChapelContext();
var author = new AuthorEntity { AuthorName = "Jack" };
appcontext.Add(author);

var contact = new ContactEntity { Email = "Jack@gmail.com" };
appcontext.Add(contact);

var authors = new List<AuthorEntity> {
    new AuthorEntity { AuthorName = "Jim"  },
    new AuthorEntity { AuthorName = "Lucy"  },
    new AuthorEntity { AuthorName = "Hally"  }
};
appcontext.AddRange(authors);
appcontext.SaveChanges();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
