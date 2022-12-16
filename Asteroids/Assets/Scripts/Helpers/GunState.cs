using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunState : MonoBehaviour
{
    public bool ReadyToShoot = true;
    public float CooldownTime = 1f;
    public float MaxChargeValue = 1f;
    public List<GunCharge> GunCharges = new (1);

    private void Update()
    {
        foreach (var charge in GunCharges.FindAll(charge => !charge.IsReady))
        {
            //at any MaxChargeValue time to charge in seconds == CooldownTime
            charge.CurrentCharge += Time.deltaTime * MaxChargeValue / CooldownTime;
            if (charge.CurrentCharge >= MaxChargeValue)
            {
                charge.IsReady = true;
                ReadyToShoot = true;
            }
        }
    }
    /// <summary>
    /// Using first "ready-to-use" charge
    /// </summary>
    public void UseCharge()
    {
        var charge = GunCharges.First(charge => charge.IsReady);
        charge.CurrentCharge = 0;
        charge.IsReady = false;
        if (GunCharges.Find(charge => charge.IsReady) == null)
        {
            ReadyToShoot = false;
        }
    }
    /// <summary>
    /// Geting all charges
    /// </summary>
    /// <remarks>current charge more than 0, and less than MaxChargeValue</remarks>
    /// <returns> </returns>
    public List<float> GetChargesList()
    {
        List<float> chargePercentList = new List<float>(GunCharges.Capacity);
        for (int i = 0; i < GunCharges.Capacity; i++)
        {
            chargePercentList.Add(GunCharges[i].CurrentCharge);
        }
        return chargePercentList;
    }
}