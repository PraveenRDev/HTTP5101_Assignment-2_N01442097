using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5101_Assignment_2_N01442097.Controllers
{
    public class DiceGameController : ApiController
    {
        /// <summary>
        /// Determines how many ways 2 dices with {m} and {n} number of faces can roll the value 10 
        /// </summary>
        /// <param name="m">number of faces in dice 1</param>
        /// <param name="n">number of faces in dice 2</param>
        /// <returns>string, representing the number of ways a sum of 10 can be obtained</returns>
        /// <example>
        /// GET api/J2/DiceGame/6/8  ->
        /// "There are 4 ways to get the sum 10."
        /// </example>
        /// <example>
        /// GET api/J2/DiceGame/12/4 ->
        /// "There are 4 ways to get the sum 10."
        /// </example>
        /// <example>
        /// GET api/J2/DiceGame/3/3 ->
        /// "There are 0 ways to get the sum 10."
        /// </example>
        /// <example>
        /// GET api/J2/Dicegame/5/5 ->
        /// "There is 1 way to get the sum 10."
        /// </example>
        /// <example>
        /// GET api/J2/Dicegame/-5/0 ->
        /// "Invalid Input"
        /// </example>
        [HttpGet]
        [Route("api/J2/DiceGame/{m}/{n}")]
        public string CalculateDiceSumOfTen(int m, int n)
        {
            if (m <= 0 || n <= 0)
            {
                return "Invalid Input - Dice cannot contain negative or 0 number of faces.";
            }
            else
            {
                // initialize a variable to calculate the number of sum of 10s (should be increased when a sum of 10 is found)
                int sumTenCounter = 0;

                /*
                    Nested for-loop is used, so the first loop would go through each face of the first dice and the
                    second loop would go through each face of second dice,
                    for each face in first dice, we go through all the faces in second dice,
                    when the sum of the face in first dice and second dice equates 10
                    sumTenCounter is increased by 1
                 */
                for (int i = 1; i <= m; i++)
                {
                    for (int j = 1; j <= n; j++)
                    {
                        if ((i + j) == 10)
                        {
                            sumTenCounter++;
                        }
                    }
                }

                string response = $"There {(sumTenCounter == 1 ? "is" : "are")} {sumTenCounter} way{(sumTenCounter == 1 ? "" : "s")} to get the sum 10.";

                return response;
            }
        }
    }
}
