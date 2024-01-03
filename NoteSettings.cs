using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "NoteSettings", menuName = "Notes/NoteSettings")]
public class NoteSettings : ScriptableObject
{
    public List<NoteData> noteDatas = new List<NoteData>();

    public IEnumerable<string> GetAllKey()
    {
        return noteDatas.Select(noteDatas => noteDatas.key);
    }

    public string GetTextByKey(string _key)
    {
        return noteDatas.Find(_x => _x.key == _key).textOfNote;
    }
}