using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public GameObject death;
    private float topSpeed = 4f;
    private Vector3 spawn;


	// Use this for initialization
	void Start () {

        spawn = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement);

        if (GetComponent<Rigidbody>().velocity.magnitude < topSpeed) GetComponent<Rigidbody>().AddForce(movement * speed);

        if (transform.position.y < -3) Dead();
     
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bread")) Dead();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Jelly")) Main.NextLevel();
    }

    void Dead()
    {
        Instantiate(death, transform.position, Quaternion.identity);
        transform.position = spawn;
    }
}
