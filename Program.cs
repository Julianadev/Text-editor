using System.IO;
internal class Program
{
  private static void Main(string[] args)
  {
    Menu();
  }
  static void Menu()
  {
    Console.Clear();
    Console.WriteLine("============ Editor de Textos ===========");
    Console.WriteLine("|                                        |");
    Console.WriteLine("|            Escolha a opção:            |");
    Console.WriteLine("|                                        | ");
    Console.WriteLine("|            1 - Abrir arquivo           |");
    Console.WriteLine("|            2 - Criar arquivo           |");
    Console.WriteLine("|            0 - Sair                    |");
    Console.WriteLine("==========================================");

    short opcao = short.Parse(Console.ReadLine());

    switch (opcao)
    {
      case 0: System.Environment.Exit(0); break;
      case 1: Abrir(); break;
      case 2: Editar(); break;
      default: Menu(); break;
    }
  }
  static void Abrir()
  {
    Console.Clear();
    Console.WriteLine("Qual o caminho do arquivo? ");
    var path = Console.ReadLine();

    using (var file = new StreamReader(path))
    {
      string texto = file.ReadToEnd();
      Console.WriteLine(texto);
    }
    Console.WriteLine("");
    Console.ReadLine();
    Menu();
  }
  static void Editar()
  {
    Console.Clear();
    Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
    Console.WriteLine("------------------------");

    try
    {
      string texto = "";

      // tecla ESC para sair
      do
      {
        texto += Console.ReadLine();
        texto += Environment.NewLine;
      }
      while (Console.ReadKey().Key != ConsoleKey.Escape);

      Salvar(texto);

    }
    catch (Exception e)
    {
      Console.WriteLine("Error: " + e.Message);
    }
  }
  static void Salvar(string texto)
  {
    Console.Clear();
    Console.WriteLine("Qual o caminho para salvar o arquivo?");
    var path = Console.ReadLine();

    //fechar e abrir automaticamente o arquivo
    using (var file = new StreamWriter(path))
    {
      file.Write(texto);
    }
    Console.WriteLine($"Arquivo {path} salvo com sucesso!");
    Console.ReadLine();
    Menu();
  }
}


