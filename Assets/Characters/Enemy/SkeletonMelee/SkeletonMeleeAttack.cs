using UnityEngine;

public class SkeletonMeleeAttack : MonoBehaviour
{
    
    public float damage = 2f;
    public float knockbackForce = 15f;
    public Collider2D swordCollider;
    
    
    void Start() {
        if (swordCollider == null) {
            Debug.LogWarning("Sword Collider not set");
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        IDamageable damageableObject = (IDamageable) collision.collider.GetComponent<IDamageable>();
    }

}
