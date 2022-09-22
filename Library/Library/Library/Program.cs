
using System.Reflection;
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
                Title = "333",
                Author = "22",
                Chapter = 24,
                CoverType = ECoverType.Soft,
                Expenditure = 1,
                Genre = EGenre.Family,
                ISBN = "9789631184501",
                Pages = 174
            }, 5);

            opus.Add(new Novel()
            {
                Title = "55555",
                Author = "22",
                Chapter = 1,
                CoverType = ECoverType.Soft,
                Expenditure = 1,
                Genre = EGenre.Drama,
                ISBN = "9789042019577",
                Pages = 140
            }, 3);

            opus.Add(new Comic()
            {
                Title = "999999999",
                Author = "1",
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
            string sor = _SetTextWithLength("Cím", _GetMaxLength("Title")) + _SetTextWithLength("| Szerző", _GetMaxLength("Author")) + "| Mennyiség";
            Console.WriteLine(sor);
            for (int i = 0; i < sor.Length; i++, Console.Write("-")) ;
            Console.WriteLine();
            foreach (var o in opus)
            {
                Console.Write($"{_SetTextWithLength(o.Key.Title, _GetMaxLength("Title"))}");
                Console.Write($"{_SetTextWithLength("| " + o.Key.Author, _GetMaxLength("Author"))}");
                Console.Write($"{o.Value,6}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
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
                string sen =""+ getValue(o.Key, field);
                if (sen.Length > length) length = sen.Length;
                
            }
            return length;
            //  return opus.Max(a => a.Key.Title.Length);
        }
        private static object getValue(object objec, string field) 
        {
         
            return objec.GetType().GetProperty(field).GetValue(objec);
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

        }

        private static void Remove()
        {

        }

        private static void Menu()
        {
            Console.WriteLine("***** Könyvtár kezelő *****");
            Console.WriteLine();
            Console.WriteLine("Menü:");
            Console.WriteLine("1. Művek listázása");
            Console.WriteLine("2. Új mű rögzítése");
            Console.WriteLine("3. Mű törlése");
            Console.WriteLine("4. Kilépés a programból");
        }
    }
}