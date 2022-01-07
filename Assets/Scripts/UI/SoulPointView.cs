using UnityEngine;
using UnityEngine.UI;

public class SoulPointView : MonoBehaviour
{
    [SerializeField]
    private Text soulPointText;

    public void UpdateView(uint currentAmountOfSoulPoints)
    {
        soulPointText.text = currentAmountOfSoulPoints.ToString();
    }
}
