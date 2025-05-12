using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField]
    Character character;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            character.Health += 10;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            character.Health -= 10;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            character.Mana += 10;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            character.Mana += 10;
        }

    }
}