
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Library
{
    internal class Program
    {
        //  static List<Opus> _ops = new List<Opus>();
        static Dictionary<Opus, int> opus = new Dictionary<Opus, int>();

        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            opus.Add(new Novel()
            {
                Title = "Kincskereső kisködmön",
                Author = "Móra Ferenc",
                Chapter = 24,
                CoverType = ECoverType.Soft,
                Expenditure = 1,
                Genre = EGenre.Family,
                ISBN = "9789631184501",
                Pages = 174
            }, 5);

            opus.Add(new Novel()
            {
                Title = "Rómeó és Júlia",
                Author = "William Shakespeare",
                Chapter = 1,
                CoverType = ECoverType.Soft,
                Expenditure = 1,
                Genre = EGenre.Drama,
                ISBN = "9789042019577",
                Pages = 140
            }, 3);

            opus.Add(new Comic()
            {
                Title = "Grafield",
                Author = "Jim Davis",
                Expenditure = 1,
                Genre = EGenre.Family,
                Pages = 8,
                Category = ECategory.Comedy,
                Commoneess = 7,
                Language = "hu"
            }, 13);

            do
            {
                Menu();
                Console.Write("Kérem válasszon a menüből: ");
                ConsoleKeyInfo input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Listing();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Add();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Remove();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.WriteLine("\r\nBye bye");
                        return;
                    default:
                        break;
                }
            } while (true);

        }

        private static void Listing()
        {
            Console.WriteLine();
            Console.WriteLine("Jelenleg művek:");
            string sor = _SetTextWithLength("Cím", _GetMaxLength()) + _SetTextWithLength("| Szerző", _GetMaxLength("Author")) + "| Mennyiség";
            Console.WriteLine(sor);
            for (int i = 0; i < sor.Length; i++, Console.Write("-")) ;
            Console.WriteLine();
            foreach (var o in opus)
            {
                Console.Write($"{_SetTextWithLength(o.Key.Title, _GetMaxLength())}");
                Console.Write($"{_SetTextWithLength("| " + o.Key.Author, _GetMaxLength("Author"))}");
                Console.Write($"{o.Value,6}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static int _GetMaxLength()
        {
            return _GetMaxLength("Title");
        }

        /// <summary>
        /// Házi feladat: kiegészíteni a metódust a Type osztály
        /// segítségével úgy, hogy dinamikusan felismerje a property-t,
        /// és az alapján állapítsa meg a hosszát
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        private static int _GetMaxLength(string field)
        {
            int length = 0;
            foreach (var o in opus)
            {
                if (field == "Title")
                {
                    if (o.Key.Title.Length > length)
                    {
                        length = o.Key.Title.Length;
                    }
                }
                else if (field == "Author")
                {
                    if (o.Key.Author.Length > length)
                    {
                        length = o.Key.Author.Length;
                    }
                }
            }
            return length;
            //  return opus.Max(a => a.Key.Title.Length);
        }

        private static string _SetTextWithLength(string text, int maxLength)
        {
            for (int i = text.Length; i < maxLength + 2; i++)
            {
                text += " ";
            }
            return text;
        }

        private static void Add()
        {
            Opus opus = _CreateObject();
            if (opus == null)
            {
                return;
            }
            Console.WriteLine();
            if (opus.GetType() == typeof(Novel))
            {
                Console.WriteLine("Kiválasztott típus: regény");
                Novel book = (Novel)opus;
                int genre = _RequestEnum(typeof(EGenre), "műfajt");
                book.Genre = (EGenre)genre;

            }
            else if (opus.GetType() == typeof(Encyclopedia))
            {
                Console.WriteLine("Kiválasztott típus: enciklopédia");
                Encyclopedia book = (Encyclopedia)opus;
                int genre = _RequestEnum(typeof(EGenre), "műfajt");
                book.Genre = (EGenre)genre;
                _RequestParams(book);
            }
            else if (opus.GetType() == typeof(Magazine))
            {
                Console.WriteLine("Kiválasztott típus: újság");
                Magazine book = (Magazine)opus;
               
                _RequestParams(book);
            }
            else
            {
                Console.WriteLine("Kiválasztott típus: képregény");
                Comic book = (Comic)opus;
                int genre = _RequestEnum(typeof(EGenre), "műfajt");
                book.Genre = (EGenre)genre;
            }
        }

        private static void Remove()
        {

        }

        private static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("***** Könyvtár kezelő *****");
            Console.WriteLine();
            Console.WriteLine("Menü:");
            Console.WriteLine("1. Művek listázása");
            Console.WriteLine("2. Új mű rögzítése");
            Console.WriteLine("3. Mű törlése");
            Console.WriteLine("4. Kilépés a programból");
        }

        private static Opus _CreateObject()
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine("***** Mű kategóriák *****");
                Console.WriteLine("1. Regény");
                Console.WriteLine("2. Enciklopédia");
                Console.WriteLine("3. Újság");
                Console.WriteLine("4. Képregény");
                Console.WriteLine("5. Visszalépés az előző menübe");
                Console.Write("Kérem válasszon: ");
                ConsoleKeyInfo input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        return new Novel();
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        return new Encyclopedia();
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        return new Magazine();
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        return new Comic();
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        return null;
                    default:
                        break;
                }
            } while (true);
        }

        private static int _RequestEnum(Type t, string title)
        {
            do
            {
                Console.WriteLine($"***** Kérem válasszon {title} *****");
                List<int> enumValues = new List<int>();
                foreach (var en in Enum.GetValues(t))
                {
                    int poz = (int)en;
                    Console.WriteLine($"{poz}. {((Enum)en).GetDescription()}");
                    enumValues.Add(poz);
                }
                Console.WriteLine("0. undefined");
                Console.Write("Kérem válasszon: ");
                string input = Console.ReadLine();
                int result;
                if (int.TryParse(input, out result))
                {
                    if (result == 0)
                    {
                        return 0;
                    }
                    if (enumValues.Contains(result))
                    {
                        return result;
                    }
                }
                Console.WriteLine("Hibás adat! Adja meg újra!");
            } while (true);
        }

        private static Opus _RequestParams(Opus op)
        {
            PropertyInfo[] props = op.GetType().GetProperties();
            bool online = false;
            foreach (var item in props.OrderBy(a => a.Attributes))
            {
                string propDescr;
                
                CustomAttributeData description = item.CustomAttributes.SingleOrDefault(a => a.AttributeType == typeof(DescriptionAttribute));
                if (description == null)
                {
                    propDescr = item.Name;
                }
                else
                {
                    propDescr = description.ConstructorArguments[0].Value.ToString();
                }


                if (item.PropertyType.BaseType == typeof(Enum))
                {
                    int res = _RequestEnum(item.PropertyType, propDescr);
                    item.SetValue(op, res);
                }
                else if (item.PropertyType == typeof(int))
                {
                    int res;
                    string inp;
                    do
                    {
                        Console.Write($"{propDescr}: ");
                        inp = Console.ReadLine();
                    } while (!int.TryParse(inp, out res));
                    item.SetValue(op, res);
                }
                else if (item.PropertyType == typeof(bool) && item.Name == "AvailableOnline")
                {
                    string inp;
                   
                    do
                    {
                        Console.Write($"{propDescr} (I/H): ");
                        inp = Console.ReadLine();
                    } while (inp.ToLower() != "i" && inp.ToLower() != "h");
                    if (inp=="i")
                    {
                        online = true;
                    }
                    item.SetValue(op, inp.ToLower() == "i");

                    
                }
                else if (item.PropertyType == typeof(bool))
                {
                    string inp;
                    do
                    {
                        Console.Write($"{propDescr} (I/H): ");
                        inp = Console.ReadLine();
                    } while (inp.ToLower() != "i" && inp.ToLower() != "h");
                    item.SetValue(op, inp.ToLower() == "i");
                }
                else if (item.PropertyType == typeof(string) && !(item.Name== "OnlineURL"))
                {
                    string inp;
                    do
                    {
                        Console.Write($"{propDescr}: ");
                        inp = Console.ReadLine();
                    } while (string.IsNullOrEmpty(inp));
                    item.SetValue(op, inp);
                }
                else if (item.PropertyType == typeof(string) && (item.Name == "OnlineURL")&& online)
                {
                    string inp;
                    do
                    {
                        Console.Write($"{propDescr}: ");
                        inp = Console.ReadLine();
                    } while (string.IsNullOrEmpty(inp));
                    item.SetValue(op, inp);
                }

            }
            return op;
        }
        private static Opus _RequestParams2(Opus op)
        {
            PropertyInfo[] props = op.GetType().GetProperties();

            foreach (var item in props.OrderBy(a => a.Attributes))
            {
                string propDescr;
                CustomAttributeData description = item.CustomAttributes.SingleOrDefault(a => a.AttributeType == typeof(DescriptionAttribute));
                if (description == null)
                {
                    propDescr = item.Name;
                }
                else
                {
                    propDescr = description.ConstructorArguments[0].Value.ToString();
                }
                if (item.PropertyType.BaseType == typeof(Enum))
                {
                    int res = _RequestEnum(item.PropertyType, propDescr);
                    item.SetValue(op, res);
                }
                else if (item.PropertyType == typeof(int))
                {
                    int res;
                    string inp;
                    do
                    {
                        Console.Write($"{propDescr}: ");
                        inp = Console.ReadLine();
                    } while (!int.TryParse(inp, out res));
                    item.SetValue(op, res);
                }
                else if (item.PropertyType == typeof(bool))
                {
                    string inp;
                    do
                    {
                        Console.Write($"{propDescr} (I/H): ");
                        inp = Console.ReadLine();
                    } while (inp.ToLower() != "i" && inp.ToLower() != "h");
                    item.SetValue(op, inp.ToLower() == "i");
                }
                else
                {
                    string inp;
                    do
                    {
                        Console.Write($"{propDescr}: ");
                        inp = Console.ReadLine();
                    } while (string.IsNullOrEmpty(inp));
                    item.SetValue(op, inp);
                }
            }
            return op;
        }
    }
}