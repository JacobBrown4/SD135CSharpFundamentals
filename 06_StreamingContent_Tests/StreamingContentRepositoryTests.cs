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
    }
}
