using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DestroyThySelf");
    }

    IEnumerator DestroyThySelf()
    {
        yield return new WaitForSeconds(15);
        Destroy(gameObject);
    }
}
