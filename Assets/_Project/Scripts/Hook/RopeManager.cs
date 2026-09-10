using UnityEngine;

public class RopeManager : MonoBehaviour
{
    [SerializeField] private Transform _endTransform;
    [SerializeField] private LineRenderer _lineRenderer;

    private void LateUpdate() {
    _lineRenderer.SetPositions(new []{transform.position, _endTransform.position});
    }
}
