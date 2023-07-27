//using UnityEngine;

//public class Player_Collision : MonoBehaviour
//{
//    private Snail_Enemy_Controller snail;
//    private Bee_Enemy_Controller bee;
//    private Enemy_Holder holder;

//    private Player_Life life;

//    private BoxCollider2D player;

//    private void Awake()
//    {
//        snail = FindObjectOfType<Snail_Enemy_Controller>();
//        player = GetComponent<BoxCollider2D>();
//        holder = FindObjectOfType<Enemy_Holder>();

//        bee = FindObjectOfType<Bee_Enemy_Controller>();
//        life = GetComponent<Player_Life>();
//    }

//    private void Update()
//    {
//        checkCollisions();
//    }

//    private void checkCollisions()
//    {
//        for(int i = 0; i < holder.enemyArray.Length; i++)
//        {
//            for (int j = 0; j < holder.enemyArray[i].transform.childCount; j++)
//            {
//                GameObject enemy = holder.enemyArray[i].transform.GetChild(j).gameObject;
//                if(enemy != null && enemy.transform.GetComponentInChildren<Collider2D>().IsTouching(player))
//                {
//                    if(enemy.transform.GetChild(0).name.Equals("Snail"))
//                        life.reduceHealth(snail.damage);
//                    if(enemy.transform.GetChild(0).name.Equals("Bee"))
//                        life.reduceHealth(bee.damage);
//                }
//            }
//        }
//    }
//}
