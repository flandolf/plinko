using UnityEngine;
using TMPro;

public class MoneyTracker : MonoBehaviour
{
    public GameObject variables;       // Reference to the GameObject holding the Variables script
    public TextMeshProUGUI moneyText;  // Reference to the TextMeshProUGUI component

    private double previousMoneyAmount;
    private double accumulatedChange;
    private float lastChangeTime;
    private float inactivityThreshold = 15f;  // 15 seconds of inactivity

    void Start()
    {
        if (variables != null)
        {
            Variables varScript = variables.GetComponent<Variables>();
            if (varScript != null)
            {
                previousMoneyAmount = varScript.money;
                UpdateMoneyText(varScript.money);
                lastChangeTime = Time.time;  // Initialize lastChangeTime to the current time
            }
        }
    }

    void Update()
    {
        if (variables != null)
        {
            Variables varScript = variables.GetComponent<Variables>();
            if (varScript != null)
            {
                double currentMoneyAmount = varScript.money;

                if (currentMoneyAmount != previousMoneyAmount)
                {
                    double changeAmount = currentMoneyAmount - previousMoneyAmount;
                    accumulatedChange += changeAmount;
                    UpdateMoneyText(accumulatedChange);
                    previousMoneyAmount = currentMoneyAmount;
                    lastChangeTime = Time.time;  // Update lastChangeTime on change
                }

                // Check for inactivity
                if (Time.time - lastChangeTime >= inactivityThreshold)
                {
                    accumulatedChange = 0;
                    UpdateMoneyText(accumulatedChange);  // Reset the text if inactive
                }
            }
        }
    }

    void UpdateMoneyText(double amount)
    {
        if (amount >= 0)
        {
            moneyText.color = Color.green;
            moneyText.text = $"+{amount:F0}$";
        }
        else
        {
            moneyText.color = Color.red;
            moneyText.text = $"{amount:F0}$";
        }
    }
}
