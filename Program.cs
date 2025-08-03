namespace _6letterwordexercise {
  internal class Program {
    static void Main(string[] args) {
      var wordsImporter = new WordsImporter("input.txt");
      var wordCombinator = new WordCombinator(6);
      var wordPrinter = new WordsPrinter();

      var wordProcessor = new WordProcessor(wordsImporter, wordCombinator, wordPrinter);

      wordProcessor.Process();
    }
  }
}
