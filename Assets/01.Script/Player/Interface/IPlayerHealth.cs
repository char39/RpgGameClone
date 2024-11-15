using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerHealth 
{
    void SetHealth(float health);

    void TakeDamage(float damage);
}
