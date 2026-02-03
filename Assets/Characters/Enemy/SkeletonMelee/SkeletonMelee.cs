using UnityEngine;

public class SkeletonMelee : MonoBehaviour
{

    bool Moving {
        set {
            _moving = value;
            animator.SetBool("moving", _moving);
        }
        get {
            return _moving;
        }
    }
    
    public float moveSpeed = 500f;
    public GameObject attackHitbox;
    public DetectionZone detectionZone;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    DamageableCharacter damageableCharacter;
    Collider2D attackCollider;

    bool _moving = false;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        damageableCharacter = GetComponent<DamageableCharacter>();
        attackCollider = attackHitbox.GetComponent<Collider2D>();
    }

    void FixedUpdate(){
        if (damageableCharacter.Targetable && detectionZone.detectedObjects.Count > 0) {
            Vector2 direction = (detectionZone.detectedObjects[0].transform.position - transform.position).normalized;
            rb.AddForce(direction * moveSpeed * Time.deltaTime);
            if (direction.x > 0) {
                spriteRenderer.flipX = false;
            } else {
                spriteRenderer.flipX = true;
            }
            Moving = true;
        } else {
            Moving = false;
        }
    }

}
