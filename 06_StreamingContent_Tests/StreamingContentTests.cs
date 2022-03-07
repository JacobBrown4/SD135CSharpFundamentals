using _06_StreamingContent_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _06_StreamingContent_Tests
{
    [TestClass]
    public class StreamingContentTests
    {
        [TestMethod]
        public void SetTitle_ShouldGetCorrectString()
        {
            StreamingContent content = new StreamingContent();

            content.Title = "Toy Story";

            string expected = "Toy Story";
            string actual = content.Title;

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(MaturityRating.G,true)]
        [DataRow(MaturityRating.TV_PG,true)]
        [DataRow(MaturityRating.R,false)]
        [DataRow(MaturityRating.TV_MA,false)]
        public void SetMaturityRating_ShouldGetCorrectFamilyFriendliness(MaturityRating rating,bool expectedFamilyFriendly)
        {
            // Triple A paradigm a short hand for test setup

            // Arrange => set the stage
            StreamingContent content = new StreamingContent("Some title", "Some description", 5, rating, GenreType.Horror);
            // Act => executing any code you need
            bool actual = content.IsFamilyFriendly;
            bool expected = expectedFamilyFriendly;

            // Assert => call your assertions
            Assert.AreEqual(expected, actual);
        }
    }
}
