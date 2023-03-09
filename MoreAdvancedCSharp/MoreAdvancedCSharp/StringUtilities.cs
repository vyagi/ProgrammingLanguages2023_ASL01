public static class StringUtilities
{
    //with adding "this" you have now an extension method

    public static string Capitalize(this string input) =>
        input[0].ToString().ToUpper() + input.Substring(1);
}

// public class BetterString : string //cannot do it because string is sealed
// {
//
// }