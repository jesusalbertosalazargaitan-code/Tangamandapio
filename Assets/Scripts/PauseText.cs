using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseText : MonoBehaviour
{
    public GameObject tutorial;
    public GameObject textTutorial;
    public GameObject textTutorial2;
    public GameObject timerText;
    public GameObject mainContinue;
    public int changeScene;
    ExcavatorController excavatorScript;

    private void Start()
    {
        excavatorScript = GetComponent<ExcavatorController>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && excavatorScript.tutorialOff == true || Input.GetKeyDown(KeyCode.Escape) && excavatorScript.tutorialOff == true)
        {
            Time.timeScale = 0f;
            tutorial.SetActive(false);
            textTutorial.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void PauseTutorial()
    {
        Time.timeScale = 0f;
        tutorial.SetActive(false);
        textTutorial.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1.0f;
        tutorial.SetActive(true);
        textTutorial.SetActive(false);
        timerText.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Continue()
    {
        StartCoroutine(Desactivartutorial());
        textTutorial.SetActive(true);
        textTutorial2.SetActive(false);
    }
    public void Salir()
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneTransitionManager.SCENE_LOBBY)
        {
            SceneTransitionManager.LoadScene(SceneTransitionManager.SCENE_MAIN_MENU);
        }
        else
        {
            SceneTransitionManager.ReturnToLobby();
        }
    }
    public void Reiniciar()
    {
        SceneTransitionManager.ReloadCurrentScene();
    }
    public void MainContinue()
    {
        textTutorial.SetActive(false);
        tutorial.SetActive(false);
        textTutorial2.SetActive(false);
        timerText.SetActive(false);
        mainContinue.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void MainContinueGame()
    {
        Time.timeScale = 1.0f;
        tutorial.SetActive(true);
        textTutorial.SetActive(false);
        timerText.SetActive(true);
    }
    public void Lvl2()
    {
        tutorial.SetActive(true);
        textTutorial.SetActive(false);
        Time.timeScale = 1.0f;
    }
    IEnumerator Desactivartutorial()
    {
        yield return new WaitForSeconds(60f);
        textTutorial.SetActive(false);
    }
}
