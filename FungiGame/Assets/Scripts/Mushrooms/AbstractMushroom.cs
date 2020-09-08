using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractMushroom : MonoBehaviour
{
	[Header("Shape Changes")]
	[SerializeField] private bool horizontalPickup;
	[SerializeField] private bool verticalPickup;
	[SerializeField] private bool crossPickup;
	[Header("Display (Percent) Changes")]
	[SerializeField] private bool plus10Percent;
	[SerializeField] private bool plus25Percent;
	[SerializeField] private bool plus50Percent;
	[Header("Sell Price")]
    [SerializeField] private float sellPrice = 10f;
	[Header("Mushroom Sprite")]
    [SerializeField] private Sprite image; //Assign to sprite renderer in child class
    
    //GameManager gameManager; ToDo: set GameManager as instance
    
    //Variable to be changed by in-editor selection
    private float percentAmount;
    private AreaShape changeShape;
    protected enum AreaShape
    {
	    Normal,
	    Vertical,
	    Horizontal,
	    Cross
    };

    protected void AssignProperties()
    {
	    if (horizontalPickup) { changeShape = AreaShape.Horizontal; }
	    if (verticalPickup) { changeShape = AreaShape.Vertical; }
	    if (crossPickup) { changeShape = AreaShape.Cross; }
	    if (plus10Percent) { percentAmount = 0.1f; }
	    if (plus25Percent) { percentAmount = 0.25f; }
	    if (plus50Percent) { percentAmount = 0.5f; }
    }
    protected void PerformEat(AreaShape setShape)
    {
	    //Todo: Call a public method in the child to call these private methods
	    //gameManager.SetArea((int)setShape);
    }

    protected void PerformSell(float price)
    {
	    //gameManager.Sell(price);
    }

    protected void PerformDisplay(float percent)
    {
	    //gameManager.DisplayBonus(percent);
    }
}
