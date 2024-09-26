using UnityEngine;
public interface IBulletLogic
{
    float ProjectileSpeed { get; }
    float ShootCooldown { get; }
    Sprite WeaponSprite { get; }
    AudioClip WeaponSound {  get; } 
    float RecoilAmount { get; }

}