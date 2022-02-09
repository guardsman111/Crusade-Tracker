using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace CrusadeTracker 
{
    public class MainMenuWindow : MonoBehaviour
    {
        public ForceDataViewModel ForceScreen;

        public GameObject LoadMenuContentHome;
        public RectTransform LoadMenuContent;
        public GameObject LoadCardPrefab;

        public List<string> forcePaths = new List<string>();
        public Dictionary<GameObject, string> forceCards = new Dictionary<GameObject, string>();


        public void OpenLoadMenu()
        {
            string[] tempPaths;
            tempPaths = Directory.GetFiles(Application.persistentDataPath);
            foreach (string path in tempPaths)
            {
                forcePaths.Add(path);
                GameObject newCard = Instantiate(LoadCardPrefab, LoadMenuContentHome.transform);
                newCard.transform.localPosition = new Vector3(0, -170 * forceCards.Count);

                forceCards.Add(newCard, path);

                string shavedPath = path.Replace(Application.persistentDataPath, "");
                shavedPath = shavedPath.Replace(".xml", "");

                newCard.GetComponent<LoadCardButton>().label.text = shavedPath;
                newCard.GetComponent<LoadCardButton>().MainMenu = this;
            }

            LoadMenuContent.sizeDelta = new Vector2(LoadMenuContent.sizeDelta.x, 170 * forceCards.Count);
        }

        public void ClearLoadedCards()
        {
            List<GameObject> cards = new List<GameObject>();
            foreach (KeyValuePair<GameObject,string> go in forceCards)
            {
                cards.Add(go.Key);
            }

            for (int i = cards.Count; i > 0; i--)
            { 
                Destroy(cards[0]);
            }

            forcePaths.Clear();
            forceCards.Clear();
        }

        public void OpenForce(GameObject forceCard) 
        {
            string forcePath;
            forceCards.TryGetValue(forceCard, out forcePath);
            ForceScreen.LoadForce(forcePath);

            ForceScreen.ForceWindow.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        public void QuitApp() 
        {
            Application.Quit();
        }
    } 
}
