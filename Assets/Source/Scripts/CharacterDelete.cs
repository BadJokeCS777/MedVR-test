﻿using UnityEngine;
using UnityEngine.UI;

public class CharacterDelete : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        CharactersList.Instance.DeleteAll();
    }
}