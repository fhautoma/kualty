using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Dynamic;
using TechChallenge.Utils;
using Newtonsoft.Json;

namespace TechChallenge.Providers
{
    /// <summary>
    /// The random data provider.
    /// </summary>
    public static class PersonDataProvider
    {

        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Random person data method.
        /// </summary>
        /// <returns>Deserialized Json object that cointains person information.</returns>
        public static T PersonData<T>()
        {

            string endPoint = new Constants().MockarooEndPoint;
            string jsonString = null;
            try
            {
                var response = client.GetStringAsync(new Uri(endPoint)).Result;

                if (response is not null)
                {
                    jsonString = response;
                }
                else
                {
                    jsonString = LocalRandomData();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                jsonString = LocalRandomData();
            }
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        /// <summary>
        /// Locals the random data.
        /// </summary>
        /// <returns>A T.</returns>
        public static string LocalRandomData()
        {
            Random rnd = new Random();
            string[] names = { "Rufus", "Bear", "Dakota", "Fido", "Vanya", "Samuel", "Koani", "Volodya", "Prince", "Yiska" };
            string[] lastNames = { "Maggie", "Penny", "Saya", "Princess", "Abby", "Laila", "Sadie", "Olivia", "Starlight", "Talla" };
            string postalCode = "";
            dynamic person = new ExpandoObject();

            var name = $"{names[rnd.Next(names.Length)]}";
            var lastName = $"{lastNames[rnd.Next(lastNames.Length)]}";
            var email = $"{name}{lastName}{rnd.Next(1000)}@autom{rnd.Next(1000)}.com".ToLower();
            for (int i = 0; i < 6; i++)
            {
                postalCode = String.Concat(postalCode, rnd.Next(7).ToString());
            }
            person.FirstName = name;
            person.LastName = lastName;
            person.PostalCode = postalCode;

            return JsonConvert.SerializeObject(person);
        }

    }
}

