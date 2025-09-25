using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projects
{
    internal class File_System_Command_Line
    {
        /*
         
        1- This Class Must Containing the Run() Method Which is must Run this Class.
        2- This is list of Command you must implemented to allow to user to interact with the Files * Dirs
        3- the Basic Commmands are :  [ list - Info - remove - mkdir - display ] , Maybe Expanded
        4- Handle the Invalid Input from the User.
         
         list C:user:/spdfsd/dfkajsd/adsfkasdf
         */
        public void Run()
        {
            while(true)
            {
                try
                {
                    Console.Write(">>");
                    // including the Path and the Command itself. 
                    string totoal_command = Console.ReadLine().Trim();
                    if(!(totoal_command == "exit"))
                    {

                        string[] command_and_path = totoal_command.Split(' ');
                        string command = command_and_path[0].ToLower();
                        string path = command_and_path[1];
                        if (command_and_path.Length > 2)
                        {
                            throw new Exception("Write Only Two Statements Separted By White Space !");
                        }
                        if(command == "list")
                        {
                            if (Directory.Exists(path))
                            {
                                foreach(var dir in Directory.GetDirectories(path))
                                {
                                    Console.WriteLine($"<dir> {dir}");
                                }
                                foreach (var file in Directory.GetFiles(path))
                                {
                                    Console.WriteLine($"<file> {file}");
                                }
                            }
                            else
                            {
                                throw new Exception("Directory Doen Not Exist !");
                            }
                        }
                        else if(command == "mkdir")
                        {
                            if(!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                            else
                            {
                                throw new Exception("Directory Name is already Exist !");
                            }
                        }
                        else if(command == "remove")
                        {
                            Directory.Delete(path);
                        }
                        else if(command == "display")
                        {
                            if (Directory.Exists(path))
                            {
                                Console.WriteLine($"Creation Time = {Directory.GetCreationTime(path).ToString()}");
                                Console.WriteLine($"Last Access = {Directory.GetLastAccessTime}");
                            }
                            else if (File.Exists(path))
                            {
                                Console.WriteLine($"Creation Time = {File.GetCreationTime(path)}");
                                Console.WriteLine($"Last Write Time = {File.GetLastWriteTime(path)}");
                                Console.WriteLine($"Last Access Time = {File.GetLastAccessTime(path)}");
                            }
                            else
                            {
                                throw new Exception("File Or Folder you Want To Display is not Exist !");
                            }
                        }
                        else if(command == "print")
                        {
                            if(File.Exists(path))
                            {
                                FileInfo info = new FileInfo(path);
                                long len_inKB = ((info.Length)/1024);
                                string name_file = info.Name;
                                string parent = info.DirectoryName;
                                string date_of_creation = info.CreationTime.ToString();
                                Console.WriteLine($"The Name of The File is = {name_file}");
                                Console.WriteLine($"Directory Parent is = {parent}");
                                Console.WriteLine($"The Creation Time of The File = {date_of_creation}");
                                Console.WriteLine($"Size of The File = {len_inKB} KB");
                            }
                            else
                            {
                                throw new Exception("File Does Not Exist ! , Enter A valid path");
                            }
                        }
                        else
                        {
                            throw new Exception("Enter a Valid Command !");
                        }
                    }
                    else
                    {
                        break;
                    }
                } catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.WriteLine(ex.Message);
                }
                
            }
        }

    }
}
