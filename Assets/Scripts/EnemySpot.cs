using UnityEngine;

public class EnemySpot : Factory
{
    [SerializeField] Enemy[] _productPrefab;
    float _generateTime = 2; //生成間隔
    float _timer;

    private void Update()
    {
        if (_timer >= _generateTime)
        {
            _timer = 0;
            GetProduct(transform.position);
        }

        _timer += Time.deltaTime;
    }

    public override IProduct GetProduct(Vector3 position)
    {
        int rand = Random.Range(0, _productPrefab.Length);
        // プレハブインスタンスを作成して製品コンポーネントを取得する
        GameObject instance = Instantiate(_productPrefab[rand].gameObject,
       position, Quaternion.identity);
        Enemy newProduct = instance.GetComponent<Enemy>();
        // 各製品に独自のロジックが含まれる
        newProduct.Initialize(rand);
        return newProduct;
    }
}
