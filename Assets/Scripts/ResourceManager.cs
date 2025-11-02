using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    Dictionary<Resource.ResourceType, int> _resourcePouch;
    public Dictionary<Resource.ResourceType, int> ResourcePouch => _resourcePouch;

    public void Initialize()
    {
        _resourcePouch = new Dictionary<Resource.ResourceType, int>();
        foreach (ResourceData item in CSVDataBase.resources)
        {
            _resourcePouch.Add(item.ResourceType, 0);
        }
    }

    public void InPouch(Resource.ResourceType item, int count)
    {
        _resourcePouch[item] += count;
        Debug.Log($"残り資材：{item},{_resourcePouch[item]}");
    }

    public void OutPouch(Resource.ResourceType item, int count)
    {
        _resourcePouch[item] -= count;
        Debug.Log($"残り資材：{item},{_resourcePouch[item]}");
    }
}
