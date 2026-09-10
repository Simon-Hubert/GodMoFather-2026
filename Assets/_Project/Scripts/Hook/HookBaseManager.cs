using System;
using UnityEngine;

public class HookBaseManager : MonoBehaviour
{
    [SerializeField] private HookControllerHorizontal _controller;

    private Vector2 _origin;

    private void Start() {
        _origin = transform.position;
    }

    private void Update() {
        transform.position = _origin + _controller.Target * Vector2.right;
    }
}
