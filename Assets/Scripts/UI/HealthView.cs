using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{

    [SerializeField]
    private Image[] hearts;
    [SerializeField]
    private Sprite fullHeart;
    [SerializeField]
    private Sprite halfHeart;
    [SerializeField]
    private Sprite emptyHeart;


    public void UpdateView(float currentHealth)
    {
        for (int i = 0; i < 3; i++)
        {
            hearts[i].sprite = emptyHeart;
        }

        int counter = 0;
        for (counter = 0; counter < currentHealth / 2; counter++) // even
        {
            hearts[counter].sprite = fullHeart;
        }
        if (currentHealth % 2 == 1) //uneven
        {
            hearts[counter - 1].sprite = halfHeart;
        }





        //// checks for every half point of the current health
        //for (float i = 0; i < currentHealth / 2; i += 0.5f)
        //{
        //    // fill every full heart
        //    if (i % 1 == 0)
        //    {
        //        hearts[(int)(i)].GetComponent<Image>().sprite = fullHeart;
        //    }
        //    // fill every half heart
        //    else
        //    {
        //        hearts[Mathf.ToInt(i)].GetComponent<Image>().sprite = halfHeart;
        //    }
        //}
    }
}
