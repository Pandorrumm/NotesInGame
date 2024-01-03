using TMPro;
using UnityEngine;
using Zenject;

public class NoteView : MonoBehaviour
{
    [SerializeField] private NoteInfo noteInfo = null;

    [Space]
    [SerializeField] private NoteButton noteButtonPrefab = null;
    [SerializeField] private Transform parent = null;

    private CollectedNotesSaver collectedNotesSaver;
    private NoteSettings noteSettings;

    [Inject]
    private void Construct(NoteSettings _noteSettings, CollectedNotesSaver _collectedNotesSaver)
    {
        noteSettings = _noteSettings;
        collectedNotesSaver = _collectedNotesSaver;
    }

    private void OnEnable()
    {
        CreateNoteButtons();
    }

    private void CreateNoteButtons()
    {
        if (collectedNotesSaver.IsThereAreSavedKeys())
        {
            for (int i = parent.childCount; i < collectedNotesSaver.GetAllKeys().Count; i++)
            {
                NoteButton noteButton = Instantiate(noteButtonPrefab, parent);
                noteButton.Init(collectedNotesSaver.GetAllKeys()[i], noteSettings.GetTextByKey(collectedNotesSaver.GetAllKeys()[i]), noteInfo);
            }
        }
    }
}