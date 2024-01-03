using System;
using DG.Tweening;
using Share;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor;
using TMPro;
using Zenject;

public class Note : MonoBehaviour, ICanUseItem, IInteraction
{
    [SerializeField, ValueDropdown(nameof(GetAllNoteKey))] private string key;

    [Header("Duration")]
    [SerializeField] private float moveDuration = 1f;
    [SerializeField] private float rotateDuration = 1f;

    [Header("UI")]
    [SerializeField] private UIViewData gameScreen = null;
    [SerializeField] private UIViewData noteScreen = null;
    [SerializeField] private TextMeshProUGUI noteText = null;

    public bool IsInstantInteraction => false;
    public bool IsOverrideButtonBack => false;

    public event Action OnInteractionComplete = null;
    public event Action OnRead = null;

    private NoteSettings noteSettings;
    private CollectedNotesSaver collectedNotesSaver;

    private GameObject target;
    private Transform playerCamera;

    [Inject]
    private void Construct(NoteSettings _noteSettings, CollectedNotesSaver _collectedNotesSaver, PlayerDatasForNote _playerDatasForNote)
    {
        noteSettings = _noteSettings;
        collectedNotesSaver = _collectedNotesSaver;

        target = _playerDatasForNote.Target();
        playerCamera = _playerDatasForNote.PlayerCamera();
    }

    private IEnumerable<string> GetAllNoteKey()
    {
        NoteSettings settings = AssetDatabase.LoadMainAssetAtPath("Assets/Data/Notes/NoteSettings.asset") as NoteSettings;
        return settings != null ? settings.GetAllKey() : null;
    }

    private void Start()
    {
        noteText.text = noteSettings.GetTextByKey(key);
    }

    public bool CanUseItem(ItemData _item, out string _description, out List<SpecificItem> _requiredItems, out bool _isShowUI)
    {
        _description = "Read document";
        _requiredItems = null;
        _isShowUI = true;

        return true;
    }

    public void StartInteraction(ItemData _currentItem)
    {
        transform.DOMove(target.transform.position, moveDuration);
        transform.DOLookAt(playerCamera.transform.position, rotateDuration);

        UIManager.ShowScreen(noteScreen);
    }

    public void FinishInteraction()
    {
        collectedNotesSaver.SaveNoteKey(key);

        gameObject.SetActive(false);
        UIManager.ShowScreen(gameScreen);

        OnInteractionComplete?.Invoke();
        OnRead?.Invoke();
    }
}