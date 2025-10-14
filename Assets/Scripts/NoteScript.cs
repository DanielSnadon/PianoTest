using NUnit.Framework.Internal;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class NoteScript : MonoBehaviour
{
    private AudioSource cameraAudioSource;
    private ParticleSystem deathParticles;
    public AudioClip noteSound;
    public float speed = 0.1f;
    public char noteName = '0';
    public int noteNumberPos = 0;
    public float deathAnimationSpeed = 0.2f;    
    private float border = -15;
    private float hitpos = -7;
    private float depthBorder = -5;
    private bool alreadyPlayed = false;

    void Start()
    {
        deathParticles = gameObject.GetComponent<ParticleSystem>();
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
        deathParticles.Play();
        alreadyPlayed = true;
    }

    void checkKeyboard()
    {
        if (!alreadyPlayed && Input.anyKeyDown && (transform.position.z - hitpos) < 2)
        {
            if ((noteNumberPos == 0 && Input.GetKeyDown(KeyCode.Z))
            || (noteNumberPos == 1 && Input.GetKeyDown(KeyCode.X))
            || (noteNumberPos == 2 && Input.GetKeyDown(KeyCode.C))
            || (noteNumberPos == 3 && Input.GetKeyDown(KeyCode.V)))
            {
                completeNote();
            }
        }
    }
    
    void Move()
    {
        if (!alreadyPlayed)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed * deathAnimationSpeed);
            if (transform.position.y < depthBorder)
            {
                Destroy(gameObject);
            }
        }
        
    }

    void checkBorder()
    {
        if (transform.transform.position.z < border)
        {
            Destroy(gameObject);
        }
    }
}
