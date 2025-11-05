using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        play,
        end
    }
    public static GameState currentState;

    [SerializeField] ResourceSpotFactory _resourceSpotFactory;
    [SerializeField] UIManager _UIManager;
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] Home _home;
    public static ResourceManager resourceManager;

    [SerializeField] float _timer = 300; //残り時間
    public float Timer => _timer;

    private void Start()
    {
        currentState = GameState.play;
        if (resourceManager == null)
        resourceManager = gameObject.AddComponent<ResourceManager>();
        resourceManager.Initialize();
        _UIManager.Initialize();

        for (int i = 0; i < 30; i++)
        {
            _resourceSpotFactory.GenerateSpot();
        }

        //カーソルを非表示
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (currentState == GameState.end) return;

        _timer -= Time.deltaTime;
        if (_home.Health <= 0)
        {
            GameOver();
        }

        if (_timer <= 0)
        {
            _timer = 0;
            GameClear();
        }
    }

    void GameClear()
    {
        currentState = GameState.end;
        //カーソルを表示
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Ending");
    }

    void GameOver()
    {
        currentState = GameState.end;
        _gameOverPanel.SetActive(true);
        //カーソルを表示
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
