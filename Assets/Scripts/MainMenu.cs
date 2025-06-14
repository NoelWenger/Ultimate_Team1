using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame() => SceneManager.LoadScene("QuizScene");
    public void OpenShop() => SceneManager.LoadScene("Shop");
    public void OpenInventory() => SceneManager.LoadScene("Inventory");
}
