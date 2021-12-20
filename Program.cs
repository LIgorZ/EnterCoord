using System;
using System.Collections.Generic;

namespace EnterCoord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вводите координаты построчно, завершая строку клавишей ENTER. ");
            Console.WriteLine("Для завершения ввода ещё раз нажмите клавишу ENTER.");
            var list = new List<string>();  
            var queue = new Queue<char>();  
            while (true)
            {
                var code = Console.Read(); 
                try
                {
                    if (code < 0) break;
                    var ch = Convert.ToChar(code); 
                    if (ch == '\n')  
                    {
                        
                        var sb = new System.Text.StringBuilder();
                        while (queue.Count > 0)
                            sb.Append(queue.Dequeue());
                        queue.Clear(); 
                        var s = sb.ToString().Trim();
                        if (s.Length == 0) break;
                        list.Add(s);
                    }
                    queue.Enqueue(ch);                  
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Введены строки: ");
            foreach (var line in list)
                Console.WriteLine(line);
            
            var result = new List<string>();
            foreach (var line in list)
            {
                var items = line.Split(new[] { ',' });
                if (items.Length == 2)
                {
                    var x = items[0].Trim().Replace('.', ',');
                    var y = items[1].Trim().Replace('.', ',');
                    result.Add(string.Format("X:{0} Y:{1}", x, y));
                }
            }
            Console.WriteLine("В отформатированном виде координаты: ");
            foreach (var line in result)
                Console.WriteLine(line);
        }
    }
}
