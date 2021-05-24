using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    Rigidbody rb;
    gmanager gm;
    public int pointvalue = 5;
    public ParticleSystem p;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * Random.Range(12, 16), ForceMode.Impulse);
        rb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4, 4),-6);
        gm = GameObject.Find("GameManager").GetComponent<gmanager>();
    }

    private void OnMouseDown()
    {
        if (gm.isplay)
        {
            gm.updateScore(pointvalue);
            Instantiate(p, transform.position, p.transform.rotation);
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (!gameObject.CompareTag("bad"))
        {
            gm.gameover();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
