using AHKPresetCreator.Managers;
using System;

namespace AHKPresetCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Original X Coordinate: ");
            int originalX = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Original Y Coordinate: ");
            int originalY = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter New X Coordinate: ");
            int newX = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter New Y Coordinate: ");
            int newY = Convert.ToInt32(Console.ReadLine());

            var manager = new BuildScriptsManager();
            manager.BuildPresetScripts(originalX, originalY, newX, newY);
        }
    }
}
