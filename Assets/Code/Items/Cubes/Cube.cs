using UnityEngine;

public class Cube : PickUpAbleItem
{
    public BuffTypes BuffType
    {
        get => buffType;
        set => buffType = value;
    }
    
    [SerializeField] private BuffTypes buffType;
}
