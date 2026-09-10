using UnityEngine;
using UnityEngine.InputSystem;

public class ScratchingController : MonoBehaviour
{
    [Header("Scrath Radius")]
    [SerializeField] private float _circleScratchRadius;

    [Header("Brush Intensity")]
    [SerializeField] private AnimationCurve _brushIntensity;


    // TEMP
    Vector3 _cursorPosition;


    void Update()
    {
        // TEMP
        _cursorPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        RaycastHit2D hit = Physics2D.Raycast(_cursorPosition, Vector2.down, 1f, LayerMask.GetMask("Item"));
        if (hit.collider != null)
        {
            Vector2 collidePosition = hit.transform.worldToLocalMatrix.MultiplyPoint(hit.point);
            hit.transform.gameObject.GetComponent<ItemTexture>();
        }
        
    }

}
