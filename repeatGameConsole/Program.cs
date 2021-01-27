using System;

namespace repeatGameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * ВНИМАНИЕ, код подробно описан в комментириях в регионе "1 игрок хард", в остальных регионах действия кода практически совпадают по логике
             * Поэтому в остальных регионах нет такого кол-ва комментариев. Для ознаколмения с другими регионами проводите паралель с 1 регионом.
             * Если есть различия в логике работы кода между регионами и он вам не понятен, ну......, сори;)
                */
            //Параметры первого бота
            string nameBot1 = "Мс Чербер";
            Random rand = new Random();
            //Параметры второго бота
            string nameBot2 = "Дерзкий Мич";
            //Параметры игры
            int schethcik = 0;//Счётчик для определения порядка очереди ходов, в дальеших комментариях будет сокращен до наименования ID
            string pometka = "Помните, что выстрелить можно от 1 до 6 пуль!";
            int fire = 0;//Переменная выстрелов, по умолчанию со значением 0, при первом ходе игрок его меняет
            string resultUserRevert = "Yes";//Переменная ответа пользователя, по умолчанию Yes, что позволит запустить цикл игры
            Console.WriteLine("Сколько игроков от 1 по 2 будет играть ?");
            int userColumn = int.Parse(Console.ReadLine());//кол-во игроков, указанных игроком(ами)
            while (userColumn >= 3 || userColumn <= 0)//Проверка на веденные данные о кол-ве игроков
            {
                //В случае не правильного ответа от игрока, переспросить его и проверить еще раз
                Console.WriteLine("Доступна только игра для 1 игрока или для 2. Выберите, 1 игрок или 2 игрока ?");
                userColumn = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("По умолчанию у вас стандартный уровень сложности. Хотите более СЛОЖНЫЙ уровень ?");
            string resultLevel = Console.ReadLine();
            //Выполнится в случае совпадения ответа игрока с условием!
            if (resultLevel == "Да" || resultLevel == "да" || resultLevel == "Yes" || resultLevel == "yes")
            {
                #region 1 игрок хард
                if (userColumn == 1)//Если ответ игрока будет равен 1, то запуститься игра с 1 игроком
                {
                    Console.WriteLine($"Режим ХАРД выбран\n{nameBot1}: Добро пожаловать, сейчас я вам загадаю число!");
                    Console.WriteLine($"{nameBot1}: Как вас зовут ?");
                    string nameUser1 = Console.ReadLine();//Обработка имени игрока
                    Console.WriteLine($"{nameBot1}: Отлично, ваш соперник вас уже ждёт!\n{nameBot2}: Эй, чумба, зря ты решил сразиться со мной!)");
                    int randomKlin = rand.Next(0, 101);//Неудачный клин револьера(случайное событие)
                    //Обработка ответа с реваншом, так как по умолчанию мы задали значение YES, то первое условие автоматически выполнится, что позволит запустить игру
                    while (resultUserRevert == "да" || resultUserRevert == "Да" || resultUserRevert == "Yes" || resultUserRevert == "yes")
                    {
                        int magikNumberBot1 = rand.Next(12, 121);//Рандомное число от 1 бота
                        while (magikNumberBot1 > 0)//Проверка на кол-во цифр, если цифр будет больше 0, то действия игры будут повторяться пока не будет при проверке false
                        {
                            if (schethcik == 0)//Проверка ID игрока
                            {
                                //Если ID игрока равен 0, то это первый игрок
                                Console.WriteLine($"{nameBot1}: Сейчас стреляет {nameUser1}! {pometka}");
                                fire = int.Parse(Console.ReadLine());
                                if (randomKlin > 90)//Рандомное событие на клин оружия, в случае если будет true, то будет переназначение выстрелов в 0
                                {
                                    fire = 0;//Выстрелы
                                }
                                schethcik++;//Инкремент, добавит +1 в ID, чтобы передать ход другому игроку в дальнейшем
                            }
                            else if (schethcik == 1)//Проверка на ID
                            {
                                //Если ID игрока равен 1, то это  второй игрок
                                Console.WriteLine($"{nameBot1}: Сейчас стреляет {nameBot2}! {pometka}");
                                fire = rand.Next(0, 8);
                                pometka = "";//Стирается значение переменной, так как напоминание работает только в первый ход каждого игрока
                                schethcik--;//Декремент, убавит -1 в ID, чтобы передать ход другому игроку в дальнейшем 
                            }
                            switch (fire)//Проверка на кол-во выстрелов
                            {
                                case 0:
                                    Console.WriteLine($"{nameBot1}: Ты когда чистил револьер ?\nХод потрачен, пушка заклинила(");
                                    break;
                                case 1:
                                    Console.WriteLine($"{nameBot1}: Один выстрел, за то какой!");
                                    --magikNumberBot1;
                                    Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    break;
                                case 2:
                                    Console.WriteLine($"{nameBot1}: Хороший выстрел!");
                                    magikNumberBot1 -= 2;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine($"{nameBot1}: Сойдёт");
                                    magikNumberBot1 -= 3;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine($"{nameBot1}: Меткий глаз!");
                                    magikNumberBot1 -= 4;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                case 5:
                                    Console.WriteLine($"{nameBot1}: Метко!");
                                    magikNumberBot1 -= 5;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                case 6:
                                    Console.WriteLine($"{nameBot1}: Отличные выстрелы!");
                                    magikNumberBot1 -= 6;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                case 7:
                                    Console.WriteLine($"{nameBot1}: Ого, {nameBot2} нашел второй револьер с 4 патронами");
                                    magikNumberBot1 -= 10;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                default:
                                    Console.WriteLine($"{nameBot1}: Промазал, с кем не бывает, но точно не с {nameBot2}");
                                    break;
                            }
                            if (magikNumberBot1 < 1 && schethcik == 1)//Проврека на кол-во цифр и ID игрока
                            {
                                //Так как в конце каждого хода ID игрока меняется, то при проверке ID 1 == первому игроку
                                Console.WriteLine($"{nameBot2}: Чтож, ты крепкий малый, поздравляю с победой тебя!\nХочешь реванш ?");
                                resultUserRevert = Console.ReadLine();//Переменная со значением пользователя на вопрос
                            }
                            else if (magikNumberBot1 < 1 && schethcik == 0)//Проврека на кол-во цифр и ID игрока, в случае если первое условие false
                            {
                                //Так как в конце каждого хода ID игрока меняется, то при проверке ID 0 == второму игроку
                                Console.WriteLine($"{nameBot1}: Поздравляем {nameBot2} с очередной победой!");
                                Console.WriteLine($"{nameBot2}: Хочешь реванш ?");
                                resultUserRevert = Console.ReadLine();//Переменная со значением пользователя на вопрос
                            }
                        }
                        Console.Clear();//Очистка прошлых выводов, для удобной читаемости
                        Console.WriteLine($"{nameBot1}: Спасибо вам за игру!");
                    }
                }
                #endregion
                #region 2 игрока хард
                if (userColumn == 2)
                {
                    Console.WriteLine($"Режим ХАРД выбран\n{nameBot1}: Добро пожаловать, сейчас я вам загадаю число!");
                    Console.WriteLine($"{nameBot1}: Как вас зовут ?");
                    string nameUserOne = Console.ReadLine();
                    Console.WriteLine($"{nameBot1}: Имя второго игрока ?");
                    string nameUserTwo = Console.ReadLine();
                    Console.WriteLine($"{nameBot1}: Оу, кто-то присоединился к вам!\n{nameBot2}: Эй, чумбы, я первый уничтожу эти цифры!)");
                    int randomKlin = rand.Next(0, 101);//Неудачный клин револьера(случайное событие)
                    while (resultUserRevert == "да" || resultUserRevert == "Да" || resultUserRevert == "Yes" || resultUserRevert == "yes")
                    {
                        int magikNumberBot1 = rand.Next(12, 121);
                        while (magikNumberBot1 > 0)
                        {
                            if (schethcik == 0)
                            {
                                Console.WriteLine($"{nameBot1}: Сейчас стреляет {nameUserOne}! {pometka}");
                                fire = int.Parse(Console.ReadLine());
                                if (randomKlin > 90)
                                {
                                    fire = 0;
                                }
                                schethcik++;
                            }
                            else if (schethcik == 1)
                            {
                                Console.WriteLine($"{nameBot1}: Сейчас стреляет {nameUserTwo}! {pometka}");
                                fire = int.Parse(Console.ReadLine());
                                if (randomKlin > 90)
                                {
                                    fire = 0;
                                }
                                schethcik++;
                            }
                            else if (schethcik == 2)
                            {
                                Console.WriteLine($"{nameBot1}: Сейчас стреляет {nameBot2}! {pometka}");
                                fire = rand.Next(0, 8);
                                pometka = "";
                                schethcik -= 2;
                            }
                            switch (fire)
                            {
                                case 0:
                                    Console.WriteLine($"{nameBot1}: Ты когда чистил револьер ?\nХод потрачен, пушка заклинила(");
                                    break;
                                case 1:
                                    Console.WriteLine($"{nameBot1}: Один выстрел, за то какой!");
                                    --magikNumberBot1;
                                    Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    break;
                                case 2:
                                    Console.WriteLine($"{nameBot1}: Хороший выстрел!");
                                    magikNumberBot1 -= 2;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine($"{nameBot1}: Сойдёт");
                                    magikNumberBot1 -= 3;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine($"{nameBot1}: Меткий глаз!");
                                    magikNumberBot1 -= 4;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                case 5:
                                    Console.WriteLine($"{nameBot1}: Метко!");
                                    magikNumberBot1 -= 5;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                case 6:
                                    Console.WriteLine($"{nameBot1}: Отличные выстрелы!");
                                    magikNumberBot1 -= 6;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                case 7:
                                    Console.WriteLine($"{nameBot1}: Ого, {nameBot2} нашел второй револьер с 4 патронами");
                                    magikNumberBot1 -= 10;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                default:
                                    Console.WriteLine($"{nameBot1}: Промазал, с кем не бывает, но точно не с {nameBot2}");
                                    break;
                            }
                            if (magikNumberBot1 < 1 && schethcik == 1)
                            {
                                Console.WriteLine($"{nameBot2}: Чтож, ты крепкий малый {nameUserOne}, поздравляю с победой тебя!\nХочешь реванш ?");
                                resultUserRevert = Console.ReadLine();
                            }
                            else if (magikNumberBot1 < 1 && schethcik == 2)
                            {
                                Console.WriteLine($"{nameBot2}: Чтож, ты крепкий малый {nameUserTwo}, поздравляю с победой тебя!\nХочешь реванш ?");
                                resultUserRevert = Console.ReadLine();
                            }
                            else if (magikNumberBot1 < 1 && schethcik == 0)
                            {
                                Console.WriteLine($"{nameBot1}: Поздравляем с очередной победой {nameBot2}!");
                            }
                        }
                    }
                }
                #endregion
                //В случае стандартного уровня сложности
            }
            //Выполнится в случае не совпадения с первым условием и при совпадение этого условия
            else if (resultLevel == "Нет" || resultLevel == "нет" || resultLevel == "No" || resultLevel == "no")
            {
                #region 1 игрок на стандарте            
                if (userColumn == 1)
                {
                    Console.WriteLine($"{nameBot1}: Добро пожаловать, сейчас я вам загадаю число!");
                    Console.WriteLine($"{nameBot1}: Как вас зовут ?");
                    string nameUser1 = Console.ReadLine();
                    Console.WriteLine($"{nameBot1}: Отлично, ваш соперник вас уже ждёт!\n{nameBot2}: Эй, чумба, зря ты решил сразиться со мной!)");
                    while (resultUserRevert == "да" || resultUserRevert == "Да" || resultUserRevert == "Yes" || resultUserRevert == "yes")
                    {
                        int magikNumberBot1 = rand.Next(13, 56);
                        while (magikNumberBot1 > 0)
                        {
                            if (schethcik == 0)
                            {
                                Console.WriteLine($"{nameBot1}: Сейчас стреляет {nameUser1}! {pometka}");
                                fire = int.Parse(Console.ReadLine());
                                schethcik++;
                            }
                            else if (schethcik == 1)
                            {
                                Console.WriteLine($"{nameBot1}: Сейчас стреляет {nameBot2}! {pometka}");
                                fire = rand.Next(0, 7);
                                pometka = "";
                                schethcik--;
                            }
                            switch (fire)
                            {
                                case 0:
                                    Console.WriteLine($"{nameBot1}: Ты когда чистил револьер ?\nХод потрачен, пушка заклинила(");
                                    break;
                                case 1:
                                    Console.WriteLine($"{nameBot1}: Один выстрел, за то какой!");
                                    --magikNumberBot1;
                                    Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    break;
                                case 2:
                                    Console.WriteLine($"{nameBot1}: Хороший выстрел!");
                                    magikNumberBot1 -= 2;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine($"{nameBot1}: Сойдёт");
                                    magikNumberBot1 -= 3;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine($"{nameBot1}: Меткий глаз!");
                                    magikNumberBot1 -= 4;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                case 5:
                                    Console.WriteLine($"{nameBot1}: Метко!");
                                    magikNumberBot1 -= 5;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                case 6:
                                    Console.WriteLine($"{nameBot1}: Отличные выстрелы!");
                                    magikNumberBot1 -= 6;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                default:
                                    Console.WriteLine($"{nameBot1}: Промазал, с кем не бывает, но точно не с {nameBot2}");
                                    break;
                            }
                            if (magikNumberBot1 < 1 && schethcik == 1)
                            {
                                Console.WriteLine($"{nameBot2}: Чтож, ты крепкий малый, поздравляю с победой тебя!\nХочешь реванш ?");
                                resultUserRevert = Console.ReadLine();
                            }
                            else if (magikNumberBot1 < 1 && schethcik == 0)
                            {
                                Console.WriteLine($"{nameBot1}: Поздравляем {nameBot2} с очередной победой!");
                                Console.WriteLine($"{nameBot2}: Хочешь реванш ?");
                                resultUserRevert = Console.ReadLine();
                            }
                        }
                        Console.Clear();
                        Console.WriteLine($"{nameBot1}: Спасибо вам за игру!");
                    }
                }
                #endregion
                #region 2 игрока на стандарте
                else if (userColumn == 2)
                {
                    Console.WriteLine($"{nameBot1}: Добро пожаловать, сейчас я вам загадаю число!");
                    Console.WriteLine($"{nameBot1}: Как вас зовут ?");
                    string nameUserOne = Console.ReadLine();
                    Console.WriteLine($"{nameBot1}: Имя второго игрока ?");
                    string nameUserTwo = Console.ReadLine();
                    Console.WriteLine($"{nameBot1}: Да начнётся пальба!");
                    //Обработка реванша, по умолчанию значение да, но после каждой игры оно меняется в зависимости от ответа игрока
                    while (resultUserRevert == "да" || resultUserRevert == "Да" || resultUserRevert == "Yes" || resultUserRevert == "yes")
                    {
                        int magikNumberBot1 = rand.Next(13, 56);
                        while (magikNumberBot1 > 0)
                        {
                            if (schethcik == 0)
                            {
                                Console.WriteLine($"{nameBot1}: Сейчас стреляет {nameUserOne}! {pometka}");
                                fire = int.Parse(Console.ReadLine());
                                schethcik++;
                            }
                            else if (schethcik == 1)
                            {
                                Console.WriteLine($"{nameBot1}: Сейчас стреляет {nameUserTwo}! {pometka}");
                                fire = int.Parse(Console.ReadLine());
                                schethcik--;
                            }
                            switch (fire)
                            {
                                case 0:
                                    Console.WriteLine($"{nameBot1}: Ты когда чистил револьер ?\nХод потрачен, пушка заклинила(");
                                    break;
                                case 1:
                                    Console.WriteLine($"{nameBot1}: Один выстрел, за то какой!");
                                    --magikNumberBot1;
                                    Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    break;
                                case 2:
                                    Console.WriteLine($"{nameBot1}: Хороший выстрел!");
                                    magikNumberBot1 -= 2;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine($"{nameBot1}: Сойдёт");
                                    magikNumberBot1 -= 3;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine($"{nameBot1}: Меткий глаз!");
                                    magikNumberBot1 -= 4;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                case 5:
                                    Console.WriteLine($"{nameBot1}: Метко!");
                                    magikNumberBot1 -= 5;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                case 6:
                                    Console.WriteLine($"{nameBot1}: Отличные выстрелы!");
                                    magikNumberBot1 -= 6;
                                    if (magikNumberBot1 > 0)
                                    {
                                        Console.WriteLine($"{nameBot1}: Осталось {magikNumberBot1} жалких цифр!");
                                    }
                                    break;
                                default:
                                    Console.WriteLine($"{nameBot1}: Промазал, с кем не бывает...");
                                    break;
                            }
                            if (magikNumberBot1 < 1 && schethcik == 1)
                            {
                                Console.WriteLine($"{nameBot2}: Чтож, ты крепкий малый {nameUserOne}, поздравляю с победой тебя!\nХочешь реванш ?");
                                resultUserRevert = Console.ReadLine();
                            }
                            else if (magikNumberBot1 < 1 && schethcik == 2)
                            {
                                Console.WriteLine($"{nameBot2}: Чтож, ты крепкий малый {nameUserTwo}, поздравляю с победой тебя!\nХочешь реванш ?");
                                resultUserRevert = Console.ReadLine();
                            }
                        }
                    }
                }

            }           
                     #endregion
            /*В случае если ответ игрока не подходит не под одно из условий, программа просто завершает свою работу.
            Стоит отметить, что можно переделать обработчик ответа. Для того, чтобы программа в случае не совпадения просто переспросила ответ
            Также стоит отметить, что программа создана исключительно в тренировочной цели. Поэтому работа проводилась не всеми возможными способами C#
             */
        }
    }
}
