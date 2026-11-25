using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeWeapon : Weapon {

    private float _attackRadius;
    private List<Entity> _foundTargetsBuffer;
    public void SetUpStats() {

    }
    public override void Shoot(Vector2 position) {

    }
}