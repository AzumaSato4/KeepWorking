using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleStart : MonoBehaviour
{
    [SerializeField] TitleSoundManager _soundManager;

    [SerializeField] TextMeshProUGUI _startText;
    [SerializeField] Animator _startTextAnime;
    bool _isStart;

    public void OnClick(InputValue val)
    {
        if (_isStart) return;
        if (val.isPressed)
        {
            _isStart = true;
            _startTextAnime.SetTrigger("Start");
            _soundManager.PlaySE(TitleSoundManager.SE_Type.click);
            Invoke("LoadScene", 2.0f);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Main");
    }
}
