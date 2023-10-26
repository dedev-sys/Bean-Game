using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneManager : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        int stones1 = Random.Range(1, 3);

        if (stones1 == 1) Destroy(transform.Find("Stones1/ObjectLeft/StoneLeft").gameObject);
        else Destroy(transform.Find("Stones1/ObjectRight/StoneRight").gameObject);

        int stones2 = Random.Range(1, 3);

        if (stones2 == 1) Destroy(transform.Find("Stones2/ObjectLeft/StoneLeft").gameObject);
        else Destroy(transform.Find("Stones2/ObjectRight/StoneRight").gameObject);

        int stones3 = Random.Range(1, 3);

        if (stones3 == 1) Destroy(transform.Find("Stones3/ObjectLeft/StoneLeft").gameObject);
        else Destroy(transform.Find("Stones3/ObjectRight/StoneRight").gameObject);

        int stones4 = Random.Range(1, 3);

        if (stones4 == 1) Destroy(transform.Find("Stones4/ObjectLeft/StoneLeft").gameObject);
        else Destroy(transform.Find("Stones4/ObjectRight/StoneRight").gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
