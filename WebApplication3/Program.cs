using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

var builder = WebApplication.CreateBuilder(args);

string connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<VoteContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/users/{id}", async (long id, VoteContext db) =>
{
    var user = await db.Users.FindAsync(id);

    if (user.IsVoted)
    {
        return Results.BadRequest("Daha önce oy kullandýnýz!");
    }
    else if (user != null)
    {
        return Results.Ok(user);
    }
    else
    {
        return Results.NotFound();
    }
}).WithName("GetUser");

app.MapGet("/candicades", async (VoteContext db) =>
{
    var Candidates = await db.Candidates.ToListAsync();

    if (Candidates.Any())
    {
        return Results.Ok(Candidates);
    }
    else
    {
        return Results.NotFound();
    }
}).WithName("GetCandicades");

app.MapGet("/givevote/{userId}/{candidateId}", async (long userId, long candidateId, VoteContext db) =>
{
    try
    {
        var candidates = await db.Candidates.FirstOrDefaultAsync(x => x.Id == candidateId);
        var user = await db.Users.FirstOrDefaultAsync(x => x.Id == userId);

        if (candidates != null && user != null)
        {
            candidates.VoteCount++;
            user.IsVoted = true;

            await db.SaveChangesAsync();

            return Results.Ok();
        }
        else
        {
            return Results.NotFound();
        }
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
}).WithName("GiveVote");

app.Run();