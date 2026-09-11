using System;
using UnityEngine;

public class IsHovered : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    
    private void OnEnable() {
        ScratchingController._onExitShape += OnExitShape;
    }

    private void OnDisable() {
        ScratchingController._onExitShape -= OnExitShape;
    }
    
    private void OnExitShape() {
        _source.Stop();
    }

    public void OnEnterShape() {
        _source.Stop();
        _source.Play();
    }
}
