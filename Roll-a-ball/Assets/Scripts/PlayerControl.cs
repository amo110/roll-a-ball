using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int count;

	void Start ()
	{
		count = 0;
		SetCountText();
		winText.text = "";
	}
	void FixedUpdate ()
	{
		float moveHorisontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorisontal, 0.0f, moveVertical);


		GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "PickUp")
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText();
		}
	}
void SetCountText()
{
	countText.text = "count: " + count.ToString();
		if (count >= 20) {
			winText.text = "YOU WIN!";
		}
	}
}