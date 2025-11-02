using UnityEngine;

public class BombFactory : Factory
{
    [SerializeField] Bomb[] _productPrefab;
    float _scale;

    public void GenerateBomb(Vector3 spot, float scale)
    {
        _scale = scale;
        GetProduct(spot);
    }

    public override IProduct GetProduct(Vector3 position)
    {
        Resource.ResourceType type = Resource.ResourceType.wood;
        if (GameManager.resourceManager.ResourcePouch[Resource.ResourceType.stone] > 0)
        {
            type = Resource.ResourceType.stone;
        }
        if (GameManager.resourceManager.ResourcePouch[Resource.ResourceType.gold] > 0)
        {
            type = Resource.ResourceType.gold;
        }
        GameManager.resourceManager.ResourcePouch[type]--;
        // プレハブインスタンスを作成して製品コンポーネントを取得する
        GameObject instance = Instantiate(_productPrefab[(int)type].gameObject, position, Quaternion.identity);
        instance.transform.localScale = new Vector3(_scale, Mathf.Abs(_scale), 1);
        Bomb newProduct = instance.GetComponent<Bomb>();
        // 各製品に独自のロジックが含まれる
        newProduct.Initialize((int)type);
        return newProduct;
    }
}
