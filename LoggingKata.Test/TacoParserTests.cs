using System;
using System.Runtime.InteropServices;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.518362, -87.7164, Taco Bell Russellvill...", -87.7164)]
        [InlineData("34.944183,-85.22637, Taco Bell Fort Oglethorp...", -85.22637)]
        [InlineData("34.437096,-85.750809, Taco Bell Fort Payn...", -85.750809)]
        [InlineData("30.416551,-86.607497, Taco Bell Fort Walton Beac...", -86.607497)]
        [InlineData("30.448367,-86.638431, Taco Bell Fort Walton Beach...", -86.638431)]
        [InlineData("34.007986,-85.983625, Taco Bell Gadsde..", -85.983625)]
        [InlineData("33.652223,-86.819279, Taco Bell Gardendal...", -86.819279)]
        [InlineData("31.046207,-85.893043, Taco Bell Geneva...", -85.893043)]
        [InlineData("31.835933,-86.630853, Taco Bell Greenville...", -86.630853)]
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
            var tacoParserTest = new TacoParser();

            //Act
            var actual = tacoParserTest.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.518362, -87.7164, Taco Bell Russellvill...", 34.518362)]
        [InlineData("34.944183,-85.22637, Taco Bell Fort Oglethorp...", 34.944183)]
        [InlineData("34.437096,-85.750809, Taco Bell Fort Payn...", 34.437096)]
        [InlineData("30.416551,-86.607497, Taco Bell Fort Walton Beac...", 30.416551)]
        [InlineData("30.448367,-86.638431, Taco Bell Fort Walton Beach...", 30.448367)]
        [InlineData("34.007986,-85.983625, Taco Bell Gadsde..", 34.007986)]
        [InlineData("33.652223,-86.819279, Taco Bell Gardendal...", 33.652223)]
        [InlineData("31.046207,-85.893043, Taco Bell Geneva...", 31.046207)]
        [InlineData("31.835933,-86.630853, Taco Bell Greenville...", 31.835933)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //TODO: Create a test ShouldParseLatitude

            //Arrange
            var tacoParserTest = new TacoParser();

            //Act
            var actual = tacoParserTest.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Latitude);
        }



    }
}
