using System.Collections.Generic;
using UnityEngine;

public class CollectedNotesSaver : MonoBehaviour
{
    public List<string> collectedNoteKeys = new List<string>();

    public void SaveNoteKey(string _key)
    {
        collectedNoteKeys.Add(_key);
    }

    public List<string> GetAllKeys()
    {
        List<string> keys = new List<string>();

        for (int i = 0; i < collectedNoteKeys.Count; i++)
        {
            keys.Add(collectedNoteKeys[i]);
        }

        return keys;
    }

    public bool IsThereAreSavedKeys()
    {
        return collectedNoteKeys.Count > 0;
    }
}
