using System;
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
    private float border = -5;
    private float hitpos = 0;
    private float depthBorder = -5;
    public float noteAcceptRange = 2;
    public bool alreadyPlayed = false;
    public bool autoPlay = false;
    private ResultCounter counterScript;

    void Start()
    {
        deathParticles = gameObject.GetComponent<ParticleSystem>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        counterScript = GameObject.Find("CounterManager").GetComponent<ResultCounter>();
    }

    void Update()
    {
        checkBorder();
        Move();
        checkKeyboard();
    }

    void completeNote()
    {
        alreadyPlayed = true;
        cameraAudioSource.PlayOneShot(noteSound);
        deathParticles.Play();
    }

    void checkKeyboard()
    {
        if (alreadyPlayed)
        {
            return;
        }

        float pressPrecision = Math.Abs(transform.position.z - hitpos);

        if (((pressPrecision < noteAcceptRange) &&
        ((noteNumberPos == 0 && Input.GetKeyDown(KeyCode.Z))
        || (noteNumberPos == 1 && Input.GetKeyDown(KeyCode.X))
        || (noteNumberPos == 2 && Input.GetKeyDown(KeyCode.C))
        || (noteNumberPos == 3 && Input.GetKeyDown(KeyCode.V))))
        || (autoPlay && transform.position.z - hitpos < 0.01))
        {
            if (pressPrecision < 0.5)
            {
                counterScript.perfectsCount++;
                counterScript.updatePerfectText();

            } else if (pressPrecision < 1.0) {
                counterScript.goodsCount++;
                counterScript.updateGoodText();
                
            } else
            {
                counterScript.okaysCount++;
                counterScript.updateOkayText();

            }
            completeNote();
        }
    }
    
    void Move()
    {
        if (alreadyPlayed)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed * deathAnimationSpeed);
        }
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void checkBorder()
    {
        if (transform.transform.position.z < border || transform.position.y < depthBorder)
        {
            if (!alreadyPlayed)
            {
                counterScript.missesCount++;
                counterScript.updateMissText();
            }
            Destroy(gameObject);
        }
    }
}
