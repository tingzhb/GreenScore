
using UnityEngine;

[CreateAssetMenu]
public class ItemDetails : ScriptableObject{
	public string itemName;
	public ItemType itemType;
	public int id, spriteIndex;
	public float greenScore, price;
}
