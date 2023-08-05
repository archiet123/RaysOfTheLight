// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class WeaponSelect : MonoBehaviour
// {
//     public WeaponChoice[] weaponChoices;
//     public GameObject ButtonParent;
//     public GameObject AmmoUI;

//     public GameObject Hammer;
//     public GameObject Pistol;
//     public GameObject AR;
//     public GameObject Donut;
//     public GameObject Phish;
//     GameObject ActiveWeapon;


//     void Start()
//     {
//         ActiveWeapon = Pistol;
//         // Debug.Log(ActiveWeapon);
//     }

//     private void OnEnable()
//     {
//         for (int i = 0; i < GameManager.Instance.weaponCounts[GameManager.Instance.currentWeapon]; i++)
//         {
//             // Debug.Log("For Loop");
//             int WeaponNum = i + 1;
//             // weaponChoices[i].gameObject.SetActive(true);
//             weaponChoices[i].WeaponText.text = (i + 1).ToString();
//             weaponChoices[i].GetComponent<Button>().onClick.RemoveAllListeners();
//             weaponChoices[i].GetComponent<Button>().onClick.AddListener(() => SelectWeapon(WeaponNum));
//             // weaponChoices[i].GetComponent<Button>().onClick.AddListener(() => SelectWeapon(GameManager.Instance.currentWeapon, WeaponNum));
//             //(currentWeapon) can be used as a weapon type
//         }
//     }

//     private void SelectWeapon(int ID)
//     {
//         // Debug.Log(ID);
//         if (ID == 1)
//         {
//             ActiveWeapon.SetActive(false);
//             ActiveWeapon = AR;
//             ActiveWeapon.SetActive(true);
//             AmmoUI.SetActive(true);
//             // Debug.Log(ActiveWeapon);
//         }
//         else if (ID == 13)
//         {
//             ActiveWeapon.SetActive(false);
//             ActiveWeapon = Pistol;
//             ActiveWeapon.SetActive(true);
//             AmmoUI.SetActive(true);
//             // Debug.Log(ActiveWeapon);
//         }
//         else if (ID == 3)
//         {
//             ActiveWeapon.SetActive(false);
//             ActiveWeapon = Donut;
//             ActiveWeapon.SetActive(true);
//             AmmoUI.SetActive(true);
//             // Debug.Log(ActiveWeapon);
//         }

//         else if (ID == 4)
//         {
//             ActiveWeapon.SetActive(false);
//             ActiveWeapon = Hammer;
//             ActiveWeapon.SetActive(true);
//             AmmoUI.SetActive(false);
//             // Debug.Log(ActiveWeapon);
//         }

//         else if (ID == 5)
//         {
//             ActiveWeapon.SetActive(false);
//             ActiveWeapon = Phish;
//             ActiveWeapon.SetActive(true);
//             AmmoUI.SetActive(true);
//             // Debug.Log(ActiveWeapon);
//         }
//     }
// }
