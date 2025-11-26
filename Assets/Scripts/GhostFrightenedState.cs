using UnityEngine;

public class GhostFrightenedState : GhostBaseState
{
    public SpriteRenderer body;
    public SpriteRenderer eyes;
    public SpriteRenderer frightened;
    public SpriteRenderer frightenedExpiring;

    private SpriteAnimation backToNormalAnimation;

    public bool Eaten { get; private set; }

    private void Awake()
    {
        backToNormalAnimation = frightenedExpiring.GetComponent<SpriteAnimation>();
    }

    private void OnEnable()
    {
        Ghost.Movement.speedMultiplier = 0.5f;
        Eaten = false;
    }

    public override void Enable(float duration)
    {
        base.Enable(duration);

        body.enabled = false;
        eyes.enabled = false;
        frightened.enabled = true;
        frightenedExpiring.enabled = false;

        Invoke(nameof(Flash), duration / 2.0f);
    }

    private void Flash()
    {
        if (Eaten)
        {
            frightened.enabled = false;
            frightenedExpiring.enabled = true;
            backToNormalAnimation.Restart();
        }
    }

    public override void Disable()
    {
        base.Disable();
        frightened.enabled = false;
        frightenedExpiring.enabled = false;
        body.enabled = true;
        eyes.enabled = true;
    }

    private void OnDisable()
    {
        Ghost.Movement.speedMultiplier = 1.0f;
        Eaten = false;
    }
}
