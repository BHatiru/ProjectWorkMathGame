using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class RoomInfo
{
    public string name;

    public int X;
    public int Y;
}

public class RoomController : MonoBehaviour
{
    public static RoomController instance;

    string currentWorldName = "Basement";

    RoomInfo currentLoadRoomData;

    Room currRoom;

    Queue<RoomInfo> loadRoomQueue = new Queue<RoomInfo>();

    public List<Room> loadedRooms = new List<Room>();

    bool isLoadingRoom = false;
    bool spawnedBossRoom = false;
    bool updatedRooms = false;

    private void Awake()
    {
        instance = this;
    }
    //TestPurpose
    void Start()
    {
        
        /*LoadRoom("Start", 0, 0);
        LoadRoom("Empty", 1, 0);
        LoadRoom("Empty", -1, 0);
        LoadRoom("Empty", 0, 1);
        LoadRoom("Empty", 0, -1);*/
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            /*AsyncOperation unloadRooms = SceneManager.UnloadSceneAsync("Assets/Scenes/GamingLevel/BasementBasic1");
            loadRoomQueue.Clear();
            loadedRooms.Clear();*/
            DungeonCrawlerController.positionsVisited.Clear();            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }      
        UpdateRoomQueue();
    }
    //Load Rooms In Queue(prevents overlapping and helps to spawn boss in last room in queue)
    void UpdateRoomQueue()
    {
        if (isLoadingRoom)
        {
            return;
        }
        if (loadRoomQueue.Count == 0)
        {
            if (!spawnedBossRoom)
            {
                StartCoroutine(SpawnBossRoom());
            }else if (spawnedBossRoom && !updatedRooms)
            {
                foreach(Room room in loadedRooms)
                {
                    room.RemoveUnconnectedDoors();
                }
                UpdateRooms();
                updatedRooms = true;
            }
            return;
        }

        currentLoadRoomData = loadRoomQueue.Dequeue();
        isLoadingRoom = true;

        StartCoroutine(LoadRoomRoutine(currentLoadRoomData));
    }

    public void RoomsRemover()
    {
        loadedRooms.Clear();
        loadRoomQueue.Clear();       
    }
    //Coroutine to spawn boss
    IEnumerator SpawnBossRoom()
    {
        spawnedBossRoom = true;
        yield return new WaitForSeconds(0.5f);
        if(loadRoomQueue.Count == 0)
        {
            Room bossRoom = loadedRooms[loadedRooms.Count - 1];
            Vector2Int tempRoom = new Vector2Int(bossRoom.X, bossRoom.Y);
            Destroy(bossRoom.gameObject);
            var roomToRemove = loadedRooms.Single(r => r.X == tempRoom.x && r.Y == tempRoom.y);
            loadedRooms.Remove(roomToRemove);
            LoadRoom("End", tempRoom.x, tempRoom.y);
           
        }
    }
    //Loading room
    public void LoadRoom(string name, int x, int y)
    {
        if (DoesRoomExist(x, y))
        {
            return;
        }
        

        RoomInfo newRoomData = new RoomInfo();
        newRoomData.name = name;
        newRoomData.X = x;
        newRoomData.Y = y;

        loadRoomQueue.Enqueue(newRoomData);
    }
    //Coroutine for adding room scenes in main scene
    IEnumerator LoadRoomRoutine(RoomInfo info)
    {
        string roomName = currentWorldName + info.name;

        AsyncOperation loadRoom = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);

        while(loadRoom.isDone == false)
        {
            yield return null;
        }
    }
    //Register each room is they loaded or not 
    public void RegisterRoom(Room room)
    {
        if (!DoesRoomExist(currentLoadRoomData.X, currentLoadRoomData.Y))
        {
            room.transform.position = new Vector3(
                currentLoadRoomData.X * room.Width,
                currentLoadRoomData.Y * room.Height,
                0);

            room.X = currentLoadRoomData.X;
            room.Y = currentLoadRoomData.Y;
            room.name = currentWorldName + "-" + currentLoadRoomData.name + " " + room.X + ", " + room.Y;
            room.transform.parent = transform;

            isLoadingRoom = false;

            if (loadedRooms.Count == 0)
            {
                CameraController.instance.currRoom = room;
            }

            loadedRooms.Add(room);

            //room.RemoveUnconnectedDoors();
        }
        else
        {
            Destroy(room.gameObject);
            isLoadingRoom = false;
        }
    }
    //just bool for checking if room exist
    public bool DoesRoomExist(int x, int y)
    {
        return loadedRooms.Find(item => item.X == x && item.Y == y) != null;
    }
    //Find room
    public Room FindRoom(int x, int y)
    {
        return loadedRooms.Find(item => item.X == x && item.Y == y);
    }
    //Method for choosing random room type 
    public string GetRandomRoomName()
    {
        string[] possibleRooms = new string[]
        {
            "Empty", "Basic1", "Basic1","Basic1","Basic1","Basic1","Basic1"
        };

        return possibleRooms[Random.Range(0, possibleRooms.Length)];
    }
    //For camera transition and room update start
    public void OnPlayerEnterRoom(Room room)
    {
        CameraController.instance.currRoom = room;
        currRoom = room;

        StartCoroutine(RoomCoroutine());
    }
    //coroutine to update rooms
    public IEnumerator RoomCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        UpdateRooms();
    }
    //Method for updating Enemies and Doors
    public void UpdateRooms()
    {
        foreach (Room room in loadedRooms)
        {
            if (currRoom != room)
            {
                EnemyController[] enemies = room.GetComponentsInChildren<EnemyController>();
                if (enemies != null)
                {
                    foreach (EnemyController enemy in enemies)
                    {
                        enemy.notInRoom = true;
                    }

                    foreach (Door door in room.GetComponentsInChildren<Door>())
                    {
                        door.doorCollider.SetActive(false);
                    }
                }
                else
                {
                    foreach (Door door in room.GetComponentsInChildren<Door>())
                    {
                        door.doorCollider.SetActive(false);
                    }
                }
            }
            else
            {
                EnemyController[] enemies = room.GetComponentsInChildren<EnemyController>();
                if (enemies.Length > 0)
                {
                    foreach (EnemyController enemy in enemies)
                    {
                        enemy.notInRoom = false;
                    }
                   foreach (Door door in room.GetComponentsInChildren<Door>())
                    {
                        door.doorCollider.SetActive(true);
                    }
                }
                else
                {
                    foreach (Door door in room.GetComponentsInChildren<Door>())
                    {
                        door.doorCollider.SetActive(false);
                    }
                }

            }
        }
    }
}
