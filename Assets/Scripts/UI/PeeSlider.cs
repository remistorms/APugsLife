using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeeSlider : MonoBehaviour
{
    private Slider peeSlider;
    private Marker markerRef;

    private void Start()
    {
        peeSlider = GetComponent<Slider>();
        markerRef = FindObjectOfType<Marker>();
        peeSlider.maxValue = markerRef.waterLevel;
    }

    private void Update()
    {
        peeSlider.value = markerRef.waterLevel;
    }
}
