using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFire : MonoBehaviour
{
    public GameObject GroundFirePrefab;
    public GameObject AttacksParent;
    public VolcanoBossEncounterController ControllerScript;
    // Start is called before the first frame update
    private void OnEnable()
    {
        if (AttacksParent == null)
        {
            //AttacksParent = FindWithTag("AbilityParent");
        }

        if (ControllerScript == null)
        {
            ControllerScript = FindObjectOfType<VolcanoBossEncounterController>();
        }
    }
    void Start()
    {

        if (ControllerScript.vEnd == false)
        {
            GameObject GroundFire = Instantiate(GroundFirePrefab, new Vector3(transform.position.x, transform.position.y, 0f), transform.rotation);
           // GroundFire.transform.parent = AttacksParent.transform;
            GroundFire.GetComponent<GroundFire>().time = Random.Range(27, 33) * 2;
            GameObject GroundFire1 = Instantiate(GroundFirePrefab, new Vector3(transform.position.x - 0.5f, transform.position.y + 1.25f, 0f), transform.rotation);
            //GroundFire1.transform.parent = AttacksParent.transform;
            GroundFire1.GetComponent<GroundFire>().time = Random.Range(27, 34) * 2;
            GameObject GroundFire2 = Instantiate(GroundFirePrefab, new Vector3(transform.position.x + 0.5f, transform.position.y + 1.5f, 0f), transform.rotation);
            //GroundFire2.transform.parent = AttacksParent.transform;
            GroundFire2.GetComponent<GroundFire>().time = Random.Range(28, 33) * 2;
            GameObject GroundFire3 = Instantiate(GroundFirePrefab, new Vector3(transform.position.x + 1f, transform.position.y + 0.5f, 0f), transform.rotation);
            //GroundFire3.transform.parent = AttacksParent.transform;
            GroundFire3.GetComponent<GroundFire>().time = Random.Range(27, 35) * 2;
            GameObject GroundFire4 = Instantiate(GroundFirePrefab, new Vector3(transform.position.x + 1.75f, transform.position.y, 0f), transform.rotation);
            //GroundFire4.transform.parent = AttacksParent.transform;
            GroundFire4.GetComponent<GroundFire>().time = Random.Range(27, 36) * 2;
            GameObject GroundFire5 = Instantiate(GroundFirePrefab, new Vector3(transform.position.x + 0.75f, transform.position.y - 0.75f, 0f), transform.rotation);
            //GroundFire5.transform.parent = AttacksParent.transform;
            GroundFire5.GetComponent<GroundFire>().time = Random.Range(30, 33) * 2;
            GameObject GroundFire6 = Instantiate(GroundFirePrefab, new Vector3(transform.position.x, transform.position.y - 1.25f, 0f), transform.rotation);
            //GroundFire6.transform.parent = AttacksParent.transform;
            GroundFire6.GetComponent<GroundFire>().time = Random.Range(27, 33) * 2;
            GameObject GroundFire7 = Instantiate(GroundFirePrefab, new Vector3(transform.position.x - 0.75f, transform.position.y - 0.5f, 0f), transform.rotation);
            //GroundFire7.transform.parent = AttacksParent.transform;
            GroundFire7.GetComponent<GroundFire>().time = Random.Range(29, 33) * 2;
            GameObject GroundFire8 = Instantiate(GroundFirePrefab, new Vector3(transform.position.x - 1.25f, transform.position.y + 0.5f, 0f), transform.rotation);
            //GroundFire8.transform.parent = AttacksParent.transform;
            GroundFire8.GetComponent<GroundFire>().time = Random.Range(29, 35) * 2;
            GameObject GroundFire9 = Instantiate(GroundFirePrefab, new Vector3(transform.position.x - 2f, transform.position.y + 1f, 0f), transform.rotation);
            //GroundFire9.transform.parent = AttacksParent.transform;
            GroundFire9.GetComponent<GroundFire>().time = Random.Range(24, 33) * 2;
            GameObject GroundFire10 = Instantiate(GroundFirePrefab, new Vector3(transform.position.x, transform.position.y + 2.5f, 0f), transform.rotation);
            //GroundFire10.transform.parent = AttacksParent.transform;
            GroundFire10.GetComponent<GroundFire>().time = Random.Range(25, 33) * 2;
            GameObject GroundFire11 = Instantiate(GroundFirePrefab, new Vector3(transform.position.x + 1.5f, transform.position.y - 1.25f, 0f), transform.rotation);
           // GroundFire11.transform.parent = AttacksParent.transform;
            GroundFire11.GetComponent<GroundFire>().time = Random.Range(31, 33) * 2;
            GameObject GroundFire12 = Instantiate(GroundFirePrefab, new Vector3(transform.position.x - 1f, transform.position.y - 1.75f, 0f), transform.rotation);
          //  GroundFire12.transform.parent = AttacksParent.transform;
            GroundFire12.GetComponent<GroundFire>().time = Random.Range(27, 38) * 2;
            GameObject GroundFire13 = Instantiate(GroundFirePrefab, new Vector3(transform.position.x + 0.5f, transform.position.y - 2.25f, 0f), transform.rotation);
         //   GroundFire13.transform.parent = AttacksParent.transform;
            GroundFire13.GetComponent<GroundFire>().time = Random.Range(27, 36) * 2;
            GameObject GroundFire14 = Instantiate(GroundFirePrefab, new Vector3(transform.position.x + 2.5f, transform.position.y + 0.5f, 0f), transform.rotation);
          //  GroundFire14.transform.parent = AttacksParent.transform;
            GroundFire14.GetComponent<GroundFire>().time = Random.Range(27, 35) * 2;
            GameObject GroundFire15 = Instantiate(GroundFirePrefab, new Vector3(transform.position.x - 1.75f, transform.position.y - 0.5f, 0f), transform.rotation);
           // GroundFire15.transform.parent = AttacksParent.transform;
            GroundFire15.GetComponent<GroundFire>().time = Random.Range(27, 37) * 2;
            GameObject GroundFire16 = Instantiate(GroundFirePrefab, new Vector3(transform.position.x + 1.5f, transform.position.y + 1.75f, 0f), transform.rotation);
           // GroundFire16.transform.parent = AttacksParent.transform;
            GroundFire16.GetComponent<GroundFire>().time = Random.Range(29, 34) * 2;
            GameObject GroundFire17 = Instantiate(GroundFirePrefab, new Vector3(transform.position.x - 1.25f, transform.position.y + 2f, 0f), transform.rotation);
           // GroundFire17.transform.parent = AttacksParent.transform;
            GroundFire17.GetComponent<GroundFire>().time = Random.Range(27, 33) * 2;
        }

        this.gameObject.SetActive(false);
    }
}
