using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippingPlatform : MonoBehaviour
{
    [SerializeField] private float flipDelay = 1f;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Flip());
    }

    private void Update()
    {
        if (Mathf.Abs(transform.rotation.z) == 180)
        {

        }
    }

    private IEnumerator Flip()
    {
        yield return new WaitForSeconds(flipDelay * 0.75f);
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(flipDelay * 0.25f);
        transform.Rotate(new Vector3(0, 0, -180f));
    }
}
