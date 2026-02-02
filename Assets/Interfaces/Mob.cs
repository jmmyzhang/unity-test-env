using UnityEngine;

public interface Mob {
    
    public float Damage { set; get; }
    public float KnockbackForce { set; get; }
    public float MoveSpeed { set; get; }
    public void OnCollisionEnter2D(Collision2D col);

}