using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeWeapon : Weapon {

    public float AttackRadius;
    public Team EnemyTeam;
    public float DamageAmount;
    public LayerMask AttackLayer;

    private List<Entity> _foundTargetsBuffer = new();
    private Collider2D[] _foundCollidersBuffer = new Collider2D[64];

    public void SetUpStats(float damageAmount, float attackRadius, Team enemiesTeam, LayerMask attackLayer) {
        DamageAmount = damageAmount;
        AttackRadius = attackRadius;
        EnemyTeam = enemiesTeam;
        AttackLayer = attackLayer;
    }


    public override void Shoot(Vector2 position) {
        _foundCollidersBuffer = Physics2D.OverlapCircleAll(position, AttackRadius, AttackLayer);
        FillTargetsBuffer();

        DealEffects();

        ClearLists();
    }


    private void DealEffects() {
        foreach (var e in _foundTargetsBuffer) {
            //e.TakeDamage(DamageAmount);

        }
    }
    private void FillTargetsBuffer() {
        foreach (var c in _foundCollidersBuffer) {
            if (c.TryGetComponent<Entity>(out var e) == false)
                continue;

            //if (e.Team != EnemyTeam)
            //    continue;

            _foundTargetsBuffer.Add(e);
        }
    }
    private void ClearLists() {
        for (int i = 0; i < _foundTargetsBuffer.Count; i++) {
            _foundCollidersBuffer[i] = null;
        }
        _foundTargetsBuffer.Clear();
    }
}