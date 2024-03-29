using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfWineskin : SmallToken
{

  public static string itemName = "Half-Wineskin";
  public static string desc = "Each side of the wineskin can be used to advance 1 space without having to move the time marker.";
  public PhotonView photonView;

  public void Awake() {
    TokenName = Type;
  }

  public static HalfWineskin Factory() {
    GameObject halfWineskinGO = PhotonNetwork.Instantiate("Prefabs/Tokens/WineskinHalf", Vector3.zero, Quaternion.identity, 0);
    HalfWineskin halfWineskin = halfWineskinGO.GetComponent<HalfWineskin>();
    halfWineskin.Cell = null;
    return halfWineskin;
  }

  public static HalfWineskin Factory(int cellID)
  {
    HalfWineskin halfWineskin = HalfWineskin.Factory();
    halfWineskin.Cell = Cell.FromId(cellID);
    return halfWineskin;
  }

  public static HalfWineskin Factory(string hero)
  {
    HalfWineskin halfWineskin = HalfWineskin.Factory();
    GameManager.instance.findHero(hero).heroInventory.AddItem(halfWineskin);
    return halfWineskin;
  }

  public override void UseCell(){
    EventManager.TriggerCellItemClick(this);
  }

  public override void UseHero(){
    EventManager.TriggerHeroItemClick(this);
  }

  public override void UseEffect(){
    EventManager.TriggerFreeMove(this);
  }
  
  public static string Type { get => typeof(HalfWineskin).ToString(); }
}
