using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPoolTest : MonoBehaviour
{
    [SerializeField] private EnemyAnimationDetails[] enemyAnimationDetails;
    [SerializeField] GameObject enemyExamplePrefab;
    private float timer = 1f;
   [System.Serializable]
   public struct EnemyAnimationDetails
    {
        public RuntimeAnimatorController animatorController;
        public Color spriteColor;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer<= 0f)
        {
            GetEnemyExample();
            timer = 1f;
        }
    }

    private void GetEnemyExample()
    {
        Room currentROom = GameManager.Instance.GetCurrentRoom();

        Vector3 spawnPosition = new Vector3(Random.Range(currentROom.lowerBounds.x, currentROom.upperBounds.x),
            Random.Range(currentROom.lowerBounds.y, currentROom.upperBounds.y), 0f);
        EnemyAnimation enemyAnimation = (EnemyAnimation)PoolManager.Instance.ReuseComponent(enemyExamplePrefab, 
            HelperUtilities.GetSpawnPositionNearestToPlayer(spawnPosition), Quaternion.identity);

        int randomIndex = Random.Range(0, enemyAnimationDetails.Length);
        enemyAnimation.gameObject.SetActive(true);
        enemyAnimation.SetAnimation(enemyAnimationDetails[randomIndex].animatorController, enemyAnimationDetails[randomIndex].spriteColor);
    }
}
