using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvas : MonoBehaviour
{
    [SerializeField] private RectTransform rect;
    Transform camTransform;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        camTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        rect.rotation = camTransform.rotation;
    }
}
