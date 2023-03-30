using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//when something get into the alta, make the runes glow
namespace Cainos.PixelArtTopDown_Basic
{

    public class PropsAltar : MonoBehaviour
    {
        public List<SpriteRenderer> runes;
        public float lerpSpeed;

        private Color curColor;
        private Color targetColor;

        private float timeDelay = 1.5f;
        private bool hasPlayer = false;
         [SerializeField] Loading load;


        private void Start()
        {
            //load = GetComponent<Loading>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            targetColor = new Color(1, 1, 1, 1);
            hasPlayer = true;
                  
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            targetColor = new Color(1, 1, 1, 0);
            hasPlayer = false;
            timeDelay = 1.5f;
        }

       

        private void Update()
        {
            curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

            foreach (var r in runes)
            {
                r.color = curColor;
            }

            Debug.Log("Time: " + timeDelay);
            if (hasPlayer)
            {
                timeDelay -= Time.deltaTime;
            }
            if(timeDelay <= 0)
            {
                //SceneManager.LoadScene("RoomBoss1");
                load.LoadScene(2);
                timeDelay = 1.5f;
                
            }    
                

        }
    }
}
