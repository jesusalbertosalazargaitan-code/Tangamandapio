using System.Linq.Expressions;
using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;

public class PhotoPrefabs : MonoBehaviour
{
    private GameObject album;
    public void Start()
    {
        album = GameObject.FindWithTag("Active");
        StartCoroutine(NextPosition());
        
    }
    private void Update()
    {
        
    }
    IEnumerator NextPosition()
    {
        yield return new WaitForSecondsRealtime(3f);
        transform.localPosition = new Vector3(0.154f, -0.087f, 0.221f);
        transform.localScale = new Vector3(0.0055f, 0.0055f, 0.0055f);
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
