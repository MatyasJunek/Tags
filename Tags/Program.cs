using System;
using System.Text.RegularExpressions;

namespace ConsoleApp15
{

    class ChangeText
    {
        public string[] commands = {"blue", "note", "redback", "capital", "under"};
        public static string command;
        public string Command(string _change)
        {          
            if (_change.Contains("<"+commands[0]+">"))
            {
                command = commands[0];
                Blue(_change);
            }
            else if(_change.Contains("<" + commands[1] + ">"))
            {
                command = commands[1];
                Note(_change);
            }
            else if (_change.Contains("<" + commands[2] + ">"))
            {
                command = commands[2];
                RedBack(_change);
            }
            else if (_change.Contains("<" + commands[3] + ">"))
            {
                command = commands[3];
                Capital(_change);
            }
            else if (_change.Contains("<" + commands[4] + ">"))
            {
                command = commands[4];
                Under(_change);
            }


            return _change;
        }

        public string Blue(string _text)
        {
            _text = _text.Remove(0, command.Length + 2);
            _text = _text.Remove(_text.IndexOf('<'), command.Length + 3);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(_text);
            Console.ForegroundColor = ConsoleColor.White;
            return _text;
        }
        public string Note(string _text)
        {
            _text = _text.Remove(0, command.Length + 2);
            _text = _text.Remove(_text.IndexOf('<'), command.Length + 3);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("/" + _text + "/");
            Console.ForegroundColor = ConsoleColor.White;
            return _text;
        }
        public string RedBack(string _text)
        {
            _text = _text.Remove(0, command.Length + 2);          
            _text = _text.Remove(_text.IndexOf('<'), command.Length + 3);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(_text);
            Console.BackgroundColor = ConsoleColor.Black;
            return _text;
        }
        public string Capital(string _text)
        {
            _text = _text.Remove(0, command.Length + 2);
            _text = _text.Remove(_text.IndexOf('<'), command.Length + 3);
            Console.Write(_text.ToUpper());
            return _text;
        }
        public string Under(string _text)
        {
            _text = _text.Remove(0, command.Length + 2);
            _text = _text.Remove(_text.IndexOf('<'), command.Length + 3);
            Console.Write("____"+_text + "____");
            return _text;
        }
    }
    class Program
    {     
        static void Main(string[] args)
        {          
            string commandPattern = @"\<[a-z]+\>\w+.\w*\</[a-z]+\>";
            Regex regex = new Regex(commandPattern);
            ChangeText change = new ChangeText();

            string text = "Testovací <blue>text</blue>. Nevím, jak program volat z příkazového <note>řádku</note>. Jinak program <redback>funguje</redback>. " +
                "Ema má <capital>mísu</capital>. <under>Máma</under> mele maso";

            MatchCollection found = regex.Matches(text);


            int occur = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if ((text[i] == '<') && (found[occur].ToString().Contains(change.commands[0]) || found[occur].ToString().Contains(change.commands[1]) || found[occur].ToString().Contains(change.commands[2]) || found[occur].ToString().Contains(change.commands[3]) || found[occur].ToString().Contains(change.commands[4])))
                {         
                        change.Command(found[occur].ToString());
                        i = i + found[occur].Length - 1;
                        occur++;                  
                }
                else
                {
                    Console.Write(text[i]);
                }
            }
            Console.ReadLine();
        }
    }
}
