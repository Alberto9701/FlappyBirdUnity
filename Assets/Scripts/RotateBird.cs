using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBird : MonoBehaviour
{
    public float maxDownVelocity=-5f;
    private float maxDownAngle=-90f;

    public Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb2d != null)
        {
            //rb2d.velocity.y
            float currentVelocity = Mathf.Clamp(rb2d.velocity.y, maxDownVelocity, 0);
            float angle = (currentVelocity / maxDownVelocity)*maxDownAngle;
            Quaternion rotation=Quaternion.Euler(0,0,angle);
            transform.rotation = rotation;

        }

    }
}
