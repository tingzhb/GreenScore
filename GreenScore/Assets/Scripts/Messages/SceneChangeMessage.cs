using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeMessage : IMessage {
	public int SceneNumber { get; set; }
}
