using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnImages : MonoBehaviour
{
    public List<Texture2D> images;
    public GameObject content;
    public GameObject imagePrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < images.Count; i++)
        {

            RawImage img = Instantiate(imagePrefab).GetComponent<RawImage>();
            img.transform.SetParent(content.transform);
            img.transform.localScale = new Vector3(1, 1, 1);
            img.texture = images[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
