using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualisor : MonoBehaviour
{
    public float minHeight = 1.0f;       // Minimum scale on the y-axis
    public float maxHeight = 10.0f;      // Maximum scale on the y-axis
    public float updateSpeed = 0.1f;    // Speed of scaling
    public int band = 0;                // Audio frequency band to visualize

    private AudioSource audioSource;
    private Material material;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        // Get the spectrum data from the audio source
        float[] spectrumData = new float[256];
        audioSource.GetSpectrumData(spectrumData, band, FFTWindow.BlackmanHarris);

        // Calculate the average amplitude from the spectrum data
        float averageAmplitude = 0f;
        for (int i = 0; i < spectrumData.Length; i++)
        {
            averageAmplitude += spectrumData[i];
        }
        averageAmplitude /= spectrumData.Length;

        // Scale the cube based on the average amplitude
        float newScale = Mathf.Lerp(minHeight, maxHeight, averageAmplitude);
        Vector3 newScaleVector = new Vector3(transform.localScale.x, newScale, transform.localScale.z);
        transform.localScale = Vector3.Lerp(transform.localScale, newScaleVector, Time.deltaTime * updateSpeed);

        // Change the color based on the amplitude
        Color newColor = Color.Lerp(Color.black, Color.white, averageAmplitude);
        material.color = newColor;
    }
}
