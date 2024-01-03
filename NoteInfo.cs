using TMPro;
using UnityEngine;

public class NoteInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI description = null;

    private void OnEnable()
    {
        description.text = "";
    }

    public void Init(string _description)
    {
        description.text = _description;
    }
}
