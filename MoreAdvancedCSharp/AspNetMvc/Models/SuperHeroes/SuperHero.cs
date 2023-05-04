namespace AspNetMvc.Models.SuperHeroes;

public record SuperHero(int Id, string Name, int Age, List<string> Powers)
{
    public static List<SuperHero> Heroes = new List<SuperHero>
    {
        new (1, "Spiderman", 30, new List<string> { "Jumping", "Climbing" }),
        new (2, "Superman", 38, new List<string> { "Flying", "Strong", "X-Ray" }),
        new (3, "Batman", 45, new List<string> { "Money", "Technology" }),
    };
}