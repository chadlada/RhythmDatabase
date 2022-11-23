using System;

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

        static void AddBand()
        {
          var context = new RhythmContext();
          
            var name = PromptForString("Name of Band: ");
            var country = PromptForString("Country of Origin: ");
            var members = PromptForString("Number of Members: ");
            var website = PromptForString("Website: ");
            var genre = PromptForString("Genre: ");
            var signed = PromptForString("Are they signed?: ");
            var contactName = PromptForString("Contact Name ");
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
        
      }
   
    }
  }
}
