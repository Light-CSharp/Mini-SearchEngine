namespace Mini_SearchEngine.Basic_logic
{
    public class SearchResult(HashSet<int> documentsId)
    {
        public HashSet<int> DocumentsId { get; init; } = documentsId;

        public bool IsEmpty => DocumentsId.Count is 0;
        public int Count => DocumentsId.Count;
    }
}