using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Herbs {
    Herb3,
    Herb4
}

public class Herb : SmallToken
{
    // Start is called before the first frame update
    public static string itemName = "Herb";
    public static string desc = "Medicinal herb can help you do three things. Gain WillPower, get free moves, or add to your strength in battle";
    public static Herbs herbType;
    public Herbs myType;
    public static GameObject token;
    public PhotonView photonView;

    public static Herb Factory()
    {
      return Herb.Factory(Herbs.Herb3);
    }

    public static Herb Factory(int cellID)
    {
      return Herb.Factory(cellID, Herbs.Herb3);
    }

    public static Herb Factory(Herbs type)
    {
      herbType = type;
      GameObject herbGo = PhotonNetwork.Instantiate("Prefabs/Tokens/" + herbType, Vector3.zero, Quaternion.identity, 0);
      token = herbGo;
      Herb herb = herbGo.GetComponent<Herb>();
      herb.Cell = null;
      if(type == Herbs.Herb3) {
        herb.maxUse = 3;
      } else {
        herb.maxUse = 4;
      }
      return herb;
    }

    public static Herb Factory(int cellID, Herbs type)
    {
      Herb herb = Herb.Factory(type);
      herb.Cell = Cell.FromId(cellID);
      return herb;
    }

    public void OnEnable(){
      myType = herbType;
    }

    public override void UseCell(){
      EventManager.TriggerCellItemClick(this);
    }

    public override void UseHero(){
      EventManager.TriggerHeroItemClick(this);
    }

    public override void UseEffect(){
      EventManager.TriggerHerbUseUI(this);
    }
}
