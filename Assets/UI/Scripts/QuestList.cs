using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestList : MonoBehaviour
{
    [SerializeField] private Animator anim;
    string[] questList = new string[5];
    [SerializeField] private TextMeshProUGUI firstQuest;
    [SerializeField] private TextMeshProUGUI secondQuest;
    [SerializeField] private TextMeshProUGUI thirdQuest;
    [SerializeField] private TextMeshProUGUI fourthQuest;
    [SerializeField] private TextMeshProUGUI timer;

    private int currentKillsPolicemens;
    private int currentKillsCivilians;
    private int currentKillsWithCritical;
    
    private bool a;
    private bool b;
    private bool c;
    private bool d;

    private bool openQuest;
    private float second1, minute1, second2, minute2, param;

    private void Start()
    {
        questList[0] = ("1) Hold out for 5 minutes");
        questList[1] = ("2) Kill 5 policemen");
        questList[2] = ("3) Kill 20 civilians");
        questList[3] = ("4) Kill with a critical attack 5 peoples");

        firstQuest.text = "" + questList[0];
        secondQuest.text = "" + questList[1];
        thirdQuest.text = "" + questList[2];
        fourthQuest.text = "" + questList[3];
    }

    private void Update()
    {
        QuestProgress();
        QuestSuccess();
        OnOffQuestsList();
        HoldOut();
    }

    private void QuestProgress()
    {
        if (currentKillsPolicemens >= 5) b = true;
        if (currentKillsCivilians >= 20) c = true;
        if (currentKillsWithCritical >= 5) d = true;
    }

    public void QuestKillsPolicemens()
    {
        currentKillsPolicemens ++;
    }
    public void QuestKillsCivilians()
    {
        currentKillsCivilians ++;
    }
    public void QuestKillsWithCritical()
    {
        currentKillsWithCritical ++;
    }

    private void HoldOut()
    {
        param += Time.deltaTime;
        if (param >= 1)
        {
            second1++;
            param = 0;
            if (second1 >= 10)
            {
                second2++;
                second1 = 0;
            }
        }
        if(second2 >= 6)
        {
            minute1++;
            second2 = 0;
            if (minute1 >= 10)
            {
                minute2++;
            }
        }
        if (minute1 == 5) a = true;
        timer.text = minute2 + minute1 + ":" + second2 + second1;
    }

    private void QuestSuccess()
    {
        if(a) firstQuest.color = Color.green;
        if(b) secondQuest.color = Color.green;
        if(c) thirdQuest.color = Color.green;
        if(d) fourthQuest.color = Color.green;
    }

    private void OnOffQuestsList()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && openQuest)
        {
            anim.SetTrigger("CloseQuest");
            openQuest = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Tab) && !openQuest)
        {
            anim.SetTrigger("OpenQuest");
            openQuest = true;
            return;
        }
    }
}
