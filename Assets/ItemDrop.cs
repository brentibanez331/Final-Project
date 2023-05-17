using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject expLoot;

    [SerializeField] int minDrops;
    [SerializeField] private int maxDrops;
    [SerializeField] float experienceValue;

    ExpLoot exp;

    int drops;

    private float spread = 10;

    private void Start()
    {
        exp = expLoot.GetComponent(typeof(ExpLoot)) as ExpLoot;        
    }

    public void DropLoot()
    {
        exp.SetExpValue(experienceValue);

        drops = Random.Range(minDrops, maxDrops);

        for(int i = 0; i < drops; i++)
        {
            Vector3 newRotation = new Vector3(0f, 0f, Random.Range(-spread, spread));
            Instantiate(expLoot, transform.position, Quaternion.Euler(newRotation));
        }
    }
}
