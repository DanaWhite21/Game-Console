using System;
using System.Diagnostics;

namespace repeatDeletMe
{
    class Program
    {
        static void Main(string[] args)
        {
            #region game number 0.1
            Console.WriteLine("Добро пожаловать в игру!\nРады вас приветствовать в цифровой перестрелке;0\nВведите имя 1 игрока: ");
            string nameOneUser = Console.ReadLine();
            Console.WriteLine("Введите имя 2 игрока: ");
            string nameTwoUser = Console.ReadLine();
            string nameBot = "Мистер Чербен";
            Console.WriteLine($"{nameBot} загадывает число");
            Random XNumber = new Random();//Рандомайзер для бота
            string resultUser = "Yes";//Заготовка для записывания ответа игрока
            string textDzink = "Помни, что выстрелить можно только 1,2,3 или 4 патронами за один раз";//Напоминание в первые ходы игроков
            int i = 0;//Для идентификации игрока

            while (resultUser == "Yes" || resultUser == "yes" || resultUser == "да" || resultUser == "Да")
            {
                int MagicBotNumber = XNumber.Next(12, 121);//Бот загадывает число
                while (MagicBotNumber != 0 && MagicBotNumber > 0)
                {//Цикл для повторных выстрелов
                    if (i == 0 || i == 2)//Определение, какой игрок будет сейчас ходить
                    {
                        Console.WriteLine($"{nameBot}: Твой ход, {nameOneUser}! {textDzink}");
                        i -= 2;//Вычитание из индентификатора для передачи хода второму игроку
                    }
                    else
                    {
                        Console.WriteLine($"{nameBot}: Твой ход, {nameTwoUser}! {textDzink}");
                        textDzink = "";//Обнуление первичного напоминания
                    }
                    int fire = int.Parse(Console.ReadLine());//Обработчик выстрела кол-ва пуль
                    switch (fire)//Вариативность на кол-во выстрелов
                    {
                        case 0:
                            Console.WriteLine($"Воздух это тоже оружие, но не в твоем случае)\nОсталось {MagicBotNumber} цифр");
                            break;
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                            MagicBotNumber -= fire;
                            Console.WriteLine($"Ого, отличное попадание! Осталось {MagicBotNumber} цифр");
                            break;
                        case 50://Выстрел для разработчика(бога);)
                            MagicBotNumber -= fire;
                            Console.WriteLine($"Разработчик, рад видеть вас! Осталось {MagicBotNumber} цифр");
                            break;
                        default://В случае не соблюдения условий игры
                            Console.WriteLine("Ковбой, тише, случилась осечька!");
                            break;
                    }
                    i++;//Инкрементация для передачи счётчика следующему игроку
                }
                Console.Clear();//Очистка консоли для повышения читаемости
                if (i == 0 || i == 2)//Обратный игрок, так как система подсчёта сделана пока так, то тогда при выходе из цикла, условия определения игрока меняется наоборот
                {
                    Console.WriteLine($"{nameBot}: Ого, Чумба, да ты реально меткй стрелок. {nameOneUser} уже плачет о своем поражении\nХотите реванш ?");
                    resultUser = Console.ReadLine();

                }
                else
                {
                    Console.WriteLine($"{nameBot}: Ого, Чумба, да ты реально меткй стрелок. {nameTwoUser} уже плачет о своем поражении\nХотите реванш ?");
                    resultUser = Console.ReadLine();
                }
            }
            if (resultUser == "no" || resultUser == "No" || resultUser == "нет" || resultUser == "Нет")
            {
                Console.WriteLine($"{nameBot}:Спасибо вам за великолпеную игру. Еще увидимся {nameOneUser} и {nameTwoUser}!");
                Console.Clear();
            }
            else 
            {
                Console.WriteLine($"{nameBot}: Чумба, я тебя не понимаю!");
            }
            #endregion

        }
    }
}
