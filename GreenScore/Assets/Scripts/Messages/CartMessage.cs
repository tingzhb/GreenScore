using System.Collections.Generic;

public class CartMessage : IMessage{
	public List<ItemDetails> ItemDetailsList { get; set; }
}
