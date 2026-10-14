using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // End 버튼용: 게임 종료
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
