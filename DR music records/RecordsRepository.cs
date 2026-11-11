using System.Linq.Expressions;

namespace DR_music_records
{ 
    public class RecordsRepository
    {
        private List<Records> _data = new List<Records>();
        
        private int _nextId = 1;

        public RecordsRepository()
        {
            // Initialize with some sample records
            _data.Add(new Records("Album 1", "Artist 1", 180, 2020));
            _data.Add(new Records("Album 2", "Artist 2", 240, 2019));
            _data.Add(new Records("Album 3", "Artist 3", 210, 2021));
            _data.Add(new Records("Kiss", "Batman", 200, 2022));
        }

        public List<Records> GetAllRecords(string title = null, string artist = null)
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
            //if (sortBy != null)
            //{
            //    switch (sortBy)
            //    {
            //        case "title":
            //            records = records.OrderBy(r => r.Title).ToList();
            //            break;
            //        case "artist":
            //            records = records.OrderBy(r => r.Artist).ToList();
            //            break;
            //        case "year":
            //            records = records.OrderBy(r => r.PublicationYear).ToList();
            //            break;
            //    }
            return records;
        }
            

        }
     }

