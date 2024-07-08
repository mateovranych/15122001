namespace API.Models.DTOs.ResponseDTO
{
	public class ResponseDTO
	{
		public bool isSucces { get; set; } = true;

		public object Result { get; set; }

		public string DisplayMessage { get; set; }

		public List<string> ErrorsMessage { get; set; }
	}
}
