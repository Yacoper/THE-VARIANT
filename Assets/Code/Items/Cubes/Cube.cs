public class Cube : PickUpAbleItem
{
    public BuffTypes BuffType
    {
        get => buffType;
        set => buffType = value;
    }
    
    private BuffTypes buffType;
}
