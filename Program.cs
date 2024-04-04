using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "test.dott";
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Interpret(line);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Dosya okunurken hata oluştu: {e.Message}");
        }
    }

    static void Interpret(string line)
    {
        if (line.Contains("...."))
        {
            // "...." işareti bulunduğunda, bu işaretin arasındaki sayıları toplayacak olan fonksiyon.
            string[] parts = line.Split(new string[] { "...." }, StringSplitOptions.None);
            if (parts.Length == 2)
            {
                int baslangic = int.Parse(parts[0].Trim());
                int bitis = int.Parse(parts[1].Trim());

                int toplam = baslangic + bitis;
                HandlePrint(toplam.ToString());
            }
            else
            {
                Console.WriteLine($"hata: {line}");
            }
        }
        else if (line.StartsWith("..."))
        {
            HandlePrint(line.Substring(3));
        }
        else if (line.StartsWith("."))
        {
            HandleVariableDeclaration(line.Substring(1));
        }
        else
        {
            Console.WriteLine($"Söz dizimi hatası: {line}");
        }
    }

    // konsola yazdıracağımız kısım
    static void HandlePrint(string text)
    {
        Console.WriteLine(text);
    }

    static void HandleVariableDeclaration(string expression)
    {
        string[] parts = expression.Split('=');
        if (parts.Length == 2)
        {
            string varName = parts[0].Trim();
            string varValue = parts[1].Trim();
            Console.WriteLine($"Değişken tanımlandı: {varName} = {varValue}");
        }
        else
        {
            Console.WriteLine($"Söz dizimi hatası: {expression}");
        }
    }
}
