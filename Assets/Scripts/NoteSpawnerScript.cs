using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NoteSpawnerScript : MonoBehaviour
{
    public int currentNoteNumber = 0;
    public char currentNoteChar;
    public bool isPlaying;
    public float countdown;
    public TMP_InputField noteList;
    public string currentNoteSheet;
    public GameObject notePrefab;
    public List<GameObject> cubePositions;
    public float tempo = 1;
    public float currentSpeed;
    private string allNotes = "1!2@34$5%6^78*9(0qQwWeErtTyYuiIoOpPasSdDfgGhHjJklLzZxcCvVbBnm";
    void Start()
    {

    }

    void Update()
    {
        if (isPlaying)
        {
            noteReader();
        }
    }
    public void fetchSheetInput()
    {
        currentNoteSheet = noteList.text;
        currentNoteNumber = 0;
        isPlaying = true;
    }
    public void noteReader()
    {
        countdown += Time.deltaTime;
        if (countdown > tempo && !(currentNoteNumber + 1 > currentNoteSheet.Length))
        {
            countdown = 0;
            currentNoteChar = currentNoteSheet[currentNoteNumber++];
            if (currentNoteChar == '[')
            {
                while (currentNoteSheet[currentNoteNumber] != ']')
                {
                    currentNoteChar = currentNoteSheet[currentNoteNumber];
                    Vector3 notePos = cubePositions[allNotes.IndexOf(currentNoteChar) % 12 / 3].transform.position;
                    spawnNote(currentNoteChar, currentSpeed, notePos);
                    currentNoteNumber++;
                }
            }
            else if (allNotes.Contains(currentNoteChar))
            {
                Vector3 notePos = cubePositions[3 - allNotes.IndexOf(currentNoteChar) % 12 / 3].transform.position;
                spawnNote(currentNoteChar, currentSpeed, notePos);
            }
            else if (currentNoteChar == '|')
            {
                countdown = -tempo;
            }
            else if (currentNoteChar == '-')
            {
                countdown = tempo / 2;
            }
            else if (currentNoteChar == '\n')
            {
                countdown = -tempo / 2;
            }
            else
            {
                countdown = 0;
            }

        }
        else if (currentNoteNumber + 1 > currentNoteSheet.Length)
        {
            isPlaying = false;
        }
    }

    public void spawnNote(char NoteName, float speed, Vector3 pos)
    {
        GameObject newNote = Instantiate(notePrefab, pos, notePrefab.transform.rotation);
        NoteScript newNoteScript = newNote.GetComponent<NoteScript>();
        newNoteScript.speed = speed;
        newNoteScript.noteName = NoteName;
    }
}
