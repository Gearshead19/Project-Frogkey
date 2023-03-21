using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_move : MonoBehaviour
{
    //x is speed, while y is added to, and z is subtracted
    public Vector3 x_axis_move;
    private bool x_bool = true;
    //true == postive and false = negative

    public Vector3 y_axis_move;
    private bool y_bool = true;

    public Vector3 z_axis_move;
    private bool z_bool = true;

    private Vector3 self_orign;

    public Vector3 way_point;
    public float way_point_speed = 0;
    public float stop_distance = 1;
    private bool way_point_bool = true;

    // Start is called before the first frame update
    void Start()
    {
        self_orign = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveManager();
    }


    void MoveManager()
    {
        if (y_axis_move.x > 0)
        {
            Y_movement();
        }

        if (x_axis_move.x > 0)
        {
            X_movement();
        }

        if (z_axis_move.x > 0)
        {
            Z_movement();
        }

        if (way_point_speed > 0 && way_point != null)
        {
            way_point_movement();
        }
    }

    void Y_movement()
    {
        if (y_bool == true)
        {
            if (this.transform.position.y > (self_orign.y + y_axis_move.y))
            {
                y_bool = false;
            }
            else
            {
                this.transform.Translate(0, y_axis_move.x * Time.deltaTime, 0);
            }
        }
        else
        {
            if (this.transform.position.y < (self_orign.y - y_axis_move.z))
            {
                y_bool = true;
            }
            else
            {
                this.transform.Translate(0, -(y_axis_move.x * Time.deltaTime), 0);
            }
        }
    }

    void X_movement()
    {
        if (x_bool == true)
        {
            if (this.transform.position.x > (self_orign.x + x_axis_move.y))
            {
                x_bool = false;
            }
            else
            {
                this.transform.Translate(x_axis_move.x * Time.deltaTime, 0, 0);
            }
        }
        else
        {
            if (this.transform.position.x < (self_orign.x - x_axis_move.z))
            {
                x_bool = true;
            }
            else
            {
                this.transform.Translate(-(x_axis_move.x * Time.deltaTime), 0, 0);
            }
        }
    }

    void Z_movement()
    {
        if (z_bool == true)
        {
            if (this.transform.position.z > (self_orign.z + z_axis_move.y))
            {
                z_bool = false;
            }
            else
            {
                this.transform.Translate(0, 0, z_axis_move.x * Time.deltaTime);
            }
        }
        else
        {
            if (this.transform.position.z < (self_orign.z - z_axis_move.z))
            {
                z_bool = true;
            }
            else
            {
                this.transform.Translate(0, 0, -(z_axis_move.x * Time.deltaTime));
            }
        }
    }

    void way_point_movement()
    {
        if (way_point_bool == true)
        {
            if (Vector3.Distance(way_point, this.gameObject.transform.position) < stop_distance)
            {
                way_point_bool = false;
            }
            else
            {
                move_to_waypoint(way_point);
                Movement_waypoint();
            }
        }
        else
        {
            if (Vector3.Distance(this.gameObject.transform.position, self_orign) < stop_distance)
            {
                way_point_bool = true;
            }
            else
            {
                move_to_waypoint(self_orign);
                Movement_waypoint();
            }
        }
    }

    void move_to_waypoint(Vector3 point)
    {
        Vector3 director = point - transform.position;
        Quaternion rotator = Quaternion.LookRotation(director);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotator, way_point_speed * Time.deltaTime);
    }

    void Movement_waypoint()
    {
        transform.Translate(0, 0, way_point_speed * Time.deltaTime);
    }
}
