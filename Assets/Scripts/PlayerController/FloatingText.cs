using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class FloatingText : MonoBehaviour {
    private Vector3 moveDirection;

    private float timer = 0;

    [SerializeField]
    private float _speed = 10f;

    [SerializeField]
    private float _fadeOutTime = 2f;

    [SerializeField]
    private TextMeshPro textMeshProUGUI;
    
    private Transform _mainCameraTransform;

    private void Start() {
        _mainCameraTransform = Camera.main.transform;
        moveDirection = new Vector3(Random.Range(-0.5f, 0.5f), 1, Random.Range(-0.5f, 0.5f)).normalized;
        textMeshProUGUI.DOFade(0, _fadeOutTime);
        Destroy(gameObject, 2.5f);
    }

    private void Update() {
        transform.position += moveDirection * (_speed * Time.deltaTime);
        timer += Time.deltaTime;
        transform.LookAt(transform.position + _mainCameraTransform.rotation * Vector3.forward, _mainCameraTransform.rotation * Vector3.up);
    }
}