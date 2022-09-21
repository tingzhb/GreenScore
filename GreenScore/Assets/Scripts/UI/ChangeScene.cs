using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour{
	[SerializeField] private int newSceneNumber, currentSceneNumber;

	public void Change(){
		SceneChangeMessage sceneChangeMessage = new(){NewSceneNumber = newSceneNumber, CurrentSceneNumber = currentSceneNumber};
		Broker.InvokeSubscribers(typeof(SceneChangeMessage), sceneChangeMessage);
	}
}
