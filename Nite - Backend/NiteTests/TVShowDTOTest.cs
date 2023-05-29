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
        public void NameIsNullTest()
        {
            var show = new TVShowDTO()
            {
                Id = 1,
                Name = "",
                Year = 2011,
                Audience = "18+",
                Seasons = 8,
                Genre = "Drama",
                Status = "Ended",
                Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.",
                Streaming = "Netflix",
                Likes = 1024
            };

            var expected = true;

            if (string.IsNullOrEmpty(show.Name))
                expected = false;

            Assert.IsFalse(expected);
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