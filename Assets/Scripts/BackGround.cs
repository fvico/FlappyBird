using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [Range(0,10)]
    public float backGroundSpeed;
    private Renderer myMaterial;
    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.material.mainTextureOffset = myMaterial.material.mainTextureOffset + Vector2.right * backGroundSpeed * Time.deltaTime;
    }
}
