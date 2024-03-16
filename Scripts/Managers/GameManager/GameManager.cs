using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isMainManu = false;
    [SerializeField] private string _nameMainMenuScene;
    [SerializeField] private string _nameBaseScene;

    public bool IsMainMenu => _isMainManu;

    public void LoadScene()
    {
        BaseLoadScene(_nameBaseScene);
    }

    public void ReturnToMainMenu()
    {
        BaseLoadScene(_nameMainMenuScene);
    }

    private void BaseLoadScene(string nameScene)
    {
        if (!string.IsNullOrEmpty(nameScene))
        {
            SceneManager.LoadScene(nameScene);
        }
    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}