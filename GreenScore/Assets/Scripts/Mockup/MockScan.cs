using System.Collections;
using UnityEngine;

public class MockScan : MonoBehaviour{
	public void Scan(){
		SceneChangeMessage sceneChangeMessage = new(){NewSceneNumber = 1};
		Broker.InvokeSubscribers(typeof(SceneChangeMessage), sceneChangeMessage);
		StartCoroutine(DelayLoad());
	}
	private IEnumerator DelayLoad(){
		yield return new WaitForSeconds(0.2f);
		ProductScannedMessage productScannedMessage = new(){ScannedData = Random.Range(0, 7)};
		Broker.InvokeSubscribers(typeof(ProductScannedMessage), productScannedMessage);
	}
}