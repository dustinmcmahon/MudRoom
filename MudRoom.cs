using System;

namespace MudRoom
{
    public class MudRoom {

        public static void Main(String[] args) {
            Console.WriteLine("Welcome to the MudRoom!");
            int roomCount;
            do
            {
                Console.WriteLine("How many rooms would you like to make?(1-16)");
                roomCount = Convert.ToInt32(Console.ReadLine());
            } while (roomCount < 0 || roomCount > 16);

            Room entrance = new Room();
            Room curRoom = entrance;

            for (int x = 1; x < roomCount; x++) {
                Room newRoom = new Room();
                bool added = entrance.AddRoomConnection(newRoom);
                if (!added) {
                    Room? location = entrance.GetNorthRoom();
                    if (location != null) added = location.AddRoomConnection(newRoom);
                    if (!added)
                    {
                        location = entrance.GetEastRoom();
                        if (location != null) added = location.AddRoomConnection(newRoom);
                        if (!added)
                        {
                            location = entrance.GetSouthRoom();
                            if (location != null) added = location.AddRoomConnection(newRoom);
                            if (!added)
                            {
                                location = entrance.GetWestRoom();
                                if (location != null) added = location.AddRoomConnection(newRoom);
                                if (!added)
                                {
                                    Console.WriteLine("Building is Full!");
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(entrance.ToString());
        }
    }
}