using System;
using System.IO;
namespace DirectoryX
{
    class DirectoryOperations
    {
        public void ScanDirectories()
        {
            string filePath = "";
            Validation validation = new Validation();
            Console.WriteLine("What directory do you want to scan?\n" +
                "1. Desktop\n" +
                "2. Downloads\n" +
                "3. Documents\n");
            Console.Write("Input: ");
            int input = validation.NumberValidation(Console.ReadLine());
            // switch statement for user input
            switch(input)
            {
                case 1:
                    filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); 
                    ListDirectories(filePath);
                    break;
                case 2:
                    filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                    ListDirectories(filePath);
                    break;
                case 3:
                    filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    ListDirectories(filePath);
                    break;
                default:
                    Console.WriteLine("Enter a valid option");
                    break;
            }
        }
        void ListDirectories(string path)
        {
            int amount = 0;
            string[] dirs = Directory.GetDirectories(path);
            // list all directories within the list 
            foreach(string dir in dirs)
            {
                amount++;
                Console.WriteLine($"{amount}. {dir}");
            }
            Console.WriteLine("");
            if (amount == 0)
            {
                Console.WriteLine("No directories were found within the selected folder");
            }
        }

        public void NewDirectory()
        {
            string path = "";
            string name = "";
            Validation validation = new Validation();
            Console.WriteLine("Select from the following directories where you would like to create a new folder\n" +
                "1. Desktop\n" +
                "2. Downloads\n" +
                "3. Documents");
            Console.Write("Input: ");
            int userAnswer = validation.NumberValidation(Console.ReadLine());
            // switch statement for user input
            switch (userAnswer)
            {
                case 1:
                    path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    name = NameDirectory();
                    CreateDirectory(path, name);
                    break;
                case 2:
                    path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                    name = NameDirectory();
                    CreateDirectory(path, name);
                    break;
                case 3:
                    path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    name = NameDirectory();
                    CreateDirectory(path, name);
                    break;
                default:
                    Console.WriteLine("Enter a valid option");
                    break;
            }
        } 

        string NameDirectory()
        {
            Validation validation = new Validation();
            Console.WriteLine("What do you want to name the folder?");
            string name = validation.InputValidation(Console.ReadLine());
            Console.WriteLine($"Folder named: {name}");
            return name;
        } 
        void CreateDirectory(string path, string name)
        {
            string combinedPath = Path.Combine(path, name);
            try
            {
                // check if directory already exist 
                if (Directory.Exists(combinedPath))
                {
                    Console.WriteLine("Directory / folder already exist");
                }
                else
                {
                    Directory.CreateDirectory(combinedPath);
                    Console.WriteLine("Directory created!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       public void DeleteDirectory()
        {
            Validation validation = new Validation();
            Console.WriteLine("Enter the name of the folder that you want to delete\n" +
                "UNTIL A FUTURE UPDATE ONLY FOLDERS INSIDE OF YOUR USERPROFILE FOLDER WILL BE DELETED");
            Console.Write("Input: ");
            string answer = validation.InputValidation(Console.ReadLine());
            string combinePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), answer);
            // check if directory exist 
            try
            {
                if (Directory.Exists(combinePath))
                {
                    Directory.Delete(combinePath, true);
                }
                else
                {
                    Console.WriteLine("Directory could not be found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}