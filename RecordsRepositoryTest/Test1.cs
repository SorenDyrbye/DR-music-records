using DR_music_records;
using DR_music_records.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


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

        [TestMethod]
        public void Test_Adding_Record()
        {
            //arrange
            var newRecord = new Records("New Album", "New Artist", 300, 2023);
            var newRecord2 = new Records("New Album 2", "New Artist 2", 250, 2024);

            //act
            _repo.Add(newRecord);
            _repo.Add(newRecord2);

            //assert
            var checkRecord = newRecord;
            Assert.AreEqual(5, checkRecord.Id);
            Assert.AreEqual("New Album", checkRecord.Title);
            Assert.AreEqual("New Artist", checkRecord.Artist);
            Assert.AreEqual(300, checkRecord.Duration);
            Assert.AreEqual(2023, checkRecord.PublicationYear);

            var checkRecord2 = newRecord2;
            Assert.AreEqual(6, checkRecord2.Id);
            Assert.AreEqual("New Album 2", checkRecord2.Title);
            Assert.AreEqual("New Artist 2", checkRecord2.Artist);
            Assert.AreEqual(250, checkRecord2.Duration);
            Assert.AreEqual(2024, checkRecord2.PublicationYear);

        }
        [TestMethod]
        public void Test_GetById()
        {
            // Arrange
            
            // Act
            var record = _repo.GetById(2);
            // Assert
            
            Assert.AreEqual(2, record.Id);
        }

        [TestMethod]
        public void Test_Delete_Record()
        {
            // Arrange
            int idToDelete = 3;
            // Act
            var deletedRecord = _repo.Delete(idToDelete);
            // Assert
           Assert.AreEqual(3, deletedRecord.Id);
           Assert.AreEqual(3, _repo.GetAllRecords().Count);

        }

        [TestMethod]
        public void Test_Update_Record()
        {
            // Arrange
            int idToUpdate = 1;
            var updatedData = new Records("Updated Album", "Updated Artist", 220, 2025);
            // Act
            var updatedRecord = _repo.Update(idToUpdate, updatedData);
            // Assert
            Assert.AreEqual(idToUpdate, updatedRecord.Id);
            Assert.AreEqual("Updated Album", updatedRecord.Title);
            Assert.AreEqual("Updated Artist", updatedRecord.Artist);
            Assert.AreEqual(220, updatedRecord.Duration);
            Assert.AreEqual(2025, updatedRecord.PublicationYear);
        }
    }
}

