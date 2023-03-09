public static class IntUtilities
{
    public static bool IsOdd(this int input) => input % 2 == 1;

    public static bool IsPrime(this int input)
    {
        for (var i = 2; i < input; i++)
            if (input % i == 0)
                return false;

        return true;
    }
}