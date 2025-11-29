using UnityEngine;

public class GhostChaseStateInky : GhostChaseState
{
    public Ghost Blinky;
    private Pacman pacman;


    private void Start()
    {
        pacman = GameManager.Instance.pacman;
    }

    protected override Vector3 GetTargetPosition()
    {
        Vector3 pacmanPosition = Ghost.target.transform.position;

        if (Blinky == null)
        {
            return pacmanPosition;
        }
        Vector2 pacmanDirection = pacman.Movement.Direction;
        Vector3 offsetPosition = pacmanPosition + new Vector3(pacmanDirection.x, pacmanDirection.y, 0f) * 2f; // 2 units ahead of Pacman

        Vector3 blinkyPosition = Blinky.transform.position;
        Vector3 vectorToTarget = offsetPosition - blinkyPosition;   // the vector drawn from blinky to offsetPosition

        Vector3 finalTarget = blinkyPosition + (vectorToTarget * 2f);
        return finalTarget;
    }
}
