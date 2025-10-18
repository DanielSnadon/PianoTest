using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NoteSpawnerScript : MonoBehaviour
{
    private AudioSource cameraAudioSource;
    public int currentNoteNumber = 0;
    public bool isPlaying = false;
    public bool autoPlay = false;
    public TMP_InputField noteSheetInput;
    public TMP_InputField tempoInput;
    public TMP_InputField speedInput;
    public Slider pitchSlider;
    public Slider volumeSlider;
    public string currentNoteSheet;
    public GameObject notePrefab;
    public List<GameObject> cubePositions;
    private int noteNumberPos;
    private float currentSpeed = 1;
    private float tempo = 1;
    private float countdown;
    private string allNotes = "1!2@34$5%6^78*9(0qQwWeErtTyYuiIoOpPasSdDfgGhHjJklLzZxcCvVbBnm";
    public GameObject counterManager;
    private ResultCounter counterScript;
    void Start()
    {
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        counterScript = counterManager.GetComponent<ResultCounter>();
    }

    void Update()
    {
        if (isPlaying)
        {
            noteReader();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            startGame();
        }
    }

    public void noteReader()
    {
        countdown += Time.deltaTime;
        if (countdown > tempo && !(currentNoteNumber + 1 > currentNoteSheet.Length))
        {
            countdown = 0;
            char currentNoteChar = currentNoteSheet[currentNoteNumber++];

            if (currentNoteChar == '[')
            {
                while (currentNoteSheet[currentNoteNumber] != ']')
                {
                    currentNoteChar = currentNoteSheet[currentNoteNumber];
                    noteNumberPos = 3 - allNotes.IndexOf(currentNoteChar) % 12 / 3;
                    Vector3 notePos = cubePositions[noteNumberPos].transform.position;
                    spawnNote(currentNoteChar, currentSpeed, notePos);
                    currentNoteNumber++;
                }
            }
            else if (allNotes.Contains(currentNoteChar))
            {
                noteNumberPos = 3 - allNotes.IndexOf(currentNoteChar) % 12 / 3;
                Vector3 notePos = cubePositions[noteNumberPos].transform.position;
                spawnNote(currentNoteChar, currentSpeed, notePos);
            }
        }
        else if (currentNoteNumber + 1 > currentNoteSheet.Length)
        {
            isPlaying = false;
        }
    }

    public void spawnNote(char noteName, float speed, Vector3 pos)
    {
        GameObject newNote = Instantiate(notePrefab, pos, notePrefab.transform.rotation);
        NoteScript newNoteScript = newNote.GetComponent<NoteScript>();

        newNoteScript.noteSound = Resources.Load<AudioClip>($"Audio/Notes/{allNotes.IndexOf(noteName)}");

        if (newNoteScript.noteSound == null)
        {
            Debug.LogError("Не удалось загрузить звук ноты!");
            newNoteScript.noteSound = Resources.Load<AudioClip>("Audio/Notes/error");
        }

        newNoteScript.speed = speed;
        newNoteScript.noteName = noteName;
        newNoteScript.noteNumberPos = noteNumberPos;
        newNoteScript.autoPlay = autoPlay;
        counterScript.overall++;
        counterScript.updateOverallText();
    }

    public void fetchSheetInput()
    {
        currentNoteSheet = noteSheetInput.text;
    }

    public void fetchTempo()
    {
        tempo = 60 / float.Parse(tempoInput.text);
    }

    public void fetchSpeed()
    {
        currentSpeed = float.Parse(speedInput.text);
    }
    public void startGame()
    {
        counterScript.resetAllCounts();
        currentNoteNumber = 0;
        isPlaying = true;
    }

    public void changePitch()
    {
        cameraAudioSource.pitch = pitchSlider.value;
    }
    public void changeVolume()
    {
        cameraAudioSource.volume = volumeSlider.value;
    }

    public void enableAutoPilot()
    {
        autoPlay = !autoPlay;
    }
}
