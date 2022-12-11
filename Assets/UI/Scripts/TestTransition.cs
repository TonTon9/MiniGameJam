using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestTransition : MonoBehaviour
{
    [SerializeField] public Animator _animator;
    [SerializeField] public GameObject _sceneTrasition;

    private void Start()
    {
      
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // public void EndAnimation()
    // {
    //     _animator.SetTrigger("endScene");
    // }
    //
    // public void StartAnimation()
    // {
    //     _animator.SetTrigger("startScene");
    // }
}
