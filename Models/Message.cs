using System;
namespace Minitwit7.Models
{
	public class Message
	{
		public int MessageId { get; set; }
		public int AuthorId { get; set; }
		public string text { get; set; } = "";
		public int PubDate { get; set; }
		public int Flagged { get; set; }
	}
}

