using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private CinemachineVirtualCamera _vcam;
    [SerializeField] private List<Room> _rooms;

    private void Start()
    {
        foreach (Room room in _rooms)
        {
            room.OnEnter += EnterRoom;
        }

#if !UNITY_EDITOR
        StartCoroutine(SwapRooms());
#endif
    }

    private void OnDestroy()
    {
        foreach (Room room in _rooms)
        {
            room.OnEnter -= EnterRoom;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EnterRoom(_rooms[0].transform);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            EnterRoom(_rooms[1].transform);
        }
    }

    IEnumerator SwapRooms()
    {
        while (true)
        {
            EnterRoom(_rooms[0].transform);
            yield return new WaitForSeconds(2f);
            EnterRoom(_rooms[1].transform);
            yield return new WaitForSeconds(2f);
        }
    }

    private void EnterRoom(Transform location)
    {
        _vcam.Follow = location;
    }
}
