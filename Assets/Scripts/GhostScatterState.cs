using UnityEngine;

public class GhostScatterState : GhostBaseState
{
    [SerializeField] private Transform corner;
    public Transform Corner => corner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();

        if (enabled && node != null)
        {
            Vector2 direction = Vector2.zero;
            float minDistance = float.MaxValue;

            foreach (Vector2 dir in node.AvailableDirections)
            {
                if (dir == -Ghost.Movement.Direction)
                {
                    continue;
                }

                Vector3 newPosition = transform.position + new Vector3(dir.x, dir.y, 0.0f);
                float distance = (corner.position - newPosition).sqrMagnitude;

                if (distance < minDistance)
                {
                    direction = dir;
                    minDistance = distance;
                }
            }
            Ghost.Movement.SetDirection(direction);
        }
    }

    public override void Disable()
    {
        base.Disable();

        if (Ghost.FrightenedState.enabled)
        {
            return;
        }

        Ghost.ChaseState.Enable();
    }
}
