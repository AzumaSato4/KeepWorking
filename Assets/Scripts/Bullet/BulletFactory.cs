using UnityEngine;

public class BulletFactory : Factory
{
    [SerializeField] Bullet[] _productPrefab;
    float _scale;

    public void GenerateBullet(Vector3 spot, float scale)
    {
        _scale = scale;
        GetProduct(spot);
    }

    public override IProduct GetProduct(Vector3 position)
    {
        int rand = Random.Range(0, _productPrefab.Length);
        // プレハブインスタンスを作成して製品コンポーネントを取得する
        GameObject instance = Instantiate(_productPrefab[rand].gameObject, position, Quaternion.identity);
        instance.transform.localScale = new Vector3(_scale, _scale, 1);
        Bullet newProduct = instance.GetComponent<Bullet>();
        // 各製品に独自のロジックが含まれる
        newProduct.Initialize(rand);
        return newProduct;
    }
}
