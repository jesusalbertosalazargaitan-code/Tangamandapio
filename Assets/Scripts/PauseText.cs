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
    public void PauseTutorial()
    {
        Time.timeScale = 0f;
        tutorial.SetActive(false);
        textTutorial.SetActive(true);
    }
    public void ContinueGame()
    {
        Time.timeScale = 1.0f;
        tutorial.SetActive(true);
        textTutorial.SetActive(false);
        timerText.SetActive(true);
    }
    public void Continue()
    {
        StartCoroutine(Desactivartutorial());
        textTutorial.SetActive(true);
        textTutorial2.SetActive(false);
    }
    public void Salir()
    {
        SceneManager.LoadScene(1);
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(changeScene);
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
