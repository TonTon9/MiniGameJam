using UnityEngine;

public class Renamer : MonoBehaviour {
    [SerializeField]
    private GameObject[] _gameObjects;

    [ContextMenu("Renamge")]
    private void Renager() {
        foreach (var gameObject1 in _gameObjects) {
            gameObject1.name = $"mixamorig:{gameObject1.name}";
        }
    }
}
