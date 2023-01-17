using System;

namespace MudRoom
{
    public class MudRoom
    {
        private static int CREATURESEED = 1;
        private static int ROOMSEED = 1;

        public static void Main(String[] args) {
            Console.WriteLine("Welcome to the MudRoom!");
            
            List<Room> roomList = CreateRooms();
            FillRooms(roomList);
            ExecutionLoop(roomList);

            PrintRoomInformation(1, roomList);
        }

        // Build The Dungeon!!
        // rebuild this to work with a recursive helper funcion
        // aim random generation of the rooms
        private static List<Room> CreateRooms() {
            int roomCount;
            do
            {
                Console.WriteLine("How many rooms would you like to make?(1-16)");
                roomCount = Convert.ToInt32(Console.ReadLine()) + 0;
            } while (roomCount <= 0 || roomCount > 16);

            List<Room> roomList =  new List<Room>();
            Room entrance = new Room(ROOMSEED++);
            roomList.Add(entrance);

            for (int x = 1; x < roomCount; x++)
            {

                Room newRoom = new Room(ROOMSEED++);
                bool added = entrance.AddRoomConnection(newRoom);
                roomList.Add(newRoom);

                if (!added)
                {
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

            return roomList;
        }

        // Populate Dungeon with creatures
        private static void FillRooms(List<Room> roomList)
        {

            // Creature Building Section
            int creatureCount;
            do
            {
                Console.WriteLine("How many creatures would you like to make?(at least 1)");
                creatureCount = Convert.ToInt32(Console.ReadLine());
            } while (creatureCount < 0);

            Random r = new Random();
            for (int x = 0; x < creatureCount; x++)
            {
                if (x == 0)
                {
                    roomList[0].AddCreatureToRoom(new Creature(CREATURESEED++, 0));
                }
                else
                {
                    roomList[r.Next(roomList.Count - 1)].AddCreatureToRoom(new Creature(CREATURESEED++, (r.Next(2)+1)));
                }
            }
        }

        // main execution loop
        private static void ExecutionLoop(List<Room> roomList)
        {
            String? inLine;
            PrintInstructions();
            Console.WriteLine("Enter a command after the promt");
            do
            {
                Console.Write(">> ");
                inLine = Console.ReadLine();
                if (String.IsNullOrEmpty(inLine)) {
                    Console.WriteLine("Enter a command after the promt");
                }
                else if (inLine.Contains(":"))
                {
                    ExecuteCreatureCommand(inLine, roomList);
                }
                else {
                    ExecutePlayerCommand(inLine, roomList);
                }

            } while (inLine != "exit");
        }

        private static void PrintInstructions() {
            Console.WriteLine("Command Type: Player\n\thelp: print commands\n\tlook: print room condition\n\tclean: clean current room\n\tdirty: make the current room dirtier\n\tnorth,east,south,west: move in the given direction\n\texit: quit game");
            Console.WriteLine("Command Type: Creature\n\tNOTE: all creature commands follow this pattern [creatureNumber]:[command]\n\tlook: diplay creatures room information\n\tclean: force creature to clean the room\n\tdirty: force creature to dirty the room\n\tnorth,east,south,west: force creature to move in the given direction");
        }

        /**
         * Parse command string to get creature ID and command
         **/
        private static void ExecuteCreatureCommand(string commandString, List<Room> roomList)
        {
            String[] commands = commandString.Split(':');
            int creatureID = Int32.Parse(commands[0]);
            String command = commands[1];
            ExecuteCommand(creatureID, command, roomList);
        }

        /**
         * this is just a passthrough to the execute command function
         */
        private static void ExecutePlayerCommand(string commandString, List<Room> roomList) => ExecuteCommand(1, commandString, roomList);

        /**
         * Execute All Commands 
         */
        private static void ExecuteCommand(int charactedID, string command, List<Room> roomList)
        {
            Console.WriteLine($"Character #{charactedID} performs {command}");
            switch (command) {
                case "look":
                    Console.WriteLine("Look Command");
                    break;
                case "clean":
                    Console.WriteLine("Clean Command");
                    break;
                case "dirty":
                    Console.WriteLine("Dirty Command");
                    break;
                case "north":
                    Console.WriteLine("Move North Command");
                    break;
                case "east":
                    Console.WriteLine("Move North Command");
                    break;
                case "south":
                    Console.WriteLine("Move North Command");
                    break;
                case "west":
                    Console.WriteLine("Move North Command");
                    break;
            }
        }

        private static void PrintRoomInformation(int roomId, List<Room> roomList) {
            foreach(Room r in roomList)
            {
                if (r.IsRoomNumber(roomId)) { 
                    Console.WriteLine(r.ToString());
                }
            }
        }
    }
}