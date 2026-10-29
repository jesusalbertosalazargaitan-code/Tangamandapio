using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip clip;
    public float return1;
    public float return2;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(FinalCount());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator FinalCount()
    {
        yield return new WaitForSeconds(return1);
        audioSource.Play();
        yield return new WaitForSeconds(return2);
        audioSource.Stop();
    }
}
