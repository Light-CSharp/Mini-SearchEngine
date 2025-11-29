using Mini_SearchEngine;

namespace XUnitTest_Mini_SearchEngine
{
    public class XUnitTest
    {
        [Theory]
        [InlineData(@"C:\Users\Broky\OneDrive\Desktop\Тесты для поискового движка\Проверка изменения пути\Первый тест.txt")]
        [InlineData("C:\\Users\\Broky\\OneDrive\\Desktop\\Тесты для поискового движка\\Проверка изменения пути\\Второй тест.txt")]
        [InlineData("C:/Users/Broky/OneDrive/Desktop/Тесты для поискового движка/Проверка изменения пути/Третий тест.txt")]
        [InlineData("C://Users//Broky//OneDrive//Desktop//Тесты для поискового движка//Проверка изменения пути//Четвёртый тест.txt")]
        [InlineData("\"C:/Users/Broky/OneDrive/Desktop/Тесты для поискового движка/Проверка изменения пути/Пятый тест.txt\"")]
        public void FileReadIsCorrect(string path)
        {
            Assert.NotNull(TextSource.FromFile(path));
        }
    }
}