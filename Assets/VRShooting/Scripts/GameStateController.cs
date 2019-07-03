using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    [SerializeField] GameObject gameReady;  // GameReady ゲームオブジェクト参照
    [SerializeField] RemainTimer timer;     // RemainTimer コンポーネント参照
    [SerializeField] GameObject gameStart;  // GameStart ゲームオブジェクト参照
    [SerializeField] GameObject gameOver;   // GameOver ゲームオブジェクト参照
    [SerializeField] GameObject result;     // Result ゲームオブジェクト参照
    [SerializeField] GameObject player;     // PlayerGun ゲームオブジェクト参照
    [SerializeField] GameObject spawners;   // Spawner ゲームオブジェクト参照
    

    // ステートベースクラス
    abstract class BaseState
    {
        public GameStateController Controller { get; set; }

        public enum StateAction
        {
            STATE_ACTION_WAIT,
            STATE_ACTION_NEXT
        }

        public BaseState(GameStateController c) { Controller = c; }

        public virtual void OnEnter() { }
        public virtual StateAction OnUpdate() { return StateAction.STATE_ACTION_NEXT; }
        public virtual void OnExit() { }
    }

    // ゲーム開始準備ステート
    class ReadyState : BaseState
    {
        float timer;

        public ReadyState(GameStateController c) : base(c) { }
        public override void OnEnter()
        {
            // ready文字列を表示
            Controller.gameReady.SetActive(true);
        }
        public override StateAction OnUpdate()
        {
            timer += Time.deltaTime;
            // 5秒後に次へ
            if (timer > 5.0f)
            {
                return StateAction.STATE_ACTION_NEXT;
            }
            return StateAction.STATE_ACTION_WAIT;
        }
        public override void OnExit()
        {
            // ready文字列を非表示
            Controller.gameReady.SetActive(false);
        }
    }

    // ゲーム開始表示ステート
    class StartState : BaseState
    {
        float timer;

        public StartState(GameStateController c) : base(c) { }
        public override void OnEnter()
        {
            // タイマーを表示
            Controller.timer.gameObject.SetActive(true);

            // start文字列を表示
            Controller.gameStart.SetActive(true);

            // playerを表示
            Controller.player.SetActive(true);

            // spawnersを表示
            Controller.spawners.SetActive(true);
        }
        public override StateAction OnUpdate()
        {
            timer += Time.deltaTime;
            // 1秒後に次へ
            if (timer > 1.0f)
            {
                return StateAction.STATE_ACTION_NEXT;
            }
            return StateAction.STATE_ACTION_WAIT;
        }
        public override void OnExit()
        {
            // Start文字列を非表示
            Controller.gameStart.SetActive(false);
        }
    }

    // ゲーム中ステート
    class PlayingState : BaseState
    {
        public PlayingState(GameStateController c) : base(c) { }
        public override StateAction OnUpdate()
        {
            // タイマーが終了したらゲームオーバーへ
            if (!Controller.timer.IsCountingDown())
            {
                return StateAction.STATE_ACTION_NEXT;
            }
            return StateAction.STATE_ACTION_WAIT;
        }

        public override void OnExit()
        {
            // プレイヤーを非表示
            Controller.player.SetActive(false);

            // 敵の発生を止める
            Controller.spawners.SetActive(false);
        }
    }

    // ゲームオーバー表示ステート
    class GameOverState : BaseState
    {
        
        GameObject cubes = GameObject.FindWithTag("cubes");
        float timer;
        public GameOverState(GameStateController c) : base(c) { }
        public override void OnEnter()
        {
            // ゲームオーバーを表示
            Controller.gameOver.SetActive(true);
            Destroy(cubes);
            
                
        }
        public override StateAction OnUpdate()
        {
            timer += Time.deltaTime;
            // 2秒後に次へ
            if (timer > 2.0f)
            {
                return StateAction.STATE_ACTION_NEXT;
            }
            return StateAction.STATE_ACTION_WAIT;
        }
        public override void OnExit()
        {
            // ゲームオーバーを非表示
            Controller.gameOver.SetActive(false);
        }
    }

    // リザルト表示ステート
    class ResultState : BaseState
    {
        GameObject camera = GameObject.FindWithTag("camera");
        public ResultState(GameStateController c) : base(c) { }
        public override void OnEnter()
        {
            // リザルト表示
            Controller.result.SetActive(true);
            camera.transform.position  = new Vector3(1f,3f,0f);
        }
        public override StateAction OnUpdate() { return StateAction.STATE_ACTION_WAIT; }
    }

    // ゲームの状態リスト
    List<BaseState> state;

    // カレントのゲーム状態
    int currentState;

    void Start()
    {
        // ゲームの状態を順番に登録
        state = new List<BaseState> {
            new ReadyState(this),
            new StartState(this),
            new PlayingState(this),
            new GameOverState(this),
            new ResultState(this)
        };

        // 最初の状態の開始処理
        state[currentState].OnEnter();
    }

    void Update()
    {
        // 状態を更新
        var stateAction = state[currentState].OnUpdate();

        // 次の状態へ遷移するか判定
        if (stateAction == BaseState.StateAction.STATE_ACTION_NEXT)
        {
            // 状態の終了処理
            state[currentState].OnExit();
            // 次の状態へ
            ++currentState;
            // 状態の開始処理
            state[currentState].OnEnter();
        }
    }
}