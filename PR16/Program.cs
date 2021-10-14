using System;
using System.Linq;
using System.Text;

namespace PR16
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.OutputEncoding = Encoding.Unicode;
            int sw = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("-> Оберіть операцію:");
                    Console.WriteLine("\t-> 1. Показати різницю забитих і пропущених голів для кожної команди.");
                    Console.WriteLine("\t-> 2. Показати повну інформацію про матч.");
                    Console.WriteLine("\t-> 3. Показати інформацію про матчі в конкретну дату.");
                    Console.WriteLine("\t-> 4. Показати всі матчі конкретної команди.");
                    Console.WriteLine("\t-> 5. Показати всіх гравців, які забили голи в конкретну дату.");
                    Console.WriteLine("\t-> 6. Додати нову інформацію про матч.");
                    Console.WriteLine("\t-> 7. Змінити дані про матч.");
                    Console.WriteLine("\t-> 8. Видалити матч.");
                    Console.WriteLine("\t-> 0. Вихід.");
                    Console.Write("-> Ваш вибір: ");
                    sw = int.Parse(Console.ReadLine());
                }
                catch(Exception ex)
                {
                    Console.WriteLine("!-> " + ex.Message);
                    Console.WriteLine("-----------------------------------------");
                }

                switch (sw)
                {
                    case 1:
                        try
                        {
                            Console.WriteLine("---------------------------------");
                            Console.WriteLine("\tРізниця на табло");
                            using (FootballModel f = new FootballModel())
                            {
                                var q = from obj in f.Matches select obj;
                                foreach (var item in q)
                                {
                                    Console.WriteLine("---------------------------------");
                                    Console.WriteLine($"-> {item.First_Team}\t| \t{item.Second_Team}");
                                    Console.WriteLine($"->\t{item.First_Team_Score}\t: \t{item.Second_Team_Score}");
                                }
                            }
                            Console.WriteLine("---------------------------------");
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("!-> " + ex.Message);
                            Console.WriteLine("------------------------------------------");
                        }
                        break;

                    case 2:
                        int iter = 0;
                        try
                        {
                            Console.WriteLine("------------------------------------------");
                            using (FootballModel f = new FootballModel())
                            {
                                var q = from obj in f.Matches select obj;
                                foreach (var item in q)
                                {
                                    iter++;
                                    Console.WriteLine($"-> Інформація про {iter} матч:");
                                    Console.WriteLine($"\t-> Команда: {item.First_Team}");
                                    Console.WriteLine($"\t-> Суперник: {item.Second_Team}");
                                    Console.WriteLine($"\t-> Рахунок: {item.First_Team_Score} : {item.Second_Team_Score}");
                                    Console.WriteLine($"\t-> Інформація: забила команда {item.Score_Info}");
                                    Console.WriteLine($"\t-> Дата матчу: {item.Match_Date}");
                                    Console.WriteLine("------------------------------------------");
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("!-> " + ex.Message);
                            Console.WriteLine("------------------------------------------");
                        }
                        break;

                    case 3:
                        int iterS = 0;
                        DateTime myDate;
                        try
                        {
                            Console.WriteLine("------------------------------------------");
                            Console.Write("-> Введіть дату матчу: ");
                            myDate = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("------------------------------------------");
                        
                            using (FootballModel f = new FootballModel())
                            {
                                var q = from obj in f.Matches
                                        where obj.Match_Date == myDate
                                        select obj;
                                      
                                foreach (var item in q)
                                {
                                    iterS++;
                                    Console.WriteLine($"-> Інформація про {iterS} матч:");
                                    Console.WriteLine($"\t-> Команда: {item.First_Team}");
                                    Console.WriteLine($"\t-> Суперник: {item.Second_Team}");
                                    Console.WriteLine($"\t-> Рахунок: {item.First_Team_Score} : {item.Second_Team_Score}");
                                    Console.WriteLine($"\t-> Інформація: забила команда {item.Score_Info}");
                                    Console.WriteLine($"\t-> Дата матчу: {item.Match_Date}");
                                    Console.WriteLine("------------------------------------------");
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("!-> " + ex.Message);
                            Console.WriteLine("------------------------------------------");
                        }
                        break;

                    case 4:
                        int iterT = 0;
                        string myCommand;
                        try
                        {
                            Console.WriteLine("------------------------------------------");
                            Console.Write("-> Введіть вашу команду: ");
                            myCommand = Console.ReadLine();
                            Console.WriteLine("------------------------------------------");
                            using (FootballModel f = new FootballModel())
                            {
                                var q = from obj in f.Matches
                                        where obj.First_Team == myCommand
                                        || obj.Second_Team == myCommand
                                        select obj;

                                foreach(var item in q)
                                {
                                    iterT++;
                                    Console.WriteLine($"-> Інформація про {iterT} матч:");
                                    Console.WriteLine($"\t-> Команда: {item.First_Team}");
                                    Console.WriteLine($"\t-> Суперник: {item.Second_Team}");
                                    Console.WriteLine($"\t-> Рахунок: {item.First_Team_Score} : {item.Second_Team_Score}");
                                    Console.WriteLine($"\t-> Інформація: забила команда {item.Score_Info}");
                                    Console.WriteLine($"\t-> Дата матчу: {item.Match_Date}");
                                    Console.WriteLine("------------------------------------------");
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("!-> " + ex.Message);
                            Console.WriteLine("------------------------------------------");
                        }
                        break;

                    case 5:
                        int iterF = 0;
                        DateTime myDateS;
                        try
                        {
                            Console.WriteLine("------------------------------------------");
                            Console.Write("-> Введіть дату матчу: ");
                            myDateS = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("------------------------------------------");
                            using (FootballModel f = new FootballModel())
                            {
                                var q = from obj in f.Varehouses
                                        join obj2 in f.Matches on
                                        obj.Id equals obj2.Id
                                        where obj2.Match_Date == myDateS
                                        select new { obj.Name, obj.Surname, 
                                            obj.Patronymic, obj2.Match_Date };

                                foreach(var item in q)
                                {
                                    iterF++;
                                    Console.WriteLine($"-> Інформація про {iterF} гравця:");
                                    Console.WriteLine($"\t-> Ім'я: {item.Name}");
                                    Console.WriteLine($"\t-> Прізвище: {item.Surname}");
                                    Console.WriteLine($"\t-> По-батькові: {item.Patronymic}");
                                    Console.WriteLine($"\t-> Забив: {item.Match_Date}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("!-> " + ex.Message);
                            Console.WriteLine("------------------------------------------");
                        }
                        Console.WriteLine("-----------------------------------------");
                        break;

                    case 6:
                        Console.WriteLine("-----------------------------------------");
                        try
                        {
                            Console.WriteLine("-> Введіть нову інформацію про матч.");
                            Console.Write("\t-> Перша команда: ");
                            string newFirstTeam = Console.ReadLine();
                            Console.Write("\t-> Друга команда: ");
                            string newSecondTeam = Console.ReadLine();
                            Console.Write("\t-> Рекорд першої комнади: ");
                            int newFirstCommandRecord = int.Parse(Console.ReadLine());
                            Console.Write("\t-> Рекорд другої команди: ");
                            int newSecondCommandRecord = int.Parse(Console.ReadLine());
                            Console.Write("\t-> Інформація: ");
                            string newInfo = Console.ReadLine();
                            Console.Write("\t-> Дата матчу: ");
                            DateTime newDate = DateTime.Parse(Console.ReadLine());

                            using (FootballModel f = new FootballModel())
                            {
                                Matches m = new Matches()
                                {
                                    First_Team = newFirstTeam,
                                    Second_Team = newSecondTeam,
                                    First_Team_Score = newFirstCommandRecord,
                                    Second_Team_Score = newSecondCommandRecord,
                                    Score_Info = newInfo,
                                    Match_Date = newDate
                                };

                                //if(m.First_Team != newFirstTeam
                                //    || m.Second_Team != newSecondTeam
                                //    || m.First_Team_Score != newFirstCommandRecord
                                //    || m.Second_Team_Score != newSecondCommandRecord
                                //    || m.Score_Info != newInfo
                                //    || m.Match_Date != newDate)
                                //{
                                    f.Matches.Add(m);
                                    f.SaveChanges();
                                    Console.WriteLine("-> Нову інформацію успішно додано!");
                                //}
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("!->" + ex.Message);
                            Console.WriteLine("------------------------------------------");
                        }
                        Console.WriteLine("-----------------------------------------");
                        break;

                    case 7:
                        Console.WriteLine("------------------------------------------");
                        Matches _m = new Matches();
                        using (FootballModel f = new FootballModel())
                        {
                            Console.WriteLine("-> Оберіть параметр для зміни:");
                            Console.WriteLine("\t-> 1. Змінити назву першої команди.");
                            Console.WriteLine("\t-> 2. Змінити назву другої команди.");
                            Console.WriteLine("\t-> 3. Змінити рекорд першої команди.");
                            Console.WriteLine("\t-> 4. Змінити рекорд другої команди.");
                            Console.WriteLine("\t-> 5. Змінити інформацію про рекорд.");
                            Console.WriteLine("\t-> 6. Змінити дату проведення матчу.");
                            Console.Write("-> Ваш вибір: ");
                            int _sw = int.Parse(Console.ReadLine());
                            Console.WriteLine("----------------------------------------");

                            switch (_sw)
                            {
                                case 1:
                                    Console.Write("-> Введіть назву першої команди: ");
                                    string C1 = Console.ReadLine();
                                    if (C1 == _m.First_Team)
                                    {
                                        Console.Write("-> Введіть нову назву першої команди: ");
                                        string newC1 = Console.ReadLine();
                                        var _query = f.Matches.Where(obj => obj.First_Team == newC1).FirstOrDefault();
                                        _query.First_Team = newC1;
                                        Console.WriteLine("!-> Запис змінено!");
                                        f.SaveChanges();
                                        Console.WriteLine("-----------------------------------------");
                                    }
                                    else if(C1 != _m.First_Team)
                                    {
                                        Console.WriteLine("-> Дані не знайдено!");
                                        Console.WriteLine("-----------------------------------------");
                                        Console.ReadKey();
                                    }
                                    break;

                                case 2:
                                    Console.Write("-> Введіть назву другої команди: ");
                                    string C2 = Console.ReadLine();
                                    if (C2 == _m.Second_Team)
                                    {
                                        Console.Write("-> Введіть нову назву другої команди: ");
                                        string newC2 = Console.ReadLine();
                                        var _query = f.Matches.Where(obj => obj.Second_Team == newC2).FirstOrDefault();
                                        _query.Second_Team = newC2;
                                        Console.WriteLine("!-> Запис змінено!");
                                        f.SaveChanges();
                                        Console.WriteLine("-----------------------------------------");
                                    }
                                    else if (C2 != _m.Second_Team)
                                    {
                                        Console.WriteLine("-> Дані не знайдено!");
                                        Console.WriteLine("-----------------------------------------");
                                        Console.ReadKey();
                                    }
                                    break;

                                case 3:
                                    Console.Write("-> Введіть рекорд першої команди: ");
                                    int rC1 = int.Parse(Console.ReadLine());
                                    if (rC1 == _m.First_Team_Score)
                                    {
                                        Console.Write("-> Введіть новий рекорд першої команди: ");
                                        int newrC1 = int.Parse(Console.ReadLine());
                                        var _query = f.Matches.Where(obj => obj.First_Team_Score == newrC1).FirstOrDefault();
                                        _query.First_Team_Score = newrC1;
                                        Console.WriteLine("!-> Запис змінено!");
                                        f.SaveChanges();
                                        Console.WriteLine("-----------------------------------------");
                                    }
                                    else if (rC1 != _m.First_Team_Score)
                                    {
                                        Console.WriteLine("-> Дані не знайдено!");
                                        Console.WriteLine("-----------------------------------------");
                                        Console.ReadKey();
                                    }
                                    break;

                                case 4:
                                    Console.Write("-> Введіть рекорд другої команди: ");
                                    int rC2 = int.Parse(Console.ReadLine());
                                    if (rC2 == _m.Second_Team_Score)
                                    {
                                        Console.Write("-> Введіть новий рекорд другої команди: ");
                                        int newrC2 = int.Parse(Console.ReadLine());
                                        var _query = f.Matches.Where(obj => obj.Second_Team_Score == newrC2).FirstOrDefault();
                                        _query.Second_Team_Score = newrC2;
                                        Console.WriteLine("!-> Запис змінено!");
                                        f.SaveChanges();
                                        Console.WriteLine("-----------------------------------------");
                                    }
                                    else if (rC2 != _m.Second_Team_Score)
                                    {
                                        Console.WriteLine("-> Дані не знайдено!");
                                        Console.WriteLine("-----------------------------------------");
                                        Console.ReadKey();
                                    }
                                    break;
                                    
                                case 5:
                                    Console.Write("-> Введіть інформацію про рекорд: ");
                                    string record = Console.ReadLine();
                                    if (record == _m.Score_Info)
                                    {
                                        Console.Write("-> Введіть новий рекорд другої команди: ");
                                        string newRec = Console.ReadLine();
                                        var _query = f.Matches.Where(obj => obj.Score_Info == newRec).FirstOrDefault();
                                        _query.Score_Info = newRec;
                                        Console.WriteLine("!-> Запис змінено!");
                                        f.SaveChanges();
                                        Console.WriteLine("-----------------------------------------");
                                    }
                                    else if (record != _m.Score_Info)
                                    {
                                        Console.WriteLine("-> Дані не знайдено!");
                                        Console.WriteLine("-----------------------------------------");
                                        Console.ReadKey();
                                    }
                                    break;

                                case 6:
                                    Console.Write("-> Введіть дату проведення матчу: ");
                                    DateTime date = DateTime.Parse(Console.ReadLine());
                                    if (date == _m.Match_Date)
                                    {
                                        Console.Write("-> Введіть нову дату проведення матчу: ");
                                        DateTime newDate = DateTime.Parse(Console.ReadLine());
                                        var _query = f.Matches.Where(obj => obj.Match_Date == newDate).FirstOrDefault();
                                        _query.Match_Date = newDate;
                                        Console.WriteLine("!-> Запис змінено!");
                                        f.SaveChanges();
                                        Console.WriteLine("-----------------------------------------");
                                    }
                                    else if (date != _m.Match_Date)
                                    {
                                        Console.WriteLine("-> Дані не знайдено!");
                                        Console.WriteLine("-----------------------------------------");
                                        Console.ReadKey();
                                    }
                                    break;
                            }
                        }
                        break;

                    case 8:
                        Console.WriteLine("------------------------------------------");
                        try
                        {
                            Console.Write("-> Введіть назву команди: ");
                            string commName = Console.ReadLine();
                            Console.Write("-> Введіть дату проведення матчу: ");
                            DateTime d = DateTime.Parse(Console.ReadLine());
                            Matches mm = new Matches();
                            Console.WriteLine("-> Ви дійсно бажаєте видалити матч?");
                            Console.WriteLine("\t-> Так.");
                            Console.WriteLine("\t-> Ні.");
                            Console.Write("-> Ваш вибір: ");
                            int delete = int.Parse(Console.ReadLine());

                            using (FootballModel f = new FootballModel())
                            {
                                if(delete == 1 && commName == mm.First_Team || 
                                    commName == mm.Second_Team && d == mm.Match_Date)
                                {
                                    Matches del_query = f.Matches.Where(q => q.First_Team == commName
                                    && q.Match_Date == d).FirstOrDefault();
                                    f.Matches.Remove(del_query);
                                    f.SaveChanges();
                                    Console.WriteLine("!-> Матч видалено!");
                                    Console.WriteLine("-----------------------------------------");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("!-> " + ex.Message);
                            Console.WriteLine("------------------------------------------");
                        }
                        Console.WriteLine("-----------------------------------------");
                        break;

                    case 0:
                        Environment.Exit(0);
                        Console.WriteLine("-----------------------------------------");
                        break;
                }
            }
        }
    }
}
