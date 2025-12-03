using Mini_SearchEngine;
using Mini_SearchEngine.Basic_logic;

namespace XUnitTest_Mini_SearchEngine
{
    public class XUnitTest
    {
        [Fact]
        public void FileReadReturnNull()
        {
            Assert.Null(TextSource.FromFile(null!));
            Assert.Null(TextSource.FromString(null!));
        }

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

        [Fact]
        public void TokenizerReturnNull()
        {
            Assert.Equal([], Tokenizer.GetTokens("             "));
            Assert.Equal([], Tokenizer.GetTokens(null!));
        }

        [Theory]
        [InlineData("привет друг", new string[] { "привет", "друг" })]
        [InlineData("вот и настал    конец данной    истории", 
            new string[] { "вот", "и", "настал", "конец", "данной", "истории" })]
        public void TokenizerGetTokensIsCorrect(string text, string[] outputArray)
        {
            Assert.Equal(outputArray, Tokenizer.GetTokens(text));
        }
    }
}