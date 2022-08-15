using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject background;
    Vector3 startLocation;
    private void Start()
    {
        background = this.gameObject;
        startLocation = background.transform.position;
    }
    private void Update()
    {
        if (gameObject.transform.position.x < -gameObject.transform.localScale.x/2)
        {
            gameObject.GetComponent<SpriteRenderer>().drawMode = SpriteDrawMode.Tiled;
            gameObject.GetComponent<SpriteRenderer>().size = new Vector2(20, 10);
            Debug.Log(gameObject.transform.position.x);
        }
    }
}
