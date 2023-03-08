using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    /*
    public GameObject mBubblePrefab;
    public GameObject mBubblePrefab_1;
    public GameObject mBubblePrefab_2;

    private List<Bubble> mAllBubbles = new List<Bubble>();
    private Vector2 mBottomLeft = Vector2.zero;
    private Vector2 mTopRight = Vector2.zero;
    */

    public GameObject BubblePrefab;
    public GameObject BubblePrefab_1;
    public GameObject BubblePrefab_2;

    private List<Bubble> AllBubbles = new List<Bubble>();
    private Vector2 BottomLeft = Vector2.zero;
    private Vector2 TopRight = Vector2.zero;

    private void Awake()
    {
        // Bounding values
        //mBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane));
        //mTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight / 2, Camera.main.farClipPlane));

        BottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane));
        TopRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight / 2, Camera.main.farClipPlane));
    }

    private void Start()
    {
        StartCoroutine(CreateBubbles());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane)), 0.5f);
        Gizmos.DrawSphere(Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, Camera.main.farClipPlane)), 0.5f);
    }

    public Vector3 GetPlanePosition()
    {
        // Random Position
        //float targetX = Random.Range(mBottomLeft.x, mTopRight.x);
        //float targetY = Random.Range(mBottomLeft.y, mTopRight.y);

        float targetX = Random.Range(BottomLeft.x, TopRight.x);
        float targetY = Random.Range(BottomLeft.y, TopRight.y);

        return new Vector3(targetX, targetY, 0);
    }

    private IEnumerator CreateBubbles()
    {
        while (AllBubbles.Count < 40)
        {
            // Create and add bubbles
            /*
            GameObject newBubbleObject = Instantiate(mBubblePrefab, GetPlanePosition(), Quaternion.identity, transform);
            Bubble newBubble = newBubbleObject.GetComponent<Bubble>();

            GameObject newBubbleObject_1 = Instantiate(mBubblePrefab_1, GetPlanePosition(), Quaternion.identity, transform);
            Bubble newBubble_1 = newBubbleObject_1.GetComponent<Bubble>();

            GameObject newBubbleObject_2 = Instantiate(mBubblePrefab_2, GetPlanePosition(), Quaternion.identity, transform);
            Bubble newBubble_2 = newBubbleObject_2.GetComponent<Bubble>();

            // Setup bubble
            newBubble.mBubbleManager = this;
            mAllBubbles.Add(newBubble);

            newBubble_1.mBubbleManager = this;
            mAllBubbles.Add(newBubble_1);

            newBubble_1.mBubbleManager = this;
            mAllBubbles.Add(newBubble_2);

            yield return new WaitForSeconds(0.5f);
            */
            GameObject newBubbleObject = Instantiate(BubblePrefab, GetPlanePosition(), Quaternion.identity, transform);
            Bubble newBubble = newBubbleObject.GetComponent<Bubble>();

            GameObject newBubbleObject_1 = Instantiate(BubblePrefab_1, GetPlanePosition(), Quaternion.identity, transform);
            Bubble newBubble_1 = newBubbleObject_1.GetComponent<Bubble>();

            GameObject newBubbleObject_2 = Instantiate(BubblePrefab_2, GetPlanePosition(), Quaternion.identity, transform);
            Bubble newBubble_2 = newBubbleObject_2.GetComponent<Bubble>();

            // Setup bubble
            newBubble.BubbleManager = this;
            AllBubbles.Add(newBubble);

            newBubble_1.BubbleManager = this;
            AllBubbles.Add(newBubble_1);

            newBubble_2.BubbleManager = this;
            AllBubbles.Add(newBubble_2);

            yield return new WaitForSeconds(0.5f);
        }
    }
}
