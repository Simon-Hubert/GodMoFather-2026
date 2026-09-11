using System;
using UnityEngine;
using UnityEngine.VFX;

public class VFXHandler : MonoBehaviour
{
    [SerializeField] private VisualEffect _wow;
    [SerializeField] private VisualEffect _wizz;
    
    private void OnEnable() {
        Object.OnScored += Play;
    }

    private void OnDisable() {
        Object.OnScored -= Play;
    }
    
    private void Play(ScoreEvent obj) {
        switch (obj.threshold) {
            case 0:
                _wow?.Play();
                break;
            case 2:
                _wizz?.Play();
                break;
        }
    }
}
