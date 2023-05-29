using Nite.API.Data.Models;

namespace NiteTests
{
    [TestClass]
    public class TVShowDTOTest
    {
        [TestMethod]
        public void TVShowNotNullTest()
        {
            var show = new TVShowDTO()
            {
                Id = 1,
                Name = "Game of Thrones",
                Year = 2011,
                Audience = "18+",
                Seasons = 8,
                Genre = "Drama",
                Status = "Ended",
                Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.",
                Streaming = "Netflix",
                Likes = 1024
            };

            Assert.IsNotNull(show);
        }

        [TestMethod]
        public void IdTest()
        {
            var show = new TVShowDTO()
            {
                Id = 1,
                Name = "Game of Thrones",
                Year = 2011,
                Audience = "18+",
                Seasons = 8,
                Genre = "Drama",
                Status = "Ended",
                Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.",
                Streaming = "Netflix",
                Likes = 1024
            };

            var expected = 1;
            Assert.AreEqual(expected, show.Id);
        }

        [TestMethod]
        public void NameTest()
        {
            var show = new TVShowDTO()
            {
                Id = 1,
                Name = "Game of Thrones",
                Year = 2011,
                Audience = "18+",
                Seasons = 8,
                Genre = "Drama",
                Status = "Ended",
                Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.",
                Streaming = "Netflix",
                Likes = 1024
            };

            var expected = "Game of Thrones";

            Assert.AreEqual(expected, show.Name);
        }

        [TestMethod]
        public void YearTest()
        {
            var show = new TVShowDTO()
            {
                Id = 1,
                Name = "Game of Thrones",
                Year = 2011,
                Audience = "18+",
                Seasons = 8,
                Genre = "Drama",
                Status = "Ended",
                Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.",
                Streaming = "Netflix",
                Likes = 1024
            };

            var expected = 2011;

            Assert.AreEqual(expected, show.Year);
        }

        [TestMethod]
        public void AudienceTest()
        {
            var show = new TVShowDTO()
            {
                Id = 1,
                Name = "Game of Thrones",
                Year = 2011,
                Audience = "18+",
                Seasons = 8,
                Genre = "Drama",
                Status = "Ended",
                Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.",
                Streaming = "Netflix",
                Likes = 1024
            };

            var expected = "18+";

            Assert.AreEqual(expected, show.Audience);
        }

        [TestMethod]
        public void SeasonsTest()
        {
            var show = new TVShowDTO()
            {
                Id = 1,
                Name = "Game of Thrones",
                Year = 2011,
                Audience = "18+",
                Seasons = 8,
                Genre = "Drama",
                Status = "Ended",
                Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.",
                Streaming = "Netflix",
                Likes = 1024
            };

            var expected = 8;

            Assert.AreEqual(expected, show.Seasons);
        }


        [TestMethod]
        public void GenreTest()
        {
            var show = new TVShowDTO()
            {
                Id = 1,
                Name = "Game of Thrones",
                Year = 2011,
                Audience = "18+",
                Seasons = 8,
                Genre = "Drama",
                Status = "Ended",
                Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.",
                Streaming = "Netflix",
                Likes = 1024
            };

            var expected = "Drama";

            Assert.AreEqual(expected, show.Genre);
        }


        [TestMethod]
        public void StatusTest()
        {
            var show = new TVShowDTO()
            {
                Id = 1,
                Name = "Game of Thrones",
                Year = 2011,
                Audience = "18+",
                Seasons = 8,
                Genre = "Drama",
                Status = "Ended",
                Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.",
                Streaming = "Netflix",
                Likes = 1024
            };

            var expected = "Ended";

            Assert.AreEqual(expected, show.Status);
        }

        [TestMethod]
        public void DescriptionTest()
        {
            var show = new TVShowDTO()
            {
                Id = 1,
                Name = "Game of Thrones",
                Year = 2011,
                Audience = "18+",
                Seasons = 8,
                Genre = "Drama",
                Status = "Ended",
                Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.",
                Streaming = "Netflix",
                Likes = 1024
            };

            var expected = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.";

            Assert.AreEqual(expected, show.Description);
        }

        [TestMethod]
        public void StreamingTest()
        {
            var show = new TVShowDTO()
            {
                Id = 1,
                Name = "Game of Thrones",
                Year = 2011,
                Audience = "18+",
                Seasons = 8,
                Genre = "Drama",
                Status = "Ended",
                Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.",
                Streaming = "Netflix",
                Likes = 1024
            };

            var expected = "Netflix";

            Assert.AreEqual(expected, show.Streaming);
        }

        [TestMethod]
        public void LikesTest()
        {
            var show = new TVShowDTO()
            {
                Id = 1,
                Name = "Game of Thrones",
                Year = 2011,
                Audience = "18+",
                Seasons = 8,
                Genre = "Drama",
                Status = "Ended",
                Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.",
                Streaming = "Netflix",
                Likes = 1024
            };

            var expected = 1024;

            Assert.AreEqual(expected, show.Likes);
        }

        [TestMethod]
        public void DaysUntilNewSeasonTest()
        {
            var show = new TVShowDTO()
            {
                Id = 1,
                Name = "Game of Thrones",
                Year = 2011,
                Audience = "18+",
                Seasons = 8,
                Genre = "Drama",
                Status = "Ended",
                Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.",
                Streaming = "Netflix",
                Likes = 1024,
                NewSeason = "2023-06-01"
            };

            var expected = 3;

            Assert.AreEqual(expected, show.DaysUntilNewSeason);
        }
    }
}