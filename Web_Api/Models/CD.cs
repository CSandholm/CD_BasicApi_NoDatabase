namespace Web_Api.Models
{
	public class CD
	{
		public int Id { get; set; }
		public string Title { get; set; }

		public string Artist { get; set; }
		public CD(int id, string title, string artist) 
		{ 
			Id = id;
			Title = title;
			Artist = artist;
		}
	}
}
