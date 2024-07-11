using UnityEngine;

public class Fruit : MonoBehaviour
{
    public enum Type { Blueberry, Strawberry, Durian }
    public Type fruitType;

    private GameManager gameManager;
    private bool isMerged = false; // 과일이 이미 합쳐졌는지 여부

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isMerged && collision.gameObject.CompareTag(this.tag)) // 플래그 확인
        {
            Fruit otherFruit = collision.gameObject.GetComponent<Fruit>();

            if (otherFruit != null && otherFruit.fruitType == fruitType && !otherFruit.isMerged)
            {
                // 과일 합치기 로직
                MergeFruits(collision.gameObject);
                gameManager.OnFruitMerged(fruitType);
            }
        }
    }

    private void MergeFruits(GameObject otherFruit)
    {
        isMerged = true; // 현재 과일이 합쳐졌음을 표시
        Fruit otherFruitScript = otherFruit.GetComponent<Fruit>();
        if (otherFruitScript != null)
        {
            otherFruitScript.isMerged = true; // 다른 과일도 합쳐졌음을 표시
        }

        Debug.Log($"과일 합쳐짐: {fruitType}");

        Vector3 mergePosition = transform.position; // 합쳐질 위치
        Destroy(otherFruit);
        Destroy(this.gameObject);

        GameObject newFruit = null;
        Type newFruitType = Type.Blueberry; // 기본값

        switch (fruitType)
        {
            case Type.Blueberry:
                newFruitType = Type.Strawberry;
                break;
            case Type.Strawberry:
                newFruitType = Type.Durian;
                break;
                // 추가적인 과일 합치기 로직이 필요하다면 여기에 추가
        }

        newFruit = InstantiateFruit(newFruitType, mergePosition);
    }

    private GameObject InstantiateFruit(Type newFruitType, Vector3 position)
    {
        GameObject fruitPrefab = null;
        switch (newFruitType)
        {
            case Type.Blueberry:
                fruitPrefab = Resources.Load<GameObject>("Blueberry");
                break;
            case Type.Strawberry:
                fruitPrefab = Resources.Load<GameObject>("Strawberry");
                break;
            case Type.Durian:
                fruitPrefab = Resources.Load<GameObject>("Durian");
                break;
        }
        return Instantiate(fruitPrefab, position, Quaternion.identity);
    }
}
