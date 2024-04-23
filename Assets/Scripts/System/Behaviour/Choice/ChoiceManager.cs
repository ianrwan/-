using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChoiceManager : MonoBehaviour
{
    public static ChoiceManager instance;

    [SerializeField] private GameObject choicePanel;
    private bool isChoosing = false;

    [Header("Choices")]
    [SerializeField] private GameObject[] choices;

    private void Awake()
    {
        if(instance != null)
            Debug.LogWarning("It's not allowed to set multiple ChoiceManager");
        instance = this;
    }

    public void Start()
    {
        isChoosing = false;
        choicePanel.SetActive(false);

        DoChoice();
    }

    private void Update()
    {
        if(!isChoosing)
            return;

        if(InputManager.instance.isSubmit)
        {
            MakeChoice();
        }
    }

    private void DoChoice()
    {
        isChoosing = true;
        choicePanel.SetActive(true);

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        // to clear the first gameobject in EventSystem and delete it
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0]);

        // set the toggle on the first item
        var setToggleCurrent = choicePanel.GetComponent<SetToggleCurrent>();
        setToggleCurrent.SetToggleOnCurrent(EventSystem.current.currentSelectedGameObject);
    }

    public void MakeChoice()
    {
        GameObject choice = EventSystem.current.currentSelectedGameObject;
        choice.GetComponent<TitleButton>().action.Invoke();
        EndChoice();
    }

    public void EndChoice()
    {
        isChoosing = false;
        choicePanel.SetActive(false);
    }
}
