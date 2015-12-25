using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var isText = Clipboard.ContainsText();

            Console.WriteLine("Первое задание");
            Console.WriteLine(String.Format("Содержится текст: {0}", (isText) ? "Да" : "Нет"));
            if (isText)
            {
                var cmp = StringComparer.CurrentCultureIgnoreCase;  // Сравнение слов без учета регистра
                var CollectionWord = CreateCollection();

                CollectionWord.Sort(cmp); 
                Display(CollectionWord);  
            }
            Console.ReadKey();
        }

        private static void Display(List<string> list)
        {
            Console.WriteLine();
            foreach (string s in list)
            {
                Console.WriteLine(s);
            }
        }

        private static List<string> CreateCollection()
        {
            var res = new List<string>();

            var Text = Clipboard.GetText();
            var array = Text.Split(' ').ToList();
            foreach (var item in array)
            {
                var str = item.Replace(".", "")
                              .Replace(",", "")
                              .Replace("?", "")
                              .Replace("!", "")
                              .Replace(":", "")
                              .Replace(";", "")
                              .Replace(" ", "")
                              .Replace("\t", "")
                              .Replace("\n", "");
                if (!res.Contains(str))
                {
                    res.Add(str);
                    if (res.Count == 1000)
                    {
                        break;
                    }
                }
            }

            return res;
        }

    }
}
