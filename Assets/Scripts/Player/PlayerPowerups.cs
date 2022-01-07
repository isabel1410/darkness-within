using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerPowerups : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private PowerupsView powerupsView;

    [SerializeField]
    private Powerup[] powerups;

    public void GetSpeedMovementPowerup(int percentage)
    {
        Powerup powerup = powerups.Where(powerup => powerup.name == "SpeedMovementPowerup").First();
        if (!powerup.aquired)
        {
            powerup.aquired = true;
            playerMovement.AdjustMovementSpeedPercentage(percentage);
            powerupsView.UpdateView(powerups);
        }
    }
}
