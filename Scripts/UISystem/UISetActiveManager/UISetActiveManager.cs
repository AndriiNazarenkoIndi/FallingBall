using UnityEngine;
using UnityEngine.UI;

public class UISetActiveManager : MonoBehaviour
{
    [Header("Control buttons")]
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _restartButton;

    [Header("Shop panel")]
    [SerializeField] private ShopManager _shopManager;
    [SerializeField] private UIPanel _shopPanel;

    private bool _setActiveShopPanel = false;

    public void SetActiveNextLevelButton()
    {
        UIObjectSetActive(_nextLevelButton.gameObject, true);
    }

    public void SetActiveMainMenuButton()
    {
        UIObjectSetActive(_mainMenuButton.gameObject, true);
    }

    public void SetActiveRestartButton()
    {
        UIObjectSetActive(_restartButton.gameObject, true);
    }

    public void SetActiveShopPanel()
    {
        _setActiveShopPanel = !_setActiveShopPanel;
        UIObjectSetActive(_shopPanel.gameObject, _setActiveShopPanel);
    }

    private void UIObjectSetActive(GameObject uiObject, bool isActive)
    {
        uiObject.SetActive(isActive);
    }
}