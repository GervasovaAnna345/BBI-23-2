using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        
        string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        string answerFolderPath = Path.Combine(downloadsPath, "Answer");
        Directory.CreateDirectory(answerFolderPath);

        
        CreateOrUpdateFile(Path.Combine(answerFolderPath, "cw2_1.json"), "Солнечные блики");
        CreateOrUpdateFile(Path.Combine(answerFolderPath, "cw2_2.json"), "Программирование это круто");

        
        string textFromFile = File.ReadAllText(Path.Combine(answerFolderPath, "cw2_1.json"));
        string encryptedText = EncryptText(textFromFile);
        Console.WriteLine("Зашифрованный текст:");
        Console.WriteLine(encryptedText);
    }

    
    static void CreateOrUpdateFile(string filePath, string content)
    {
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, content);
        }
        else
        {
            Console.WriteLine($"Файл {Path.GetFileName(filePath)} уже существует. Содержимое файла:");
            Console.WriteLine(File.ReadAllText(filePath));
        }
    }

    
    static string EncryptText(string text)
    {
        string russianAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        string encryptedText = "";
        foreach (char letter in text.ToLower())
        {
            if (char.IsLetter(letter))
            {
                int newIndex = (russianAlphabet.IndexOf(letter) - 10 + russianAlphabet.Length) % russianAlphabet.Length;
                encryptedText += char.IsUpper(letter) ? char.ToUpper(russianAlphabet[newIndex]) : russianAlphabet[newIndex];
            }
            else
            {
                encryptedText += letter;
            }
        }
        return encryptedText;
    }
}