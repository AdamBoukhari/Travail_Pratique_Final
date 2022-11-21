using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float rumbleOffset = 1;
    private RoomManager roomManager;
    private float rumbleCoolDown;
    private int xMinLimit;
    private int xMaxLimit;
    private int yMinLimit;
    private int yMaxLimit;


    private void Start()
    {
        roomManager = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomManager>();
        Camera camera = gameObject.GetComponent<Camera>();
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;
        xMinLimit = (int)(roomManager.GetRoomLimit(Utils.limitsTypes.LEFT) + halfWidth);
        xMaxLimit = (int)(roomManager.GetRoomLimit(Utils.limitsTypes.RIGHT) - halfWidth);
        yMinLimit = (int)(roomManager.GetRoomLimit(Utils.limitsTypes.DOWN) + halfHeight);
        yMaxLimit = (int)(roomManager.GetRoomLimit(Utils.limitsTypes.UP) - halfHeight);
    }

    void Update()
    {
        float nextPositionX = Utils.ManageLimits(target.position.x, xMinLimit, xMaxLimit);
        float nextPositionY = Utils.ManageLimits(target.position.y, yMinLimit, yMaxLimit);

        if (rumbleCoolDown > 0)
        {
            rumbleCoolDown -= Time.deltaTime;
            nextPositionX += Random.Range(-rumbleOffset, rumbleOffset);
            nextPositionY += Random.Range(-rumbleOffset, rumbleOffset);
        }
        gameObject.transform.position = new Vector3(nextPositionX, nextPositionY, -10);
    }


    public void Shake(float time)
    {
        rumbleCoolDown = time;
    }


    public void Shake(float time, float rumble)
    {
        this.rumbleOffset = rumble;
        rumbleCoolDown = time;
    }
}
