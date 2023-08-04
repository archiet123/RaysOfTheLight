using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string InteractText;

    public string NpcName;
    public Dialogue dialogue;
    public GameObject DialogueManager;
    //bools
    [SerializeField] public bool TalkingToNPC = false;

    Transform player;
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        player = PlayerTracker.instance.player.transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        FacePlayer();
    }

    public void Interact()
    {
        // Debug.Log($"Interacted with {NpcName}");
        // Debug.Log("got name");
        //dialouge stuff to go here
        TriggerDialogue();
    }

    //returns objects or npcs interact text
    public string GetInteractText()
    {
        return InteractText;
    }

    public void Interact(Transform InteractorTransform)
    {
        // Debug.Log("test interact");
        Interact();
    }

    public Transform GetTransform()
    {
        // Debug.Log("got transform for derick");
        return transform;
    }

    public void TriggerDialogue()
    {
        DialogueManager.GetComponent<DialogueSystem>().StartDialogue(dialogue);
        TalkingToNPC = true;
        FindObjectOfType<PlayerInteract>().GetBool(TalkingToNPC);
        Debug.Log("StartDialogue");
    }

    void FacePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }
}