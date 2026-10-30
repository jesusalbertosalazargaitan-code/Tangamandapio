using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExcavatorController : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    public float speed = 5f;
    public float speedRotation;
    public bool active = true;
    public bool active2;
    public bool tutorialOff = true;
    public Transform objeto2;
    public Transform objeto3;
    public Transform objeto4;
    public float rangeXpositive;      // numeroflotante para el eje X +
    public float rangeXnegative;      // numeroflotante para el eje X -
    public float timer;
    public TextMeshProUGUI timerText;
    public GameObject finalMenu1;
    private AudioSource audioSource;
    public AudioClip clip;
    
    public void Awake()
    {
        Time.timeScale = 0;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        
    }

    // Update is called once per frame
    public void Update()
    {   
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        float MoveX = Input.GetAxis("Mouse X") * 100f * Time.deltaTime;
        float MoveY = Input.GetAxis("Mouse Y") * 100f * Time.deltaTime;
        timer -= Time.deltaTime;
        timerText.text = "Tiempo:  " + timer.ToString("0");
        if (timer <= 0)
        {
            timerText.enabled = false;
            timer = 0;
            Time.timeScale = 0;
            finalMenu1.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            tutorialOff = false;
        }

        if (active == true & !active2)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
            transform.Rotate(Vector3.up * speedRotation * Time.deltaTime * horizontalInput);
            Transform objeto = transform.Find("Base");
            objeto.transform.Rotate(Vector3.up * 40f * Time.deltaTime * MoveX);
            objeto2.transform.Rotate(Vector3.right * 40f * Time.deltaTime * MoveY);
        }
        if (Input.GetKey(KeyCode.E))
        {
            objeto3.transform.Rotate(Vector3.right * 40f * Time.deltaTime);
            objeto4.transform.Rotate(Vector3.right * 40f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            objeto3.transform.Rotate(Vector3.left * 40f * Time.deltaTime);
            objeto4.transform.Rotate(Vector3.right * 40f * Time.deltaTime);
        }


        Vector3 angles = objeto2.transform.localEulerAngles;

        if (angles.x > 180) angles.x -= 360;
        
        angles.x = Mathf.Clamp(angles.x, rangeXnegative, rangeXpositive);

        objeto2.transform.localEulerAngles = new Vector3( angles.x, objeto2.transform.localEulerAngles.y, objeto2.transform.localEulerAngles.z);

        Vector3 angles1 = objeto3.transform.localEulerAngles;

        if (angles1.x > 180) angles1.x -= 360;

        angles1.x = Mathf.Clamp(angles1.x, -80f, 3f);

        objeto3.transform.localEulerAngles = new Vector3(angles1.x, objeto3.transform.localEulerAngles.y, objeto3.transform.localEulerAngles.z);

        Vector3 angles2 = objeto4.transform.localEulerAngles;

        if (angles2.x > 180) angles2.x -= 360;

        angles2.x = Mathf.Clamp(angles2.x, -80f, 60f);

        if (angles2.z > 180) angles2.z -= 360;

        angles2.z = Mathf.Clamp(angles2.x, 0f, 0f);

        if (angles2.y > 180) angles2.y -= 360;

        angles2.y = Mathf.Clamp(angles2.x, 0f, 0f);

        objeto4.transform.localEulerAngles = new Vector3(angles2.x, angles2.y, angles2.z);


        if (transform.position.x > 21)
        {
            transform.position = new Vector3(21, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -18)
        {
            transform.position = new Vector3(-18, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -13)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -13);
        }
        if (transform.position.z > 13)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 13);
        }

    }
}
