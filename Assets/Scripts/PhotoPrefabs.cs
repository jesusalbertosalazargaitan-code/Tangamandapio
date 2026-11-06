using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements;

public class PhotoPrefabs : MonoBehaviour
{
    private GameObject album;
    // Lista estática para guardar TODAS las fotos compartidas entre las diferentes instancias
    private static List<GameObject> todasLasFotos = new List<GameObject>();
    public int limiteParaActivarTodas = 8;
    public bool isActive = false; // Variable para controlar si la foto está activa o no
    public void Awake()
    {
        isActive = false; // Inicializamos la variable isActive en false al despertar el objeto
    }
    public void Start()
    {
        album = GameObject.FindWithTag("Active");
        StartCoroutine(NextPosition());
        // Si se reinicia el nivel, limpiamos las referencias destruidas
        todasLasFotos.RemoveAll(foto => foto == null);

        // Añadimos nueva foto a la lista global
        todasLasFotos.Add(this.gameObject);

        //Evaluamos cuántas fotos llevamos en total
        if (todasLasFotos.Count < limiteParaActivarTodas)
        {
            // Si no hemos llegado al límite, apagamos la foto anterior (si es que hay más de una)
            if (todasLasFotos.Count > 1)
            {
                // La foto anterior siempre está en la posición
                todasLasFotos[todasLasFotos.Count - 2].SetActive(false);
            }
        }
        else if (todasLasFotos.Count == limiteParaActivarTodas)
        {
            //Si llegamos exactamente al límite, recorremos la lista y encendemos TODAS
            foreach (GameObject fotoGuardada in todasLasFotos)
            {
                if (fotoGuardada != null)
                {
                    fotoGuardada.SetActive(true);
                }
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isActive)
        {
            this.gameObject.SetActive(false);
        }
    }
    // Limpiamos la memoria si este objeto se destruye manualmente
    private void OnDestroy()
    {
        if (todasLasFotos.Contains(this.gameObject))
        {
            todasLasFotos.Remove(this.gameObject);
        }
    }
    IEnumerator NextPosition()
    {
        yield return new WaitForSecondsRealtime(3f);
        int width = Screen.width;
        if(width <= 1000)
        {
            transform.localPosition = new Vector3(0.154f, -0.087f, 0.221f);
            transform.localScale = new Vector3(0.012f, 0.012f, 0.012f);
        }
        else
        {
            transform.localPosition = new Vector3(0.2705f, -0.1523f, 0.3871f);
            transform.localScale = new Vector3(0.012f, 0.012f, 0.012f);
        }
        isActive = true;
    }
    IEnumerator PhotoPrefabPosition()
    {
        yield return new WaitForSecondsRealtime(0.21f);
        transform.localPosition = new Vector3(0.2705f, -0.1523f, 0.3871f);
    }
    //private void OnMouseEnter()
    //{
    //    if(album.activeSelf == true)
    //       transform.localScale = new Vector3(0.012f, 0.012f, 0.012f);
    //}
    //private void OnMouseExit()
    //{
    //    if (album.activeSelf == true)
    //        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
    //}
    //private void OnMouseDown()
    //{
    //   if (album.activeSelf == true)
    //   {
    //        transform.localPosition = new Vector3(0f, 0f, 0.698f);
    //        transform.localScale = new Vector3(0.11f, 0.11f, 0.11f);
    //    }
    //}
}
