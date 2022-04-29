using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int itemsCount;
    public Text ItemsCountText;


    private void setItemText()
    {
        ItemsCountText.text = itemsCount.ToString();
    }

    private void addPoints(int pointsCount)
    {
        itemsCount += pointsCount;
        setItemText();
    }
    public void RestartGame()
    {
        itemsCount = 0;
        setItemText();
        ObjectsSpawner.RemoveObjectFromListDelegate(null, true);
    }


    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            var touchPosition = touch.position;
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touchPosition);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject, 100))
                {

                    if (hitObject.transform.CompareTag("SpawnedObject"))
                    {
                        addPoints(hitObject.transform.GetComponent<SpawnedObject>().Points);
                        ObjectsSpawner.RemoveObjectFromListDelegate(hitObject.transform.gameObject, false);
                        Destroy(hitObject.transform.gameObject);
                        
                    }
                }
            }
        }
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            print("tap");
            var touchPosition1 = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(touchPosition1);
            RaycastHit hitObject;
            if (Physics.Raycast(ray, out hitObject, 100))
            {

                if (hitObject.transform.CompareTag("SpawnedObject"))
                {
                    addPoints(hitObject.transform.GetComponent<SpawnedObject>().Points);
                    ObjectsSpawner.RemoveObjectFromListDelegate(hitObject.transform.gameObject, false);
                    Destroy(hitObject.transform.gameObject);
                }
            }
        }
#endif
    }
}
