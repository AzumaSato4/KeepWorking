using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTitle : MonoBehaviour
{
    public void OnTitleButton()
    {
            SceneManager.LoadScene("Title");
    }
}
