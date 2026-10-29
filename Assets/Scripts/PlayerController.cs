using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class PlayerController : MonoBehaviour
{
    public float changeScale;
    public float speed;
    public float rotationSpeed;
    public GameObject album;
    Rigidbody rb;
    public GameObject electricidad;
    public GameObject multimedia;
    public GameObject contabilidad;
    public GameObject construccion;
    bool instructor;
    bool instructor2;
    bool instructor3;
    bool instructor4;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Time.timeScale = changeScale;
    }


    void FixedUpdate()
    {
        // Obtenemos el input clásico (Vertical para W/S o Flecha Arriba/Abajo, Horizontal para A/D o Flecha Izquierda/Derecha)
        // Usamos "Vertical" y "Horizontal" para que tenga suavidad, o "GetAxisRaw" si prefieres respuesta inmediata sin inercia.
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculamos la dirección deseada en función del input tradicional
        Vector3 direccionDeseada = (transform.forward * moveZ) + (transform.right * moveX);

        // Si la magnitud de la dirección deseada es mayor que 1, normalizamos el vector para evitar que el jugador se mueva más rápido en diagonal
        if (direccionDeseada.magnitude > 1)
        {
            // Normalizamos el vector de dirección deseada para mantener una velocidad constante en todas las direcciones
            direccionDeseada.Normalize();
        }

        // Establecemos la velocidad del Rigidbody en función de la dirección deseada multiplicada por la velocidad actual, manteniendo la componente vertical para el salto o la gravedad
        rb.velocity = new Vector3(direccionDeseada.x * speed, rb.velocity.y, direccionDeseada.z * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Instructor") & !instructor)
        {
            electricidad.SetActive(true);
            Time.timeScale = 0;
            instructor = true;
        }
        if (collision.gameObject.CompareTag("Instructor2") & !instructor2)
        {
            multimedia.SetActive(true);
            Time.timeScale = 0;
            instructor2 = true;
        }
        if (collision.gameObject.CompareTag("Instructor3") & !instructor3)
        {
            contabilidad.SetActive(true);
            Time.timeScale = 0;
            instructor3 = true;
        }
        if (collision.gameObject.CompareTag("Instructor4") & !instructor4)
        {
            construccion.SetActive(true);
            Time.timeScale = 0;
            instructor4 = true;
        }
        if (collision.gameObject.CompareTag("Gate"))
            SceneManager.LoadScene(2);
        if (collision.gameObject.CompareTag("Gate2"))
            SceneManager.LoadScene(3);
        if (collision.gameObject.CompareTag("Gate3"))
            SceneManager.LoadScene(4);
        if (collision.gameObject.CompareTag("Gate4"))
            SceneManager.LoadScene(6);
    }
    private void OnCollisionExit(Collision collision)
    {
        
    }
        
    
}
