using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
public class PlayerProfile{
    [field: SerializeField]
    public PostProcessProfile postProcessProfile{ get; private set; }

    [field: SerializeField]
    public GameObject model { get; private set; }

    [field: SerializeField]
    public Animator animator { get; private set; }

    [field: SerializeField]
    public float moveSpeed { get; private set; }
}