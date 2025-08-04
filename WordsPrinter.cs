using _6letterwordexercise.Interfaces;

namespace _6letterwordexercise {
  public class WordsPrinter : IWordsPrinter {
    public void PrintWords(string[] words) {
      foreach (var word in words) {
        Console.WriteLine(word);
      }
    }
  }
}
