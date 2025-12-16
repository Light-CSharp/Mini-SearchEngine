using System.Xml.XPath;

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
        /// Ищет документы, содержащие все слова запроса.
        /// </summary>
        /// <param name="query">Запрос, в котором ищется нужное нам слова.</param>
        /// <returns>id документов, в которых был запрос.</returns>
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

            string[] tokens = Tokenizer.GetTokens(query);
            if (tokens.Length is 0)
            {
                return [];
            }

            if (!index.TryGetValue(tokens[0], out HashSet<int>? documents))
            {
                return [];
            }
            HashSet<int> result = [.. documents];

            // Пересекаем хешсеты с первым, чтобы выяснить пересечение в документах.
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
    }
}