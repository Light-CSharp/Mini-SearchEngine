using System.Text.RegularExpressions;

namespace Mini_SearchEngine
{
    public static class TextNormalizer
    {
        /// <summary>
        /// Возвращает текст, который был нормализован по нижнему регистру, 
        /// а также с удалением знаков препинания. 
        /// </summary>
        /// <param name="text">Текст, который будет нормализован.</param>
        /// <returns>Нормализованный текст.</returns>
        public static string? Normalize(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                MessageAssistant.RedMessage("Пустой текст на начальном этапе нормализации текста!");
                return null;
            }

            text = text.ToLowerInvariant().Replace("\"", "").Replace("\'", "");

            // Удаляем знаки препинания, а также сжимаем различные символы форматирования.
            text = Regex.Replace(text, @"[,\.\?!:;-]", "");
            text = Regex.Replace(text, @"\s+", " ").Trim();

            if (text is "")
            {
                Console.WriteLine("Пустой текст после нормализации текста!");
                return null;
            }

            return text;
        }
    }
}