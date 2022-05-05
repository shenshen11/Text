using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundparallax : MonoBehaviour
{
    public float parallaxFactor = 0.1f;
    public float framesParallaxFactor = 0.3f;
    public float smoothX = 4;
    public Transform[] backgrounds;

    private Transform cam;
    private Vector3 camPrePos;

    private void Awake()
    {
        cam = Camera.main.transform;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        camPrePos = cam.position;
    }

    void bkParallax()
    {
        float fparallax = (camPrePos.x - cam.position.x) * parallaxFactor;
        if(Mathf.Abs(fparallax)>0)
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {
                float bkNewX = backgrounds[i].position.x + fparallax * (1 + i * framesParallaxFactor);
                Vector3 bkNewPos = new Vector3(bkNewX, backgrounds[i].position.y, backgrounds[i].position.z);
                backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, bkNewPos, Time.deltaTime * smoothX);
            }
            camPrePos = cam.position;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        bkParallax();
    }
}
