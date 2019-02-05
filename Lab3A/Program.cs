/*
  Class:  Media.cs
  Author: Arpit Patel
  Student ID: 000762465
  Date:   November 6, 2018

*/


using Lab3A;
/// <summary>
/// Purpose: This is the main class it contain the actual process of the program.
///          It is displaying menu and do process on that menus.
///          
/// </summary>


using System;
using System.Collections.Generic;
using System.IO;

namespace Lab3A
{
    class Program
    {


        /// <summary>
        /// main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;

            //media list for all objects
            List<Media> media = new List<Media>();

            // reas data from file and store in media list
            media = ReadEmployees("Data.txt");


            Boolean running = true; //  looping variable

            // loop for ask for everytime input 
            while (running)
            {

                try
                {

                    //Display menu 
                    Console.Clear();
                    Console.WriteLine("                               \n " +
                                      "\t=============================\n" +
                                      "\t     Media collection      \n" +
                                      "\t=============================\n");


                    Console.WriteLine("1. List All Books");
                    Console.WriteLine("2. List All Movies");
                    Console.WriteLine("3. List All Songs");
                    Console.WriteLine("4. List All Media");
                    Console.WriteLine("5. Search All Media by Title\n");
                    Console.WriteLine("6. Exit Program\n\n");


                    Console.WriteLine("Enter Choice: ");
                    //Console.CursorLeft = 21; // set curser 21 column left
                    //Console.CursorTop = 12;     // set cusrser at y position
                    int option = int.Parse(Console.ReadLine()); // Read character from user input.

                    Console.WriteLine(); // add a blank space

                    // switch fro the all opration logic
                    switch (option)
                    {
                        case 1:
                            // get book objects from media list
                            for (int i = 0; i < media.Count; i++)
                            {
                                if (media[i].GetType() == typeof(Book))
                                {
                                    Console.WriteLine(media[i]);
                                }
                            }

                            break;
                        case 2:
                            // get movie objects from media list
                            for (int i = 0; i < media.Count; i++)
                            {
                                if (media[i].GetType() == typeof(Movie))
                                {
                                    Console.WriteLine(media[i]);
                                }
                            }

                            break;
                        case 3:
                            // get song objects from media list
                            for (int i = 0; i < media.Count; i++)
                            {
                                if (media[i].GetType() == typeof(Song))
                                {
                                    Console.WriteLine(media[i]);
                                }
                            }
                            break;
                        case 4:
                            // ptint media objects
                            for (int i = 0; i < media.Count; i++)
                            {
                                Console.WriteLine(media[i]);
                            }

                            break;
                        case 5:
                            // search keyword in all media list
                            Console.WriteLine("Enter a search string");
                            string searchString = Console.ReadLine();
                            Console.WriteLine("\n\n");

                            for (int i = 0; i < media.Count; i++)
                            {
                                if (media[i].Search(searchString))
                                {
                                    Console.WriteLine(media[i]);
                                    if (media[i].GetType() == typeof(Book))
                                    {
                                        Book b = (Book)media[i];
                                        Console.WriteLine(b.Summary);
                                    }
                                    if (media[i].GetType() == typeof(Movie))
                                    {
                                        Movie m = (Movie)media[i];
                                        Console.WriteLine(m.Summary);
                                    }

                                    Console.WriteLine("\n");


                                }
                            }


                            break;
                        case 6:

                            running = false;

                            break;

                        default:
                            Console.WriteLine("Invalid option - please re-enter");
                            Console.WriteLine("Enter any key to continue.....");
                            break;
                    }

                    Console.WriteLine("\nEnter any key to continue.....");
                    Console.Write("\t");
                    Console.ReadKey(); // read key from keyboard
                }
                catch (Exception ex)
                {
                    Console.WriteLine("" + ex.Message);
                    Console.WriteLine("Enter any key to continue.....");
                    Console.ReadKey(); // move screen to next loop 

                }


            }

            Console.WriteLine("Bye Bye..");

            /// <summary>
            /// Read data from text file and return Employee data array 
            /// </summary>
            /// <param name="fileName"></param>
            /// <returns>employees</returns>
            List<Media> ReadEmployees(string fileName)
            {

                // exception handling filenotfound and general exception
                try
                {
                    // reader object for file read
                    StreamReader reader = new StreamReader(fileName);
                    // array to store data 
                    List<Media> medias = new List<Media>();
                    // count how many employee we have
                    //get text file data row and split by colon store into array
                    while (!reader.EndOfStream)
                    {

                        String lineRead = reader.ReadLine(); // read line
                        String[] fields = lineRead.Split('|'); 

                        // check book value in file 
                        if (fields[0] == "BOOK")
                        {
                            string summary = "";
                            string line;
                            while ((line = reader.ReadLine()) != "-----")
                            {
                                summary += line;
                            }
                            medias.Add(new Book(fields[1], int.Parse(fields[2]), fields[3], summary));
                        }

                        // check movie value in file
                        if (fields[0] == "MOVIE")
                        {
                            string summary = "";
                            string line;
                            while ((line = reader.ReadLine()) != "-----")
                            {
                                summary += line;
                            }
                            medias.Add(new Movie(fields[1], int.Parse(fields[2]), fields[3], summary));
                        }

                        // check the song value in file
                        if (fields[0] == "SONG")
                        {
                            //string summary = "";
                            //string line;
                            //while ((line = reader.ReadLine()) != "-----")
                            //{
                            //    summary += line;
                            //}
                            medias.Add(new Song(fields[1], int.Parse(fields[2]), fields[3], fields[4]));
                        }

                       


                    }
                    return medias;


                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine($"File not found {fileName}");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error Reading data ");
                }
                return null;

            }



        }
    }
}
