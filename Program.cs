using System;
using System.IO;
using System.Linq;

namespace FileScaner
{
    class Program

    {
        static void Main(string[] args)
        {
            string TargetFolder = @"C:\Users\wmtra\Desktop\TestDir\Modul8_Task1";  //args[0]; 

            try
            {
                if (Directory.Exists(TargetFolder))
                {

                    string[] directories = Directory.GetDirectories(TargetFolder);
                    foreach (string d in directories) Console.WriteLine(d);
                    foreach (string d in directories)// (Where d:Directory => d.GetLastAccessTime <= DateTime.Now.AddMinutes(30) ))
                    {
                        if (Directory.GetLastAccessTime(d) < DateTime.Now.AddMinutes(30))
                        {

                            Console.WriteLine("Папка " + d + " использовалась: " + Directory.GetLastAccessTime(d) + " и будет удалена через: " + (DateTime.Now - Directory.GetLastAccessTimeUtc(d)));
                            Console.WriteLine("Папка " + d + " удалена: " + DateTime.Now);
                            DateTime date1 = DateTime.Now;
                            DateTime date2 = Directory.GetLastAccessTime(d);
                            TimeSpan interval = date1 - date2;
                            Console.WriteLine($"Крайний доступ: {0} - Время текущее: {1} = Осталось до удаления дней.часов.минут.секунд: {2}", date1, date2, interval.ToString());
                            Directory.Delete(d, true);
                            Console.WriteLine("Папка " + d + " УДАЛЕНА! " + DateTime.Now);
                        }
                    }
                    string[] files = Directory.GetFiles(TargetFolder);
                    foreach (string f in files) Console.WriteLine(f);
                    foreach (string d in files) //(Where d => d.GetLastAccessTime <= DateTime.Now.AddMinutes(30) ))
                    {
                        if (File.GetLastAccessTime(d) < DateTime.Now.AddMinutes(30))
                        {

                            Console.WriteLine("Файл " + d + " использовался: " + File.GetLastAccessTime(d) + " и будет удален через: " + (DateTime.Now - File.GetLastAccessTime(d)));

                            DateTime date1 = DateTime.Now;
                            DateTime date2 = File.GetLastAccessTime(d);
                            TimeSpan interval = date1 - date2;
                            Console.WriteLine($"Крайний доступ: {0} - Время текущее: {1} = Осталось до удаления дней.часов.минут.секунд: {2}", date1, date2, interval.ToString());
                            File.Delete(d);
                            Console.WriteLine("Файл " + d + " УДАЛЕН !!!!:  " + DateTime.Now);
                        }
                    }
                }

                else throw new Exception("Такой папки не сущесвует! Или передан в программу не корректный путь! Или нет прав доступа к папке!");
            }

            catch (Exception ex)
            { Console.WriteLine(ex); }
        }

    }
}