using System.Collections;
using System.IO;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    enum Header
    {
        category,
        name,
        type,
        speed,
        maxHealth,
        defense,
        strength,
        coolTime,
        penetration,
        renge,
        recoverTime,
        recoverPower,
        amount
    }

    static bool isRead;

    void Awake()
    {
        if (isRead) return;
        StartCoroutine(FindFile());
    }

    IEnumerator FindFile()
    {
#if UNITY_WEBGL
        //StreamingAssetsフォルダのCSVファイルパスを取得
        string path = Application.streamingAssetsPath + "/GameData.csv";
        using (var request = UnityEngine.Networking.UnityWebRequest.Get(path))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityEngine.Networking.UnityWebRequest.Result.Success)
                ReadData(request.downloadHandler.text.Split('\n'));
            else
                Debug.LogError("CSV読み込み失敗: " + request.error);
        }
#else
        //StreamingAssetsフォルダのCSVファイルパスを取得
        string filePath = Path.Combine(Application.streamingAssetsPath, "GameData.csv");

        //ファイルを読み込む
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            ReadArrowData(lines);
        }
        else
        {
            Debug.LogError("CSVファイルが見つかりませんでした: " + filePath);
        }
#endif
        isRead = true;
    }

    void ReadData(string[] lines)
    {
        foreach (string line in lines)
        {
            string[] values = line.Split(',');
            //ヘッダーはスキップ
            if (values[0] == "Category") continue;
            switch (values[0])
            {
                case "Player":
                    ReadPlayerData(values);
                    break;
                case "Enemy":
                    ReadEnemyData(values);
                    break;
                case "Arrow":
                    ReadArrowData(values);
                    break;
                case "Bomb":
                    ReadBombData(values);
                    break;
                case "Spot":
                    ReadSpotData(values);
                    break;
                case "Resource":
                    ReadResourceData(values);
                    break;
            }
        }
    }

    void ReadPlayerData(string[] values)
    {
        string name = values[(int)Header.name];
        float moveSpeed = float.Parse(values[(int)Header.speed]);
        float strength = float.Parse(values[(int)Header.strength]);
        float coolTime = float.Parse(values[(int)Header.coolTime]);
        Debug.Log($"{name},{moveSpeed},{strength},{coolTime}");

        CSVDataBase.playerStatus = new PlayerStatus(moveSpeed, strength, coolTime);
    }

    void ReadEnemyData(string[] values)
    {
        string productName = values[(int)Header.name];
        string enemyType = values[(int)Header.type];
        float moveSpeed = float.Parse(values[(int)Header.speed]);
        float maxHealth = float.Parse(values[(int)Header.maxHealth]);
        float defense = float.Parse(values[(int)Header.defense]);
        float strength = float.Parse(values[(int)Header.strength]);
        float coolTime = float.Parse(values[(int)Header.coolTime]);
        Debug.Log($"{productName},{enemyType},{moveSpeed},{maxHealth},{defense},{strength},{coolTime}");

        Enemy.EnemyType type = Enemy.EnemyType.goblin;
        switch (enemyType)
        {
            case "goblin":
                type = Enemy.EnemyType.goblin;
                break;
            case "skeleton":
                type = Enemy.EnemyType.skeleton;
                break;
            case "bat":
                type = Enemy.EnemyType.bat;
                break;
        }

        CSVDataBase.enemyStatus.Add(
            new EnemyStatus(productName, type, moveSpeed, maxHealth, defense, strength, coolTime)
            );
    }


    void ReadArrowData(string[] values)
    {
        string productName = values[(int)Header.name];
        float shotSpeed = float.Parse(values[(int)Header.speed]);
        float strength = float.Parse(values[(int)Header.strength]);
        float penetration = float.Parse(values[(int)Header.penetration]);
        Debug.Log($"{productName},{shotSpeed},{strength},{penetration}");

        CSVDataBase.arrowStatus = new ArrowStatus(productName, shotSpeed, strength, penetration);
    }

    void ReadBombData(string[] values)
    {
        string productName = values[(int)Header.name];
        string turretType = values[(int)Header.type];
        float strength = float.Parse(values[(int)Header.strength]);
        float renge = float.Parse(values[(int)Header.renge]);
        Debug.Log($"{productName},{turretType},{strength},{renge}");

        Bomb.BombType type = Bomb.BombType.wood;
        switch (turretType)
        {
            case "wood":
                type = Bomb.BombType.wood;
                break;
            case "stone":
                type = Bomb.BombType.stone;
                break;
            case "gold":
                type = Bomb.BombType.gold;
                break;
        }

        CSVDataBase.bombStatus.Add(
            new BombStatus(productName, type, strength, renge)
            );
    }

    void ReadSpotData(string[] values)
    {
        string productName = values[(int)Header.name];
        string spotType = values[(int)Header.type];
        float maxHealth = float.Parse(values[(int)Header.maxHealth]);
        float defense = float.Parse(values[(int)Header.defense]);
        float recoverTime = float.Parse(values[(int)Header.recoverTime]);
        float recoverPower = float.Parse(values[(int)Header.recoverPower]);
        int amount = int.Parse(values[(int)Header.amount]);
        Debug.Log($"{productName},{spotType},{maxHealth},{defense},{recoverTime},{recoverPower},{amount}");

        Resource.ResourceType type = Resource.ResourceType.wood;
        switch (spotType)
        {
            case "wood":
                type = Resource.ResourceType.wood;
                break;
            case "stone":
                type = Resource.ResourceType.stone;
                break;
            case "gold":
                type = Resource.ResourceType.gold;
                break;
        }

        CSVDataBase.spotStatus.Add(
            new SpotStatus(productName, type, maxHealth, defense, recoverTime, recoverPower, amount)
            );
    }

    void ReadResourceData(string[] values)
    {
        string productName = values[(int)Header.name];
        string spotType = values[(int)Header.type];
        Debug.Log($"{productName},{spotType}");

        Resource.ResourceType type = Resource.ResourceType.wood;
        switch (spotType)
        {
            case "wood":
                type = Resource.ResourceType.wood;
                break;
            case "stone":
                type = Resource.ResourceType.stone;
                break;
            case "gold":
                type = Resource.ResourceType.gold;
                break;
        }

        CSVDataBase.resources.Add(
            new ResourceData(productName, type)
            );
    }
}
