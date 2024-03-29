using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBoardTrade : MonoBehaviour
{
  Text farmerCount;
  Text willPower;
  Text strength;
  Text numOfDice;

  void OnEnable() {
    EventManager.FarmersInventoriesUpdate += UpdateFarmerCount;
    EventManager.MainHeroInit += InitHero;
    EventManager.CompleteHeroBoardUpdate += updateCompleteBoard;
  }

  void OnDisable() {
    EventManager.FarmersInventoriesUpdate -= UpdateFarmerCount;
    EventManager.MainHeroInit -= InitHero;
    EventManager.CompleteHeroBoardUpdate -= updateCompleteBoard;
  }

  // Start is called before the first frame update
  void Awake() {
    farmerCount = transform.Find("Farmer/Count").GetComponent<Text>();
    strength = transform.Find("Strength/Count").GetComponent<Text>();
    willPower = transform.Find("Willpower/Count").GetComponent<Text>();
    numOfDice = transform.Find("Dice/Count").GetComponent<Text>();
  }

  private void UpdatePlayerStats(Hero hero) {
  // if(hero.TokenName.Equals(GameManager.instance.MainHero.TokenName)){
      Awake();
      strength.text = hero.Strength.ToString();
      willPower.text = hero.Willpower.ToString();
      updateNumOfDice(hero);

//    }
  }

  void UpdateFarmerCount(int attachedFarmers, int noTargetFarmers, int detachedFarmers) {
      farmerCount.text = attachedFarmers.ToString();
  }

  void InitHero(Hero hero) {
    Transform heroes = transform.Find("Heroes");

    foreach (Transform child in heroes) {
        foreach (Transform grandChild in child) {
            grandChild.gameObject.SetActive(false);
        }
    }

    GameObject go = heroes.Find(hero.name + "/" + hero.HeroName).gameObject;
    go.SetActive(true);

    UpdatePlayerStats(hero);
  }

  //NEED SOMETHING FOR FARMERCOUNT
  public void updateCompleteBoard(Hero hero){
    InitHero(hero);
    strength.text = hero.Strength.ToString();
    willPower.text = hero.Willpower.ToString();
    updateNumOfDice(hero);

  }


  void updateNumOfDice(Hero hero){
    numOfDice.text = "" + hero.Dices[hero.Willpower];
  }
}
