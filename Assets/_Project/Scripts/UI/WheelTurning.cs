using UnityEngine;

public class WheelTurning : MonoBehaviour
{
    void Update()
    {
        transform.rotation = transform.localRotation * Quaternion.Euler(0, 0, -90 * Time.deltaTime);
    }
}
