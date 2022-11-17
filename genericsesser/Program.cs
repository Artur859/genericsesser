using System;
using System.IO;

namespace Genericsesser
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Person artur = new("Artur", "Gusuila", 36);
            Logger(artur);
            Console.WriteLine(artur.Cognome);
        }
        public static void Logger<T>(T item) where T : class
        {
            var proprieta = item.GetType().GetProperties();
            var nomeItem = item.GetType().Name;
            string percorso = Path.Combine(Environment.CurrentDirectory, $"{nomeItem}.txt");
            if (!File.Exists(percorso))
            {
                foreach (var prop in proprieta)
                {
                    File.AppendAllText(percorso, prop.Name);
                    File.AppendAllText(percorso, " ");
                }
            }
            File.AppendAllText(percorso, "\n");
            foreach (var prop in proprieta)
            {
                File.AppendAllText(percorso, prop.GetValue(item).ToString());
                File.AppendAllText(percorso, " ");
            }
            File.AppendAllText(percorso, "\n");
        }
    }
    public class Person
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Eta { get; set; }

        public Person(string name, string lastName, int age)
        {
            Nome = name;
            Cognome = lastName;
            Eta = age;
        }
    }
}
