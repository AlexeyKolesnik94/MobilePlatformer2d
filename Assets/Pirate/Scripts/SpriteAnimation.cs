using System;
using UnityEngine;
using UnityEngine.Events;

namespace Pirate.Scripts {
    
    [RequireComponent(typeof(SpriteRenderer))]
    
    public class SpriteAnimation : MonoBehaviour {

        [SerializeField] private int frameRate;
        [SerializeField] private bool loop;
        [SerializeField] private Sprite[] sprites;
        [SerializeField] private UnityEvent onComplite;

        private SpriteRenderer _spriteRenderer;

        private float _secondsPerFrame;
        private float _nextFrameTime;
        private int _currentSpriteIndex;

        private void OnEnable() {
            _secondsPerFrame = 1f / frameRate;
            _nextFrameTime = Time.time + _secondsPerFrame;
            _currentSpriteIndex = 0;
        }

        private void Start() {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update() {
            if (_nextFrameTime > Time.time) return;

            if (_currentSpriteIndex >= sprites.Length) {
                if (loop) {
                    _currentSpriteIndex = 0;
                } else {
                    enabled = false;
                    onComplite?.Invoke();
                    return;
                }
            }
            
            _spriteRenderer.sprite = sprites[_currentSpriteIndex];
            _nextFrameTime += _secondsPerFrame;
            _currentSpriteIndex++;
        }
    }
}