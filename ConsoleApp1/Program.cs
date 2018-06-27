using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            String answer;
            DateTime _date = new DateTime(2018, 06, 24, 23, 00, 00);
            Message _message = new Message(Environment.UserName, _date);

            do
            {
                Console.WriteLine(_message.GetHelloMessage());
                answer = Console.ReadLine();
            }
            while (answer != "exit");
        }
    }
}

