namespace DR_music_records
{
    public class Records
    {
        public int id { get; set; }
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public int Duration { get; set; } // in seconds
        public int PublicationYear { get; set; }

        public Records(string title, string artist, int duration, int publicationYear)
        {
            Title = title;
            Artist = artist;
            Duration = duration;
            PublicationYear = publicationYear;
        }
    }
}
