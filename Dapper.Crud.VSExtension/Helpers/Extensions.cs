namespace Dapper.Crud.VSExtension.Helpers
{
    internal static class Extensions
    {
        public static string Or(this string text, string alternative)
        {
            return string.IsNullOrWhiteSpace(text) ? alternative : text;
        }
    }
}