using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private float speed;
    
    void Update() {
        transform.position += Vector3.right * (speed * Time.deltaTime);
    }
}
