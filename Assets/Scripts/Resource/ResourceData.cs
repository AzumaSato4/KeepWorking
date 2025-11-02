public class ResourceData
{
    public string ProductName { get; }
    public Resource.ResourceType ResourceType { get; }

    public ResourceData(string productName, Resource.ResourceType resourceType)
    {
        ProductName = productName;
        ResourceType = resourceType;
    }
}
