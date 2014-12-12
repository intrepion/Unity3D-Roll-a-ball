using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    private int count;

    void Start ()
    {
        count = 0;
        SetCountText ();
        winText.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidbody.AddForce (movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter (Collider other)
    {
        if ("PickUp" == other.gameObject.tag) {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText ();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (12 <= count) {
            winText.text = "You Win!";
        }
    }
}
