using UnityEngine;

public class ItemTexture : MonoBehaviour
{
    // ----- Variables -----
    private SpriteRenderer _spriteRenderer;
    public SpriteRenderer SpriteRender => _spriteRenderer;

    private Texture2D _texture;
    public Texture2D Texture => _texture;

    private BoxCollider2D _boxCollider;


    private MeasureScratchCompletion _measureScratchCompletion;


    // ----- Functions -----
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _measureScratchCompletion = GetComponent<MeasureScratchCompletion>();
    }

    private void Start()
    {
        MakeTexture();
        SetCollider();
    }

    // ----- Custom Functions -----

    public void SetSprite(Sprite sprite)
    {
        if (sprite == null) return;

        _spriteRenderer.sprite = sprite;
        MakeTexture();
        SetCollider();

        _measureScratchCompletion.ResetCompletion();
    }

    private void MakeTexture()
    {
        Vector3 startingPoint = Camera.main.WorldToScreenPoint(_spriteRenderer.bounds.min);
        Vector3 endingPoint = Camera.main.WorldToScreenPoint(_spriteRenderer.bounds.max);

        int width = Mathf.FloorToInt(endingPoint.x - startingPoint.x);
        int height = Mathf.FloorToInt(endingPoint.y - startingPoint.y);

        _texture = new Texture2D(width, height);
        _texture.wrapMode = TextureWrapMode.Clamp;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                _texture.SetPixel(i, j, Color.black);
            }
        }
        _texture.Apply();

        _spriteRenderer.material.SetTexture("_tex", _texture);
    }

    private void SetCollider()
    {
        //Mettre le Collider à la bonne taille
        float width = _spriteRenderer.bounds.max.x - _spriteRenderer.bounds.min.x;
        float height = _spriteRenderer.bounds.max.y - _spriteRenderer.bounds.min.y;


        _boxCollider.size = new Vector2(width / transform.localScale.x, height / transform.localScale.x);
    }

}
