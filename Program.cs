using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

public class LabWork
{
    // Задание 1: Вставить за первым вхождением элемента E все элементы списка L
    public static List<int> Task1_InsertAfterFirstOccurrence(List<int> L, int E)
    {
        if (L.Contains(E))
        {
            int index = L.IndexOf(E);
            L.InsertRange(index + 1, L);
        }
        return L;
    }

    // Задание 2: Добавить элемент E в начало и конец списка L
    public static LinkedList<int> Task2_AddToEnds(LinkedList<int> L, int E)
    {
        L.AddFirst(E);
        L.AddLast(E);
        return L;
    }

    // Задание 3: Определить, какие книги прочли все, некоторые или никто
    public static Dictionary<string, HashSet<string>> Task3_BookReaders(List<string> books, List<HashSet<string>> readers)
    {
        var allRead = new HashSet<string>(readers[0]);
        var someRead = new HashSet<string>();
        var noneRead = new HashSet<string>(books);

        foreach (var reader in readers.Skip(1))
        {
            allRead.IntersectWith(reader);
            someRead.UnionWith(reader);
        }

        noneRead.ExceptWith(someRead);
        someRead.ExceptWith(allRead);

        return new Dictionary<string, HashSet<string>>
        {
            { "all_read", allRead },
            { "some_read", someRead },
            { "none_read", noneRead }
        };
    }

    // Задание 4: Найти символы, которых нет в первом слове, но есть в остальных
    public static HashSet<char> GetChars(string inputText)
    {
        // Разбиваем текст на слова
        var words = inputText.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        // Проверяем, что в тексте есть хотя бы два слова
        if (words.Length < 2)
        {
            Console.WriteLine("Текст должен содержать хотя бы два слова.");
            return new HashSet<char>();
        }

      
        var firstWordChars = new HashSet<char>(words[0]);

       
        var commonChars = new HashSet<char>(words[1]);

       
        foreach (var word in words.Skip(1))
        {
            commonChars.IntersectWith(word);
        }

        
        commonChars.ExceptWith(firstWordChars);

        return commonChars;
    }

    
    public static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Выберите задание для выполнения:");
            Console.WriteLine("1 - Задание 1 (Список)");
            Console.WriteLine("2 - Задание 2 (Связанный список)");
            Console.WriteLine("3 - Задание 3 (Чтение книг)");
            Console.WriteLine("4 - Задание 4 (Общие символы)");
            Console.WriteLine("5 - Задание 5 (Олимпиада)");
            Console.WriteLine("0 - Выход");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    // Задание 1
                    Console.Clear();
                    Console.WriteLine("Задание 1: Вставить элементы после первого вхождения элемента E.");
                    Console.WriteLine("Введите список чисел через пробел:");
                    var list1 = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                    Console.WriteLine("Введите элемент E:");
                    int E = int.Parse(Console.ReadLine());
                    list1 = Task1_InsertAfterFirstOccurrence(list1, E);
                    Console.WriteLine("Результат: " + string.Join(", ", list1));
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case "2":
                    // Задание 2
                    Console.Clear();
                    Console.WriteLine("Задание 2: Добавить элемент E в начало и конец списка.");
                    Console.WriteLine("Введите список чисел через пробел:");
                    var list2 = new LinkedList<int>(Console.ReadLine().Split(' ').Select(int.Parse));
                    Console.WriteLine("Введите элемент E:");
                    E = int.Parse(Console.ReadLine());
                    list2 = Task2_AddToEnds(list2, E);
                    Console.WriteLine("Результат: " + string.Join(", ", list2));
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case "3":
                    // Задание 3
                    Console.Clear();
                    Console.WriteLine("Задание 3: Определить, какие книги прочли все, некоторые или никто.");
                    Console.WriteLine("Введите количество книг:");
                    int numBooks = int.Parse(Console.ReadLine());
                    var books = new List<string>();
                    Console.WriteLine("Введите названия книг через запятую:");
                    var bookInput = Console.ReadLine();
                    books = bookInput.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(b => b.Trim()).ToList(); // Удаляем лишние пробелы

                    Console.WriteLine("Введите количество читателей:");
                    int numReaders = int.Parse(Console.ReadLine());
                    var readers = new List<HashSet<string>>();
                    for (int i = 0; i < numReaders; i++)
                    {
                        Console.WriteLine($"Введите книги, прочитанные {i + 1}-м читателем, через запятую:");
                        var readerInput = Console.ReadLine();
                        readers.Add(new HashSet<string>(readerInput.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                                   .Select(b => b.Trim()))); // Удаляем лишние пробелы
                    }

                    var bookReadResult = Task3_BookReaders(books, readers);
                    Console.WriteLine("Книги прочитанные всеми: " + string.Join(", ", bookReadResult["all_read"]));
                    Console.WriteLine("Книги прочитанные некоторыми: " + string.Join(", ", bookReadResult["some_read"]));
                    Console.WriteLine("Не прочитанные книги: " + string.Join(", ", bookReadResult["none_read"]));
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case "4":
                    // Задание 4
                    Console.Clear();
                    Console.WriteLine("Задание 4: Найти символы, которых нет в первом слове, но есть в остальных.");
                    Console.WriteLine("Введите текст:");
                    string text = Console.ReadLine();
                    var commonChars = GetChars(text);
                    Console.WriteLine("Символы: " + string.Join(", ", commonChars));
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case "0":
                    
                    exit = true;
                    Console.WriteLine("Программа завершена.");
                    break;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}
