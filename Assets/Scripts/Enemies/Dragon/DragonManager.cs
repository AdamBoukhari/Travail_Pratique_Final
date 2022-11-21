using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonManager : MonoBehaviour
{
    public enum DragonStateToSwitch { PassiveFar, PassiveClose, PassiveRange, AggressiveFar, AggressiveClose, AggressiveRange }
    private DragonState dragonState;
    private DragonStateToSwitch state = DragonStateToSwitch.PassiveFar;
    private RoomManager roomManager;
    private MovingManager movements;
    private Vector2 roomPosition;

    private void Start()
    {
        roomManager = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomManager>();
        movements = gameObject.GetComponent<MovingManager>();
        roomPosition = gameObject.transform.position;
        dragonState = GetComponent<DragonStatePassiveFar>();
        dragonState.enabled = true;
        dragonState.Init();
    }

    public void UpdateDragon()
    {
        dragonState.ManageStateChange();
        dragonState.UpdateDragon();
    }

    public void ChangeDragonState(DragonStateToSwitch nextState)
    {
        dragonState.enabled = false;
        switch (nextState)
        {
            case DragonStateToSwitch.PassiveFar:
                {
                    dragonState = gameObject.GetComponent<DragonStatePassiveFar>();
                    state = DragonStateToSwitch.PassiveFar;
                    break;
                }
            case DragonStateToSwitch.PassiveClose:
                {
                    dragonState = gameObject.GetComponent<DragonStatePassiveClose>();
                    state = DragonStateToSwitch.PassiveClose;
                    break;
                }
            case DragonStateToSwitch.PassiveRange:
                {
                    dragonState = gameObject.GetComponent<DragonStatePassiveRange>();
                    state = DragonStateToSwitch.PassiveRange;
                    break;
                }
            case DragonStateToSwitch.AggressiveFar:
                {
                    dragonState = gameObject.GetComponent<DragonStateAggressiveFar>();
                    state = DragonStateToSwitch.AggressiveFar;
                    break;
                }
            case DragonStateToSwitch.AggressiveClose:
                {
                    dragonState = gameObject.GetComponent<DragonStateAggressiveClose>();
                    state = DragonStateToSwitch.AggressiveClose;
                    break;
                }
            case DragonStateToSwitch.AggressiveRange:
                {
                    dragonState = gameObject.GetComponent<DragonStateAggressiveRange>();
                    state = DragonStateToSwitch.AggressiveRange;
                    break;
                }
        }
        dragonState.enabled = true;
        dragonState.Init();
    }

    public Vector2 GetRoomPosition()
    {
        return roomPosition;
    }

    public void UpdateRoomPosition(Vector2Int offset)
    {
        if (VerifyAllTiles(offset))
        {
            roomPosition = new Vector2(roomPosition.x + offset.x, roomPosition.y + offset.y);
            movements.UpdateTargetPosition(roomPosition.x * Utils.UNIT_SIZE, roomPosition.y * Utils.UNIT_SIZE);
        }
    }

    private bool VerifyAllTiles(Vector2Int offset)
    {
        bool canMove = true;

        //Première tuile
        Vector2 firstTilePosition = new Vector2(roomPosition.x - (0.5f * Utils.UNIT_SIZE), roomPosition.y + (0.5f * Utils.UNIT_SIZE));
        Vector2 expectedFirstTileDestination = new Vector2(firstTilePosition.x + offset.x, firstTilePosition.y + offset.y);
        if (expectedFirstTileDestination != roomManager.MoveTo(firstTilePosition, offset.x, offset.y))
            canMove = false;

        //Deuxième tuile
        Vector2 secondTilePosition = new Vector2(roomPosition.x + (0.5f * Utils.UNIT_SIZE), roomPosition.y + (0.5f * Utils.UNIT_SIZE));
        Vector2 expectedSecondTileDestination = new Vector2(secondTilePosition.x + offset.x, secondTilePosition.y + offset.y);
        if (expectedSecondTileDestination != roomManager.MoveTo(secondTilePosition, offset.x, offset.y))
            canMove = false;

        //Troisième tuile
        Vector2 thirdTilePosition = new Vector2(roomPosition.x - (0.5f * Utils.UNIT_SIZE), roomPosition.y - (0.5f * Utils.UNIT_SIZE));
        Vector2 expectedThirdTileDestination = new Vector2(thirdTilePosition.x + offset.x, thirdTilePosition.y + offset.y);
        if (expectedThirdTileDestination != roomManager.MoveTo(thirdTilePosition, offset.x, offset.y))
            canMove = false;

        //Quatrième tuile
        Vector2 fourthTilePosition = new Vector2(roomPosition.x + (0.5f * Utils.UNIT_SIZE), roomPosition.y - (0.5f * Utils.UNIT_SIZE));
        Vector2 expectedFourthTileDestination = new Vector2(fourthTilePosition.x + offset.x, fourthTilePosition.y + offset.y);
        if (expectedFourthTileDestination != roomManager.MoveTo(fourthTilePosition, offset.x, offset.y))
            canMove = false;

        return canMove;
    }

    public bool IsMyPosition(Vector2 position)
    {
        bool isPosition = false;

        if (position == new Vector2(roomPosition.x + (0.5f * Utils.UNIT_SIZE), roomPosition.y + (0.5f * Utils.UNIT_SIZE)))
            isPosition = true;
        else if (position == new Vector2(roomPosition.x + (0.5f * Utils.UNIT_SIZE), roomPosition.y - (0.5f * Utils.UNIT_SIZE)))
            isPosition = true;
        else if (position == new Vector2(roomPosition.x - (0.5f * Utils.UNIT_SIZE), roomPosition.y + (0.5f * Utils.UNIT_SIZE)))
            isPosition = true;
        else if (position == new Vector2(roomPosition.x - (0.5f * Utils.UNIT_SIZE), roomPosition.y - (0.5f * Utils.UNIT_SIZE)))
            isPosition = true;

        return isPosition;
    }
}
