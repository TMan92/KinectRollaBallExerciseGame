using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    //[SerializeField] SoundManager soundManager;

    public Sprite BubbleSprite; // removed the m for all
    public Sprite BubbleSprite_1;
    public Sprite BubbleSprite_2;
    public Sprite PopSprite;

    [HideInInspector]
    //public BubbleManager mBubbleManager = null;
    public BubbleManager BubbleManager = null;

    /*
    private Vector3 mMovementDirection = Vector3.zero;
    private SpriteRenderer mSpriteRenderer = null;
    private Coroutine mCurrentChanger = null;
    */
    private Vector3 MovementDirection = Vector3.zero;
    private SpriteRenderer SpriteRenderer = null;
    private Coroutine CurrentChanger = null;

    private void Awake()
    {
       //mSpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        //mCurrentChanger = StartCoroutine(DirectionChanger());
        CurrentChanger = StartCoroutine(DirectionChanger());
    }

    private void OnBecameInvisible()
    {
        //transform.position = mBubbleManager.GetPlanePosition();
        transform.position = BubbleManager.GetPlanePosition();
    }

    private void Update()
    {
        // Movement
        //transform.position += mMovementDirection * Time.deltaTime * 0.35f;
        transform.position += MovementDirection * Time.deltaTime * 0.35f;

        // Rotation
        //transform.Rotate(Vector3.forward * Time.deltaTime * mMovementDirection.x * 20, Space.Self);
        transform.Rotate(Vector3.forward * Time.deltaTime * MovementDirection.x * 40, Space.Self);
    }

    public IEnumerator Pop()
    {
        //soundManager.PlaySound();

        SpriteRenderer.sprite = PopSprite;

        StopCoroutine(CurrentChanger);
        MovementDirection = Vector3.zero;

        yield return new WaitForSeconds(0.5f);

        transform.position = BubbleManager.GetPlanePosition();

        SpriteRenderer.sprite = BubbleSprite;
        CurrentChanger = StartCoroutine(DirectionChanger());

        SpriteRenderer.sprite = BubbleSprite_1;
        CurrentChanger = StartCoroutine(DirectionChanger());

        SpriteRenderer.sprite = BubbleSprite_2;
        CurrentChanger = StartCoroutine(DirectionChanger());

        /*
        mSpriteRenderer.sprite = mPopSprite;

        StopCoroutine(mCurrentChanger);
        mMovementDirection = Vector3.zero;

        yield return new WaitForSeconds(0.5f);

        transform.position = mBubbleManager.GetPlanePosition();

        mSpriteRenderer.sprite = mBubbleSprite;
        mCurrentChanger = StartCoroutine(DirectionChanger());

        mSpriteRenderer.sprite = mBubbleSprite_1;
        mCurrentChanger = StartCoroutine(DirectionChanger());

        mSpriteRenderer.sprite = mBubbleSprite_2;
        mCurrentChanger = StartCoroutine(DirectionChanger());

        */
    }

    private IEnumerator DirectionChanger()
    {
        while (gameObject.activeSelf)
        {
            //mMovementDirection = new Vector2(Random.Range(-100, 100) * 0.01f, Random.Range(0, 100) * 0.01f);
            MovementDirection = new Vector2(Random.Range(-100, 100) * 0.01f, Random.Range(0, 100) * 0.01f);

            yield return new WaitForSeconds(5.0f);
        }
    }
}
