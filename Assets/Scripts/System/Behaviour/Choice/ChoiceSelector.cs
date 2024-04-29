using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChoiceSelector : MonoBehaviour
{
    [Tooltip("Input the name for choicePanel.")]
    [SerializeField] private new string name;
    public string Name
    {
        get => name;
    }

    [SerializeField] private GameObject choicePanel;
    private bool isChoosing = false;

    [Header("Choices")]
    [SerializeField] private GameObject[] choices;

    private void Awake()
    {
        isChoosing = false;
        choicePanel.SetActive(false);
    }

    public void StartChoice()
    {
        isChoosing = true;
        choicePanel.SetActive(true);

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
