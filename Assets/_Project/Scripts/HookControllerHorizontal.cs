using UnityEngine;

public class HookControllerHorizontal : HookController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override float GetOrigin() {
        return transform.position.x;
    }
    protected override void UpdatePos() {
        Vector3 pos = transform.position;
        pos.x = origin + offset;
        transform.position = pos;
    }
}
