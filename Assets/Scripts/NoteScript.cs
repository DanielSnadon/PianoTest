using Unity.VisualScripting;
using UnityEngine;
public class NoteScript : MonoBehaviour
{
    private AudioSource cameraAudioSource;
    public AudioClip noteSound;
    public float speed = 0.1f;
    public char noteName = '0';
    public int noteNumberPos = 0;
    
    private float border = -15;
    private float hitpos = -7;

    void Start()
    {
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();

    }

    void Update()
    {
        checkBorder();
        Move();
        checkKeyboard();
    }

    void OnMouseDown()
    {
        completeNote();
    }

    void completeNote()
    {
        cameraAudioSource.PlayOneShot(noteSound);
        Destroy(gameObject);
    }

    void checkKeyboard()
    {
        if (Input.anyKeyDown && (transform.position.z - hitpos) < 3)
        {
            if ((noteNumberPos == 0 && Input.GetKeyDown(KeyCode.LeftArrow))
            || (noteNumberPos == 1 && Input.GetKeyDown(KeyCode.DownArrow))
            || (noteNumberPos == 2 && Input.GetKeyDown(KeyCode.UpArrow))
            || (noteNumberPos == 3 && Input.GetKeyDown(KeyCode.RightArrow)))
            {
                completeNote();
            }
        }
    }
    
    void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void checkBorder()
    {
        if (transform.transform.position.z < border)
        {
            Destroy(gameObject);
        }
    }
}
