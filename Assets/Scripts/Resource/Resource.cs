using UnityEngine;

public abstract class Resource : MonoBehaviour, IProduct
{
    public enum ResourceType
    {
        wood,
        stone,
        gold
    }

    protected string _productName;
    public string ProductName { get => _productName; }
    protected ResourceType type;
    public ResourceType Type { get => type; }

    public abstract void Initialize(int id);
}
