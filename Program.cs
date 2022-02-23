using System;
using System.IO;
using System.Threading;
namespace lab8._11
{
    class Program
    {
        public static void Options()
        {
            Console.Write("\nDIR    wyświetla pliki i katalogi znajdujące się w aktywnym katalogu.\n" +
                "CD     wyświetla nazwę lub umożliwia zmianę obecnego katalogu.\n" +
                "TYPE   wyświetla zawartość pliku tekstowego.\n" +
                "HELP   wyświetla dostępne komendy.\n" +
                "CLS    czyści konsolę.\n" +
                "EXIT   wyłącza konsolę.\n\n");
        }
        public static string UserProfile()
        {
            return Convert.ToString(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
        }        
        public static void Write(string text)
        {
            foreach (var character in text)
            {
                Console.Write(character);
                Thread.Sleep(200);
            }
        }
        static void Main(string[] args)
        {
            bool stan = true;
            string main = UserProfile();            
            string bls = @"\";            
            string txt = ".txt";                     
            while (stan)
            {                
                Console.Write(main + ">");
                string line = Console.ReadLine();
                string[] command = line.Split(" ");                
                string cat;
                string text="";
                switch (command[0])
                {
                    case "dir":
                        if (command.Length > 1) cat = command[1];
                        else cat = "";                         
                        try
                        {
                            var Files = Directory.EnumerateFiles(main + bls + cat);
                            var Directories = Directory.EnumerateDirectories(main + bls + cat);
                            Console.WriteLine();
                            foreach (var File in Files)
                            {
                                Console.WriteLine(File);
                            }
                            foreach (var File in Directories)
                            {
                                Console.WriteLine(File);
                            }
                            Console.WriteLine();
                        }
                        catch
                        {
                            Console.WriteLine("System nie może znaleźć określonej ścieżki");                           
                        }                                               
                        break;
                    case "cd":
                        if (command.Length > 1) main = command[1];
                        else main = UserProfile();
                        if (main != "")
                        {
                            try
                            {
                                var Files = Directory.EnumerateFiles(main + bls);                              
                            }
                            catch
                            {
                                main = UserProfile();
                                Console.WriteLine("System nie może znaleźć określonej ścieżki");
                            }
                        }
                        else main = UserProfile();
                        break;
                    case "type":
                        if (command.Length > 1) text = command[1];
                        else text = "";
                        try
                        {                            
                            if (!text.EndsWith(".txt")) text += txt;
                            string file = File.ReadAllText(main + bls + text);
                            Console.WriteLine("\n" + file + "\n");
                        }
                        catch
                        {                          
                            Console.WriteLine("Nie można odnaleźć określonego pliku");                           
                        }
                        break;
                    case "cls":
                        Console.Clear();                       
                        break;
                    case "help":
                        Options();
                        break;
                    case "exit":
                        Console.Write("Wyłączanie");
                        Write("....");
                        stan = false;                       
                        break;
                }
            }
        }
    }
}
