using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;
    public float speedSpeed = 1f;

    private SpriteRenderer spriteRenderer;
    [SerializeField] private LayerMask layer;
    [SerializeField] private int Xdirection = 1;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer.color = Color.red;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.color = Color.black;
        Collider2D[] coliders =  Physics2D.OverlapCircleAll(transform.position,10f, layer);
        for (int i = 0; i < coliders.Length; i++)
        {
            if (coliders[i].TryGetComponent(out Enemy enemy))
            {
                Xdirection = -1;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Xdirection,0) * speed * Time.deltaTime);
    }
    private void OnEnable()
    {
        
    }
}
