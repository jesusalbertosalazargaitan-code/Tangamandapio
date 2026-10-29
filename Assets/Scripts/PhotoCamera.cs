using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PhotoCamera : MonoBehaviour
{
    public TextMeshProUGUI prefabsText;
    public GameObject text;
    public GameObject camara;
    Texture2D photoTexture;
    public GameObject album;
    public GameObject prefab;
    public GameObject photo;
    public GameObject prefabHolder;
    public GameObject[] prefabArray;
    private AudioSource audioSource;
    public AudioClip audioClip;
    public int totalPrefabs;
    bool takePhoto = true;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        UpdateScore(0);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) & takePhoto)
        {
            Time.timeScale = 0f;
            StartCoroutine(Continue());
            UpdateScore(1);
            StartCoroutine(CapturePhoto());
            camara.SetActive(true);
            audioSource.Play();
        }
        else camara.SetActive(false);

        totalPrefabs = prefabHolder.transform.childCount;
        prefabArray = new GameObject[totalPrefabs];

        for (int i = 0; i < prefabArray.Length; i++)
        {
            prefabArray[i] = prefabHolder.transform.GetChild(i).gameObject;
        }
        if(totalPrefabs >= 8)
        {
            StartCoroutine(MenuAlbum());
            takePhoto = false;
        }
    }
    
    IEnumerator CapturePhoto()
    {
        // Espera a que todo el renderizado de la pantalla termine perfectamente
        yield return new WaitForEndOfFrame();

        //Capturamos el tama�o REAL de la ventana de juego
        int width = Screen.width;
        int height = Screen.height;

        //Inicializamos la textura con el tama�o completo
        photoTexture = new Texture2D(width, height, TextureFormat.RGB24, false);

        //Leemos los p�xeles de toda la pantalla
        photoTexture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        photoTexture.Apply();

        //Creamos el Sprite
        Sprite sprite = Sprite.Create(photoTexture, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));

        //Instanciamos el prefab y asignamos el sprite
        GameObject instance = Instantiate(prefab, new Vector3(0f, 0f, 1.309f), Quaternion.identity);

        if (instance.TryGetComponent<SpriteRenderer>(out SpriteRenderer sr))
        {
            sr.sprite = sprite;
        }

        if (photo != null)
        {
            instance.transform.SetParent(photo.transform, false);
        }

        takePhoto = false;

        yield return new WaitForSecondsRealtime(3.0f); // Cd para la siguiente foto
        takePhoto = true;
    }
    IEnumerator MenuAlbum()
    {
        yield return new WaitForSecondsRealtime(3f);
        AlbumPrefabs();
        album.SetActive(true);
        text.SetActive(false);
        Time.timeScale = 0;
    }
    IEnumerator Continue()
    {
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1f;
    }
    void AlbumPrefabs()
    {
        
            prefabArray[0].transform.localPosition = new Vector3(-0.2452f, 0.1073f, 0.3303f);
            prefabArray[1].transform.localPosition = new Vector3(-0.0854f, 0.1073f, 0.3303f);
            prefabArray[2].transform.localPosition = new Vector3(0.0832f, 0.1073f, 0.3303f);
            prefabArray[3].transform.localPosition = new Vector3(0.2484f, 0.1073f, 0.3303f);
            prefabArray[4].transform.localPosition = new Vector3(-0.2487f, 0.001f, 0.3303f);
            prefabArray[5].transform.localPosition = new Vector3(-0.0854f, 0.001f, 0.3303f);
            prefabArray[6].transform.localPosition = new Vector3(0.0832f, 0.001f, 0.3303f);
            prefabArray[7].transform.localPosition = new Vector3(0.2484f, 0.001f, 0.3303f);
        
    }
    public void Continuar()
    {
        SceneTransitionManager.ReturnToLobby();
    }
    public void ReiniciarMultimedia()
    {
        SceneTransitionManager.ReloadCurrentScene();
    }
    public void UpdateScore(int scoreToAdd)
    {
        totalPrefabs += scoreToAdd;
        prefabsText.text = "Fotos: " + totalPrefabs + " /8";

    }
}
