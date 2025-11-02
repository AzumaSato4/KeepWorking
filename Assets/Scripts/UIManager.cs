using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Home _home;
    [SerializeField] GameManager gameManager;
    ResourceManager _resourceManager;

    [SerializeField] Slider _homeHPslider;
    [SerializeField] TextMeshProUGUI[] _resourceCountText;
    [SerializeField] TextMeshProUGUI[] _TimerText;

    int _minites;
    int _seconds;

    public void Initialize()
    {
        _homeHPslider.maxValue = _home.Health;
        _resourceManager = GameManager.resourceManager;
    }

    private void Update()
    {
        UIUpdate();
    }

    void UIUpdate()
    {
        _homeHPslider.value = _home.Health;
        _resourceCountText[0].text = _resourceManager.ResourcePouch[Resource.ResourceType.wood].ToString();
        _resourceCountText[1].text = _resourceManager.ResourcePouch[Resource.ResourceType.stone].ToString();
        _resourceCountText[2].text = _resourceManager.ResourcePouch[Resource.ResourceType.gold].ToString();

        _minites = (int)gameManager.Timer / 60;
        _seconds = (int)gameManager.Timer % 60;
        _TimerText[0].text = _minites.ToString("00");
        _TimerText[1].text = _seconds.ToString("00");
    }
}
