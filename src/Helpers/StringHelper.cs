namespace SmartLocate.Desktop.Admin.Helpers;

public static class StringHelper
{
    private static readonly Random Random = new Random();

    public static string GetRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[Random.Next(s.Length)]).ToArray());
    }
}