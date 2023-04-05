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
        Loading load;
        public int loadScene; 

        GameManager gameMn;
        public int number;
        

        private void Start()
        {
            gameMn = FindObjectOfType<GameManager>();
            load = GameObject.Find("SceneLoaderCanvas").GetComponent<Loading>();
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

            /*if(SceneManager.GetActiveScene().name == "WorldMap")
            {*/
                switch(number)
                {
                    case 1:
                        if (hasPlayer && !gameMn.winboss1)
                        {
                            timeDelay -= Time.deltaTime;
                        }

                        if (timeDelay <= 0)
                        {
                            load.LoadScene(loadScene);
                            timeDelay = 1.5f;
                        }
                        break;
                    case 2:
                        if (hasPlayer && !gameMn.winboss2)
                        {
                            timeDelay -= Time.deltaTime;
                        }

                        if (timeDelay <= 0)
                        {
                            load.LoadScene(loadScene);
                            timeDelay = 1.5f;
                        }
                        break;
                    case 3:
                        Debug.Log("Win boss: " + gameMn.winboss1);
                        if (hasPlayer && gameMn.winboss1)
                        {
                            timeDelay -= Time.deltaTime;
                        }

                        if (timeDelay <= 0)
                        {
                            Debug.Log("da ve worldmap");
                            load.LoadScene(loadScene);
                            timeDelay = 1.5f;
                        }
                        break;
                }

                
              

            
                

        }
    }
}
