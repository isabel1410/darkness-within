using UnityEngine;

public class PlayerSoulPoints : MonoBehaviour
{
    [SerializeField]
    private SoulPointView soulPointView;
    
    [SerializeField]
    private uint currentAmountOfSoulPoints;

    // Start is called before the first frame update
    private void Start()
    {
        SoulPoint.OnGetSoulPoints += OnGetSoulPoints;
        soulPointView.UpdateView(currentAmountOfSoulPoints);
    }

    private void OnGetSoulPoints()
    {
        soulPointView.UpdateView(++currentAmountOfSoulPoints);
    }
}
