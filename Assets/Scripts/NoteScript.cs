using UnityEngine;
public class NoteScript : MonoBehaviour
{
    private AudioSource cameraAudioSource;
    public AudioClip NoteSound;
    public float speed = 0.1f;
    public char noteName = '0';
    private string allNotes = "1!2@34$5%6^78*9(0qQwWeErtTyYuiIoOpPasSdDfgGhHjJklLzZxcCvVbBnm";
    void Start()
    {
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        NoteSound = Resources.Load<AudioClip>($"Audio/Notes/{allNotes.IndexOf(noteName)}");

        if (NoteSound == null)
        {
            Debug.LogError("Не удалось загрузить звук ноты!");
            NoteSound = Resources.Load<AudioClip>("Audio/Notes/error");
        }

    }

    void Update()
    {
        if (transform.transform.position.z < -15)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnMouseDown()
    {
        cameraAudioSource.PlayOneShot(NoteSound);
        Destroy(gameObject);
    }
}
