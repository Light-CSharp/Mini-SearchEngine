namespace Mini_SearchEngine
{
    public static class MessageAssistant
    {
        /// <summary>
        /// Выводит сообщение красного цвета, нужен для обозначения неудачности действия.
        /// </summary>
        /// <param name="message">Текст, который будет изменён в цвете.</param>
        public static void RedMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}