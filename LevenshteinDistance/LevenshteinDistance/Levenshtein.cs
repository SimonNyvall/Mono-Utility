namespace LevenshteinDistance;

public class Levenshtein
{
    public static string[] Search(string searchTerm, params string[] searchList)
    {
        var searchResults = new List<string>();
        var searchScores = new List<int>();
        foreach (var item in searchList)
        {
            var score = Compute(searchTerm, item);
            searchScores.Add(score);
            searchResults.Add(item);
        }

        var sortedResults = searchResults.OrderBy(x => searchScores[searchResults.IndexOf(x)]).ToList();
        return sortedResults.ToArray();
    }
   

    private static int Compute(string searchTerm, string guessedTerm)
    {
        int stLength = searchTerm.Length;
        int gtLength = guessedTerm.Length;
        int[,] costMatrix = new int[stLength + 1, gtLength + 1];

        if (stLength == 0) return gtLength;

        if (gtLength == 0) return stLength;
        
        for (int i = 0; i <= stLength; costMatrix[i, 0] = i++);
        for (int j = 0; j <= gtLength; costMatrix[0, j] = j++);

        for (int i = 1; i <= stLength; i++)
        {
            for (int j = 1; j <= gtLength; j++)
            {
                int cost = (guessedTerm[j - 1] == searchTerm[i - 1]) ? 0 : 1;
                costMatrix[i, j] = Math.Min(
                    Math.Min(costMatrix[i - 1, j] + 1, costMatrix[i, j - 1] + 1),
                    costMatrix[i - 1, j - 1] + cost);
            }
        }

        return costMatrix[stLength, gtLength];
    }
}