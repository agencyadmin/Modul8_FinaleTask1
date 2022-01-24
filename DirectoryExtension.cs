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
        public static uint DirFile(DirectoryInfo d) // метод считает ТОЛЬКО количество файлов в папке и ее подкаталогах
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
        public static uint ClearDir(DirectoryInfo d) // метод возвращает количество удаленных файлов
        {
            
            uint deleted = 0;
            long initialsize = DirSize(d);
            
            FileInfo[] files = d.GetFiles();
            foreach (FileInfo fi in files) //.Where(d => File.GetLastAccessTime(d.Name) <= DataTime.Now.AddMinutes(30)))
            {
                if (fi.Exists)
                {
                    try
                    {
                        if (File.GetLastAccessTime(fi.FullName) <= DateTime.Now.AddMinutes(-30))
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
                deleted += ClearDir(di); 
            }

            return deleted;
        }
    }
}
