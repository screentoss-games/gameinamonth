using System.Collections;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BlockManager))]
public class BlockManagerEditor : Editor {
	public override void OnInspectorGUI() {
		DrawDefaultInspector();

		BlockManager myScript = (BlockManager)target;
		if (GUILayout.Button("Build Object")) {
			// myScript.BuildObject();
		}
	}
}