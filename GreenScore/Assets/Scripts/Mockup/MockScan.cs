using System.Collections;
using UnityEngine;

public class MockScan : MonoBehaviour{
	[SerializeField] private int scanCode;
	
	public void Scan(){
		ProductScannedMessage productScannedMessage = new(){ScannedData = scanCode};
		Broker.InvokeSubscribers(typeof(ProductScannedMessage), productScannedMessage);
		StartCoroutine(DelaySceneChange());
	}

	private IEnumerator DelaySceneChange(){
		yield return new WaitForSeconds(0.5f);
		SceneChangeMessage sceneChangeMessage = new(){NewSceneNumber = 1};
		Broker.InvokeSubscribers(typeof(SceneChangeMessage), sceneChangeMessage);
	}
}
