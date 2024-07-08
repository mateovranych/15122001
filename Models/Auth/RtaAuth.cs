namespace API.Models.Auth
{
	public class RtaAuth
	{
		public RtaAuth(string token, bool esAdmin)
		{
			Token = token;
			EsAdmin = esAdmin;
		}

		public string Token { get; }

		public bool EsAdmin { get; }

	}
}
