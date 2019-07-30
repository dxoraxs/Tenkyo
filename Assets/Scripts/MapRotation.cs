using UnityEngine;

public class MapRotation : MonoBehaviour
{
    private Quaternion _cameraPosition;
    private Transform _transform;
    private bool _isRotation;
    private Vector2 _lastTouchPosition;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _cameraPosition = _transform.rotation;
        //Debug.Log(_transform.rotation.GetType());
    }
    
    void Update()
    {
        if (!_isRotation) return;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _lastTouchPosition = touch.position;
                    break;
                case TouchPhase.Moved:
                    float _distanceTouch = Vector2.Distance(_lastTouchPosition, touch.position) / 500;
                    if (_lastTouchPosition.y - touch.position.y > 10 && _cameraPosition.x > -90) _cameraPosition.x -= _distanceTouch;
                    else if (_lastTouchPosition.y - touch.position.y < -10 && _cameraPosition.x < 90)  _cameraPosition.x += _distanceTouch;


                    if (_lastTouchPosition.x - touch.position.x > 10 && _cameraPosition.z < 90) _cameraPosition.z += _distanceTouch;
                    else if (_lastTouchPosition.x - touch.position.x < -10 && _cameraPosition.z > -90) _cameraPosition.z -= _distanceTouch;

                    _lastTouchPosition = touch.position;

                    break;
            }
        }
#region MonoBehaviour
        if (Input.GetKey(KeyCode.D))
        {
            _cameraPosition.z -= 0.005f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _cameraPosition.z += 0.005f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            _cameraPosition.x += 0.005f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _cameraPosition.x -= 0.005f;
        }
#endregion
    }

    private void FixedUpdate()
    {
        if (_isRotation) MoveRamp();
    }

    void MoveRamp()
    {
        _transform.localRotation = Quaternion.Lerp(_transform.localRotation, _cameraPosition, Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Rigidbody>().velocity = other.GetComponent<Rigidbody>().velocity / 2;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            _isRotation = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isRotation = false;
        }
    }
}