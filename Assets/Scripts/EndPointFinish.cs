using UnityEngine;

public class EndPointFinish : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 _translate = (other.transform.position - transform.position) * (1 - Vector3.Distance(other.transform.position, transform.position)) * Time.deltaTime * 2;
            other.transform.GetComponent<Rigidbody>().AddForce(_translate, ForceMode.VelocityChange);// = other.transform.position + _translate;//.Translate(_translate);
        }
    }
}