public class ShowProductDetailsMessage : IMessage {
	
	public string ItemName { get; set; }
	public ItemType ItemType { get; set; }
	public int Id { get; set; }
	public int SpriteIndex { get; set; }
	public float GreenScore { get; set; }
	public float Price { get; set; }
}
