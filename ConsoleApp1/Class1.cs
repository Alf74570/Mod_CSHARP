using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Message
    {
        private String _user;
        private DateTime _date;
        private int _limit1;
        private int _limit2;
        private int _limit3;

        public Message(String _user, DateTime _date, int _limit1 = 8, int _limit2 = 13, int _limit3 = 18)
        {
            this._user = _user;
            this._date = _date;
            this._limit1 = _limit1;
            this._limit2 = _limit2;
            this._limit3 = _limit3;

        }

        public String GetHelloMessage()
        {
            if (_date.DayOfWeek == DayOfWeek.Saturday ||
                    _date.DayOfWeek == DayOfWeek.Sunday ||
                    (_date.DayOfWeek == DayOfWeek.Monday && _date.Hour < _limit1) ||
                    (_date.DayOfWeek == DayOfWeek.Friday && _date.Hour >= _limit3))
            {
                // nous sommes le week-end
                return ($"Bon Week-end {Environment.UserName}");

            }
            else if (_date.Hour >= _limit1 && _date.Hour <= _limit2)
            {
                // nous sommes en semaine et le matin
                return ("Bonjour " + Environment.UserName);

            }
            else if (_date.Hour > _limit2 && _date.Hour < _limit3)
            {
                // nous sommes en semaine et l'après-midi
                return ($"Bon Après-Midi {Environment.UserName} ");

            }
            else
            {
                // nous sommes dans la soirée
                return ($"Bonsoir {Environment.UserName}");

            }
        }

    }
}

