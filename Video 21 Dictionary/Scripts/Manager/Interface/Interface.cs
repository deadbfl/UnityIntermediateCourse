public interface ISelectable
{
    public void Select();
    public void DeSelect();
}

public interface IInput
{
    public Inputs Type { get; set; }
}