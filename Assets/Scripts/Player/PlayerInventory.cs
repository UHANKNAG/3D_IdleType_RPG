using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<ItemObject> items;

    public void AddItem(ItemObject item)
    {
        foreach (var i in items)
        {
            if (i.itemName == item.itemName)
            {
                i.quantity++;
                return;
            }
        }

        item.quantity = 1;
        items.Add(item);
    }

    public void UseItem(ItemObject item)
    {
        string name = item.itemName;
        foreach (var i in items)
        {
            // 있을 때만 사용 가능
            if (i.itemName == name)
            {
                i.quantity--;

                switch (i.buffName)
                {
                    case "Heal":
                        Heal(i);
                        break;

                    case "Attack":
                        Attack(i);
                        break;

                    case "Speed":
                        Speed(i);
                        break;

                    default:
                        break;
                }

                if (i.quantity == 0)
                {
                    items.Remove(i);
                    return;
                }
            }
        }
    }
    
    void Heal(ItemObject item)
    {
        PlayerMediator.Instance.playerCondition.hp.curValue += item.buffAmount;
    }

    void Attack(ItemObject item)
    {
        StartCoroutine(AttackUp(item));
    }

    void Speed(ItemObject item)
    {
        StartCoroutine(SpeedUp(item));
    }

    private IEnumerator AttackUp(ItemObject item)
    {
        float duration = item.duration;
        float amount = item.buffAmount;

        PlayerMediator.Instance.playerStats.stats["Attack"].value += amount;
        
        yield return new WaitForSeconds(duration);
        
        PlayerMediator.Instance.playerStats.stats["Attack"].value -= amount;
    }
    
    private IEnumerator SpeedUp(ItemObject item)
    {
        float duration = item.duration;
        float amount = item.buffAmount;

        PlayerMediator.Instance.playerStateMachine.moveSpeed += amount;
        PlayerMediator.Instance.playerStats.stats["AttackCoolDown"].value /= 2f;
        
        yield return new WaitForSeconds(duration);
        
        PlayerMediator.Instance.playerStateMachine.moveSpeed -= amount;
        PlayerMediator.Instance.playerStats.stats["AttackCoolDown"].value *= 2f;
    }
}
