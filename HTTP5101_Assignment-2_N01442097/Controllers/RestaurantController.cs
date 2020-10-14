using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5101_Assignment_2_N01442097.Controllers
{
    public class RestaurantController : ApiController
    {
        /// <summary>
        /// Calculate the calories according to the chosen menu items. 
        /// </summary>
        /// <param name="burger">choice of burger</param>
        /// <param name="drink">choice of drink</param>
        /// <param name="side">choice of side</param>
        /// <param name="dessert">choice of dessert</param>
        /// <returns>A string represeting, total number of calories found in the chosen from the menu</returns>
        /// <example>
        /// GET api/J1/Menu/4/4/4/4  ->
        /// "Your total calorie count is 0"
        /// </example>
        /// <example>
        /// GET api/J1/Menu/1/2/3/4 ->
        /// "Your total calorie count is 691"
        /// </example>
        [HttpGet]
        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        public string CalculateCalories(int burger, int drink, int side, int dessert)
        {
            // initialize a variable to calculate the total calories (should be increased according to the chosen item)
            int calorieCounter = 0;

            // calculate the calories in chosen burger
            switch (burger)
            {
                // 1 - Cheeseburger (461 Calories)
                case 1:
                    calorieCounter += 461;
                    break;

                // 2 - Fish Burger (431 Calories)
                case 2:
                    calorieCounter += 431;
                    break;

                // 3 - Veggie Burger (420 Calories)
                case 3:
                    calorieCounter += 420;
                    break;

                // default - no burger (0 Calories)
                default:
                    calorieCounter += 0;
                    break;
            }

            // calculate the calories in chosen drink
            switch (drink)
            {
                // 1 - Soft Drink (130 Calories)
                case 1:
                    calorieCounter += 130;
                    break;

                // 2 - Orange Juice (160 Calories)
                case 2:
                    calorieCounter += 160;
                    break;

                // 3 - Milk (118 Calories)
                case 3:
                    calorieCounter += 118;
                    break;

                // default - no drink (0 Calories)
                default:
                    calorieCounter += 0;
                    break;
            }

            // calculate the calories in chosen side
            switch (side)
            {
                // 1 - Fries (100 Calories)
                case 1:
                    calorieCounter += 100;
                    break;

                // 2 - Baked Potato (57 Calories)
                case 2:
                    calorieCounter += 57;
                    break;

                // 3 - Chef Salad (70 Calories)
                case 3:
                    calorieCounter += 70;
                    break;

                // default - no side order (0 Calories)
                default:
                    calorieCounter += 0;
                    break;
            }

            // calculate the calories in chosen dessert
            switch (dessert)
            {
                // 1 - Apple Pie (167 Calories)
                case 1:
                    calorieCounter += 167;
                    break;

                // 2 - Sundae (266 Calories)
                case 2:
                    calorieCounter += 266;
                    break;

                // 3 - Fruit Cup (75 Calories)
                case 3:
                    calorieCounter += 75;
                    break;

                // default - no dessert (0 Calories)
                default:
                    calorieCounter += 0;
                    break;
            }

            string response = $"Your total calorie count is {calorieCounter}";

            return response;

        }
    }
}
