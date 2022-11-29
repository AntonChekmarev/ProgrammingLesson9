using System;

namespace Task3
{

    public class Task
    {
        public void Start() // === START ===
        {
            PrintStartTask("68", "на входе натуральные числа M и N, на выходе результат выполнения функции Аккермана.");

            int m = InputIntForAckerman("Введите число M"); // сначала строго M
            int n = InputIntForAckerman("Введите число N",m);

            Console.WriteLine();
            Console.WriteLine("Результат: " + AckermanFunction(m, n));

            PrintFinishTask();
        } // === FINISH ===

        /// <summary>
        /// Функция Аккермана
        /// </summary>
        /// <param name="m">число M</param>
        /// <param name="n">число N</param>
        /// <returns>число</returns>
        int AckermanFunction(int m, int n)
        {
            if (m == 0) return n + 1;
            else if (n == 0) return AckermanFunction(m - 1, 1);
            return AckermanFunction(m - 1, AckermanFunction(m, n - 1));
        }


        /// <summary>
        /// ввод чисел M и N для функции аккермана. Обязательно первым вводить M
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="m">если пользователь вводит число M, то параметр опустить. если вводится число N, то необходимо указать каким было M</param>
        /// <returns>число</returns>
        static int InputIntForAckerman(string inputText, int m = -1)
        {
            int rezult;

            Console.WriteLine("");
            do
            {
                Console.ResetColor();
                Console.Write(inputText + ": ");

                string str = Console.ReadLine()!.Trim();

                if (int.TryParse(str, out rezult) == false) // преобразование
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("err: неcоответствие типу Integer!");
                    continue;
                }

                if (rezult < 0) // доп проверка
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("err: число не должно быть отрицательным!");
                    continue;
                }

                if (m == -1) // если вводится число M
                {
                    if (rezult > 5) 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("err: во избежания переполнения, M не должно быть больше 5!");
                        continue;
                    }
                }
                else // если вводится число N
                {
                    if (m == 5 && rezult > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("err: во избежания переполнения при M = 5, допустимо только N = 0!");
                        continue;
                    }
                    if (m == 4 && rezult > 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("err: во избежания переполнения при M = 4, допустимо N не больше 1!");
                        continue;
                    }
                    if (m == 3 && rezult > 10)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("err: во избежания переполнения при M = 3, допустимо N не больше 10!");
                        continue;
                    }
                    if (m == 2 && rezult > 1000)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("err: во избежания переполнения при M = 2, допустимо N не больше 1000!");
                        continue;
                    }
                    if (m == 1 && rezult > 100000)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("err: во избежания переполнения при M = 1 допустимо N не больше 100000!");
                        continue;
                    }
                    if (m == 0 && rezult > 2147483646)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("err: во избежания переполнения при M = 0, допустимо N не больше 2147483646!");
                        continue;
                    }
                }
                break;
            } while (true);

            return rezult;
        }
    
        /// <summary>
        /// отрисовка заголовка задачи
        /// </summary>
        /// <param name="taskNumber">название задачи</param>
        /// <param name="taskText">текст задачи</param>
        /// <param name="infoText">дополнительная информация (необязательный параметр)</param>
        static void PrintStartTask(string taskNumber, string taskText, string infoText = "")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"ЗАДАЧА {taskNumber}: " + taskText);
            if (infoText != "")
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("info: " + infoText);
            }
            Console.ResetColor();
        }

        /// <summary>
        /// отрисовка завершения задачи
        /// </summary>
        static void PrintFinishTask()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("* для завершения задачи нажмите любую клавишу...");
            Console.ResetColor();
            Console.ReadKey(true);
        }








        //На случай запуска как самостоятельно проекта, не из под Главного Меню
        class Program
        {
            static void Main()
            {
                Task task = new();
                task.Start();
            }
        }
    }
}