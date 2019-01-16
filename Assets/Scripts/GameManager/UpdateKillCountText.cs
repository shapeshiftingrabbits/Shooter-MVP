using Player;
using UnityEngine;
using UnityEngine.UI;

public class UpdateKillCountText : MonoBehaviour {

    public GameObject player;
    private PlayerScript playerScript;
    private Text killCountText;

    void Start () {
        playerScript = player.GetComponent<PlayerScript> ();
        killCountText = gameObject.GetComponent<Text> ();
    }
    
    void Update () {
        killCountText.text = "Score: " + playerScript.player.EnemiesKilled ().ToString();
    }
}
