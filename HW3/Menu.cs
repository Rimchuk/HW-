using HW3.classes;
using HW3.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HW3
{
    public class Menu
    {
        List<Person> workerList;
        ChoiseOfSerializable ch = new ChoiseOfSerializable();
        ISerialize mySerializer;

        public void Show()
        {
            if (ch.ChoiserOfSerializable() == "XML")
            {
                mySerializer = new MySerializeXml();
            }
            else if (ch.ChoiserOfSerializable() == "BIN")
            {
                mySerializer = new MySerializeBin();
            }

                 workerList = (List<Person>)mySerializer.DeserializeList();
            Console.Write("Данные с файла были успешно загружены!\nНажмите любую кнопку для продолжения...");
            Console.ReadLine();

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Введите команду: ");
                Console.ResetColor();
                string[] commands = Console.ReadLine().Split(' ');
                if (commands.Length == 0 || commands.Length > 2)
                {
                    Help();
                    continue;
                }
                if (commands.Length == 1)
                {
                    switch (commands[0].ToLower())
                    {
                        case "add":
                            string temp;
                            bool isExist = false;
                            int id;
                            string reg;
                            Console.Write("\nВведите ID: ");
                            temp = Console.ReadLine();
                            if (!Int32.TryParse(temp, out id))
                            {
                                Error();
                                continue;
                            }
                            foreach (var w in workerList)
                            {
                                if (w.ID == id)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Ошибка!\nРаботник с таким ID уже сществует!");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                    isExist = true;

                                }
                            }

                            if (isExist)
                            {
                                continue;
                            }

                            Console.Write("Введите имя: ");
                            temp = Console.ReadLine();
                            string name;

                            Regex regex = new Regex(@"[A-ZА-Я]{1}[a-zа-я]*");//( @"[A-ZА-Я]*",RegexOptions.Compiled | RegexOptions.IgnoreCase);
                            Match match = regex.Match(temp);
                            if (match.Success)
                            {
                                name = temp;
                            }
                            else
                            {
                                Error();
                                continue;
                            }

                            Console.Write("Введите фамилия: ");
                            temp = Console.ReadLine();
                            string surname;

                            if (match.Success)
                            {
                                surname = temp;
                            }
                            else
                            {
                                Error();
                                continue;
                            }

                            Console.Write("Введите возраст: ");
                            temp = Console.ReadLine();
                            int age;
                            if (!Int32.TryParse(temp, out age))
                            {
                                Error();
                                continue;
                            }

                            Console.Write("Введите номер телефона: ");
                            temp = Console.ReadLine();
                            reg = @"[\+][3][8][0]\d{9}";
                            string phoneNumber;
                            if (Regex.IsMatch(temp, reg))
                            {
                                phoneNumber = temp;
                            }
                            else
                            {
                                Error();
                                continue;
                            }

                            Console.Write("Введите E-Mail: ");
                            temp = Console.ReadLine();
                            reg = @"\b[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}\b";
                            string eMail;
                            if (Regex.IsMatch(temp, reg))
                            {
                                eMail = temp;
                            }
                            else
                            {
                                Error();
                                continue;
                            }
                            workerList.Add(new Worker(id, name, surname, age, phoneNumber, eMail));
                            Console.WriteLine("Работник успешно добавлен в базу данных!");
                            break;

                        case "see":
                            foreach (var w in workerList)
                            {
                                Console.WriteLine(w.ToString());
                            }
                            Console.ReadLine();
                            break;

                        case "exit":

                                                     
                                mySerializer.SerializeList(workerList);
                                                                                  
                            return;

                        case "help":
                            Help();
                            break;

                        default:
                            Help();
                            break;
                    }
                }
                else if (commands.Length == 2)
                {
                    switch (commands[0].ToLower())
                    {
                        case "find":
                            int id;
                            if (!Int32.TryParse(commands[1], out id))
                            {
                                Help();
                                continue;
                            }
                            else
                            {
                                Int32.TryParse(commands[1], out id);
                                for (int i = 0; i < workerList.Count; i++)
                                {
                                    if (workerList[i].ID == id)
                                    {
                                        Console.WriteLine(workerList[i].ToString());
                                        Console.ReadLine();
                                    }
                                }
                            }
                            break;
                        case "del":
                            int del;
                            if (!Int32.TryParse(commands[1], out del))
                            {
                                Help();
                                continue;
                            }
                            else
                            {
                                Int32.TryParse(commands[1], out del);
                                for (int i = 0; i < workerList.Count; i++)
                                {
                                    if (workerList[i].ID == del)
                                    {
                                        workerList.RemoveAt(i);
                                        Console.WriteLine("Данные о работнике успешно удалены!");
                                        Console.ReadLine();
                                    }
                                }
                            }
                            break;
                        default:
                            Help();
                            break;
                    }
                }
            }
        }

        private void Error()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nОшибка ввода данных!\nНажмите любую кнопку для перехода в главное меню...");
            Console.ResetColor();
            Console.ReadLine();
        }

        private void Help()
        {
            Console.WriteLine("Help:");
            Console.WriteLine("\t-help - помощь");
            Console.WriteLine("\t-exit - сохранить сессию и выти с программы");
            Console.WriteLine("\t-add - добавить ");
            Console.WriteLine("\t-see - просмотреть список ");
            Console.WriteLine("\t-find [id] - поиск по id");
            Console.WriteLine("\t-del [id] - удалить а по id");

            Console.ReadLine();
        }
    }
}