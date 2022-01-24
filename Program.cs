using System;
using System.IO;
using System.Linq;
using FileScaner;

namespace FileScaner
{
    class Program

    {
        public static void Main(string[] args)
        {
            DirectoryInfo dir = new (args[0]);
            long initialSize = DirectoryExtension.DirSize(dir);
            string TargetFolder = args[0]; //@"C:\Users\wmtra\Desktop\TestDir\Modul8_Task1";  
            Console.WriteLine($"Исходный размер папки: {DirectoryExtension.DirSize(dir)} байт");
            Console.WriteLine("************************************************************************************************");
            // Console.WriteLine($"Папка содержит поддериктории и файлы в них: {Directory.GetFileSystemEntries(TargetFolder)} байт");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine($"Освобождено: {initialSize - DirectoryExtension.DirSize(dir)} байт. ");
            Console.WriteLine($"Удалено: {DirectoryExtension.ClearDir(dir)} файлов.");
            Console.WriteLine($"Текущий размер папки: {DirectoryExtension.DirSize(dir)} байт.");
            Console.WriteLine("_________________________________________________________________________________________________");

            //if (Directory.Exists(TargetFolder)) 
            //{
            //    try
            //    {



            //        string[] directories = Directory.GetDirectories(TargetFolder);
            //        //  foreach (string d in directories) Console.WriteLine(d);
            //        foreach (string d in directories)// (Where d:Directory => d.GetLastAccessTime <= DateTime.Now.AddMinutes(30) )) //перебор всех папок в папке для чистки без субдиректорий!
            //        {
            //            if (Directory.GetLastAccessTime(d) < DateTime.Now.AddMinutes(30))
            //            {

            //                Console.WriteLine("Папка " + d + " использовалась: " + Directory.GetLastAccessTime(d) + " и уже не использовалась: " + (DateTime.Now - Directory.GetLastAccessTime(d)));
            //                Console.WriteLine("Папка " + d + " удалена: " + DateTime.Now);
            //                DateTime date1 = DateTime.Now;
            //                DateTime date2 = Directory.GetLastAccessTime(d);
            //                TimeSpan interval = date1 - date2;
            //                Console.WriteLine($"Крайний доступ: {0} - Время текущее: {1} и не использовалась: дней.часов.минут.секунд: {2}", date2, date1, interval.ToString());
            //                Directory.Delete(d, true);
            //                Console.WriteLine("Папка " + d + " УДАЛЕНА! " + DateTime.Now);
            //            }
            //        }
            //        string[] files = Directory.GetFiles(TargetFolder);
            //        // foreach (string f in files) Console.WriteLine(f); // вывод списка файлов для удаления в целевой папке переданной в программу для чистки
            //        foreach (string d in files) //(Where d => d.GetLastAccessTime <= DateTime.Now.AddMinutes(30) ))
            //        {
            //            if (File.GetLastAccessTime(d) < DateTime.Now.AddMinutes(30))
            //            {

            //                Console.WriteLine("Файл " + d + " использовался: " + File.GetLastAccessTime(d) + " и не использовался: " + (DateTime.Now - File.GetLastAccessTime(d)));

            //                DateTime date1 = DateTime.Now;
            //                DateTime date2 = File.GetLastAccessTime(d);
            //                TimeSpan interval = date1 - date2;
            //                Console.WriteLine($"Крайний доступ: {0} - Время текущее: {1} и не использовался: дней.часов.минут.секунд: {2}", date2, date1, interval.ToString());
            //                File.Delete(d);
            //                Console.WriteLine("Файл " + d + " УДАЛЕН !!!!:  " + DateTime.Now);
            //            }
            //            else throw new Exception("Такой папки не сущесвует! Или передан в программу не корректный путь! Или нет прав доступа к папке!");
            //        }






            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"Во время удаления файлов и определения времени последнего доступа к ним возникла ошибка: {0} !", ex);
            //    }
            //}

            //else Console.WriteLine($"По переданному в программу аргументу или параметру пути {args[0]} папки не существует!");
        }

    }

}


