using UnityEngine;

public class ResourceSpotFactory : Factory
{
    [SerializeField] ResourceSpot[] _productPrefab;
    [SerializeField] int _maxRightSpown = 35;
    [SerializeField] int _maxLeftSpown = 35;
    bool[] randRightSpots; //生成位置がかぶらないようにするために記録
    bool[] randLeftSpots; //生成位置がかぶらないようにするために記録

    private void Awake()
    {
        randRightSpots = new bool[_maxRightSpown];
        randLeftSpots = new bool[_maxLeftSpown];
    }

    public void GenerateSpot()
    {
        Vector3 spownSpot = CheckSpot();
        GetProduct(spownSpot);
    }

    Vector3 CheckSpot()
    {
        int rand;
        int randSpot;
        bool isCheck = false;
        do
        {
            rand = Random.Range(-_maxLeftSpown, _maxRightSpown);
            if (rand < -1)
            {
                randSpot = Mathf.Abs(rand);
                Debug.Log(randSpot);
                if (!randLeftSpots[randSpot - 1])
                {
                    isCheck = true;
                    randLeftSpots[randSpot - 1] = true;
                }
            }
            else if (rand > 1)
            {
                randSpot = rand;
                if (!randRightSpots[randSpot - 1])
                {
                    isCheck = true;
                    randRightSpots[randSpot - 1] = true;
                }
            }
            else
            {
                continue;
            }
        } while (!isCheck);
        Vector3 spownSpot = new Vector3(rand, 0, 0);
        return spownSpot;
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
