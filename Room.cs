namespace MudRoom
{
    internal class Room
    {
        private int _roomId;
        private Room? North;
        private Room? East;
        private Room? South;
        private Room? West;
        private List<Creature> CreatureList = new List<Creature>();
        // cleaness of the room 0 = dirty, 1 = half clean/dirty, 2 = clean
        private int state;

        public Room(int roomID)
        {
            _roomId = roomID;
            this.North = null;
            this.East = null;
            this.South = null;
            this.West = null;
            Random random = new Random();
            state = random.Next(3);
        }

        // getters and setters for the room exits
        public Room? GetNorthRoom() => North;
        public void SetNorthRoom(Room room) => North = room;
        public Room? GetEastRoom() => East;
        public void SetEastRoom(Room room) => East = room;
        public Room? GetSouthRoom() => South;
        public void SetSouthRoom(Room room) => South = room;
        public Room? GetWestRoom() => West;
        public void SetWestRoom(Room room) => West = room;

        public bool AddRoomConnection(Room room) {
            bool res = true;
            if (North == null) SetNorthRoom(room);
            else if (East == null) SetEastRoom(room);
            else if (South == null) SetSouthRoom(room);
            else if (West == null) SetWestRoom(room);
            else return false;
            return res;
        }

        public void CleanRoom() {
            if (state < 2) state++;
        }
        public void DirtyRoom() {
            if (state > 0) state--;
        }

        // add creature to the room
        public void AddCreatureToRoom(Creature creature) => CreatureList.Add(creature);
        //remove creature from the room
        public bool RemoveCreature(Creature creature) {
            return CreatureList.Remove(creature);
        }

        public override String ToString() {
            String res = $"Room #{_roomId} is {RoomState()}:\nExits:\n";
            if (North != null) { res = $"{res}\tNorth\n"; }
            if (East != null) { res = $"{res}\tEast\n"; }
            if (South != null) { res = $"{res}\tSouth\n"; }
            if (West != null) { res = $"{res}\tWest\n"; }
            if (North == null && East == null && South == null && West == null) { res = $"{res}None\n"; }

            res = $"{res}Creatures:\n";
            foreach (Creature x in CreatureList) {
                res = $"{res}\t{x}\n";
            }

            return res;
        }

        public String RoomState() {
            switch (state) {
                case 0:
                    return "dirty";
                case 1:
                    return "half clean";
                default:
                    return "clean";
            }
        }
    }
}
