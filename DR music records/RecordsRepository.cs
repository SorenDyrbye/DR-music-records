using System.Linq.Expressions;

namespace DR_music_records
{
    public class RecordsRepository
    {
        private List<Records> _records = new List<Records>();
        
        private int _nextId = 1;

        public RecordsRepository()
        {
            // Initialize with some sample records
            _records.Add(new Records("Album 1", "Artist 1", 180, 2020));
            _records.Add(new Records("Album 2", "Artist 2", 240, 2019));
            _records.Add(new Records("Album 3", "Artist 3", 210, 2021));
        }

        public List<Records> GetAllRecords()
        {
            return new List<Records>(_records);
        }
    }
}
