using UnityEngine;

public class GhostChaseStateBlinky : GhostChaseState
{
    protected override Vector3 GetTargetPosition()
    {
        return Ghost.target.transform.position;
    }
}
