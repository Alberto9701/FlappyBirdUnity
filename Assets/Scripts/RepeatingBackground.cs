using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLenght;
    // Start is called before the first frame update

    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        groundHorizontalLenght = groundCollider.size.x;
    }

    private void RepositionBackground()
    {
        transform.Translate(Vector2.right * groundHorizontalLenght * 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x< -(groundHorizontalLenght))
        {
            RepositionBackground();
        }
    }
}
