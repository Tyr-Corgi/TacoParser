using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Data;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two parserBells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath); //THis creates an Array of the CSV file. 

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse).ToArray;
            var locations = lines.Select(parser.Parse).ToArray();

            //DO NOT CHANGE ANYTHING ABOVE!!!!

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // Loop through all combinations of parserBell locations
            //ITrackable tacoBell1 = null;
            //ITrackable tacoBell2 = null;
            //double totalDistance = 0;

            /* start of my code
            foreach (var num1 in locations)
            {
                var location1 = new GeoCoordinate(num1.Location.Latitude, num1.Location.Latitude);
                foreach (var num2 in locations)
                {
                    if (num1 == num2) continue;
                    var location2 = new GeoCoordinate(num2.Location.Longitude, num2.Location.Longitude);
                    double distanceBetween = location1.GetDistanceTo(location2);
                    if (distanceBetween > totalDistance)
                    {
                        totalDistance = distanceBetween;
                        tacoBell1 = num1;
                        tacoBell2 = num2;
                    }
                }
            }
            end of my code  */

            ITrackable tacoBell3 = new TacoBell();
            ITrackable tacoBell4 = new TacoBell();

            var distance = 0.0;



            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two parserbells that are the farthest from each other.
            // Create a `double` variable to store the distance


            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)

            for (var i = 0; i < locations.Length; i++)

            {
                var locA = locations[i];
                // Create a new corA Coordinate with your locA's lat and long
                var corA = new GeoCoordinate();
                corA.Latitude = locA.Location.Latitude;
                corA.Longitude = locA.Location.Longitude;

                for (var j = 0 ; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate()
                    {
                        Latitude = locB.Location.Latitude,
                        Longitude = locB.Location.Longitude
                    };

                    var currentDistance = corA.GetDistanceTo(corB);

                    if (currentDistance > distance)
                    {
                        distance = currentDistance;
                        tacoBell3 = locA;
                        tacoBell4 = locB;
                    }
                    
                }
            }


            // Create a new Coordinate with your tacoBell2's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            //double distanceBetween = location1.GetdistanceTo(location2);

            // Once you've looped through everything, you've found the two parserBells farthest away from each other.


            /*my code
            Console.WriteLine($"The two parserBells that are the furthest from one another are:");
            Console.WriteLine($"{tacoBell1.Name} at ({tacoBell1.Location.Latitude}, {tacoBell1.Location.Longitude}) and");
            Console.WriteLine($"{tacoBell2.Name} at ({tacoBell2.Location.Latitude}, {tacoBell2.Location.Longitude})");
            */

            Console.WriteLine($"The two parserBells that are the furthest from one another are:");
            Console.WriteLine($"\n{tacoBell3.Name} and ({tacoBell3.Location.Latitude}, {tacoBell3.Location.Longitude}) and");
            Console.WriteLine($"{tacoBell4.Name} at ({tacoBell4.Location.Latitude}, {tacoBell4.Location.Longitude})");
            Console.WriteLine($"They are {Math.Round(distance *.00062,2)} miles apart");




        }

    }
}
