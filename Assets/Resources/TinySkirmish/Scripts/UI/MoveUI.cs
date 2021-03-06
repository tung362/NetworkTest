﻿using UnityEngine;
using System.Collections;

public class MoveUI : MonoBehaviour
{
    public bool Toggle = false;
    public Vector3 Target = Vector3.zero;
    public float Speed = 1000;

    private Vector3 PreviousPosition;

    [Header("Chain Reaction")]
    public MoveUI[] TriggeredObjects;
    public float TriggerAtDistance = 0;

    private bool RunOnce = true;

    private RectTransform TheRectTransform;

    void Start()
    {
        TheRectTransform = GetComponent<RectTransform>();
        PreviousPosition = TheRectTransform.anchoredPosition3D;
    }

    void Update()
    {
        if (!Toggle) return;
        TheRectTransform.anchoredPosition = Vector3.MoveTowards(TheRectTransform.anchoredPosition, Target, Speed * Time.deltaTime);

        if(TriggeredObjects.Length > 0 && RunOnce)
        {
            float distance = Vector3.Distance(TheRectTransform.anchoredPosition3D, Target);
            if(distance <= TriggerAtDistance)
            {
                foreach(MoveUI obj in TriggeredObjects) obj.Toggle = true;
                RunOnce = false;
            }
        }
    }

    public void Reset()
    {
        RunOnce = true;
        Toggle = false;
        TheRectTransform.anchoredPosition3D = PreviousPosition;
    }

    public void ToggleTrueFalse()
    {
        Toggle = !Toggle;
    }
}
