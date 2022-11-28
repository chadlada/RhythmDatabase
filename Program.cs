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
 
 static void AddAlbumBand()
 {
var context = new RhythmContext();
Album newAlbum = new Album();

newAlbum.Title = PromptForString("What is the title of the album you want to add?");

Console.WriteLine("Is the album explicit? \n If Yes, type TRUE \n If not, type FALSE");
var isExplicitInput = Console.ReadLine().ToLower();
newAlbum.IsExplicit = bool.Parse(isExplicitInput);

Console.WriteLine("What is the release date of the album? \n Please format YYYY/MM/DD");
var newAlbumReleaseDate = Console.ReadLine();
var releaseDateInput = DateTime.Parse(newAlbumReleaseDate);

bool selectingBand = true;
var bandForAlbum = new Band();

while(selectingBand)
{
  var bandSelection = PromptForString("Type the name of the band you'd like to add then press ENTER: ");
  if(context.Bands.FirstOrDefault(band => band.Name == bandSelection) != null)
  {
    bandForAlbum = context.Bands.FirstOrDefault(band => band.Name == bandSelection);
    selectingBand = false;
  }
  else
  {
    Console.WriteLine("There is no band in the database by that name ");
    Console.WriteLine("Please try again");
  }

  newAlbum.BandId = bandForAlbum.Id;
  context.Albums.Add(newAlbum);
  context.SaveChanges();

  Console.WriteLine("\n Added To Database \n");
  Console.WriteLine("Press ENTER to return to main menu");
  var quitToMenu = Console.ReadLine();
  Console.Clear();



}


 }

static void AddSongToAlbum()
{
  var context = new RhythmContext();
  Song newSong = new Song();

  newSong.Title = PromptForString("What song would you like to add");
  newSong.TrackNumber = PromptForInteger("What is the track number of the song?");
  newSong.Duration = PromptForString("What is the duration of the song?");

  var selectingAlbum = true;
  var albumForSong = new Album();

  while(selectingAlbum)
  {
    var albumSelection = PromptForString("Which album would you like to add this song to?");

if(context.Albums.FirstOrDefault(album => album.Title == albumSelection) !=null)
{
  albumForSong = context.Albums.FirstOrDefault(album => album.Title == albumSelection);
  selectingAlbum = false;
}
else
{
  Console.WriteLine("There are no albums by that name. Try again. ");
}

  }

Console.WriteLine($"{newSong.Title} has been added to {albumForSong.Title}");
newSong.AlbumId = albumForSong.Id;
context.Songs.Add(newSong);
context.SaveChanges();

Console.WriteLine("Press ENTER to return to main menu");
var quiteToMenu = Console.ReadLine();
Console.Clear();

}

static void LetBandGo() 
{
  var context = new RhythmContext();
var selectingBand = true;
var selectingBandToRemove = new Band();

while(selectingBand)
{
  var bandToRemove = PromptForString("Which band would you like to remove from label?");

  if(context.Bands.FirstOrDefault(band => band.Name == bandToRemove) !=null)
  {
selectingBandToRemove = context.Bands.FirstOrDefault(band => band.Name == bandToRemove);
selectingBand = false;
  }
  else
  {
    Console.WriteLine("There is no band by that name. Please try again");
  }
}
selectingBandToRemove.IsSigned = false;
Console.WriteLine($"{selectingBandToRemove.Name} removed");
context.SaveChanges();
Console.WriteLine("Press ENTER to return to main menu");
var quitToMenu = Console.ReadLine();
Console.Clear();
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


var keepGoing = true;
while(keepGoing)
{
      var menuSelection = MenuChoice();
      switch(menuSelection)
      {
        case "1":
        AddBand();
        break;
        case "2":
        ViewAllBands();
        break;
        case "3":
        AddAlbumBand();
        break;
        case "4":
        AddSongToAlbum();
        break;
        case "5":
        LetBandGo();
        break;
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
}
