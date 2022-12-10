using UnityEngine;

public class FirstPersonCamera {
    private Transform _cameraTransform;
    private Transform _playerTransform;
    private float _mouseSens;
    
    private float _mouseX;
    private float _mouseY;
    private Vector3 _angle;

    public FirstPersonCamera(Transform cameraTransform,Transform playerTransform, float mouseSens) {
        _cameraTransform = cameraTransform;
        _playerTransform = playerTransform;
        _mouseSens = mouseSens;
    }

    public void RotateCamera() {
        RotateCameraByY();
        RotatePlayerTransformAndCameraByX();

    }

    private void RotatePlayerTransformAndCameraByX() {
        _mouseY = Input.GetAxis("Mouse X") * _mouseSens;
        _playerTransform.Rotate(Vector3.up * _mouseY);
    }

    private void RotateCameraByY() {
        _mouseX = Input.GetAxis("Mouse Y");
        Debug.Log(_cameraTransform.localRotation.eulerAngles.x);
        if (_cameraTransform.localRotation.eulerAngles.x < 273 && _cameraTransform.localRotation.eulerAngles.x > 250)
        {            
            _mouseX = Mathf.Clamp(_mouseX, -1, 0);
        }
        if (_cameraTransform.localRotation.eulerAngles.x > 39 && _cameraTransform.localRotation.eulerAngles.x < 100)
        {            
            _mouseX = Mathf.Clamp(_mouseX, 0, 1);
        }        
        _angle = new Vector3(-_mouseX * _mouseSens, 0, 0);
        _cameraTransform.Rotate(_angle);
    }
}