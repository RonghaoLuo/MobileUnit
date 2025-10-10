using UnityEngine;

public class TouchTest : MonoBehaviour
{
    [SerializeField] private Vector2 startPos, endPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startPos = Input.GetTouch(0).position;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endPos = Input.GetTouch(0).position;

                Debug.Log(endPos.normalized - startPos.normalized);

                startPos = Vector2.zero;
                endPos = Vector2.zero;
            }

        }
        
    }
}
