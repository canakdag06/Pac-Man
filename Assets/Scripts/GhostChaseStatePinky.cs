using UnityEngine;

public class GhostChaseStatePinky : GhostChaseState
{
    protected override Vector3 GetTargetPosition()
    {
        Pacman pacman = GameManager.Instance.pacman;

        Vector3 targetPos = Ghost.target.transform.position;
        Vector2 forwardDirection = pacman.Movement.Direction;

        targetPos += new Vector3(forwardDirection.x, forwardDirection.y, 0f) * 4f;
        return targetPos;
    }
}
