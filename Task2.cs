namespace Task2
{
    public class Task
    {
        public void Start() // === START ===
        {
            PrintStartTask("66", "на входе два натуральных числа, на выходе сумма натуральных числе в промежутке между ними.");

            int m = InputInt("Введите 1-е число");
            int n = InputInt("Введите 2-е число");

            Console.WriteLine();
            Console.WriteLine("Результат: " + ((m < n) ? IntervalNumbersSum(m, n) : IntervalNumbersSum(n, m)));

            PrintFinishTask();
        } // === FINISH ===

        /// <summary>
        /// получение суммы натуральных чисел в промежутке между двумя числами.
        /// </summary>
        /// <param name="minNumber">меньшее число</param>
        /// <param name="maxNumber">большее число</param>
        /// <returns>число</returns>
        static int IntervalNumbersSum(int minNumber, int maxNumber)
        {
            if (minNumber == maxNumber) return minNumber;
            return minNumber + IntervalNumbersSum(minNumber + 1, maxNumber);
        }
       

        /// <summary>
        /// ввод числа типа integer с контролем
        /// </summary>
        /// <param name="inputText">сообщение перед вводом</param>
        /// <returns>число</returns>
        static int InputInt(string inputText)
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

                if (rezult <= 0) // доп проверка
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("err: число должно быть натуральным!");

                    continue;
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