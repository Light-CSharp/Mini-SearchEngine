namespace Mini_SearchEngine.Basic_logic
{
    public class SearchEngine
    {
        private readonly Dictionary<string, HashSet<int>> index = [];

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
        }

        /// <summary>
        /// Ищет пересечение токенов в документах по запросу.
        /// </summary>
        /// <param name="query">Запрос, в котором ищется нужное нам слово.</param>
        /// <returns>Возвращается id документов, в которых был запрос.</returns>
        public HashSet<int> Search(string? query)
        {
            if (string.IsNullOrEmpty(query))
            {
                MessageAssistant.RedMessage("Пустой запрос!");
                return [];
            }

            query = TextNormalizer.Normalize(query!);
            if (string.IsNullOrEmpty(query))
            {
                return [];
            }

            return index.TryGetValue(query, out HashSet<int>? documents) ? documents : []; 
        }
    }
}