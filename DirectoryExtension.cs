using System;
using System.IO;
using System.Linq;

namespace  FileScaner
{
    public static class DirectoryExtension
    {
        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;

            FileInfo[] files = d.GetFiles();

            foreach (FileInfo fi in files)
            {
                size += fi.Length;
            }

            DirectoryInfo[] dirs = d.GetDirectories();  

            foreach (DirectoryInfo di in dirs)
            {
                size += DirSize(di);
            }

            return size;
        }
        public static uint DirFile(DirectoryInfo d) // метод считает ТОЛЬКО количество файлов в папке и ее подкаталогах  //добавить подсчет папок
        {
            uint amount = 0;

            FileInfo[] files = d.GetFiles();

            foreach (FileInfo fi in files)
            {
                amount ++;
            }

            DirectoryInfo[] dirs = d.GetDirectories();

            foreach (DirectoryInfo di in dirs)
            {
                amount += DirFile(di); ;
            }

            return amount;
        }
        public static uint ClearDir(DirectoryInfo d) // метод удаляет и возвращает количество удаленных файлов и папок не используемых свыше 30 минут
        {
            
            uint deleted = 0;
                        
            FileInfo[] files = d.GetFiles();
            foreach (FileInfo fi in files) //.Where(d => File.GetLastAccessTime(d.Name) <= DataTime.Now.AddMinutes(30)))
            {
                if (fi.Exists)
                {
                    try
                    {
                        if (File.GetLastAccessTime(fi.FullName) <= DateTime.Now.AddMinutes(-30)) // добиться правильного формата времени последнего доступа может через просто нейм может приведением в стринг
                        {
                            File.Delete(fi.FullName);
                            Console.WriteLine($"Удален файл: {fi.FullName} размером {fi.Length} байт. ");
                            deleted ++;
                        }
                    }

                    catch (Exception ex) 
                    {
                        Console.WriteLine($"Во время удаления файлов и определения времени последнего доступа к ним возникла ошибка: {0} !", ex);
                    }
                }
                
            }

            DirectoryInfo[] dirs = d.GetDirectories();

            foreach (DirectoryInfo di in dirs)
            {
                if (di.Exists)
                {
                    try
                    {
                        if (Directory.GetLastAccessTime(di.Name) <= DateTime.Now.AddMinutes(-30)) //
                        {
                           
                           Console.WriteLine($"Удалена папка со всеми файлами: {di.FullName}");
                           deleted += ClearDir(di);
                           di.Delete(true);

                        }
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine($"Во время удаления файлов и определения времени последнего доступа к ним возникла ошибка: {0} !", ex);
                    }
                }
                 
            }

            return deleted;
        }
    }
}
