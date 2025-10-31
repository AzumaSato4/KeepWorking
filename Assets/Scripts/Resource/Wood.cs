using UnityEngine;

public class Wood : Resource
{
    private void Awake()
    {
        _productName = "Wood";
        type = ResourceType.wood;
    }

    public override void Initialize(int id)
    {
        //この製品で一意の任意のロジック
        gameObject.name = _productName;
    }
}
