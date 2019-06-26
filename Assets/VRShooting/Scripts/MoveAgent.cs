﻿using System.Collections;
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
            if (agent.remainingDistance < 0.5f)
            {
                //次の地点に移動
                GotoNextPoint();
            }

        }

        void GotoNextPoint()
        {
            
            //床の移動地点をカメラに
            var nextPoint = new Vector3(0.1f, 0.0f, 0.1f);
            //ナビメッシュエージェントへ目的地を設定
            agent.SetDestination(nextPoint);
        }
}
