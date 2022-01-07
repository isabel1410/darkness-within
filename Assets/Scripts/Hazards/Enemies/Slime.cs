using UnityEngine;

public class Slime : Enemy
{

    [SerializeField]
    private bool leaveCorruption;
    [SerializeField]
    private GameObject corruptionPuddlePrefab;

    public override void StartMovement()
    {
        base.StartMovement();
        LeaveCorruption();
    }

    private void LeaveCorruption()
    {
        if (!leaveCorruption)
        {
            return;
        }

        GameObject corruptionPuddle = Instantiate(corruptionPuddlePrefab);
        corruptionPuddle.transform.position = transform.position;
    }
}
