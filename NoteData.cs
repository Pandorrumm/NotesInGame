using UnityEngine;

[CreateAssetMenu(fileName = "Note", menuName = "Notes/NoteData")]
public class NoteData : ScriptableObject
{
    public string key;

    [Space]
    [Multiline] public string textOfNote;
}