using UnityEngine;

public class Fruit : MonoBehaviour
{
    public enum Type { Blueberry, Strawberry, Durian }
    public Type fruitType;

    private GameManager gameManager;
    private bool isMerged = false; // ������ �̹� ���������� ����

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isMerged && collision.gameObject.CompareTag(this.tag)) // �÷��� Ȯ��
        {
            Fruit otherFruit = collision.gameObject.GetComponent<Fruit>();

            if (otherFruit != null && otherFruit.fruitType == fruitType && !otherFruit.isMerged)
            {
                // ���� ��ġ�� ����
                MergeFruits(collision.gameObject);
                gameManager.OnFruitMerged(fruitType);
            }
        }
    }

    private void MergeFruits(GameObject otherFruit)
    {
        isMerged = true; // ���� ������ ���������� ǥ��
        Fruit otherFruitScript = otherFruit.GetComponent<Fruit>();
        if (otherFruitScript != null)
        {
            otherFruitScript.isMerged = true; // �ٸ� ���ϵ� ���������� ǥ��
        }

        Debug.Log($"���� ������: {fruitType}");

        Vector3 mergePosition = transform.position; // ������ ��ġ
        Destroy(otherFruit);
        Destroy(this.gameObject);

        GameObject newFruit = null;
        Type newFruitType = Type.Blueberry; // �⺻��

        switch (fruitType)
        {
            case Type.Blueberry:
                newFruitType = Type.Strawberry;
                break;
            case Type.Strawberry:
                newFruitType = Type.Durian;
                break;
                // �߰����� ���� ��ġ�� ������ �ʿ��ϴٸ� ���⿡ �߰�
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
