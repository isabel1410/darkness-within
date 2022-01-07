using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoulPoints : MonoBehaviour
{
    [SerializeField]
    private SoulPointView soulPointView;
    
    [SerializeField]
    private uint currentAmountOfSoulPoints;

    // Start is called before the first frame update
    void Start()
    {
        SoulPoint.OnGetSoulPoints += OnGetSoulPoints;
        currentAmountOfSoulPoints = 0;
        soulPointView.UpdateView(currentAmountOfSoulPoints);
    }

    private void OnGetSoulPoints(uint reward)
    {
        currentAmountOfSoulPoints += reward;
        soulPointView.UpdateView(currentAmountOfSoulPoints);
    }
}
