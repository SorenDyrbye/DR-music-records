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
            Assert.AreEqual(3, records.Count);
        }
    }
}
