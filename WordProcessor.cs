using _6letterwordexercise.Interfaces;

namespace _6letterwordexercise {
  public class WordProcessor : IWordProcessor {
    public readonly IWordsImporter _wordsImporter;
    public readonly IWordCombinator _wordCombinator;
    public readonly IWordsPrinter _wordPrinter;

    public WordProcessor(IWordsImporter wordsImporter, IWordCombinator wordCombinator, IWordsPrinter wordPrinter) {
      _wordsImporter = wordsImporter;
      _wordCombinator = wordCombinator;
      _wordPrinter = wordPrinter;
    }

    public void Process() {
      var importedWords = _wordsImporter.ImportWords();

      var wordCombinations = _wordCombinator.GetCombinations(importedWords);

      _wordPrinter.PrintWords(wordCombinations);
    }
  }
}
