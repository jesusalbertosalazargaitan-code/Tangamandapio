using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDebug : MonoBehaviour
{
    void Awake()
    {
        // Fuerza a actualizar la iluminación ambiental y los datos globales de renderizado
        DynamicGI.UpdateEnvironment();
    }
}
