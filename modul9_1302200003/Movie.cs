namespace modul9_1302200003
{
    public class Movie
    {

        public string Title { get; set; }
        public string Director { get; set; }
        public List<string> Stars { get; set; }
        public String Description { get; set; }
        public Movie(string v1, string v2, List<string> stars2, string v3)
        {
            this.Title = v1;
            this.Director = v2;
            this.Stars = stars2;
            this.Description = v3;
        }



    }
}
