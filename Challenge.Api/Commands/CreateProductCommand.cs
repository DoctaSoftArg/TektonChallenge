﻿namespace Challenge.Api.Commands
{
	public class CreateProductCommand
	{
		public string? Name { get; set; }
		public string? StatusName { get; set; }
		public int? Stock { get; set; }
		public string? Description { get; set; }
		public decimal? Price { get; set; }
		public decimal? Discount { get; set; }
		public decimal? FinalPrice { get; set; }
	}

}
