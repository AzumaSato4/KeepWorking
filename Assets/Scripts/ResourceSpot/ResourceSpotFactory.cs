using UnityEngine;

public class ResourceSpotFactory : Factory
{
    [SerializeField] ResourceSpot[] _productPrefab;
    [SerializeField] float _maxRightSpown = 35;
    [SerializeField] float _maxLeftSpown = 35;

    public void GenerateSpots()
    {
        float rand = Random.Range(-_maxLeftSpown, _maxRightSpown);
        Vector3 spownSpot = new Vector3(rand, 0, 0);
        GetProduct(spownSpot);
    }

    public override IProduct GetProduct(Vector3 position)
    {
        int rand = Random.Range(0, _productPrefab.Length);
        // プレハブインスタンスを作成して製品コンポーネントを取得する
        GameObject instance = Instantiate(_productPrefab[rand].gameObject,
       position, Quaternion.identity);
        ResourceSpot newProduct = instance.GetComponent<ResourceSpot>();
        // 各製品に独自のロジックが含まれる
        newProduct.Initialize(rand);
        return newProduct;
    }
}
