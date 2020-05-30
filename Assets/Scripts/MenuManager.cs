using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void triggerMenu(int i)
    {
        switch(i)
        {
            default:
            case 0:
                // Start game
                SceneManager.LoadScene("GameScene");
            break;
            case 1:
                // Quit game 
                Application.Quit();
            break;

        }
    }
}
