using _06_StreamingContent_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_StreamingContent_Console.UI
{
    public class ProgramUI
    {
        private readonly StreamingContentRepository _repo = new StreamingContentRepository();

        public void Run()
        {
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of the option you would like:\n" +
                    "1. Show all content\n" +
                    "2. Get content by title\n" +
                    "3. Get content by minimum star rating\n" +
                    "4. Add content to directory\n" +
                    "5. Update content in directory\n" +
                    "6. Remove content in directory\n" +
                    "7. Exit");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                    case "show":
                        ShowAllContent();
                        break;
                    case "2":
                        GetContentByTitle();
                        break;
                    case "3":
                        // GetContententByMinimumStarRating();
                        break;
                    case "4":
                        AddContent();
                        break;
                    case "5":
                        // UpdateContent();
                        break;
                    case "6":
                        // RemoveContent()
                        break;
                    case "7":
                    case "e":
                    case "exit":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 7. \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AddContent()
        {
            Console.Clear(); // Clear the menu
            // Set aside a variable to hold the information from the user until I'm ready
            StreamingContent content = new StreamingContent();

            // Title
            Console.Write("Please enter a title: ");
            content.Title = Console.ReadLine();

            // Description
            Console.Write("Please enter a description: ");
            content.Description = Console.ReadLine();

            // Stars
            Console.Write("Please enter a star rating 0-5: ");
            content.StarRating = double.Parse(Console.ReadLine());

            // Maturity Rating
            Console.WriteLine("Select maturity rating:\n" +
            "1.  G\n" +
            "2.  PG\n" +
            "3.  PG-13\n" +
            "4.  R\n" +
            "5.  NC 17\n" +
            "6.  TV Y\n" +
            "7.  TV G\n" +
            "8.  TV PG\n" +
            "9.  TV 14\n" +
            "10. TV MA");
            string maturityRating = Console.ReadLine();

            switch (maturityRating)
            {
                case "1":
                    content.MaturityRating = MaturityRating.G;
                    break;
                case "2":
                    content.MaturityRating = MaturityRating.PG;
                    break;
                case "3":
                    content.MaturityRating = MaturityRating.PG13;
                    break;
                case "4":
                    content.MaturityRating = MaturityRating.R;
                    break;
                case "5":
                    content.MaturityRating = MaturityRating.NC_17;
                    break;
                case "6":
                    content.MaturityRating = MaturityRating.TV_Y;
                    break;
                case "7":
                    content.MaturityRating = MaturityRating.TV_G;
                    break;
                case "8":
                    content.MaturityRating = MaturityRating.TV_PG;
                    break;
                case "9":
                    content.MaturityRating = MaturityRating.TV_14;
                    break;
                case "10":
                    content.MaturityRating = MaturityRating.TV_MA;
                    break;
            }
            // GenreType
            //  public enum GenreType { Horror = 1, Drama, Fantasy, Action, Comedy, SciFi, Romance, Bromance}
            Console.WriteLine("Select a Genre:\n" +
                "1. Horror\n" +
                "2. Drama\n" +
                "3. Fantasy\n" +
                "4. Action\n" +
                "5. Comedy\n" +
                "6. SciFi\n" +
                "7. Romance\n" +
                "8. Bromance");

            string genreInput = Console.ReadLine();

            int genreId = int.Parse(genreInput);
            // Casting
            content.GenreType = (GenreType)genreId;

            if (_repo.AddContentToDirectory(content))
            {
                Console.WriteLine("Success! Press anykey to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Failure! Press anykey to continue");
                Console.ReadKey();
            }
        }

        private void ShowAllContent()
        {
            Console.Clear();

            List<StreamingContent> listOfContent = _repo.GetContents();
            foreach (StreamingContent content in listOfContent)
            {
                DisplayContent(content);
            }

            AnyKey();
        }

        private void GetContentByTitle()
        {
            Console.Clear();
            // Prompt
            Console.Write("Enter a title: ");
            // Capture input
            string title = Console.ReadLine();
            // Look up content
            StreamingContent content = _repo.GetContentByTitle(title);
            if (content != null)
            {
                DisplayContent(content);
            }
            else
            {
                Console.WriteLine("Couldn't find content by that title");
            }
            AnyKey();
        }
        private void GetContententByMinimumStarRating()
        {
            Console.Clear();
            Console.Write("Please enter a minimum star rating: ");
            string ratingRaw = Console.ReadLine();
            double rating = double.Parse(ratingRaw);
            List<StreamingContent> listOfContent = _repo.GetByStarRatingByMinimum(rating);
            foreach(StreamingContent content in listOfContent)
            {
                DisplayContent(content);
            }
            AnyKey();
        }
        private void DisplayContent(StreamingContent content)
        {
            Console.WriteLine($"Title: {content.Title}\n" +
               $"Description: {content.Description}\n" +
               $"Genre: {content.GenreType}\n" +
               $"Maturity Rating: {content.MaturityRating}\n" +
               $"Star Rating: {content.StarRating} Stars\n");
        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }


}
