namespace _6letterwordexercise {
  public interface IWordsPrinter {
    void PrintWords(string[] words);
  }
  public class WordsPrinter : IWordsPrinter {
    public void PrintWords(string[] words) {
      foreach (var word in words) {
        Console.WriteLine(word);
      }
    }
  }
}
