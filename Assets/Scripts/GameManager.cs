using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene("射擊遊戲場景");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
