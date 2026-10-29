using TMPro;
using UnityEngine;
using System.Collections;

public class CablingRotate : MonoBehaviour
{
    public Transform[] fila1;
    public Transform[] fila2;
    public Transform[] fila3;
    public Transform[] fila4;
    public Transform[] fila5;
    public Transform[] fila6;
    public Transform[] fila7;
    public GameObject[] electric;
    public GameObject[] wires;
    public GameObject wireHolder;
    public GameObject light1;
    public GameObject finalMenu1;
    public GameObject finalMenu2;
    private AudioSource audioSource;
    public AudioClip clip;
    public AudioClip clip1;
    [SerializeField]
    int totalWires;
    public float timer;
    public TextMeshProUGUI timerText;
    public bool isActive1 = true;
    public bool isActive2 = true;
    public bool isActive3 = true;
    public bool isActive4 = true;
    public bool isActive5 = true;
    public bool isActive6 = true;
    public bool isActive7 = true;
    void Awake()
    {
        Time.timeScale = 0f;
        totalWires = wireHolder.transform.childCount;
        wires = new GameObject[totalWires];
        audioSource = GetComponent<AudioSource>();

        for (int i = 0; i < wires.Length; i++)
        {
            wires[i] = wireHolder.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "Tiempo:\n" + timer.ToString("0");
        if (!isActive1 & !isActive2 & !isActive3 & !isActive4 & !isActive5 & !isActive6 & !isActive7)
            light1.SetActive(true);

        if (timer <= 0f)
        {
            timer = 0f;
            Time.timeScale = 0f;
            StartCoroutine(Finalmenu1());
        }
        if (light1.activeSelf == true)
            StartCoroutine(Finalmenu2());
        
    }
    public void Fila1()
    {
        foreach ( Transform f1 in fila1)
        {
            f1.Rotate(new Vector3(0, 0, 90f));
            if (fila1[0].eulerAngles.z == 180 & fila1[1].eulerAngles.z == 90)
            {
                electric[0].SetActive(true);
                isActive1 = false;
                audioSource.PlayOneShot(clip);
            }
            else
            {
                isActive1 = true;
                electric[0].SetActive(false);
            }
        }
        
        
    }
    public void Fila2()
    {
        foreach (Transform f2 in fila2)
        {
            f2.Rotate(new Vector3(0, 0, 90f));
            if (fila2[0].eulerAngles.z == 270 & fila2[2].eulerAngles.z == 90)
            {
                electric[1].SetActive(true);
                isActive2 = false;
                audioSource.PlayOneShot(clip);
            }
            else 
            {
                isActive2 = true;
                electric[1].SetActive(false);
            }
        }
    }
    public void Fila3()
    {
        foreach (Transform f3 in fila3)
        {
            f3.Rotate(new Vector3(0, 0, 90f));
            if (fila3[0].eulerAngles.z == 180)
            {
                electric[2].SetActive(true);
                isActive3 = false;
                audioSource.PlayOneShot(clip);
            }
            else 
            {
                isActive3 = true;
                electric[2].SetActive(false);
            }
            
        }
    }
    public void Fila4()
    {
        foreach (Transform f4 in fila4)
        {
            f4.Rotate(new Vector3(0, 0, 90f));
            if (fila4[0].eulerAngles.z == 0 & fila4[2].eulerAngles.z == 180)
            {
                audioSource.PlayOneShot(clip);
                isActive4 = false;
                electric[3].SetActive(true);
            }
            else
            {
                isActive4 = true;
                electric[3].SetActive(false);
            }
        }
    }
    public void Fila5()
    {
        foreach (Transform f5 in fila5)
        {
            f5.Rotate(new Vector3(0, 0, 90f));
            if (fila5[2].eulerAngles.z == 0)
            {
                electric[4].SetActive(true);
                audioSource.PlayOneShot(clip);
                isActive5 = false;
            }
            else 
            {
                electric[4].SetActive(false);
                isActive5 = true;
            }
            
        }
    }
    public void Fila6()
    {
        foreach (Transform f6 in fila6)
        {
            f6.Rotate(new Vector3(0, 0, 90f));
            if (fila6[0].eulerAngles.z == 270 & fila6[1].eulerAngles.z == 90)
            {
                electric[5].SetActive(true);
                audioSource.PlayOneShot(clip);
                isActive6 = false;
            }
            else
            {
                isActive6 = true;
                electric[5].SetActive(false);
            }
        }
    }
    public void Fila7()
    {
        foreach (Transform f7 in fila7)
        {
            f7.Rotate(new Vector3(0, 0, 90f));
            if (fila7[0].eulerAngles.z == 90)
            {
                electric[6].SetActive(true);
                isActive7 = false;
                audioSource.PlayOneShot(clip);
            }
            else
            { 
                isActive7 = true;
                electric[6].SetActive(false);
            }
        }
    }
    IEnumerator Finalmenu1()
    {
        yield return new WaitForSecondsRealtime(2);
        finalMenu1.SetActive(true);
    }
    IEnumerator Finalmenu2()
    {
        yield return new WaitForSecondsRealtime(2);
        finalMenu2.SetActive(true);
    }
}
