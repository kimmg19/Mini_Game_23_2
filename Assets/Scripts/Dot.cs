using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

//�� �浹 ����
public class Dot : MonoBehaviour
{    
    public float radius;       //Ž���� ����
    public LayerMask mask_Bomb;     //Ž���� layer-Bomb
    public LayerMask mask_Dot;     //Ž���� layer-Bomb
    public TextMeshPro text;

    void Start() {
        ShowBombs();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        ShowTile();
        ShowDots();
    }

    void ShowBombs() {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, radius, mask_Bomb);       //���̾ ���� �ֺ� ���� Ž��.
        if (colls.Length == 0) {
            text.text = string.Empty;
        } else {
            text.text = colls.Length.ToString();
        }
    }

    void ShowTile() {
        text.gameObject.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    //�ֺ� �� ���� 0���� ���ֱ�.
    void ShowDots() {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, radius, mask_Dot);
        foreach (Collider2D coll in colls) {
            if (coll.transform.GetChild(0).GetComponent<TextMeshPro>().text == string.Empty) {
                coll.GetComponent<Dot>().ShowTile();
                coll.GetComponent<Dot>().ShowDots();
            }
        }
    }
}
