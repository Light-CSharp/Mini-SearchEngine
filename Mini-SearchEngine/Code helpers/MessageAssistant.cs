namespace Mini_SearchEngine
{
    public static class MessageAssistant
    {
        /// <summary>
        /// Выводит сообщение зелёного цвета, нужен для обозначения успешности действия.
        /// </summary>
        /// <param name="message">Текст, который будет изменён в цвете.</param>
        public static void GreenMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Выводит сообщение красного цвета, нужен для обозначения неудачности действия.
        /// </summary>
        /// <param name="message">Текст, который будет изменён в цвете.</param>
        public static void RedMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Выводит сообщение синего цвета, нужен вывода различной информации.
        /// </summary>
        /// <param name="message">Текст, который будет изменён в цвете.</param>
        public static void BlueMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(message);
            Console.ResetColor();
        }
    }
}