﻿using _06_StreamingContent_Repository;
using _06_StreamingContent_Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_StreamingContent_Console.UI
{
    public class ProgramUI
    {
        private readonly ContentRepository _repo = new ContentRepository();

        public void Run()
        {
            SeedContentList(); // Adding some movies before we even start
            // Now do the program stuff
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
                    "2. Show all Movies\n" +
                    "3. Show all Tv Shows\n" +
                    "4. Get content by title\n" +
                    "5. Get content by minimum star rating\n" +
                    "6. Add content to directory\n" +
                    "7. Update content in directory\n" +
                    "8. Remove content in directory\n" +
                    "9. Exit");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                    case "show":
                        ShowAllContent();
                        break;
                    case "2":
                        ShowAllMovies();
                        break;
                    case "3":
                        ShowAllShows();
                        break;
                    case "4":
                        GetContentByTitle();
                        break;
                    case "5":
                        GetContententByMinimumStarRating();
                        break;
                    case "6":
                        AddContent();
                        break;
                    case "7":
                        UpdateContent();
                        break;
                    case "8":
                        RemoveContent();
                        break;
                    case "e":
                    case "9":
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
        // Read
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
        private void ShowAllMovies()
        {
            Console.Clear();

            List<Movie> listOfContent = _repo.GetAllMovies();
            foreach (Movie content in listOfContent)
            {
                DisplayContent(content);
            }
            AnyKey();
        }
        private void ShowAllShows()
        {
            Console.Clear();

            List<Show> listOfContent = _repo.GetAllShows();
            foreach (Show content in listOfContent)
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
            foreach (StreamingContent content in listOfContent)
            {
                DisplayContent(content);
            }
            AnyKey();
        }
        // Update
        private void UpdateContent()
        {
            Console.Clear();
            Console.Write("Please enter the title of \nthe movie you wish to update: ");
            StreamingContent oldContent = _repo.GetContentByTitle(Console.ReadLine());
            if (oldContent != null)
            {
                // Title
                Console.Write("Please enter a title: ");
                string titleInput = Console.ReadLine();
                if (titleInput != "")
                {
                    oldContent.Title = titleInput;
                }

                // Description
                Console.Write("Please enter a description: ");
                string descInput = Console.ReadLine();
                if (descInput != "")
                {
                    oldContent.Description = descInput;
                }

                // Stars
                Console.Write("Please enter a star rating 0-5: ");
                string starInput = Console.ReadLine();
                if (starInput != "")
                {
                    oldContent.StarRating = double.Parse(starInput);
                }

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

                if (maturityRating != "")
                {

                    switch (maturityRating)
                    {
                        case "1":
                            oldContent.MaturityRating = MaturityRating.G;
                            break;
                        case "2":
                            oldContent.MaturityRating = MaturityRating.PG;
                            break;
                        case "3":
                            oldContent.MaturityRating = MaturityRating.PG13;
                            break;
                        case "4":
                            oldContent.MaturityRating = MaturityRating.R;
                            break;
                        case "5":
                            oldContent.MaturityRating = MaturityRating.NC_17;
                            break;
                        case "6":
                            oldContent.MaturityRating = MaturityRating.TV_Y;
                            break;
                        case "7":
                            oldContent.MaturityRating = MaturityRating.TV_G;
                            break;
                        case "8":
                            oldContent.MaturityRating = MaturityRating.TV_PG;
                            break;
                        case "9":
                            oldContent.MaturityRating = MaturityRating.TV_14;
                            break;
                        case "10":
                            oldContent.MaturityRating = MaturityRating.TV_MA;
                            break;
                    }
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
                if (genreInput != "")
                {
                    int genreId = int.Parse(genreInput);
                    // Casting
                    oldContent.GenreType = (GenreType)genreId;
                }


            }
            else
                Console.WriteLine("No content by that title found");
            AnyKey();
        }
        // Delete
        private void RemoveContent()
        {
            Console.Clear();

            List<StreamingContent> contentList = _repo.GetContents();
            int count = 0;

            foreach (StreamingContent content in contentList)
            {
                count++;
                Console.WriteLine($"{count}. {content.Title}");
            }
            Console.Write("What content do you want to remove: ");
            int targetId = int.Parse(Console.ReadLine());
            int targetIndex = targetId - 1;
            if (targetIndex >= 0 && targetIndex < contentList.Count())
            {
                StreamingContent desiredContent = contentList[targetIndex];

                if (_repo.DeleteExistingContent(desiredContent))
                {
                    Console.WriteLine($"{desiredContent.Title} deleted successfully");
                }
                else
                    Console.WriteLine("Something went wrong.");
            }
            else
                Console.WriteLine("No content has that ID");

            AnyKey();
        }

        private void SeedContentList()
        {
            Movie toyStory = new Movie("Toy Story", "Two plastic bros trauma bond", 5, MaturityRating.PG, GenreType.Bromance, 120, 1994);
            Movie starWars = new Movie("Star Wars", "Space samurai discover science", 4.3, MaturityRating.PG13, GenreType.SciFi, 120, 1976);
            Movie dune = new Movie("Dune", "Big ass worms and space coke", 5, MaturityRating.R, GenreType.SciFi, 175, 2021);

            Episode episode1 = new Episode("The Gang Gets Racist", 22, 1, 1);
            Episode episode2 = new Episode("Charlie has cancer", 22, 1, 2);
            Episode episode3 = new Episode("Underage drinking a national problem", 22, 1, 3);
            Episode episode4 = new Episode("The Gang does a thing", 22, 10, 1);

            Show always = new Show("Always Sunny", "Four drunks yell at each other", 5, MaturityRating.TV_MA, GenreType.Comedy,15,new List<Episode>() { episode3,episode4,episode2,episode1});

            _repo.AddContentToDirectory(toyStory);
            _repo.AddContentToDirectory(starWars);
            _repo.AddContentToDirectory(dune);
            _repo.AddContentToDirectory(always);
        }

        private void DisplayContent(StreamingContent content)
        {
            Console.WriteLine($"Title: {content.Title}\n" +
               $"Description: {content.Description}\n" +
               $"Genre: {content.GenreType}\n" +
               $"Maturity Rating: {content.MaturityRating}\n" +
               $"Star Rating: {content.StarRating} Stars");
            if (content is Movie)
            {
                Console.WriteLine($"Runtime {((Movie)content).RunTime}\n" +
                    $"Year: {((Movie)content).Year}");
            }
            else if (content is Show)
            {
                Show show = content as Show;
                Console.WriteLine($"Average Run Time: {show.AverageRunTime}\n" +
                    $"Number of Season: {show.NumberOfSeasons}\n");
                foreach (Episode ep in show.Episodes.OrderBy(s => s.SeasonNumber).ThenBy(e => e.EpisodeNumber))
                {
                    Console.WriteLine($"    {ep.SeasonNumber.ToString("00")}x{ep.EpisodeNumber.ToString("00")} {ep.Title}");
                }
            }
            Console.WriteLine();
        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }


}
