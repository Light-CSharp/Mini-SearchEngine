namespace Mini_SearchEngine.Basic_logic
{
    public static class Tokenizer
    {
        /// <summary>
        /// Возвращает массив токенов, чтобы движок обработал слова.
        /// </summary>
        /// <param name="text">Текст, который будет разбит на токены.</param>
        /// <returns></returns>
        public static string[] GetTokens(string? text)
        {
            if (string.IsNullOrEmpty(text))
            {
                MessageAssistant.RedMessage("Пустой текст на этапе получения токенов!");
                return [];
            }

            return text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}