using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct ObjectData
{
    public GameObject prefab;
}

[CreateAssetMenu(fileName = "ObjectDatabase", menuName = "Scriptable Objects/ObjectDatabase")]
public class ObjectDatabase : ScriptableObject
{
    [SerializeField] private ObjectData[] _objectData;

    public bool TryGetObjectByID(int id, out ObjectData data) {
        if (id < 0 || id >= _objectData.Length) {
            data = new ObjectData();
            return false;
        }
        
        data = _objectData[id];
        return true;
    }

    public ObjectData GetRandomObject() {
        int rng = Random.Range(0, _objectData.Length);
        return _objectData[rng];
    }
}
