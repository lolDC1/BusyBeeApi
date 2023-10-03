namespace BusyBee.Persistence.Helpers;

public static class SearchInputTokenizer
{
    public static List<string> TokenizeSearch(string queryRequestQuery, string delimiter = " ")
    {
        if (string.IsNullOrWhiteSpace(queryRequestQuery)) return new List<string>();

        var searchTokens = queryRequestQuery
            .Split(delimiter, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .Distinct(StringComparer.InvariantCultureIgnoreCase)
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .ToList();

        return searchTokens;
    }
}