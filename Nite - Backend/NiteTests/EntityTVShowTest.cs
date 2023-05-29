using Nite.API.Data.Models;
using Nite.API.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiteTests
{
    [TestClass]
    public class EntityTVShowTest
    {
       
        [TestMethod]
        public void TVShowNotNullTest()
        {
            var show = new TVShow()
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
            var show = new TVShow()
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
            var show = new TVShow()
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
            var show = new TVShow()
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
            var show = new TVShow()
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
            var show = new TVShow()
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
            var show = new TVShow()
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
            var show = new TVShow()
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
            var show = new TVShow()
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
            var show = new TVShow()
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
            var show = new TVShow()
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
        public void NameIsNullTest()
        {
            var show = new TVShow()
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
        public void AudienceIsNullTest()
        {
            var show = new TVShow()
            {
                Id = 1,
                Name = "Game of Thrones",
                Year = 2011,
                Audience = "",
                Seasons = 8,
                Genre = "Drama",
                Status = "Ended",
                Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.",
                Streaming = "Netflix",
                Likes = 1024
            };

            var expected = true;

            if (string.IsNullOrEmpty(show.Audience))
                expected = false;

            Assert.IsFalse(expected);
        }


        [TestMethod]
        public void GenreIsNullTest()
        {
            var show = new TVShow()
            {
                Id = 1,
                Name = "Game of Thrones",
                Year = 2011,
                Audience = "18+",
                Seasons = 8,
                Genre = "",
                Status = "Ended",
                Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.",
                Streaming = "Netflix",
                Likes = 1024
            };

            var expected = true;

            if (string.IsNullOrEmpty(show.Genre))
                expected = false;

            Assert.IsFalse(expected);
        }


        [TestMethod]
        public void StatusIsNullTest()
        {
            var show = new TVShow()
            {
                Id = 1,
                Name = "Game of Thrones",
                Year = 2011,
                Audience = "18+",
                Seasons = 8,
                Genre = "Drama",
                Status = "",
                Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.",
                Streaming = "Netflix",
                Likes = 1024
            };

            var expected = true;

            if (string.IsNullOrEmpty(show.Status))
                expected = false;

            Assert.IsFalse(expected);
        }

        [TestMethod]
        public void DescriptionIsNullTest()
        {
            var show = new TVShow()
            {
                Id = 1,
                Name = "Game of Thrones",
                Year = 2011,
                Audience = "18+",
                Seasons = 8,
                Genre = "Drama",
                Status = "Ended",
                Description = "",
                Streaming = "Netflix",
                Likes = 1024
            };

            var expected = true;

            if (string.IsNullOrEmpty(show.Description))
                expected = false;

            Assert.IsFalse(expected);
        }

        [TestMethod]
        public void StreamingIsNullTest()
        {
            var show = new TVShow()
            {
                Id = 1,
                Name = "Game of Thrones",
                Year = 2011,
                Audience = "18+",
                Seasons = 8,
                Genre = "Drama",
                Status = "Ended",
                Description = "Nine noble families fight for control over the lands of Westeros, while an ancient enemy returns after being dormant for millennia.",
                Streaming = "",
                Likes = 1024
            };

            var expected = true;

            if (string.IsNullOrEmpty(show.Streaming))
                expected = false;

            Assert.IsFalse(expected);
        }
    }
}


    