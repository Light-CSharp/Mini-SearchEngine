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


        [Fact]
        public void TextNormalizerReturnNull()
        {
            Assert.Null(TextNormalizer.Normalize(null!));
            Assert.Null(TextNormalizer.Normalize("!!!!!! .... ????? \v\v\v\v"));
        }

        [Theory]
        [InlineData("\"Привет, друг!\"")]
        [InlineData("... Вот и настал конец данной истории ... \n -- но что же дальше?")]
        [InlineData("\'Амбициозность\',        \n\t\v что имеется в виду под" + " этим словом?")]
        public void TextNormalizerIsCorrect(string text)
        {
            string normalizeText = TextNormalizer.Normalize(text)!;

            Assert.DoesNotContain("\"", normalizeText);
            Assert.DoesNotContain("\'", normalizeText);

            Assert.DoesNotMatch(@"[,\.\?!:;-]", normalizeText);
            Assert.DoesNotContain("  ", normalizeText);
        }
    }
}