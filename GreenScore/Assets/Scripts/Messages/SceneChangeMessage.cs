public class SceneChangeMessage : IMessage {
	public int NewSceneNumber { get; set; }
	public int CurrentSceneNumber{ get; set; }
}
