using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Bird : MonoBehaviour
{
    Vector3 _initialPosition;
    bool _launched;
    float _sittingTime;
    public bool idle;


    [SerializeField] float _launchPower = 100;

    private void Awake()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);

        if (_launched &&
            GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1)
        {
            _sittingTime += Time.deltaTime;
        };

        if (
        transform.position.y < -100 ||
        transform.position.x > 30 ||
        _sittingTime > 3
            )
        {
            this.idle = true;
        }
    }

    private void OnMouseDown()
    {      if (!_launched){
        GetComponent<LineRenderer>().enabled = true;
      }
    }

    private void OnMouseUp()
    {
      if (!_launched){
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition * _launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _launched = true;
        GetComponent<LineRenderer>().enabled = false;
      }

    }

    private void OnMouseDrag()
    {
        var newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (newPosition.x < _initialPosition.x) {
        transform.position = new Vector3(newPosition.x, newPosition.y);
      }
    }
}
