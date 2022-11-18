using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using static System.Net.Mime.MediaTypeNames;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    Sprite redReticle;
    [SerializeField]
    Sprite yellowReticle;
    [SerializeField]
    Sprite blueReticle;
    [SerializeField]
    Image reticle;


    [SerializeField]
    private TextMeshProUGUI ammoText;
    [SerializeField]
    private TextMeshProUGUI healthText;
    [SerializeField]
    private TextMeshProUGUI armorText;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI pickupText;
    [SerializeField]
    private TextMeshProUGUI waveText;
    [SerializeField]
    private TextMeshProUGUI enemyText;
    [SerializeField]
    private TextMeshProUGUI waveClearText;
    [SerializeField]
    private TextMeshProUGUI newWaveText;
    [SerializeField]
    Player player;
    public void UpdateReticle()
    {
        switch (GunEquipper.activeWeaponType)
        {
            case Constants.Pistol:
                reticle.sprite = redReticle;
                break;
            case Constants.Shotgun:
                reticle.sprite = yellowReticle;
                break;
            case Constants.AssaultRifle:
                reticle.sprite = blueReticle;
                break;
            default:
                return;
        }
    }// Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
    // 1
    void Start()
    {
        SetArmorText(player.armor);
        SetHealthText(player.health);
    }
    // 2
    public void SetArmorText(int armor)
    {
        //armorText.gameObject.GetComponent<TextMeshPro>().text= "Armor: " + armor;
        armorText.text  = "Armor: " + armor;
    }
    public void SetHealthText(int health)
    {
        healthText.text = "Health: " + health;
    }
    public void SetAmmoText(int ammo)
    {
        ammoText.text = "Ammo: " + ammo;
    }
    public void SetScoreText(int score)
    {
        scoreText.text = "" + score;
    }
    public void SetWaveText(int time)
    {
        waveText.text = "Next Wave: " + time;
    }
    public void SetEnemyText(int enemies)
    {
        enemyText.text = "Enemies: " + enemies;
    }

    // 1
    public void ShowWaveClearBonus()
    {
        waveClearText.enabled = true;
        StartCoroutine("hideWaveClearBonus");
    }
    // 2
    IEnumerator hideWaveClearBonus()
    {
        yield return new WaitForSeconds(4);
        waveClearText.enabled = false;
    }
    // 3
    public void SetPickUpText(string text)
    {
        pickupText.enabled = true;
        pickupText.text= text;
        // Restart the Coroutine so it doesn’t end early
        StopCoroutine("hidePickupText");
        StartCoroutine("hidePickupText");
    }
    // 4
    IEnumerator hidePickupText()
    {
        yield return new WaitForSeconds(4);
        pickupText.enabled = false;
    }
    // 5
    public void ShowNewWaveText()
    {
        StartCoroutine("hideNewWaveText");
        newWaveText.enabled = true;
    }

    // 6
    IEnumerator hideNewWaveText()
    {
        yield return new WaitForSeconds(4);
        newWaveText.enabled = false;
    }
}
