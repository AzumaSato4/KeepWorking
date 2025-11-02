using UnityEngine;

public class ArrowFactory : Factory
{
    [SerializeField] Arrow _productPrefab;
    float _scale;

    public void GenerateArrow(Vector3 spot, float scale)
    {
        _scale = scale;
        GetProduct(spot);
    }

    public override IProduct GetProduct(Vector3 position)
    {
        // プレハブインスタンスを作成して製品コンポーネントを取得する
        GameObject instance = Instantiate(_productPrefab.gameObject, position, Quaternion.identity);
        instance.transform.localScale = new Vector3(_scale, 1, 1);
        Arrow newProduct = instance.GetComponent<Arrow>();
        // 各製品に独自のロジックが含まれる
        newProduct.Initialize(0);
        return newProduct;
    }
}
