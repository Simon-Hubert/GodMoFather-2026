using UnityEngine;

public class ConveyorUI : MonoBehaviour
{
    // ----- Variables -----
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _endPosition;

    public float _speed;

    private void Update()
    {
        if (transform.position.x >= _endPosition.x)
        {
            transform.position = _startPosition;
        }

        transform.position += new Vector3(_speed * Time.deltaTime, 0, 0);
    }
}
