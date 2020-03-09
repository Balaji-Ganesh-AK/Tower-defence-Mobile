using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CityManager manager;

    public GameObject gameOverUI;

    public bool IsGameOver
    {
        get;
        private set;
    }

    // Start is called before the first frame update
    void Start()
    {
        manager = gameObject.GetComponent<CityManager>();
        if (!manager)
        {
            Debug.Assert(manager, "No manager was detected. Game cannot be reset.");
            return;
        }
    }

    // Update is called once per frame
    public void GameOver()
    {
        Debug.Log("I was indeed called");
        gameOverUI.SetActive(true);
        IsGameOver = true;
    }

    // Reloads the currently loaded scene.
    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
