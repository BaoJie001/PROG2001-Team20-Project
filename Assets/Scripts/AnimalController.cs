using UnityEngine;

public class AnimalController : MonoBehaviour
{
    
    public float moveDistance = 0.5f;
    
    public float rotateAngle = 45f;
    
    public float sizeStep = 0.2f;
    
    public float minSize = 0.5f;
    
    public float maxSize = 1.8f;

    private Vector3 startPosition;
    private Vector3 startScale;
    private Quaternion startRotation;

    void Start()
    {
        
        startPosition = transform.position;
        startScale = transform.localScale;
        startRotation = transform.rotation;
    }

    
    public void MoveLeft()
    {
        Vector3 newPos = transform.position + Vector3.left * moveDistance;
        newPos.x = Mathf.Clamp(newPos.x, -4.5f, 4.5f);
        transform.position = newPos;
    }

    
    public void MoveRight()
    {
        Vector3 newPos = transform.position + Vector3.right * moveDistance;
        newPos.x = Mathf.Clamp(newPos.x, -4.5f, 4.5f);
        transform.position = newPos;
    }

    
    public void RotateLeft()
    {
        transform.Rotate(0, -rotateAngle, 0);
    }

    
    public void RotateRight()
    {
        transform.Rotate(0, rotateAngle, 0);
    }

    
    public void Grow()
    {
        Vector3 newScale = transform.localScale + Vector3.one * sizeStep;
        if (newScale.x <= maxSize)
        {
            transform.localScale = newScale;
        }
    }

    
    public void Shrink()
    {
        Vector3 newScale = transform.localScale - Vector3.one * sizeStep;
        if (newScale.x >= minSize)
        {
            transform.localScale = newScale;
        }
    }

    
    public void ResetAnimal()
    {
        transform.position = startPosition;
        transform.localScale = startScale;
        transform.rotation = startRotation;
    }
}