using UnityEngine;

public class Pacman : MonoBehaviour
{
    [SerializeField] private SpriteAnimation deathSequence;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider;
    public Movement Movement { get; private set; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        Movement = GetComponent<Movement>();
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
        Movement.ResetState();
    }
}
