using modul9_1302200003;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var movies = new List<Movie>()
{
    new Movie("The Shawshank Redemption", "Frank Darabont",
            new List<string> { "Tim Robbins", "Morgan Freeman", "Bob Gunton", "William Sadler" },
            "Two imprisoned men bond over a number of years, finding solace and eventual redemption " +
            "through acts of common decency."
            ),
    new Movie("The Godfather", "Francis Ford Coppola",
            new List<string> { " Marlon Brando", "Al Pacino", "James Caan", "Diane Keaton" },
            "The aging patriarch of an organized crime dynasty in postwar New York City transfers " +
            "control of his clandestine empire to his reluctant youngest son."
            ),
    new Movie("The Dark Knight", "Christopher Nolan",
            new List<string> { "Christian Bale", "Heath Ledger", "Aaron Eckhart", "Michael Caine" },
            "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, " +
            "Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice."
            )

};

app.MapGet("/api/Movies", () =>
{
    return movies;
})
    .WithName("GetMovies");

app.MapPost("/api/Movies", async (Movie newMovie) =>
{
    movies.Add(newMovie);
})
    .WithName("PostMovie");

app.MapGet("/api/Movies/{id}", async (int id) =>
{
    return movies[id];
})
    .WithName("GetMovie");

app.MapDelete("/api/Movies/{id}", async (int id) =>
{
    movies.RemoveAt(id);
})
    .WithName("DeleteMovie");




app.Run();