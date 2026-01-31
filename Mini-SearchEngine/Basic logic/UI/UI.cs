#pragma warning disable CA1859

namespace Mini_SearchEngine.Basic_logic
{
    public class UI
    {
        private static readonly SearchEngine searchEngine = new();

        private enum MenuChoice : byte
        {
            AddDocument = 1,
            EnterQuery = 2,

            Exit = 0
        }

        public static void Menu()
        {
            Console.WriteLine("1. Загрузить текст (файл/строка)");
            Console.WriteLine("2. Ввести запрос");
            Console.WriteLine("0. Для выхода из программы");
        }

        private static int ReadChoice(int minimum, int maximum)
        {
            if (!int.TryParse(Console.ReadLine(), out int number) || number < minimum || number > maximum)
            {
                MessageAssistant.RedMessage("Некорректный выбор действия!");
                return -1;
            }
            Console.Clear();

            return number;
        }

        private static bool ReadChoiceIsCorrect(int number) => number != -1;

        private static string[] ProcessInput(string? input)
        {
            if (input is null)
            {
                return [];
            }

            string? normalized = TextNormalizer.Normalize(input);
            if (normalized is null)
            {
                return [];
            }

            return Tokenizer.GetTokens(normalized);
        }

        private static string[] AddDocument()
        {
            Console.WriteLine("1. Ввести текст");
            Console.WriteLine("2. Загрузить текст из файла");

            int choice = ReadChoice(1, 2);
            if (!ReadChoiceIsCorrect(choice))
            {
                return [];
            }

            return choice is 1 ? ProcessInput(TextSource.FromString(Console.ReadLine()!)) : 
                                 ProcessInput(TextSource.FromFile(Console.ReadLine()!));
        }

        private static void EnterQuery()
        {
            int method = SelectSearchMethod();
            if (method is -1)
            {
                Console.WriteLine("Неверный выбор!");
                return;
            }

            Console.WriteLine("Введите запрос: ");
            string? query = Console.ReadLine();

            IReadOnlyCollection<int> result;
            result = method is 1 ? searchEngine.Search(query) : searchEngine.SearchExcluding(query);

            if (result.Count is 0)
            {
                MessageAssistant.RedMessage("Ничего не найдено!");
                return;
            }

            Console.WriteLine("Найденные документы: ");
            foreach (int id in result)
            {
                Console.WriteLine($"Документ: #{id}");
            }
        }

        private static int SelectSearchMethod()
        {
            Console.WriteLine("1. Искать по ключевым словам");
            Console.WriteLine("2. Искать по исключающим словам");

            int choice = ReadChoice(1, 2);
            if (!ReadChoiceIsCorrect(choice))
            {
                return -1;
            }

            return choice;
        }

        public static void Run()
        {
            MenuChoice choice;
            do
            {
                Menu();

                choice = (MenuChoice)ReadChoice(0, 2);
                if (!ReadChoiceIsCorrect((int)choice))
                {
                    return;
                }

                switch (choice)
                {
                    case MenuChoice.AddDocument:
                        searchEngine.AddDocument(AddDocument());
                        break;

                    case MenuChoice.EnterQuery:
                        EnterQuery();
                        break;

                    case MenuChoice.Exit:
                        return;
                }
            }
            while (choice != MenuChoice.Exit);
        }
    }
}