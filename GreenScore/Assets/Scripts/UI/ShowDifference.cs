using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ShowDifference : MonoBehaviour{
	[SerializeField] private TextMeshProUGUI[] texts;
	[SerializeField] private GameObject[] redOverlays;
	private float[] stats;
	
	private void Awake(){
		stats = new float[]{0, 0};
		Broker.Subscribe<ShowProductDetailsMessage>(OnShowProductDetailsMessageReceived);
	}

	private void OnDisable(){
		Broker.Unsubscribe<ShowProductDetailsMessage>(OnShowProductDetailsMessageReceived);
	}
	private void OnShowProductDetailsMessageReceived(ShowProductDetailsMessage obj){
		if (obj.DisplayIndex == 0){
			stats[0] = obj.GreenScore;
			stats[1] = obj.Price;
		}
		else {
			stats[0] -= obj.GreenScore;
			stats[1] -= obj.Price;

			for (var i = 0; i < stats.Length; i++){
				if (stats[i] >= 0){
					texts[i].text = "-" + stats[i].ToString(CultureInfo.InvariantCulture);
				}
				else if (stats[i] == 0){
					texts[i].text = stats[i].ToString(CultureInfo.InvariantCulture);
				}
				else {
					redOverlays[i].SetActive(true);
					texts[i].text = "+" + (0 - stats[i]).ToString(CultureInfo.InvariantCulture);
				}
			}
		}
	}
}
