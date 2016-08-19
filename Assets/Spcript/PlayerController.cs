using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody rb;

	private int count;


	public Text countTest;
	public Text winText;


	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		sestCountText ();
		winText.text = "";

	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal"); 
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);

		rb.AddForce (movement * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
//		Destroy(other.gameObject);

		if (other.gameObject.CompareTag("PickUp")) {
			other.gameObject.SetActive (false);
			count++;
			sestCountText ();
		}

	}

	void sestCountText(){
		countTest.text = "count:" + count.ToString();
		if (count >= 12)
		{
			winText.text = "You Win! angela 你恁能 你咋不飞啊！~ ";
		}
	}
}
