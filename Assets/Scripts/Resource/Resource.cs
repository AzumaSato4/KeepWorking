using UnityEngine;

public abstract class Resource : MonoBehaviour, IProduct
{
    public enum ResourceType
    {
        wood,
        stone,
        gold
    }

    string _productName;
    ResourceType type;
    public string ProductName => _productName;
    public ResourceType Type => type;
    public abstract void Initialize(int id);
}
