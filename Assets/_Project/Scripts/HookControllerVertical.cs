using UnityEngine;

public class HookControllerVertical : HookController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override float GetOrigin() {
        return transform.position.y;
    }
    protected override void UpdatePos() {
        Vector3 pos = transform.position;
        pos.y = origin + offset;
        transform.position = pos;
    }
}
