using UnityEngine;

public class Skotta : MiniGame
{
    public GameObject snow;
    public int[,] positions = { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
    public int snows;
    void Start()
    {
        snows = 5;
        transform.position = new Vector3(-1.56f, 2.19f);
        positions[0, 0] = 1;
        int xPos = -1;
        int yPos = -1;
        for (int i = 0; i < 5; i++)
        {
            do
            {
                xPos = Random.Range(0, 4);
                yPos = Random.Range(0, 4);
            }
            while (positions[xPos, yPos] == 1);
            positions[xPos, yPos] = 1;
        }

        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                if (x == 0 && y == 0) continue;
                if (positions[x, y] == 1)
                    Instantiate(snow, new Vector3(-1.56f + x, 2.19f - y), snow.transform.rotation);
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W) && transform.position.y < 2.19f)
        {
            transform.position += Vector3.up;
        }
        if (Input.GetKeyUp(KeyCode.A) && transform.position.x > -1.56f)
        {
            transform.position += Vector3.left;
        }
        if (Input.GetKeyUp(KeyCode.S) && transform.position.y > -0.19f)
        {
            transform.position += Vector3.down;
        }
        if (Input.GetKeyUp(KeyCode.D) && transform.position.x < 1.44f)
        {
            transform.position += Vector3.right;
        }
        if (snows <= 0)
        {
            Win();
        }
        Timer();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "snow")
        {
            snows--;
            Destroy(collision.gameObject);
        }
    }
}
