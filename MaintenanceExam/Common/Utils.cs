namespace MaintenanceExam.Common
{
    public class Utils
    {
        public static readonly Random Random = new Random();

        /// <summary>
        /// Generates a random number within a specified range. NOTE: The maximumNumber is excluded, e.g. if you want a number between 1 and 10 use GenerateRandomNumber(1, 11).
        /// </summary>
        /// <param name="minimumNumber">The inclusive lower bound.</param>
        /// <param name="maximumNumber">The *exclusive* upper bound.</param>
        /// <returns>The generated random number.</returns>
        public static int GenerateRandomNumber(int minimumNumber, int maximumNumber)
        {
            return Random.Next(minimumNumber, maximumNumber);
        }

        /// <summary>
        /// Generates a random string given the desired length.
        /// </summary>
        /// <param name="length">The desired length of string.</param>
        /// <returns>The generated random string.</returns>
        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            return new string(Enumerable.Repeat(chars, length).Select(str => str[Random.Next(str.Length)]).ToArray());
        }
    }
}