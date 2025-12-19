namespace Mini_SearchEngine.Basic_logic
{
    public class SearchEngine
    {
        private readonly HashSet<int> allDocuments = [];
        private readonly Dictionary<string, HashSet<int>> index = [];

        /// <summary>
        /// Возвращает логическое значение на основе проверки запроса.
        /// </summary>
        /// <param name="query">Запрос, который будет проверен.</param>
        /// <returns>Корректность запроса.</returns>
        private static bool QueryIsCorrect(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                MessageAssistant.RedMessage("Пустой запрос!");
                return false;
            }

            query = TextNormalizer.Normalize(query)!;
            if (string.IsNullOrEmpty(query))
            {
                return false;
            }

            string[] tokens = Tokenizer.GetTokens(query);
            if (tokens.Length is 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Добавляем документ, добавив каждое слово и обозначив id документа.
        /// </summary>
        /// <param name="tokens">Массив слов.</param>
        /// <param name="documentId">id документа, показывает на документ.</param>
        public void AddDocument(string[] tokens, int documentId)
        {
            if (tokens.Length is 0)
            {
                MessageAssistant.RedMessage("Массив токенов пустой!");
                return;
            }

            foreach (string token in tokens)
            {
                // Если ключ-пары нет, то добавляем пустое множество по ключу и id документа.
                if (!index.TryGetValue(token, out HashSet<int>? documents))
                {
                    documents = [];
                    index[token] = documents;
                }
                documents.Add(documentId);
            }

            allDocuments.Add(documentId);
        }

        /// <summary>
        /// Ищет документы, содержащие все слова запроса.
        /// </summary>
        /// <param name="query">Запрос, в котором ищется нужное нам слова.</param>
        /// <returns>id документов, в которых был запрос.</returns>
        public HashSet<int> Search(string? query)
        {
            if (!QueryIsCorrect(query!))
            {
                return [];
            }

            // Получаем первое множество.
            string[] tokens = Tokenizer.GetTokens(query);
            if (!index.TryGetValue(tokens[0], out HashSet<int>? documents))
            {
                return [];
            }
            HashSet<int> result = [.. documents];

            // Пересекаем первое множество с остальными, чтобы получить пересечение документов.
            for (int i = 1; i < tokens.Length; i++)
            {
                if (!index.TryGetValue(tokens[i], out HashSet<int>? currentSet))
                {
                    return [];
                }

                result.IntersectWith(currentSet);
                if (result.Count is 0)
                {
                    return [];
                }
            }

            return result;
        }

        /// <summary>
        /// Ищет документы, в которых нет слов из запроса.
        /// </summary>
        /// <param name="query">Запрос, из которого мы берём слова на исключения.</param>
        /// <returns>id документов, в которых не было запроса.</returns>
        public HashSet<int> SearchExcluding(string? query)
        {
            if (!QueryIsCorrect(query!))
            {
                return [];
            }

            HashSet<int> exclusionDocuments = [];
            string[] tokens = Tokenizer.GetTokens(query);
            foreach (string token in tokens)
            {
                // Если слова нет в ключе, то пропускаем.
                if (!index.TryGetValue(token, out HashSet<int>? currentHashSet))
                {
                    continue;
                }

                exclusionDocuments.UnionWith(currentHashSet);
            }

            HashSet<int> result = [..allDocuments];
            result.ExceptWith(exclusionDocuments);

            return result;
        }
    }
}