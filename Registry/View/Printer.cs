using System;
using Registry.Model.ConsoleSettings;

namespace Registry.View
{
    public static class Printer
    {
        public static void Print(object sender, ConsoleEventArgs e)
        {
            Console.WriteLine("А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я\n" +
                              "а б в г д е ё ж з и й к л м н о п р с т у ф х ц ч ш щ ъ ы ь э ю я\n" +
                              "1 2 3 4 5 6 7 8 9 0\n");
            PrintMenu();
        }
        public static void PrintMenu()
        {
            Console.WriteLine("Изменить цвета? (y - да, n - нет)");
        }
        public static void PrintColor()
        {
            Console.Clear();
            Array ArrColors = Enum.GetValues(typeof(ConsoleColor));
            for (int i = 0; i < ArrColors.Length; i++)
            {
                Console.WriteLine($"{ArrColors.GetValue(i)} - {(int)ArrColors.GetValue(i)}");
            }
            Console.WriteLine("Напишите номера цветов (Текст Фон) *Например: 3 5:");
        }
        public static void Clear() => Console.Clear();
    }
}
