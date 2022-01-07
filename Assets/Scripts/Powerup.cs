using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public new string name;
    public int percentageModifier;
    public Sprite image;
    [HideInInspector]
    public bool aquired;
}
