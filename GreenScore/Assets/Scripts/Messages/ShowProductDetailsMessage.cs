public class ShowProductDetailsMessage : IMessage {
	
	public int DisplayIndex { get; set; }
	public string ItemName { get; set; }
	public string Address { get; set; }
	public string PlaceName { get; set; }
	public ItemType ItemType { get; set; }
	public int Id { get; set; }
	public int SpriteIndex { get; set; }
	public float GreenScore { get; set; }
	public float Price { get; set; }
	public float WPrice { get; set; }
}
