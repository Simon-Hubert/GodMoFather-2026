using System;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private ObjectDatabase _database;
    [SerializeField] private Transform _conveyorBelt;
    public float _interval;

    private void Spawn(ObjectData data) {
        GameObject obj = Instantiate(data.prefab, _conveyorBelt, true);
        obj.transform.position = transform.position;
    }

    private void Start() {
        _ = SpawnObjectsAsync();
    }

    private async Awaitable SpawnObjectsAsync() {
        while (true) {
            Spawn(_database.GetRandomObject());
            await Awaitable.WaitForSecondsAsync(_interval);
        }
    }
}
