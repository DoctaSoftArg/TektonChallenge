namespace Challenge.Api.Properties.Helpers
{
	public static class ProductStatusDictionary
	{
		public static readonly Dictionary<int, string> Statuses = new Dictionary<int, string>
		{
			{ 1, "Active" },
			{ 0, "Inactive" }
		};
	}

}
