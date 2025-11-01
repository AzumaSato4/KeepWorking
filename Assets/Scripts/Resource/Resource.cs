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
    public string ProductName => _productName;
    ResourceType type;
    public ResourceType Type => type;
    public abstract void Initialize(int id);
}
