using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class MoveAgent : MonoBehaviour
{
    
        
     NavMeshAgent agent;
     
       
        void Start()
        {
            //ナビゲーションエージェントを獲得
            agent = GetComponent<NavMeshAgent>();

            GotoNextPoint();

        }
        
        void Update()
        {
            
            //目的地に到着したかどうか？
            if (agent.remainingDistance > 3f)
            {
                GotoNextPoint();
            }
            else
            {
                agent.SetDestination(transform.position);
            }

        }

        void GotoNextPoint()
        {
            GameObject camera = GameObject.FindWithTag("camera");
            //床の移動地点をカメラに
            var nextPoint = camera.transform.position;
            //ナビメッシュエージェントへ目的地を設定
            agent.SetDestination(nextPoint);
        }
}
