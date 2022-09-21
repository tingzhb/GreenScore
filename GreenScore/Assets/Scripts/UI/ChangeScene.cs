using UnityEngine;

public class ChangeScene : MonoBehaviour{
	[SerializeField] private int nextSceneNumber;
	
	public void Change(){
		SceneChangeMessage sceneChangeMessage = new(){SceneNumber = nextSceneNumber};
		Broker.InvokeSubscribers(typeof(SceneChangeMessage), sceneChangeMessage);
	}
}
