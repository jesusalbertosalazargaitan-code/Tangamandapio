using UnityEngine;

public class ElectricConection : MonoBehaviour
{
    public GameObject a1;
    public GameObject a2;
    public GameObject a3;
    public GameObject a4;
    public GameObject a5;
    public GameObject a6;
    public GameObject a7;
    public GameObject a8;
    public GameObject a9;
    public GameObject a10;
    public GameObject a11;
    public GameObject a12;
    public GameObject a13;
    public GameObject a14;
    public GameObject a15;
    public GameObject a16;
    public GameObject a17;
    public GameObject a18;
    public GameObject a19;
    void Awake()
    {
        a1 = GetComponent<GameObject>();
        a2 = GetComponent<GameObject>();
        a3 = GetComponent<GameObject>();
        a4 = GetComponent<GameObject>();
        a5 = GetComponent<GameObject>();
        a6 = GetComponent<GameObject>();
        a7 = GetComponent<GameObject>();
        a8 = GetComponent<GameObject>();
        a9 = GetComponent<GameObject>();
        a10 = GetComponent<GameObject>();
        a11 = GetComponent<GameObject>();
        a12 = GetComponent<GameObject>();
        a13 = GetComponent<GameObject>();
        a14 = GetComponent<GameObject>();
        a15 = GetComponent<GameObject>();
        a16 = GetComponent<GameObject>();
        a17 = GetComponent<GameObject>();
        a18 = GetComponent<GameObject>();
        a19 = GetComponent<GameObject>();
    }

    
    void FixedUpdate()
    {
        
    }
    public void Fila1()
    {
        a1.transform.Rotate(new Vector3(0, 0, 90));
        a2.transform.Rotate(new Vector3(0, 0, 90));
    }
    public void Fila2()
    {
        
    }
    void Fila3()
    {
        a3.transform.Rotate(new Vector3(0, 0, 90));
    }
    void Fila4()
    {
        a4.transform.Rotate(new Vector3(0, 0, 90));
    }
    void Fila5()
    {
        a5.transform.Rotate(new Vector3(0, 0, 90));
    }
    void Fila6()
    {
        a6.transform.Rotate(new Vector3(0, 0, 90));
    }
    void Fila7()
    {
        a7.transform.Rotate(new Vector3(0, 0, 90));
    }
}
