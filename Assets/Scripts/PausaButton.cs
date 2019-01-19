using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaButton : MonoBehaviour
{
    bool active;
    public Canvas canvas;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    void Start()
    {
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Press()
    {
        active = !active;
        canvas.enabled = active;
        Time.timeScale = (active) ? 0 : 1f;
    }
}
