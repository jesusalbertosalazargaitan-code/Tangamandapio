using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Matematicas : MonoBehaviour
{
    public TMP_InputField inputText;
    public GameObject inicioMenu;
    public TextMeshProUGUI textName;
    public Image light1;
    public GameObject accept;
    private float suma;
    private float resta;
    private float multiplicar;
    private float dividir;
    private void Awake()
    {
        light1.color = Color.red;
        
    }
    private void FixedUpdate()
    {
        if(textName.text.Length < 5)
        {
            light1.color = Color.red;
            accept.SetActive(false);
        }
        if(textName.text.Length > 5)
        {
            light1.color = Color.green;
            accept.SetActive(true);
        }
    }
    public void Continuar()
    {
        PlayerPrefs.SetString("Name1", inputText.text);
        accept.SetActive(false);
        inicioMenu.SetActive(false);
        SceneManager.LoadScene(5);
    }
}
