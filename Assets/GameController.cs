using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class GameController : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public VariableStorageBehaviour variableStorage;
    // Start is called before the first frame update
    void Start()
    {
        variableStorage = dialogueRunner.VariableStorage;
    }

    // Update is called once per frame
    void Update()
    {
        string imageName = "";
        variableStorage.TryGetValue("$imageName", out imageName);

        Sprite newSprite = Resources.Load<Sprite>(imageName);
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }
}
