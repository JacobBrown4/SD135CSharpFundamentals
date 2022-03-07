using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_StreamingContent_Repository
{
    public class StreamingContentRepository
    {
        // Simulated database essentially
        // Essentially private
        protected readonly List<StreamingContent> _contentDirectory = new List<StreamingContent>();

        // Repository pattern; A typical design pattern for accessing/using databases
        // CRUD Functionality; The standard functions you need
        
        // Create
        public bool AddContentToDirectory(StreamingContent content)
        {
            int startingCount = _contentDirectory.Count();
            _contentDirectory.Add(content);
            bool wasAdded = (_contentDirectory.Count() > startingCount) ? true : false;
            return wasAdded;
        }
        // Read
        public List<StreamingContent> GetContents()
        {
            return _contentDirectory;
        }

        public StreamingContent GetContentByTitle(string title)
        {
            foreach (StreamingContent content in _contentDirectory)
            {
                if (content.Title.ToLower() == title.ToLower())
                {
                    return content;
                }
            }
            return null; // Not best practice, typically you want to write an exception
        }
        public List<StreamingContent> GetFamilyFriendlyContent()
        {
            List<StreamingContent> familyFriendly = new List<StreamingContent>();
            foreach(StreamingContent content in _contentDirectory)
            {
                if (content.IsFamilyFriendly)
                {
                    familyFriendly.Add(content);
                }
            }
            return familyFriendly;
        }
        public List<StreamingContent> GetUnfamilyFriendlyContent()
        {
            List<StreamingContent> nonFamilyFriendly = new List<StreamingContent>();
            foreach (StreamingContent content in _contentDirectory)
            {
                if (!content.IsFamilyFriendly)
                {
                    nonFamilyFriendly.Add(content);
                }
            }
            return nonFamilyFriendly;
        }
        public List<StreamingContent> GetByStarRatingByMinimum(double minimumStarRating)
        {
            List<StreamingContent> starContent = new List<StreamingContent>();
            foreach(StreamingContent content in _contentDirectory)
            {
                if(content.StarRating >= minimumStarRating)
                {
                    starContent.Add(content);
                }
            }
            // LINQ order by
            return starContent.OrderBy(c=>c.StarRating).ToList();
        }

        // Update
        public bool UpdateExistingContent(string originalTitle, StreamingContent newContent)
        {
            StreamingContent oldContent = GetContentByTitle(originalTitle);
            if(oldContent != null)
            {
                oldContent.Title = newContent.Title;
                oldContent.Description = newContent.Description;
                oldContent.StarRating = newContent.StarRating;
                oldContent.MaturityRating = newContent.MaturityRating;
                oldContent.GenreType = newContent.GenreType;

                return true;
            }
            else
            {
                return false;
            }
        }
        
        // Delete
        public bool DeleteExistingContent(StreamingContent existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}
