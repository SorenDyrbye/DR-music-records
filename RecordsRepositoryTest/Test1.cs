using DR_music_records;
namespace RecordsRepositoryTest
{
    [TestClass]
    public sealed class Test1
    {
        private RecordsRepository _repo = new RecordsRepository();

        [TestInitialize]
        public void TestInitialize()
        {
            _repo = new RecordsRepository();
        }


        [TestMethod]
        public void GetAllRecords_ReturnsCorrectCount()
        {
            // Arrange

            // Act
            var records = _repo.GetAllRecords();

            // Assert
            Assert.AreEqual(4, records.Count);
        }



        [TestMethod]
        public void GetAllRecords_FilterByTitle()
        {
            // Arrange
            string titleFilter = "A";
            // Act
            var records = _repo.GetAllRecords(title: titleFilter);
            // Assert
            Assert.AreEqual(3, records.Count);
        }

        [TestMethod]
        public void GetAllRecords_FilterByArtist()
        {
            // Arrange
            string artistFilter = "Artist";
            // Act
            var records = _repo.GetAllRecords(artist: artistFilter);
            // Assert
            Assert.AreEqual(3, records.Count);
        }


        [TestMethod]
        public void GetAllRecords_FilterByArtistNull()
        {
            // Arrange
            string artistFilter = null;
            // Act
            var records = _repo.GetAllRecords(artist: artistFilter);
            // Assert
            Assert.AreEqual(4, records.Count);
        }
    }
}

