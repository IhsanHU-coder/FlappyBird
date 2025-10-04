using UnityEngine;

public class LoopGround : MonoBehaviour
{
    [SerializeField] float _speed = 1.3f;
    [SerializeField] float _width = 6f;

    private SpriteRenderer _spriteRenderer;

    private Vector2 _startSize;

    private bool canMove = false;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _startSize = new Vector2(_spriteRenderer.size.x, _spriteRenderer.size.y);
    }

    public void CanMove()
    {
        canMove = true;
    }

    private void Update()
    {
        if (!canMove) return;

        _spriteRenderer.size = new Vector2(_spriteRenderer.size.x + _speed * Time.deltaTime, _spriteRenderer.size.y);

        if (_spriteRenderer.size.x > _width)
        {
            _spriteRenderer.size = _startSize;
        }
    }
}
