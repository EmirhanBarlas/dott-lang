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
                    Interpret(line.Trim());
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
        if (line.StartsWith("..."))
        {
            // "..." ile başlayan ifadeleri console.writeline olarak yazdırıyo
            HandlePrint(line.Substring(3));
        }
        else if (line.Contains(".."))
        {
            // ".." işareti arasındaki sayıları toplayan fonksiyon "2 .. 2" çıktısı 4 olarak olucak
            string[] parts = line.Split(new string[] { ".." }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2)
            {
                string baslangicStr = parts[0].Trim();
                string bitisStr = parts[1].Trim();

                int baslangic, bitis;
                if (int.TryParse(baslangicStr, out baslangic) && int.TryParse(bitisStr, out bitis))
                {
                    int toplam = baslangic + bitis;
                    HandlePrint(toplam.ToString());
                }
                else
                {
                    Console.WriteLine($"Hata: Geçersiz sayı formatı: {line}");
                }
            }
            else
            {
                Console.WriteLine($"Söz dizimi hatası: {line}");
            }
        }
        else if (line.Contains("."))
        {
            // "." işareti çıkarma fonksiyonu soldaki sayı ve sağdaki sayıyı çıkarır "2 . 2" çıktısı 0 olucak
            string[] parts = line.Split('.');
            if (parts.Length == 2)
            {
                string solStr = parts[0].Trim();
                string sagStr = parts[1].Trim();

                int sol, sag;
                if (int.TryParse(solStr, out sol) && int.TryParse(sagStr, out sag))
                {
                    int fark = sol - sag;
                    HandlePrint(fark.ToString());
                }
                else
                {
                    Console.WriteLine($"Hata: Geçersiz sayı formatı: {line}");
                }
            }
            else
            {
                Console.WriteLine($"Söz dizimi hatası: {line}");
            }
        }
        else
        {
            Console.WriteLine($"Söz dizimi hatası: {line}");
        }
    }
    static void HandlePrint(string text)
    {
        Console.WriteLine(text);
    }
}