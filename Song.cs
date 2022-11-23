namespace RhythmDatabase
{
    public class Song
    {
        public int Id { get; set; }
        public int TrackNumber { get; set; }
        public string Title { get; set; }
        public string duration { get; set; }
        public int AlbumId { get; set; }
        
        public Band Band { get; set; }
    }
}