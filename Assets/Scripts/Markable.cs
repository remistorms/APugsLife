using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Markable : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    public bool isMarked = false;
    [SerializeField] private Image fillImage;
    [SerializeField] private float amountToMark = 10;
    [SerializeField] private float markAmount = 0;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Color unmarkedColor, markedColor;
    public int pointsForMarking = 50;

    private void Awake()
    {
        fillImage.fillAmount = 0;
    }

    public void Mark(float _amount)
    {
        if(!isMarked)
        {
            markAmount += _amount;

            float percent = markAmount / amountToMark;
            fillImage.fillAmount = percent;

            meshRenderer.material.color = Color.Lerp(unmarkedColor, markedColor, percent);

            if (markAmount >= amountToMark)
            {
                markAmount = amountToMark;
                OnMarked();
            }
        }
         
    }

    private void OnMarked()
    {
        isMarked = true;
        canvasGroup.DOFade(0, 0.5f);
        GLOBAL.instance.m_Events.Fire_EVT_MarkedNewObject(this);
    }

}
