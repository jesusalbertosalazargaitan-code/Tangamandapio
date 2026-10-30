using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCamera : MonoBehaviour
{
    public GameObject text;
    public GameObject pantallaInicio;
    public GameObject album;
    public Transform player;
    public float sensibylity;
    private float rotationHorizontal = 0;
    private float rotationVertical = 0;
    void Start()
    {
        if (text != null) text.SetActive(false);
        if (pantallaInicio != null) pantallaInicio.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
            MoveMouse();
    }
    void MoveMouse()
    {
        float MoveX = Input.GetAxis("Mouse X") * sensibylity * Time.deltaTime;
        float MoveY = Input.GetAxis("Mouse Y") * sensibylity * Time.deltaTime;

        rotationHorizontal += MoveX;
        rotationVertical -= MoveY;

        rotationVertical = Math.Clamp(rotationVertical, -60, 60);

        transform.localRotation = Quaternion.Euler(rotationVertical, 0f, 0f);

        player.Rotate(Vector3.up * MoveX);
    }
    public void Continuar()
    {
        if (text != null) text.SetActive(true);
        if (pantallaInicio != null) pantallaInicio.SetActive(false);
        Time.timeScale = 1f;
    }
}
