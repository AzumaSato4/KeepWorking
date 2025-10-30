using UnityEngine;

public class ConcreteFactoryWood : Factory
{
    [SerializeField] Wood _productPrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetProduct(transform.position);
        }
    }

    public override IProduct GetProduct(Vector3 position)
    {
        // プレハブインスタンスを作成して製品コンポーネントを取得する
        GameObject instance = Instantiate(_productPrefab.gameObject,
       position, Quaternion.identity);
        Wood newProduct = instance.GetComponent<Wood>();
        // 各製品に独自のロジックが含まれる
        newProduct.Initialize();
        return newProduct;
    }
}
