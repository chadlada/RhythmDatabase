using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RhythmDatabase
{
  class Program
  {

        static string PromptForString(string prompt)
        {
            Console.WriteLine(prompt);
            var userInput = Console.ReadLine();
            return userInput;
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }
        static void AddBand()
        {
          var context = new RhythmContext();
          Band newBand = new Band();

          

            newBand.Name = PromptForString("Name of Band: ");
            newBand.CountryOfOrigin = PromptForString("Country of Origin: ");
            newBand.NumberOfMembers = PromptForInteger("Number of Members: ");
            newBand.Website = PromptForString("Website: ");
            newBand.Genre = PromptForString("Genre: ");
            Console.Write("\nIf the band is signed, type 'true' then press ENTER\nor\nIf the band isn't signed, type false then press ENTER: ");
            var isSignedInput = Console.ReadLine().ToLower();
            newBand.IsSigned = bool.Parse(isSignedInput);
            newBand.ContactName = PromptForString("Contact Name ");

            context.Bands.Add(newBand);
            context.SaveChanges();
        }

static void ViewAllBands()
{
  var context = new RhythmContext();

  foreach(var band in context.Bands)
  {
    Console.WriteLine($"\n{band.Name}\n");
  }
}

static string MenuChoice()
{
            Console.WriteLine("Choose an option:");
            Console.WriteLine("");
            Console.WriteLine("[1] Add a band");
            Console.WriteLine("[2] View All Bands");
            Console.WriteLine("[3] Add an Album for a Band");
            Console.WriteLine("[4] Add a Song to an Album");
            Console.WriteLine("[5] Let a Band Go");
            Console.WriteLine("[6] Resign a Band");
            Console.WriteLine("[7] View all albums from a band");
            Console.WriteLine("[8] View all Bands that are signed");
            Console.WriteLine("[9] View all Band that are not signed");
            Console.WriteLine("[10] View all Band that are not signed");
            Console.WriteLine("[11] Quit");

            var choice = Console.ReadLine().ToUpper();
            return choice;
}



    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to Rhythm Records!!!");
      Console.WriteLine("");
      Console.WriteLine("");
      // MenuChoice();

      var menuSelection = MenuChoice();
      switch(menuSelection)
      {
        case "1":
        AddBand();
        break;
        case "2":
        ViewAllBands();
        break;
        // case "3":
        // AddBand();
        // break;
        // case "4":
        // AddBand();
        // break;
        // case "5":
        // AddBand();
        // break;
        // case "6":
        // AddBand();
        // break;
        // case "7":
        // AddBand();
        // break;
        // case "8":
        // AddBand();
        // break;
        // case "9":
        // AddBand();
        // break;
        // case "10":
        // AddBand();
        // break;
        // case "11":
        // AddBand();
        // break;
        
      }
   
    }
  }
}
