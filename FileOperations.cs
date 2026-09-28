using System;
using System.IO;

namespace DirectoryX
{
    class FileOperations
    {
        public void ListFiles()
        {
            int amount = 0;
            // instance of validation
            Validation validation = new Validation();
            Console.WriteLine("Select from the following folders which one you would like to inspect: \n" +
                "1. Downloads\n" +
                "2. Desktop\n" +
                "3. Documents");
            Console.Write("Input: ");
            int input = validation.NumberValidation(Console.ReadLine());
            // switch statement for user input 
            switch(input)
            {
                case 1:
                    // directory path is downloads folder 
                    string downloads = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                    // get all files within the folder 
                    string[] downloadsFiles = Directory.GetFiles(downloads);
                    // for each file in the folder, log that file out to the console
                    foreach (string file in downloadsFiles)
                    {
                        amount++;
                        Console.WriteLine($"{amount}. {Path.GetFileName(file)}");
                    }
                    break;
                case 2:
                    // directory path is desktop folder
                    string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    string[] desktopFiles = Directory.GetFiles(desktop);
                    amount = 0;
                    // list all files within folder
                    foreach (string file in desktopFiles)
                    {
                        amount++;
                        Console.WriteLine($"{amount}. {Path.GetFileName(file)}");
                    }

                    break;
                case 3:
                    // directory path is the documents folder
                    string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    string[] docFiles = Directory.GetFiles(documents);
                    amount = 0;
                    // list all files within folder
                    foreach (string file in docFiles)
                    {
                        amount++;
                        Console.WriteLine($"{amount}. {Path.GetFileName(file)}");
                    }
                    break;
                default:
                    Console.WriteLine("Enter a valid option");
                    break;
            }
        }

        public void NewFile()
        {
            string fileName = "";
            string combinedPath = "";
            Validation validation = new Validation();
            Console.WriteLine("Currently testing mode this will only create a file within your desktop folder until a future update\n" +
                "Enter the type of file you want to create, more file type will be available later on\n" +
                "1. Text File\n" +
                "2. CSV File\n" +
                "3. JSON File\n" +
                "4. Markdown File");
            Console.Write("Input: ");
            int userAnswer = validation.NumberValidation(Console.ReadLine());
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            // try statement for handling errors 
            try
            {
                // switch statement for handling user input 
                switch (userAnswer)
                {
                    case 1: // Text Files
                        // ask for file name
                        fileName = FileNaming();
                        // combine users file name with txt to make a text file
                        string textFile = fileName + ".txt";
                        // combine file name and directory path 
                        combinedPath = Path.Combine(filePath, textFile);
                        // Create the file
                        FileCreate(combinedPath);
                        break;
                    case 2: // CSV Files
                        // ask for file name
                        fileName = FileNaming();
                        // combine file name with file extension
                        string csvFile = fileName + ".csv";
                        // combine file name and path
                        combinedPath = Path.Combine(filePath, csvFile);
                        // create file
                        FileCreate(combinedPath);
                        break;
                    case 3: // Json files
                        // Ask for file name
                        fileName = FileNaming();
                        // combine file name with file extension
                        string jsonFile = fileName + ".json";
                        // combine name and file path
                        combinedPath = Path.Combine(filePath, jsonFile);
                        // create file
                        FileCreate(combinedPath);
                        break;
                    case 4: // Markdown files
                        // Ask for file name
                        fileName = FileNaming();
                        // combine file name with file extension
                        string mdFile = fileName + ".md";
                        // combine file name with file path 
                        combinedPath = Path.Combine(filePath, mdFile);
                        // Create file
                        FileCreate(combinedPath);
                        break;
                    default:
                        Console.WriteLine("Enter a valid option");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        string FileNaming()
        {
            Validation validation = new Validation();
            Console.WriteLine("Enter the name for your file");
            string fileName = validation.InputValidation(Console.ReadLine());
            return fileName;
        }

        void FileCreate(string path)
        {
            // check if file already exist
            if (File.Exists(path))
            {
                Console.WriteLine("A file with that name already exist");
            }
            else
            {
                // create the file if it does not already exist
                File.Create(path).Close();
                Console.WriteLine("File created successfully.");
            }
        }

        public void FileDelete()
        {
            int amount = 0;
            int number = 0;
            string path = "";
            string[]? files = null;
            Validation validation = new Validation();
            Console.WriteLine("Select from one of the folders below\n" +
                "1. Desktop\n" +
                "2. Downloads\n" +
                "3. Documents");
            Console.Write("Input: ");
            int answer = validation.NumberValidation(Console.ReadLine());
            // switch statement for user input 
           try
            {
                switch (answer)
                {
                    case 1:
                        path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        files = Directory.GetFiles(path);
                        foreach (string file in files)
                        {
                            amount++;
                            Console.WriteLine($"{amount}. {Path.GetFileName(file)}");
                        }
                        Console.WriteLine("Enter the number for the file you wish to delete");
                        number = validation.NumberValidation(Console.ReadLine());
                        // Index starts at 0 so remove 1 from user input to match index
                        File.Delete(files[number - 1]);

                        break;
                    case 2:
                        path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                        files = Directory.GetFiles(path);
                        foreach (string file in files)
                        {
                            amount++;
                            Console.WriteLine($"{amount}. {Path.GetFileName(file)}");
                        }
                        Console.WriteLine("Enter the number for the file you wish to delete");
                        number = validation.NumberValidation(Console.ReadLine());
                        // Index starts at 0 so remove 1 from user input to match index
                        File.Delete(files[number - 1]);
                        break;
                    case 3:
                        path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        files = Directory.GetFiles(path);
                        foreach (string file in files)
                        {
                            amount++;
                            Console.WriteLine($"{amount}. {Path.GetFileName(file)}");
                        }
                        Console.WriteLine("Enter the number for the file you wish to delete");
                        number = validation.NumberValidation(Console.ReadLine());
                        // Index starts at 0 so remove 1 from user input to match index
                        File.Delete(files[number - 1]);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}