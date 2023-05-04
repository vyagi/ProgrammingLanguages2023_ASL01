using System.ComponentModel.DataAnnotations;

namespace AspNetWebApi.Models;

public class SuperHeroUpdate
{
    public int Id { get; set; }
    
    [Range(18, 99, ErrorMessage = "Hero needs to be an adult but not too old")]
    public int Age { get; set; }

    [Required(ErrorMessage = "What is a hero without his powers")]
    [RegularExpression("[a-zA-Z]*(,[a-zA-Z]*)+", ErrorMessage = "List of powers must be a comma separated list of strings")]
    public string Powers { get; set; }
}