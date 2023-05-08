using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Boss_States
{
    MOVE_TO, MOVE_AWAY, IDLE, REJUVENATE, REJUVENATEGOTO
}

public enum Boss_Attacks
{
    CLOSE_ATTACK, RANGE_FOLLOW_ATTACK, RANGE_SPREAD_ATTACK, IDLE_ATTACK
}



public class Boss_AI_script : MonoBehaviour
{
    public Boss_States Boss_state = new Boss_States();

    public Boss_Attacks Boss_Attack = new Boss_Attacks();

    private GameObject froggy_player;

    public float speed = 6;

    private float dis = 0;

    public float close_dis = 1;

    public float far_dis = 10;

    public float med_dis = 3;

    private GameObject heal;

    public float heal_dis = 0;

    private GameObject boss_body;

    private Vector3 start_pos;

    private float timer = 0;

    void Start()
    {
        start_pos = this.transform.position;
        froggy_player = GameObject.FindGameObjectWithTag("FindPlayer");
        heal = GameObject.FindGameObjectWithTag("boss_heal");
        boss_body = GameObject.FindGameObjectWithTag("boss_body");
    }

    void Update()
    {
        dis = Vector3.Distance(this.gameObject.transform.position, froggy_player.gameObject.transform.position);

        if (heal != null || heal.activeSelf == true)
        {
            heal_dis = Vector3.Distance(this.gameObject.transform.position, heal.gameObject.transform.position);
        }

        Boss_state_machine();
        Boss_attack_event();
        Face_player();
        timer_count();
    }

    void FixedUpdate()
    {
        if (heal != null || heal.activeSelf == true)
        {
            if (boss_body.GetComponent<EnemyHealth>().Half_health_check() == true)
            {
                Boss_state = Boss_States.REJUVENATEGOTO;
            }
        }
    }

    private void timer_count()
    {
        timer = timer + 1;
    }

    void Boss_state_machine()
    {
        switch (Boss_state)
        {
            case Boss_States.IDLE:
                telepot_to_start();

                if (dis > far_dis)
                {
                    Boss_state = Boss_States.MOVE_TO;
                }
                else if (dis < med_dis)
                {
                    Boss_state = Boss_States.MOVE_AWAY;
                }
                break;


            case Boss_States.MOVE_TO:
                Move_to_player(froggy_player);

                if(dis < med_dis)
                {
                    Boss_state = Boss_States.MOVE_AWAY;
                }
                break;


            case Boss_States.MOVE_AWAY:
                Move_from_player(froggy_player);

                if(dis > far_dis)
                {
                    Boss_state = Boss_States.MOVE_TO;
                }
                else if(dis < (close_dis))
                {
                    Boss_state = Boss_States.IDLE;
                }
                break;

            case Boss_States.REJUVENATEGOTO:
                if (heal != null || heal.activeSelf == true)
                {
                    Move_to_player(heal);
                }

                if(heal_dis < 1)
                {

                    boss_body.GetComponent<EnemyHealth>().Untouchable();
                    Boss_state = Boss_States.REJUVENATE;
                }

                break;

            case Boss_States.REJUVENATE:
                boss_body.GetComponent<EnemyHealth>().Healing();


                if (heal == null || heal.activeSelf == false)
                {

                    boss_body.GetComponent<EnemyHealth>().Touchable();
                    Boss_state = Boss_States.IDLE;
                }
                else if(boss_body.GetComponent<EnemyHealth>().Max_health_check() == true)
                {

                    boss_body.GetComponent<EnemyHealth>().Touchable();
                    Boss_state = Boss_States.IDLE;
                }

                break;
        }
    }

    void Boss_attack_event()
    {
        switch (Boss_Attack)
        {
            case Boss_Attacks.CLOSE_ATTACK:

                break;

            case Boss_Attacks.RANGE_FOLLOW_ATTACK:

                break;

            case Boss_Attacks.RANGE_SPREAD_ATTACK:

                break;

            case Boss_Attacks.IDLE_ATTACK:

                if(timer > 5)
                {
                    if (dis < close_dis * 2)
                    {
                        Boss_Attack = Boss_Attacks.CLOSE_ATTACK;
                    }
                    else if( 2 == 2 )
                    {
                        Boss_Attack = Boss_Attacks.RANGE_SPREAD_ATTACK;
                    }
                    else
                    {
                        Boss_Attack = Boss_Attacks.RANGE_FOLLOW_ATTACK;
                    }

                }
               


                break;


        }

    }

    void Move_to_player(GameObject goto_location)
    {
        if (goto_location.transform.position.x < this.transform.position.x)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (goto_location.transform.position.x > this.transform.position.x)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (goto_location.transform.position.z < this.transform.position.z)
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }

        if (goto_location.transform.position.z > this.transform.position.z)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    void Move_from_player(GameObject goaway_location)
    {
        if (goaway_location.transform.position.x > this.transform.position.x)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (goaway_location.transform.position.x < this.transform.position.x)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (goaway_location.transform.position.z > this.transform.position.z)
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }

        if (goaway_location.transform.position.z < this.transform.position.z)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }

    void Face_player()
    {

    }

    void telepot_to_start()
    {
        this.transform.position = start_pos;
    }

}
