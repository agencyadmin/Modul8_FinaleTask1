using System;
using System.IO;
using System.Linq;

class Program

{
    static void Main(string arg)
    {
        string TargetFolder = arg;// @"C:\Users\wmtra\Desktop\TestDir\Modul8_Task1"; 

        try
        {
            if (Directory.Exists(TargetFolder))
            {

                string[] directories = Directory.GetDirectories(TargetFolder);
                foreach (string d in directories) Console.WriteLine(d);
                foreach (string d in directories)// (where d:Directory(TargetFolder) => d.GetLastAccessTimeUTC <= DateTime.Now + DataTime.Hour(3) ))
                {
                    if (Directory.GetLastAccessTime(d) < DateTime.Now.AddMinutes(30))
                    {
                        Directory.Delete(d, true);
                        Console.WriteLine("Папка " + d + " использовалась: " + Directory.GetLastAccessTime(d) + " и будет удалена через: " + (DateTime.Now - Directory.GetLastAccessTimeUtc(d)));
                        Console.WriteLine("Папка " + d + " удалена: " + DateTime.Now);
                        DateTime date1 = DateTime.Now;
                        DateTime date2 = Directory.GetLastAccessTime(d);
                        TimeSpan interval = date1 - date2;
                        Console.WriteLine($"Крайний доступ: {0} - Время текущее: {1} = Осталось до удаления дней.часов.минут.секунд: {2}", date2, date1, interval.ToString());
                    }
                }
                string[] files = Directory.GetFiles(TargetFolder);
                foreach (string f in files) Console.WriteLine(f);
                foreach (string d in files) //(where d: Directory (TargetFolder) => d.GetLastAccessTimeUTC <= DateTime.Now + DataTime.Hour(3) ))
                {
                    if (File.GetLastAccessTime(d).AddHours(3) < DateTime.Now.AddMinutes(30))
                    {
                        File.Delete(d);
                        Console.WriteLine("Файл " + d + " использовался: " + File.GetLastAccessTime(d) + " и будет удален через: " + (DateTime.Now - File.GetLastAccessTime(d)));
                        Console.WriteLine("Файл " + d + " удален:  " + DateTime.Now);
                        DateTime date1 = DateTime.Now;
                        DateTime date2 = File.GetLastAccessTime(d);
                        TimeSpan interval = date1 - date2;
                        Console.WriteLine($"Крайний доступ: {0} - Время текущее: {1} = Осталось до удаления дней.часов.минут.секунд: {2}", date2, date1, interval.ToString());
                    }
                }
            }

            else throw new Exception("Такой папки не сущесвует! Или передан в программу не корректный путь! Или нет прав доступа к папке!");
        }

        catch (Exception ex)
        { Console.WriteLine(ex); }
    }

}