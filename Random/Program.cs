using Random;
using System.Diagnostics;


RandomGenerator randomGenerator = new RandomGenerator();
FileWriter fileWriter = new FileWriter();
Stopwatch timeMeasure = new Stopwatch();
int count = 10000000;
string path = @"C:\Users\javi\Documents\pruebanoseque\a.txt";
Console.WriteLine($"Escriba la ruta donde generar el fichero con {count} números aleatorios");
path = Console.ReadLine();


timeMeasure.Start();
List<Int32> numbers = randomGenerator.GetRandomList(count);
fileWriter.WriteInFile(path, numbers);  
timeMeasure.Stop();
Console.WriteLine($"Tiempo: {timeMeasure.Elapsed.TotalSeconds} s");
