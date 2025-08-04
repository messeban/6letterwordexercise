using _6letterwordexercise.Interfaces;

namespace _6letterwordexercise {
  public class WordsImporter : IWordsImporter {
    private readonly string _filePath;

    public WordsImporter(string filePath) {
      _filePath = filePath;
    }

    public string[] ImportWords() {
      return File.ReadAllLines(_filePath);
    }
  }
}
