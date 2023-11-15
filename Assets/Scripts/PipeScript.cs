using System.Collections;
using UnityEngine;

public class PipeScript : MonoBehaviour {

    [SerializeField]
    private string animalTag;      //ref to specific tag object to allow collide with specific pipe
    private bool moving = false;   //this for the lerp which happen when the pipe moves on tapping

    private AudioSource sound;    //audio source variable
    public AudioClip[] clips; //0 for points, 1 of end
    // Use this for initialization
    void Start ()
    {
        //audio source component assigned to the variable
        sound = GetComponent<AudioSource>();
    }
	
	void Update ()
    {
        //when the pipe moves beyond limits its transfers
        //well it means when the pipe moves to extreme right its transformed to left
        if (transform.position.x > 5.25f)
        {
            transform.position = new Vector3(-5.25f, transform.position.y);
        }

        if (transform.position.x < -5.25f)
        {
            transform.position = new Vector3(5.25f, transform.position.y);
        }
    }

    //this detects the object colliding the pipe
    void OnTriggerEnter2D(Collider2D other)
    {
        //if the tag of colliding object is equal to allowed object
        if (other.CompareTag(animalTag))
        {
            //we increase score, play pipe animation
            sound.PlayOneShot(clips[0]);
            other.gameObject.SetActive(false);
            transform.GetChild(0).GetComponent<PipeAnim>().playAnim = true;
            GameManager.instance.currentScore++;
        }
        else
        {
            //gameover
            sound.PlayOneShot(clips[1]);
            GameManager.instance.isGameOver = true;
            //some camera shake
            CameraShake.instance.ShakeCamera(0.05f, 1f);
        }
    }

    //here we lerp pipe from last pos to new pos in right direction
    public void MoveRight()
    {
        Vector3 lastPos = transform.position;
        Vector3 newPos = new Vector3(lastPos.x + 1.5f, lastPos.y);

        StartCoroutine(MoveFromTo(lastPos, newPos, 0.2f));
    }

    public void MoveLeft()
    {
        Vector3 lastPos = transform.position;
        Vector3 newPos = new Vector3(lastPos.x - 1.5f, lastPos.y);

        StartCoroutine(MoveFromTo(lastPos, newPos, 0.2f));
    }

    //lerp method
    IEnumerator MoveFromTo(Vector3 pointA, Vector3 pointB, float time)
    {
        if (!moving)
        {                     // Do nothing if already moving
            moving = true;                 // Set flag to true
            float t = 0f;
            while (t < 1.0f)
            {
                t += Time.deltaTime / time; // Sweeps from 0 to 1 in time seconds
                transform.position = Vector3.Lerp(pointA, pointB, t);
                yield return 0;
            }
            moving = false;             // Finished moving
        }
    }
}
