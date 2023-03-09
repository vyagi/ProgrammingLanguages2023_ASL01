using System.Collections;

public class Names : IEnumerable<string>
{
    public string FirstName;
    public string SecondName;
    public string LastName;

    public IEnumerator<string> GetEnumerator()
    {
        Console.WriteLine("Enumerator called for first time");
        yield return FirstName;
        Console.WriteLine("Enumerator called for second time");
        yield return SecondName;
        Console.WriteLine("Enumerator called for third time");
        yield return LastName;
        Console.WriteLine("Enumerator called for fourth time");
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}