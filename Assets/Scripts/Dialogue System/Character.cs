using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Character : MonoBehaviour
{
    public string characterName;
    public Image imageRenderer;
    public RectTransform root;

    public Vector2 anchorPadding { get { return root.anchorMax - root.anchorMin; } } // Re-check the Stellar Studio VN Tutorial on this one when the time comes



    // Make functions to move characters to specified points
    Vector2 targetPosition;
    Coroutine moving;
    public bool isMoving { get { return moving != null; } }

    public void MoveTo(Vector2 target, float speed)
    {
        StopMoving();
        moving = StartCoroutine(Moving(target, speed));
    }

    public void StopMoving(bool arriveAtTargetPositionImmediately = false)
    {
        if (isMoving)
        {
            StopCoroutine(moving);
            if (arriveAtTargetPositionImmediately)
            {
                SetPosition(targetPosition);
            }
        }
        moving = null;
    }

    public void SetPosition(Vector2 target)
    {
        Vector2 padding = anchorPadding;
        float maxX = 1f - padding.x;
        float maxY = 1f - padding.y;

        Vector2 minAnchorTarget = new Vector2(maxX * targetPosition.x, maxY * targetPosition.y);

        root.anchorMin = minAnchorTarget;
        root.anchorMax = root.anchorMin + padding;
    }

    IEnumerator Moving(Vector2 target, float speed)
    {
        targetPosition = target;

        Vector2 padding = anchorPadding;
        float maxX = 1f - padding.x;
        float maxY = 1f - padding.y;

        Vector2 minAnchorTarget = new Vector2(maxX * targetPosition.x, maxY * targetPosition.y);
        speed *= Time.deltaTime;

        while (root.anchorMin != minAnchorTarget)
        {
            root.anchorMin = Vector2.MoveTowards(root.anchorMin, minAnchorTarget, speed);
            root.anchorMax = root.anchorMin + padding;
            yield return new WaitForEndOfFrame();
        }

        StopMoving();
    }



    // Make any animations and transitions as needed
}
