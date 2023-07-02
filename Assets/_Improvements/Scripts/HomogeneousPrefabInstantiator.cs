
/*
# This code snippet was created by Zelda Hu.
# Date: 2023.06.25
# Version: 01

# COPYRIGHT NOTICE:
# Zelda Hu retains full ownership and intellectual property rights to this code.
# You may use this code for personal and educational purposes only.
# Any commercial or unauthorized use is strictly prohibited.

# PRIVACY DISCLAIMER:
# This code does not collect or store any personal or sensitive information.
# However, please review and ensure compliance with privacy regulations
# applicable to your specific use case and data.
*/
using UnityEngine;

namespace AnimalFarm
{
    /// <summary>
    /// This script is used at the beginning of the game time to populate all of the game world 
    /// it is going to happen only once at the beginning of the game
    /// between the list of prefabs get a random prefab and instantiate it in a random position 
    /// how does instantiates?
    /// the overall number is 100 and there is a creation loop that says 
    /// let's get a random animal in the list, and let's instantiate the animal 
    /// let's do it again for 100 times 
    /// </summary>
    public class HomogeneousPrefabInstantiator : MonoBehaviour
    {
        #region Public Members
        // this is a list of prefabs to be instantiated - in this case our animals 
        public GameObject[] PrefabList;
        // this is the number of max prefabs to be instantiated
        public int NumberOfPrefabs = 100; 
        // 10 is just a temporary number that you can change in the inspector later 
        // but if you keep 10 menas that you will only instantiate 10 copies of animals 
        // where is the center of the area to instantiate prefabs
        public Vector3 AreaCenter;
        // how far from that center I can instantiate prefabs 
        public Vector3 AreaSize;
        #endregion Public Members
        #region Monobehaviour
        private void Start()
        {
            InstantiatePrefabs();
        }
        #endregion Monobehaviour
        #region Private Methods
        private void InstantiatePrefabs()
        {
            if (PrefabList.Length == 0)
            {
                Debug.LogWarning("No prefabs assigned to instantiate.");
                return;
            }

            for (int i = 0; i < NumberOfPrefabs; i++)
            {
                // for the max amount of prefabs number, get a random prefab from the list
                int prefabIndex = Random.Range(0, PrefabList.Length);
                GameObject prefab = PrefabList[prefabIndex];
                // get a random position in the area
                Vector3 randomPosition = GetRandomPositionInArea();
                // get a random rotation on the y axis
                Quaternion randomRotation = GetRandomRotationOnYAxis();
                // instantiate the prefab in the random position and rotation
                Instantiate(prefab, randomPosition, randomRotation);
            }
        }

        // this is a method that returns a random position in the area
        private Vector3 GetRandomPositionInArea()
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(AreaCenter.x - AreaSize.x / 2f, AreaCenter.x + AreaSize.x / 2f),
                Random.Range(AreaCenter.y - AreaSize.y / 2f, AreaCenter.y + AreaSize.y / 2f),
                Random.Range(AreaCenter.z - AreaSize.z / 2f, AreaCenter.z + AreaSize.z / 2f)
            );

            return randomPosition;
        }
        // this is a method that returns a random rotation on the y axis
        private Quaternion GetRandomRotationOnYAxis()
        {
            float yRotation = Random.Range(0, 359);
            Quaternion randomRotation = Quaternion.Euler(0f, yRotation, 0f);
            return randomRotation;
        }
        #endregion Private Methods

    }
}