namespace Mini_SearchEngine.Basic_logic
{
    public static class Tokenizer
    {
        private static readonly HashSet<string> StopWords =
        [
            "и", "или", "а", "но", "в", "на", "с", "по", "я", "ты", "он", "это", "тот", "как", "что"
        ];

        /// <summary>
        /// Возвращает массив токенов, чтобы движок обработал слова.
        /// </summary>
        /// <param name="text">Текст, который будет разбит на токены.</param>
        /// <returns>Массив токенов (слов).</returns>
        public static string[] GetTokens(string? text)
        {
            if (string.IsNullOrEmpty(text))
            {
                MessageAssistant.RedMessage("Пустой текст на этапе получения токенов!");
                return [];
            }

            string[] tokens = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<string> result = [];
            foreach (string token in tokens)
            {
                if (!StopWords.Contains(token))
                {
                    result.Add(token);
                }
            }

            return [..result];
        }
    }
}