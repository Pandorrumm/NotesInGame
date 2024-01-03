using UnityEngine;
using UnityEngine.UI;

public class NoteButton : MonoBehaviour
{
    [SerializeField] private Text title = null;

    private NoteInfo noteInfo;
    private string description;

    public void Init(string _title, string _description, NoteInfo _noteInfo)
    {
        title.text = _title;
        noteInfo = _noteInfo;
        description = _description;
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowInfo);
    }

    private void ShowInfo()
    {
        noteInfo.Init(description);
    }
}