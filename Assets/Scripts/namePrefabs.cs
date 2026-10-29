using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class namePrefabs : MonoBehaviour
{
    public GameObject objetoNombre;
    public TMP_InputField[] inputsRespuestas; // Arrastra los 5 aquí
    public Image[] indicadoresColor;         // Arrastra los 5 aquí
    public GameObject menuFinal;             // Arrastra el menú aquí
    public GameObject respuestasCompletas;
    // He ajustado los valores para que sean correctos según tus operaciones
    private float[] respuestasCorrectas = new float[] {
        542f,
        2348f,
        1553223f,
        17f,
        46.75f
    };

    private float tolerancia = 0.01f; // Rango de error permitido

    void Start()
    {
        // 1. Recuperar nombre
        if (PlayerPrefs.HasKey("Name1"))
        {
            objetoNombre.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("Name1");
        }

        // 2. Estado inicial: todo en rojo
        foreach (var img in indicadoresColor)
        {
            if (img != null) img.color = Color.red;
        }

        if (menuFinal != null) menuFinal.SetActive(false);
    }

    void Update()
    {
        int contadorAciertos = 0;

        for (int i = 0; i < inputsRespuestas.Length; i++)
        {
            // Validamos seguridad: que existan los objetos
            if (inputsRespuestas[i] == null || indicadoresColor[i] == null) continue;

            float valorUsuario;
            // Intentamos convertir a float
            if (float.TryParse(inputsRespuestas[i].text, out valorUsuario))
            {
                // Usamos Mathf.Abs para comparar la diferencia (float - float)
                float diferencia = Mathf.Abs(valorUsuario - respuestasCorrectas[i]);

                if (diferencia < tolerancia)
                {
                    indicadoresColor[i].color = Color.green;
                    contadorAciertos++;
                }
                else
                {
                    indicadoresColor[i].color = Color.red;
                }
            }
            else
            {
                indicadoresColor[i].color = Color.red;
            }
        }

        // 3. Condición de victoria
        if (contadorAciertos == 5)
        {
            if (menuFinal != null && !menuFinal.activeSelf)
            {
                StartCoroutine(MenuFinal());
            }
        }
    }
    IEnumerator MenuFinal()
    {
        yield return new WaitForSeconds(1f);
        menuFinal.SetActive(true);
        respuestasCompletas.SetActive(false);
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(4);
    }
    public void Salir()
    {
        SceneManager.LoadScene(1);
    }
}


    
