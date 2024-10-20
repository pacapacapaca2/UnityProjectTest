using UnityEngine;

public class LoadIntoPickup : MonoBehaviour
{
    private int loadedItems = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickupItem"))
        {
            loadedItems++;
            Destroy(other.gameObject);  // Удаляем предмет после загрузки
        }
    }
}
