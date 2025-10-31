using System.IO;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    void Start()
    {
        ReadPlayerData();
        ReadSpotData();
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
}
