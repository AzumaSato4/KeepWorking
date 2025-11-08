using UnityEngine;

public class EnemySpot : Factory
{
    [SerializeField] Enemy[] _productPrefab;
    [SerializeField] Enemy _boss;
    [SerializeField] AnimationCurve _generateTime; //生成間隔
    float _generateTimer; //生成間隔

    float _timer;

    private void Update()
    {
        if (GameManager.currentState != GameManager.GameState.play) return;
        if (_timer >= _generateTimer)
        {
            _timer = 0;
            GetProduct(transform.position);
        }

        _timer += Time.deltaTime;
        _generateTimer = _generateTime.Evaluate(Time.time);
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

    public IProduct GetProductBoss()
    {
        Vector3 position = new Vector3(transform.position.x, 4, 0);
        // プレハブインスタンスを作成して製品コンポーネントを取得する
        GameObject instance = Instantiate(_boss.gameObject,
       position, Quaternion.identity);
        Enemy newProduct = instance.GetComponent<Enemy>();
        // 各製品に独自のロジックが含まれる
        newProduct.Initialize(3);
        return newProduct;
    }
}
