using System.Text;

namespace Mini_SearchEngine
{
    public static class TextSource
    {
        /// <summary>
        /// Возвращает текст из указанного пути файла.
        /// </summary>
        /// <param name="path">Путь к файлу, откуда будет браться текст.</param>
        public static string? FromFile(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                MessageAssistant.RedMessage("Пустой путь файла!");
                return null;
            }

            // Изменяем путь, убирая из него кавычки и изменяя сплеши, чтобы просчитать файл и достать из него текст.
            path = path.Trim().Replace("\"", "").Replace(@"\", "/");
            if (!File.Exists(path))
            {
                MessageAssistant.RedMessage("Неверный путь файла!");
                return null;
            }

            return File.ReadAllText(path, encoding: Encoding.UTF8);
        }

        /// <summary>
        /// Возвращает входимую строку, нужен для архитектуры при работе других классов.
        /// </summary>
        /// <param name="text">Текст, который будет возвращён.</param>
        /// <returns></returns>
        public static string? FromString(string text) => text;
    }
}