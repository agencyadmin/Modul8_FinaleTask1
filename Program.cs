using System;
using System.IO;
using System.Linq;

class Program

{
    public static void Main(string[] arg)
    {
        string TargetFolder = @"C:\Users\wmtra\Desktop\TestDir\Modul8_Task1";
        if (Directory.Exists(TargetFolder))
        {

            string[] directories = Directory.GetDirectories(TargetFolder);
            foreach (string d in directories) Console.WriteLine(d);
            foreach (string d in directories)// (where d:Directory(TargetFolder) => d.GetLastAccessTimeUTC <= DateTime.Now + DataTime.Hour(3) ))
            {
                if (Directory.GetLastAccessTimeUtc(d).AddHours(3) < DateTime.Now.AddMinutes(30))
                {
                    Directory.Delete(d, true);
                    Console.WriteLine("Папка " + d + " была создана: " + Directory.GetLastAccessTimeUtc(d) + " и будет удалена через: " + (DateTime.Now - Directory.GetLastAccessTimeUtc(d)));
                    Console.WriteLine("Папка " + d + " удалена: " + DateTime.Now);
                }
            }
            string[] files = Directory.GetFiles(TargetFolder);
            foreach (string f in files) Console.WriteLine(f);
            foreach (string d in files) //(where d: Directory (TargetFolder) => d.GetLastAccessTimeUTC <= DateTime.Now + DataTime.Hour(3) ))
            {
                if (File.GetLastAccessTimeUtc(d).AddHours(3) < DateTime.Now.AddMinutes(30))
                {
                    File.Delete(d);
                    Console.WriteLine("Файл " + d + " была создана: " + File.GetLastAccessTimeUtc(d) + " и будет удален через: " + (DateTime.Now - File.GetLastAccessTimeUtc(d)));
                    Console.WriteLine("Файл " + d + " удален: " + DateTime.Now);
                }
            }
        }
    }

}