using System.Linq.Expressions;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DR_music_records
{ 
    public class RecordsRepository
    {
        private List<Records> _data = new List<Records>();
        
        private int _nextId = 1;

        public RecordsRepository()
        {
            // Initialize with some sample records
            Add(new Records("Album 1", "Artist 1", 180, 2020));
            Add(new Records("Album 2", "Artist 2", 240, 2019));
            Add(new Records("Album 3", "Artist 3", 210, 2021));
            Add(new Records("Kiss", "Batman", 200, 2022));
        }

        public List<Records> GetAllRecords(string? title = null, string? artist = null)
        {
            List<Records> records = new(_data);
            if (title != null)
            {
                records = records.FindAll(record => record.Title.StartsWith(title));
            }
            if (artist != null)
            {
                records = records.FindAll(record => record.Artist.StartsWith(artist));
            }
                return records;
        }
        public Records? GetById(int id)
        {
            return _data.FirstOrDefault(r => r.Id == id);
        }
        public Records Add(Records record)
        {
            record.Id = _nextId++;
            _data.Add(record);
            return record;
        }
        public Records? Delete(int id)
        {
            Records? record = GetById(id);
            if (record != null)
            {
                _data.Remove(record);
            }
            return record;
        }
        public Records? Update (int id, Records data)
        {
            Records? record = GetById(id);
            if (record == null)
            {
                return null;
            }
            record.Artist = data.Artist;
            record.Title = data.Title;
            record.Duration = data.Duration;
            record.PublicationYear = data.PublicationYear;
            return record;
        }
    }
     }

