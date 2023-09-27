using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyDecimalLibrary
{
    public class DeweyDecimalManager
    {

        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to generate the author part of the Dewey Decimal
        /// </summary>
        /// <param name="dewyRandom"></param>
        /// <param name="authorLength"></param>
        /// <returns></returns>
        //source: https://chat.openai.com/share/fb07dba1-4993-46f3-beea-3607ea018bac
        public String GenerateRandomAuthor(Random dewyRandom, int authorLength)
        {
            //possible characters for the random author value
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            //character collction to hold the random author value
            char[] authorChars = new char[authorLength]; //set the size to the given parameter

            //loop until an author is generated to the length of the given parameter
            for (int i = 0; i < authorLength; i++)
            {
                //set the current character in the author value to the randomly picked alphabetical character
                authorChars[i] = alphabet[dewyRandom.Next(alphabet.Length)];
            }

            //return the randomly generated author value as a string
            return new string(authorChars);

        }
        //------------------------------------------------------------------------------------------------------------------


        //------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to generate a random dewey decimal
        /// </summary>
        /// <param name="authorLength"></param>
        /// <returns></returns>
        //source: https://chat.openai.com/share/1765476c-69b1-4e50-a66f-fd9efc287769
        public String GenerateDeweyDecimal(int authorLength)
        {
            //random value object
            Random randomPart = new Random();

            //generate the random dewey decimal category
            int dewyCategory = randomPart.Next(0, 1000); // Random category between 0 and 999
            //generate the random dewey decimal sub category
            int dewySubCategory = randomPart.Next(0, 1000); // Random subcategory between 0 and 999

            // Format the Dewey Decimal System number with leading zeros
            //format the category
            string formattedDewyCategory = dewyCategory.ToString("D3");
            //format the sub category
            string formattedDewySubCategory = dewySubCategory.ToString("D3");

            //generate the author from the random author generation method
            string dewyAuthor = GenerateRandomAuthor(randomPart, authorLength); //pass the random value object and the length of the author value

            // Combine the category and subcategory with a decimal point
            string deweyDecimal = $"{formattedDewyCategory}.{formattedDewySubCategory} {dewyAuthor}";

            //return the full dewey decimal value
            return deweyDecimal;

        }
        //------------------------------------------------------------------------------------------------------------------



    }
}
