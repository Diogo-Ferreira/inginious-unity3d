using UnityEngine;

public class firecamp_light : MonoBehaviour
{
    public float minIntensity = 0.25f;
    public float maxIntensity = 0.5f;

    public Light fireLight;

    float random;

    void Update()
    {
        random = Random.Range(0.0f, 350.0f);
        float noise = Mathf.PerlinNoise(random, Time.time);
        fireLight.GetComponent<Light>().intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
    }
}