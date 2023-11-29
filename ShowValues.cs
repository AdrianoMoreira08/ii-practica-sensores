using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowValues : MonoBehaviour
{
    string text_angular;
    string text_acceleration;
    string text_altitude;
    string text_longitude;
    string text_latitude;
    public TextMeshProUGUI text;
    public GameObject samurai;
    public GameObject Rotator;
    Transform tf;
    Transform rotator;
    // Start is called before the first frame update
    void Start()
    {
        Input.compass.enabled = true;
        tf = samurai.GetComponent<Transform>();
        rotator = Rotator.GetComponent<Transform>();
        text_angular = "Angular speed: ";
        text_acceleration = "Acceleration: ";
        text_altitude = "Altitude: ";
        text_longitude = "Longitude: ";
        text_latitude = "Latitude: ";
        Input.location.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion attitude = Input.gyro.attitude;
        // rotator.rotation = attitude;
        // rotator.Rotate(0f, 0f, 180f, Space.Self);
        // rotator.Rotate(90f, 180f, 0f, Space.World);
        // tf.rotation = Quaternion.Slerp(tf.rotation, rotator.rotation, 0.1f);
        tf.rotation = Quaternion.Euler(0, -Input.compass.trueHeading, 0);
        Vector3 move = new Vector3(Input.acceleration.x, 0, -Input.acceleration.z);
        tf.Translate(move * Time.deltaTime, Space.World);

        text.text = text_angular + Input.gyro.attitude.ToString() + "\n" + 
                    text_acceleration + Input.acceleration.ToString() + "\n" +
                    text_altitude + Input.location.lastData.altitude.ToString() + "\n" +
                    text_longitude + Input.location.lastData.longitude.ToString() + "\n" +
                    text_latitude + Input.location.lastData.latitude.ToString();

    }
}
