using System.Linq;
using UnityEngine;

public class RopeManager : MonoBehaviour
{

    private struct VerletNode
    {
        public Vector2 position;
        public Vector2 lastPosition;
    }

    private VerletNode[] _nodes = new VerletNode[7];

    [SerializeField] private Transform _endTransform;
    [SerializeField] private float _gravity;
    [SerializeField] private float _length;
    [SerializeField] private int _iterationCounts;
    [SerializeField] private LineRenderer _lineRenderer;

    public void CalculatePositions() {
        for (int i = 0; i < this._nodes.Length; i++)
        {
            VerletNode currNode = _nodes[i];
            Vector2 newPreviousPosition = currNode.position;

            _nodes[i].position = (2 * currNode.position) - currNode.lastPosition +
                                        (Vector2.down * _gravity * Mathf.Pow(Time.fixedDeltaTime, 2));
            _nodes[i].lastPosition = newPreviousPosition;
        }
    }
    
    private void FixNodeDistances()    //Applying constraints
    {
        _nodes[0].position = transform.position;
        _nodes[^1].position = _endTransform.position;
        
        for (int i = 0; i < _nodes.Length - 1; i++)
        {
            var n1 = _nodes[i];
            var n2 = _nodes[i + 1]; 
            
            var d1 = n1.position - n2.position;
            var d2 = d1.magnitude; 
            var d3 = (d2 - _length) / d2;

            _nodes[i].position -= (d1 * (0.5f * d3));
            _nodes[i + 1].position += (d1 * (0.5f * d3));
        }
    }
    
    private void FixedUpdate()
    {
        CalculatePositions(); //Verlet simulation

        for (int i = 0; i < _iterationCounts; i++)
        {
            FixNodeDistances(); //Applying constraints
        }

        RenderLine();
    }
    
    
    private void RenderLine() {
        _lineRenderer.SetPositions(_nodes.Select(e =>
        {
            Debug.Log((Vector3)e.position);
            return (Vector3)e.position;
        }).ToArray());
    }
}
