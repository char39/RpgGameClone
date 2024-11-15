using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iaihp
{
    // 체력을 설정하는 메서드
    void SetHealth(float health);

    // 현재 체력을 가져오는 메서드
    float GetHealth();

    // 데미지를 받는 메서드
    void TakeAttackDamage(float damage);

    // 공격력 설정 메서드
    void SetAttackDamage(float damage);

    // 공격력 가져오는 메서드
    float GetAttackDamage();

    float TakeSkillDamage(float damafge, float slow);
}
