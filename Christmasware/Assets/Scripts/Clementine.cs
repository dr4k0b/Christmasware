using System.Collections;
using UnityEngine;

public class Clementine : MiniGame
{
    Animator aniClementine;
    public Animator aniKey;
    int clementine;
    int key;
    public bool done;
    void Start()
    {
        aniClementine = GetComponent<Animator>();
        clementine = 0;
        key = Random.Range(1, 6);
    }
    void Update()
    {
        KeyCode keyToPress = KeyCode.Return;
        aniKey.SetInteger("key", key);
        if (key == 1)
        {
            keyToPress = KeyCode.W;
        }
        if (key == 2)
        {
            keyToPress = KeyCode.A;
        }
        if (key == 3)
        {
            keyToPress = KeyCode.S;
        }
        if (key == 4)
        {
            keyToPress = KeyCode.D;
        }
        if (key == 5)
        {
            keyToPress = KeyCode.Space;
        }
        if (Input.GetKeyUp(keyToPress))
        {
            clementine++;
            aniClementine.SetInteger("Peel", clementine);

            int prev = key;
            do
            {
                key = Random.Range(1, 6);
            }
            while (prev == key);
        }
        if (clementine == 3)
        {
            aniKey.gameObject.SetActive(false);
        }
        else
        {
            Timer();
        }
        if (done)
        {
            Win();
        }
    }
}
