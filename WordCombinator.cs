namespace _6letterwordexercise {
  public interface IWordCombinator {
    string[] GetCombinations(string[] words);
  }

  public class WordCombinator : IWordCombinator {

    private readonly int _numberOfChars;

    public WordCombinator(int numberOfChars) {
      _numberOfChars = numberOfChars;
    }
    public string[] GetCombinations(string[] words) {
      var completeWords = words.Where(words => words.Length == _numberOfChars).Distinct().ToHashSet();
      var incompleteWords = words.Where(words => words.Length != _numberOfChars).ToArray();

      var wordCombinations = new List<string>();

      for (var i = 0; i < incompleteWords.Length; i++) {
        var incompleteWord = incompleteWords[i];
        if (!completeWords.Any(cw => cw.StartsWith(incompleteWord)))
          continue;

        var completeWord = completeWords.First(cw => cw.StartsWith(incompleteWord));
        var wordCombination = new List<string>();
        var restOfTheWord = completeWord;
        var letterCount = 0;

        for (var j = 0; j < incompleteWords.Length; j++) {
          var incompleteWordToCheck = GetIncompleteWordToCheck(incompleteWords, i, j);

          if (restOfTheWord.StartsWith(incompleteWordToCheck)) {
            wordCombination.Add(incompleteWordToCheck);
            restOfTheWord = restOfTheWord.Substring(incompleteWordToCheck.Length);
            letterCount += incompleteWordToCheck.Length;

            if (letterCount == _numberOfChars) {
              wordCombination = AddWordCombination(wordCombinations, completeWord, wordCombination);
              break;
            }
          }
        }
      }

      return [.. wordCombinations];
    }

    private static string GetIncompleteWordToCheck(string[] inCompleteWords, int i, int j) {
      var indexOfNextWordToCheck = (i + j) % inCompleteWords.Length;
      var incompleteWordToCheck = inCompleteWords[indexOfNextWordToCheck];
      return incompleteWordToCheck;
    }

    private static List<string> AddWordCombination(List<string> wordCombinations, string completeWord, List<string> wordCombination) {
      wordCombinations.Add(string.Join("+", wordCombination) + "=" + completeWord);
      wordCombination = [];
      return wordCombination;
    }
  }
}
