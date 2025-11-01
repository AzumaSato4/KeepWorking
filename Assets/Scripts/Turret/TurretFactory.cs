using UnityEngine;

public class TurretFactory : Factory
{
    [SerializeField] Turret[] _productPrefab;

    public void GenerateTurret(Vector3 spot)
    {
        Vector3 spownSpot = CheckSpot(spot);
        GetProduct(spownSpot);
    }

    Vector3 CheckSpot(Vector3 spot)
    {
        Vector3 spownSpot = spot;

        return spownSpot;
    }

    public override IProduct GetProduct(Vector3 position)
    {
        int rand = Random.Range(0, _productPrefab.Length);
        // プレハブインスタンスを作成して製品コンポーネントを取得する
        GameObject instance = Instantiate(_productPrefab[rand].gameObject, position, Quaternion.identity);
        Turret newProduct = instance.GetComponent<Turret>();
        // 各製品に独自のロジックが含まれる
        newProduct.Initialize(rand);
        return newProduct;
    }
}
