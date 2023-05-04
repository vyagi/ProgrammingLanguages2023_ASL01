namespace AspNetWebApi.Models;

public class SuperHero
{
    public static List<SuperHero> Heroes = new List<SuperHero>
    {
        new (1, "Spiderman", 30, new List<string> { "Jumping", "Climbing" }),
        new (2, "Superman", 38, new List<string> { "Flying", "Strong", "X-Ray" }),
        new (3, "Batman", 45, new List<string> { "Money", "Technology" }),
    };

    public SuperHero(int id, string name, int age, List<string> powers)
    {
        Id = id;
        Name = name;
        Age = age;
        Powers = powers;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public List<string> Powers { get; set; }
}