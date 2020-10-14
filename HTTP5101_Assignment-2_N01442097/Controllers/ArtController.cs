using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5101_Assignment_2_N01442097.Controllers
{
    public class ArtController : ApiController
    {
        /// <summary>
        /// Determining the smallest possible rectangular frame(coordinates) such that each drop(coordinates) of the paint lies inside the frame.
        /// results would show the two non-negative integers separated by a single comma (no spaces). The first line represents the coordinates of 
        /// the bottom-left corner of the rectangular frame. The second line represents the coordinates of the top-right corner of the rectangular frame.
        /// Question : CCC 2020 Junior - Art (J3)
        /// J3 Question Link: https://cemc.math.uwaterloo.ca/contests/computing/2020/ccc/juniorEF.pdf
        /// </summary>
        /// <param name="coordinates">a string of comma seperated coordinates, first value is x second value is y. Coordinates should be pairs,
        ///  total coordinate count cannot be odd number</param>
        /// <returns>The first line represents the coordinates of the bottom-left corner of the rectangular frame. 
        /// The second line represents the coordinates of the top-right corner of the rectangular frame.</returns>
        /// <example>
        /// GET api/J3/Art/44,62,34,69,24,78,42,44,64,10  ->
        /// "Coordinates of Bottom-Left Corner: 23,9"
        /// "Coordinates of Top-Right Corner: 65,79"
        /// </example>
        /// <example>
        /// GET api/J3/Art/30,12,28,25,10,8,30,14,6,20 ->
        /// "Coordinates of Bottom-Left Corner: 5,7"
        /// "Coordinates of Top-Right Corner: 31,26"
        /// </example>
        /// <example>
        /// -----Coordinates that's missing pairs (uneven number of coordinates - 11 coordinates)
        /// GET api/J3/Art/30,12,28,25,10,8,30,14,6,20,11 ->
        /// "Invalid coordinates"
        /// </example>
        /// <example>
        /// -----Coordinates containing not numbers
        /// GET api/J3/Art/30,12,28,25,10,8,30,14,a,b ->
        /// "Invalid coordinates"
        /// </example>
        [HttpGet]
        [Route("api/J3/Art/{coordinates}")]
        public IEnumerable<string> GetCoordinates(string coordinates)
        {
            // split by comma and seprate the coordinates into an array
            string[] allCoordinates = coordinates.Split(',');

            // check coordinates are in pair
            if (allCoordinates.Length % 2 == 0)
            {

                // Lists to hold separated coordinates x and y
                List<int> xCoordinates = new List<int>();
                List<int> yCoordinates = new List<int>();

                // separate the x & y coordinates by looping thorugh allCoordinates
                for (int i = 0; i < allCoordinates.Length; i++)
                {
                    // if any non integer is found show invalid message
                    if (!int.TryParse(allCoordinates[i], out _))
                    {
                        return new string[] {
                            "Invalid coordinates"
                        };
                    }
                    else
                    {
                        /* if the index is an even number store that value as x-coordinate,
                            because in a pair of coordinates the first value represents the x,
                            since arrays are 0 based, the index holding first number is an even number
                         */
                        if (i % 2 == 0)
                        {
                            // index is even number: x-coordinate - add the value to xCoordinates List
                            xCoordinates.Add(int.Parse(allCoordinates[i]));
                        }
                        else
                        /* if the index is an odd number store that value as y-coordinate,
                            because in a pair of coordinates the second value represents the y,
                            since arrays are 0 based, the index holding second number is a odd number
                         */
                        {
                            // index is odd number: x-coordinate - add the value to yCoordinates List
                            yCoordinates.Add(int.Parse(allCoordinates[i]));
                        }
                    }
                }

                // function to get the Bottom-Left Coordinates
                string getBottomLeftCoordinates()
                {
                    /*
                     The lowest x and y coordinates would give us the bottom-left coordinates of the art
                     Since we need the bottom-left coordinates of the frame that covers around the drop art,
                     we can -1 from each of the values in the pair to get the bottom-left coordinates of the frame.
                     */
                    int xValue = xCoordinates.Min() - 1;
                    int yValue = yCoordinates.Min() - 1;

                    string bottomLeftCoorValues = $"{xValue},{yValue}";

                    return bottomLeftCoorValues;
                }

                // function to get the Top-Right Coordinates
                string getTopRightCoordinates()
                {
                    /*
                     The highest x and y coordinates would give us the top-right coordinates of the art
                     Since we need the top-right coordinates of the frame that covers around the drop art,
                     we can +1 to each of the values in the pair to get the top-right coordinates of the frame.
                     */
                    int xValue = xCoordinates.Max() + 1;
                    int yValue = yCoordinates.Max() + 1;

                    string topRightCoorValues = $"{xValue},{yValue}";

                    return topRightCoorValues;
                }

                // get the Bottom-Left Coordinates from the function(getBottomLeftCoordinates) and store that to a variable
                string bottomLeftCoordinates = getBottomLeftCoordinates();
                // get the Top-Right Coordinates from the function(getTopRightCoordinates) and store that to a variable
                string topRightCoordinates = getTopRightCoordinates();

                // returns the bottom left and top right coordinates of the frame
                return new string[] {
                $"Coordinates of Bottom-Left Corner: {bottomLeftCoordinates}",
                $"Coordinates of Top-Right Corner: {topRightCoordinates}"
            };
            }
            else
            // return invalid coordinates, as coordinates are not in pair
            {
                return new string[] {
                    "Invalid coordinates"
                };
            }
        }
    }
}
