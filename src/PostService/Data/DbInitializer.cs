using PostService.Entities;
using Microsoft.EntityFrameworkCore;

namespace PostService.Data;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetService<DataContext>());
    }

    private static void SeedData(DataContext context)
    {
        context.Database.Migrate();

        if (context.Posts.Any())
        {
            Console.WriteLine("Already have data - no need to seed");
            return;
        }

        var posts = new List<Post>()
        {
            new Post
            {
                Title = "Title",
                Content = "Content",
                ImageUrl = "https://unsplash.com/photos/Y-rXBRdm3x0/download?ixid=M3wxMjA3fDB8MXxzZWFyY2h8MTI4fHxjaW5xdWUlMjB0ZXJyZXxlbnwwfHx8fDE3MDExMTQyMjl8MA&force=true",
            },
            new Post
            {
                Title = "Title2",
                Content = "Content2",
                ImageUrl = "https://unsplash.com/photos/jbxbza3DwBI/download?ixid=M3wxMjA3fDB8MXxzZWFyY2h8MjA3fHxzYW50b3Jpbml8ZW58MHx8fHwxNzAxMTE0NDIzfDA&force=true",
            }
        };

        context.AddRange(posts);

        context.SaveChanges();
    }
}
