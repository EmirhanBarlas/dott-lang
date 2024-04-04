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
                    Interpret(line.Trim()); // Satırın başındaki ve sonundaki boşlukları kaldırıyoruz
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
            // "..." ile başlayan ifadeleri doğrudan yazdırıyoruz
            HandlePrint(line.Substring(3));
        }
        else if (line.Contains(".."))
        {
            // ".." işareti bulunduğunda, bu işaretin arasındaki sayıları topla
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
            // "." işareti bulunduğunda, bu işaretin sağında ve solunda bulunan sayıları çıkarıcak olan fonksiyon
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

    // konsola yazdıracağımız kısım
    static void HandlePrint(string text)
    {
        Console.WriteLine(text);
    }
}