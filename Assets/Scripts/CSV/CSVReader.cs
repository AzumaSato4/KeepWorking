using System.IO;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    void Awake()
    {
        ReadPlayerData();
        ReadSpotData();
        ReadEnemyData();
        ReadArrowData();
        ReadBombData();
        ReadResourceData();
    }

    void ReadPlayerData()
    {
        // StreamingAssetsフォルダのCSVファイルパスを取得
        string filePath = Path.Combine(Application.streamingAssetsPath, "PlayerData.csv");

        // ファイルを読み込む
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                // ヘッダー行（最初の行）はスキップ
                if (values[0] == "Name") continue;

                string name = values[0];
                float moveSpeed = float.Parse(values[1]);
                float strength = float.Parse(values[2]);
                float coolTime = float.Parse(values[3]);
                float dexterity = float.Parse(values[4]);
                Debug.Log($"{name},{moveSpeed},{strength},{coolTime},{dexterity}");

                CSVDataBase.playerStatus = new PlayerStatus(moveSpeed, strength, coolTime, dexterity);
            }
        }
        else
        {
            Debug.LogError("CSVファイルが見つかりませんでした: " + filePath);
        }
    }

    void ReadSpotData()
    {
        // StreamingAssetsフォルダのCSVファイルパスを取得
        string filePath = Path.Combine(Application.streamingAssetsPath, "SpotData.csv");

        // ファイルを読み込む
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                // ヘッダー行（最初の行）はスキップ
                if (values[0] == "Name") continue;

                string productName = values[0];
                string spotType = values[1];
                float maxHealth = float.Parse(values[2]);
                float defense = float.Parse(values[3]);
                float recoverTime = float.Parse(values[4]);
                float recoverPower = float.Parse(values[5]);
                int amount = int.Parse(values[6]);
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
        }
        else
        {
            Debug.LogError("CSVファイルが見つかりませんでした: " + filePath);
        }
    }

    void ReadEnemyData()
    {
        // StreamingAssetsフォルダのCSVファイルパスを取得
        string filePath = Path.Combine(Application.streamingAssetsPath, "EnemyData.csv");

        // ファイルを読み込む
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                // ヘッダー行（最初の行）はスキップ
                if (values[0] == "Name") continue;

                string productName = values[0];
                string enemyType = values[1];
                float moveSpeed = float.Parse(values[2]);
                float maxHealth = float.Parse(values[3]);
                float defense = float.Parse(values[4]);
                float strength = float.Parse(values[5]);
                float coolTime = float.Parse(values[6]);
                float dexterity = float.Parse(values[7]);
                Debug.Log($"{productName},{enemyType},{moveSpeed},{maxHealth},{defense},{strength},{coolTime},{dexterity}");

                Enemy.EnemyType type = Enemy.EnemyType.goblin;
                switch (enemyType)
                {
                    case "goblin":
                        type = Enemy.EnemyType.goblin;
                        break;
                }

                CSVDataBase.enemyStatus.Add(
                    new EnemyStatus(productName, type, moveSpeed, maxHealth, defense, strength, coolTime, dexterity)
                    );
            }
        }
        else
        {
            Debug.LogError("CSVファイルが見つかりませんでした: " + filePath);
        }
    }

    void ReadArrowData()
    {
        // StreamingAssetsフォルダのCSVファイルパスを取得
        string filePath = Path.Combine(Application.streamingAssetsPath, "ArrowData.csv");

        // ファイルを読み込む
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                // ヘッダー行（最初の行）はスキップ
                if (values[0] == "Name") continue;

                string productName = values[0];
                float shotSpeed = float.Parse(values[1]);
                float penetration = float.Parse(values[2]);
                float strength = float.Parse(values[3]);
                float dexterity = float.Parse(values[4]);
                Debug.Log($"{productName},{shotSpeed},{penetration},{strength},{dexterity}");

                CSVDataBase.arrowStatus = new ArrowStatus(productName, shotSpeed, penetration, strength, dexterity);
            }
        }
        else
        {
            Debug.LogError("CSVファイルが見つかりませんでした: " + filePath);
        }
    }

    void ReadBombData()
    {
        // StreamingAssetsフォルダのCSVファイルパスを取得
        string filePath = Path.Combine(Application.streamingAssetsPath, "BombData.csv");

        // ファイルを読み込む
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                // ヘッダー行（最初の行）はスキップ
                if (values[0] == "Name") continue;

                string productName = values[0];
                string turretType = values[1];
                float strength = float.Parse(values[2]);
                float dexterity = float.Parse(values[3]);
                float renge = float.Parse(values[4]);
                Debug.Log($"{productName},{turretType},{strength},{dexterity},{renge}");

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
                    new BombStatus(productName, type, strength, dexterity, renge)
                    );
            }
        }
        else
        {
            Debug.LogError("CSVファイルが見つかりませんでした: " + filePath);
        }
    }

    void ReadResourceData()
    {
        // StreamingAssetsフォルダのCSVファイルパスを取得
        string filePath = Path.Combine(Application.streamingAssetsPath, "ResourceData.csv");

        // ファイルを読み込む
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                // ヘッダー行（最初の行）はスキップ
                if (values[0] == "Name") continue;

                string productName = values[0];
                string spotType = values[1];
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
        else
        {
            Debug.LogError("CSVファイルが見つかりませんでした: " + filePath);
        }
    }
}
