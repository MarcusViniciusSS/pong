using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMovement : MonoBehaviour
{
    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;

    private int hitcounter = 0;
    private Rigidbody2D _rigidbody2D;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    public IEnumerator Launch()
    {
        hitcounter = 0;
        yield return new WaitForSeconds(1);

        Move(new Vector2(Random.Range(-2, 2), 0));
    }
    
    public void Move(Vector2 direction)
    {
        direction = direction.normalized;
        var ballSpeed = startSpeed + hitcounter * extraSpeed;

        _rigidbody2D.velocity = direction * ballSpeed;
    }

    public void IncreaseHit()
    {
        if (hitcounter * extraSpeed > maxExtraSpeed)
            return;

        hitcounter++;
    }
}
