using System.IO;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    void Awake()
    {
        ReadPlayerData();
        ReadSpotData();
        ReadEnemyData();
        ReadTurretData();
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
                Debug.Log($"{productName},{spotType},{maxHealth},{defense},{recoverTime},{recoverPower}");

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
                    new SpotStatus(productName, type, maxHealth, defense, recoverTime, recoverPower)
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

    void ReadTurretData()
    {
        // StreamingAssetsフォルダのCSVファイルパスを取得
        string filePath = Path.Combine(Application.streamingAssetsPath, "BulletData.csv");

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
                float shotSpeed = float.Parse(values[2]);
                float penetration = float.Parse(values[3]);
                float strength = float.Parse(values[4]);
                float dexterity = float.Parse(values[5]);
                Debug.Log($"{productName},{turretType},{shotSpeed},{penetration},{strength},{dexterity}");

                Bullet.BulletType type = Bullet.BulletType.bow;
                switch (turretType)
                {
                    case "bow":
                        type = Bullet.BulletType.bow;
                        break;
                }

                CSVDataBase.turretStatus.Add(
                    new BulletStatus(productName, type, shotSpeed, penetration, strength, dexterity)
                    );
            }
        }
        else
        {
            Debug.LogError("CSVファイルが見つかりませんでした: " + filePath);
        }
    }
}
