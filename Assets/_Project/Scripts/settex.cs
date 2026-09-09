using UnityEngine;

public class settex : MonoBehaviour
{
    [SerializeField] private ScratchingController _scratchController;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.SetTexture("_tex", _scratchController.Tex);
    }
}
