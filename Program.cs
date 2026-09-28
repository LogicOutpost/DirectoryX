// Created by LogicOutpost
using System;
using System.IO;
namespace DirectoryX
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the validation class 
            Validation validation = new Validation();
            // create an instance of the file class
            FileOperations files = new FileOperations();
            // create an instance of directory class
            DirectoryOperations dirs = new DirectoryOperations();
            // keep program running while run program stays true
            bool runProgram = true;
            while (runProgram)
            {
                Console.WriteLine("Welcome to DirectoryX v1.0, select from the following options below.\n" +
                    "1. List Files\n" +
                    "2. List Directories\n" +
                    "3. Create Folder\n" +
                    "4. Create File\n" +
                    "5. Delete Folder\n" +
                    "6. Delete File\n" +
                    "7. Exit");
                Console.Write("Input: ");
                int input = validation.NumberValidation(Console.ReadLine());
                // switch statement for user input 
                switch (input)
                {
                    case 1:
                        files.ListFiles(); // files - List files
                        break;
                    case 2:
                        dirs.ScanDirectories(); // directory - list directories
                        break;
                    case 3:
                        dirs.NewDirectory(); // directory - new directory 
                        break;
                    case 4:
                        files.NewFile(); // files - new file
                        break;
                    case 5:
                        dirs.DeleteDirectory(); // still needs work
                        break;
                    case 6:
                        files.FileDelete(); // files - delete file
                        break;
                    case 7:
                        runProgram = false;
                        break;
                    default:
                        Console.WriteLine("Enter a valid option");
                        break;
                }
            }
        }
    }
}
