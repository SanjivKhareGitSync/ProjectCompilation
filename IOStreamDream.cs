using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCompilation
{
    internal class IOStreamDream
    {
        private static string _destinationDirectory = "";
        private static List<string>? _FileNameCollection;
        public static int totalFileCount = 0;
        private static readonly string[] AllowedExtensions = {
        ".html", ".py", ".csv", ".txt", ".md", ".docx", ".pdf",
        ".xls", ".xlsx", ".png", ".jpg", ".jpeg", ".gif",
        ".mp4", ".zip", ".rar", ".trdx" , ".sql", ".GMUVS", ".json", ".xml"
        };

        public string DestinationDirectory
        {
            get { return _destinationDirectory; }
            set { _destinationDirectory = value; }
        }

        public IOStreamDream() { 
            DestinationDirectory = Path.GetPathRoot(Path.GetTempPath()) + "FolderDesign\\" ?? "";
        }
        public IOStreamDream(string destinationPath) { 
            _destinationDirectory = destinationPath;
        }
        public static void ProcessDirectory(string targetDirectory, int type)
        {
            totalFileCount += Directory.GetFiles(targetDirectory).Length;
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                ProcessFile(fileName, type);
            }
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                ProcessDirectory(subdirectory, type);
            }
        }

        public static void ProcessFile(string path, int type)
        {
            switch (type)
            {
                case 1:
                    Console.WriteLine($"Processed file '{path}'.");
                    break;
                case 2:
                    _FileNameCollection?.Add(Path.GetFileName(path));
                    //Console.WriteLine($"fileName: {Path.GetFileName(path)}");
                    break;
                case 3:
                    Console.WriteLine($"fileExtension: {Path.GetExtension(path)}");
                    break;
                case 4:
                    Console.WriteLine($"fileDirectory: {Path.GetDirectoryName(path)}");
                    break;
                case 5:
                    if (!path.IsDocument())
                    {
                        return;
                    }
                    CopyPasteFileToNewCategoryFolder(path);
                    break;
                case 6:
                    CutPasteFileToNewCategoryFolder(path);
                    break;
                case 7:
                    MoveFileToNewCategoryFolder(path);
                    break;
                default:
                    break;

            }
        }

        public void Run(string path, int type)
        {
            if (File.Exists(path))
            {
                // This path is a file
                ProcessFile(path, type);
            }
            else if (Directory.Exists(path))
            {
                // This path is a directory
                ProcessDirectory(path, type);
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", path);
            }
            Console.WriteLine(totalFileCount);
        }

        public void RunCollectFileNames(string path)
        {
            _FileNameCollection = new List<string>();
            Run(path, 2);
            foreach (string fileName in _FileNameCollection.OrderBy(x => Path.GetExtension(x)))
            {
                if (IsAllowedExtension(fileName))
                {
                    Console.WriteLine(fileName);
                }
            }
            Console.WriteLine("Total Allowed Files: " + _FileNameCollection.Where(x => IsAllowedExtension(x)).Count());
            _FileNameCollection.Clear();
        }
        public void RunCollectFileExtensionNames(string path)
        {
            _FileNameCollection = new List<string>();
            Run(path, 2);
            foreach (string fileName in _FileNameCollection.Where(x => !string.IsNullOrEmpty(Path.GetExtension(x)))
                                                           .OrderBy(x => Path.GetExtension(x))
                                                           .Select(x => Path.GetExtension(x + ","))
                                                           .Distinct())
            {
                Console.WriteLine(fileName);
            }
            _FileNameCollection.Clear();
        }

        static bool IsAllowedExtension(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            return AllowedExtensions.Contains(extension);
        }

        static void CopyPasteFileToNewCategoryFolder(string path)
        {
            if (!path.IsDocument())
            {
                return;
            }
            int i = 0;
            string newFilePath = "";
            string destinationDir = Path.Combine($"{_destinationDirectory}\\NewFolderStructure\\", Path.GetExtension(path).Replace(".", "") + "\\");
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }
            if (!File.Exists(destinationDir + Path.GetFileName(path)))
            {
                File.Copy(path, destinationDir + Path.GetFileName(path));
            }
            else
            {
                i++;
                newFilePath = destinationDir + Path.GetFileNameWithoutExtension(path) + "_copy(" + i + ")" + Path.GetExtension(path);
                while (File.Exists(newFilePath))
                {
                    if (new FileInfo(path).Length == new FileInfo(newFilePath).Length)
                    {
                        return;
                    }
                    i++;
                    newFilePath = destinationDir + Path.GetFileNameWithoutExtension(path) + "_copy(" + i + ")" + Path.GetExtension(path);
                }
                File.Copy(path, newFilePath);
            }
            Console.WriteLine(path);
            return;
        }

        static void CutPasteFileToNewCategoryFolder(string path)
        {
            if (!path.IsDocument())
            {
                return;
            }
            int i = 0;
            string newFilePath = "";
            string destinationDir = Path.Combine($"{_destinationDirectory}\\NewFolderStructure\\", Path.GetExtension(path).Replace(".", "") + "\\");
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }
            if (!File.Exists(destinationDir + Path.GetFileName(path)))
            {
                File.Copy(path, destinationDir + Path.GetFileName(path));
                File.Delete(path);
            }
            else
            {
                i++;
                newFilePath = destinationDir + Path.GetFileNameWithoutExtension(path) + "_copy(" + i + ")" + Path.GetExtension(path);
                while (File.Exists(newFilePath))
                {
                    if (new FileInfo(path).Length == new FileInfo(newFilePath).Length)
                    {
                        return;
                    }
                    i++;
                    newFilePath = destinationDir + Path.GetFileNameWithoutExtension(path) + "_copy(" + i + ")" + Path.GetExtension(path);
                }
                File.Copy(path, newFilePath);
                File.Delete(path);
            }
            Console.WriteLine(path);
            return;
        }

        static void MoveFileToNewCategoryFolder(string path)
        {
            if (!path.IsVideo())
            {
                return;
            }
            int i = 0;
            string newFilePath = "";
            string destinationDir = Path.Combine($"{_destinationDirectory}\\NewFolderStructure\\", Path.GetExtension(path).Replace(".", "") + "\\");
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }
            if (!File.Exists(destinationDir + Path.GetFileName(path)))
            {
                File.Move(path, destinationDir + Path.GetFileName(path));
            }
            else
            {
                i++;
                newFilePath = destinationDir + Path.GetFileNameWithoutExtension(path) + "_copy(" + i + ")" + Path.GetExtension(path);
                while (File.Exists(newFilePath))
                {
                    if (new FileInfo(path).Length == new FileInfo(newFilePath).Length)
                    {
                        return;
                    }
                    i++;
                    newFilePath = destinationDir + Path.GetFileNameWithoutExtension(path) + "_copy(" + i + ")" + Path.GetExtension(path);
                }
                File.Move(path, newFilePath);
            }
            Console.WriteLine(path);
            return;
        }


    }
}

