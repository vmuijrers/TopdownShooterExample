public interface IDamageable
{   
    float Health { get; }
    void OnTakeDamage(float damage);
}