using _06_StreamingContent_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _06_StreamingContent_Tests
{
    [TestClass]
    public class StreamingContentRepositoryTests
    {
        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            // Arrange
            StreamingContent content = new StreamingContent();
            StreamingContentRepository repository = new StreamingContentRepository();
            // Act
            bool addResult = repository.AddContentToDirectory(content);
            // Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetDirecty_ShouldReturnCorrectCollection()
        {
            // Arrange
            StreamingContent content = new StreamingContent();
            StreamingContentRepository repository = new StreamingContentRepository();

            repository.AddContentToDirectory(content);
            // Act
            List<StreamingContent> contents = repository.GetContents();

            bool directoryHasContent = contents.Contains(content);

            // Assert
            Assert.IsTrue(directoryHasContent);
        }

        private StreamingContent _content;
        private StreamingContentRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new StreamingContentRepository();
            _content = new StreamingContent("Rubber", "A car tire comes to life with the power to make people explode and goes on a murderous rampage through the California desert.", 4.2, MaturityRating.R, GenreType.Horror);
            StreamingContent content = new StreamingContent("Toy Story", "Two plastic bros", 5, MaturityRating.G, GenreType.Bromance);
            _repo.AddContentToDirectory(_content);
            _repo.AddContentToDirectory(content);
        }

        [TestMethod]
        public void GetByTitle_ShouldReturnCorrectContent()
        {
            // Arrange
            // Test Initialize got me fam, it'll run before each TestMethod

            // Act
            StreamingContent searchResult = _repo.GetContentByTitle("Rubber");

            // Assert
            Assert.AreEqual(_content, searchResult);
        }
        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            // Arrange
            StreamingContent updatedContent = new StreamingContent("Rubber", "A car tire becomes sentient with the power to make people explode and goes on a murderous rampage through the California desert.", 4.8, MaturityRating.R, GenreType.Romance);
            // Act
            bool updateResult = _repo.UpdateExistingContent("Rubber", updatedContent);

            // Assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            // Arrange
            StreamingContent content = _repo.GetContentByTitle("Rubber");

            // Act
            bool removeResult = _repo.DeleteExistingContent(content);

            // Assert
            Assert.IsTrue(removeResult);
        }
    }
}
