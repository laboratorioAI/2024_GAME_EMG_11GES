using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public Collider accumulationZoneCollider;
    public Text pointsText; // Reference to the UI Text element for displaying points.
    public string defaultMessage = "Points: 0"; // Default message to display at start.

    private int points = 0;

    void Start()
    {
        // Initialize the points display with the default message.
        UpdatePointsText(defaultMessage);
    }

    public void AddPoints(int value)
    {
        points += value;
        UpdatePointsText("Points: " + points.ToString());
    }

    void UpdatePointsText(string text)
    {
        // Update the UI text to display the specified text.
        if (pointsText != null)
        {
            pointsText.text = text;
        }
    }

    public Collider GetAccumulationZoneCollider()
    {
        return accumulationZoneCollider;
    }
}
