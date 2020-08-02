using AHKPresetCreator.Managers;
using System;

namespace AHKPresetCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            var userContinue = "y";
            string effect;

            while(userContinue.ToLower() == "y")
            {
                Console.WriteLine("What kind of script do you want to make?\n" +
                    "Enter 1 for Preset\n" +
                    "Enter 2 for Favorite\n" +
                    "Enter 3 for Stream Deck Preset\n" +
                    "Enter 4 for Stream Deck Favorite");

                int scriptType = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Original X Coordinate: ");
                int originalX = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Original Y Coordinate: ");
                int originalY = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter New X Coordinate: ");
                int newX = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter New Y Coordinate: ");
                int newY = Convert.ToInt32(Console.ReadLine());

                var manager = new BuildScriptsManager();

                switch (scriptType)
                {
                    case 1:
                        manager.BuildPresetScript(originalX, originalY, newX, newY);
                        break;
                    case 2:
                        manager.BuildFavoriteScript(originalX, originalY, newX, newY);
                        break;
                    case 3:
                        Console.WriteLine("Enter the effect you want:");
                        effect = Console.ReadLine();
                        manager.BuildStreamDeckPresetScript(originalX, originalY, newX, newY, effect);
                        break;
                    case 4:
                        Console.WriteLine("Enter the effect you want:");
                        effect = Console.ReadLine();
                        manager.BuildStreamDeckFavoriteScript(originalX, originalY, newX, newY, effect);
                        break;
                    default:
                        Console.WriteLine("You entered an invalid choice.");
                        break;
                }

                Console.WriteLine("Would you like to make another script? (Y/N)");

                userContinue = Console.ReadLine();
            }
        }
    }
}
