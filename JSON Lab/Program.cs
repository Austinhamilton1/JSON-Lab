using Microsoft.VisualBasic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSON_Lab
{
    class Program
    {
        public static void Main(string[] args)
        {
            var jsonFile = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.ToString()
                + $"{Path.DirectorySeparatorChar}Books{Path.DirectorySeparatorChar}";

            string[] files =
            {
                "crime_and_punishment.json",
                "the_shining.json",
                "beyond_good_and_evil.json",
                "catch_22.json",
                "the_metaphysics.json"
            };

            List<Book> books = new List<Book>();

            foreach (string filename in files)
            {
                using (var sr = new StreamReader(jsonFile + filename))
                {
                    string jsonString = string.Empty;
                    jsonString = sr.ReadToEnd();
                    books.Add(JsonSerializer.Deserialize<Book>(jsonString)!);
                }
            }

            books.Sort();

            foreach(Book book in books)
            {
                Console.WriteLine(book);
            }

            Book newBook = new Book
            {
                Id = "jafljIjaLI0",
                SelfLink = "https://www.googleapis.com/books/v894320/volumes/jafljIjaLI0",
                Information = new VolumeInfo
                {
                    Title = "Ishmael",
                    Authors = new List<string>(),
                    Description = "A man is down on his luck and stumbles across an ad in the newspaper" +
                    "saying there is a teacher looking for a pupil. He goes in for the ad only to find a" +
                    "gorilla. There is more to this gorilla than meets the eye, however, and the man" +
                    "embarks on an intellectually stimulating search for the soul."
                }
            };

            newBook.Information.Authors.Add("Daniel Quinn");

            string newJson = JsonSerializer.Serialize(newBook);
            using (var sw = new StreamWriter(jsonFile + "new_book.json"))
            {
                sw.Write(newJson);
            }



            Console.ReadLine();
        }
    }
}