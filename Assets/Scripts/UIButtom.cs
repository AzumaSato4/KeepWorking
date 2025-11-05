using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtom : MonoBehaviour
{
    [SerializeField] Sprite _pressed;

    public void OnPressedButton(string scene)
    {
        GetComponent<Image>().sprite = _pressed;
        SceneManager.LoadScene(scene);
    }
}
