public class BoatMovements
{
    public static bool CanTravelTo(bool[,] gameMatrix, int fromRow, int fromColumn, int toRow, int toColumn)
    {
        int rows = gameMatrix.GetLength(0);
        int columns = gameMatrix.GetLength(1);

        // Check if the start or end positions are out of bounds or are land
        if (fromRow < 0 || fromRow >= rows || fromColumn < 0 || fromColumn >= columns ||
            toRow < 0 || toRow >= rows || toColumn < 0 || toColumn >= columns ||
            !gameMatrix[fromRow, fromColumn] || !gameMatrix[toRow, toColumn])
        {
            return false;
        }

        // Direction vectors for moving up, down, left, right
        int[] rowDir = { -1, 1, 0, 0 };
        int[] colDir = { 0, 0, -1, 1 };

        // Queue for BFS
        Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
        queue.Enqueue(new Tuple<int, int>(fromRow, fromColumn));

        // Set to keep track of visited positions
        HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();
        visited.Add(new Tuple<int, int>(fromRow, fromColumn));

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int currentRow = current.Item1;
            int currentColumn = current.Item2;

            // Check if we have reached the destination
            if (currentRow == toRow && currentColumn == toColumn)
            {
                return true;
            }

            // Explore neighbors
            for (int i = 0; i < 4; i++)
            {
                int newRow = currentRow + rowDir[i];
                int newColumn = currentColumn + colDir[i];

                if (newRow >= 0 && newRow < rows && newColumn >= 0 && newColumn < columns &&
                    gameMatrix[newRow, newColumn] && !visited.Contains(new Tuple<int, int>(newRow, newColumn)))
                {
                    queue.Enqueue(new Tuple<int, int>(newRow, newColumn));
                    visited.Add(new Tuple<int, int>(newRow, newColumn));
                }
            }
        }

        // No path found
        return false;
    }
    /*
        public static void Main(string[] args)
        {

            bool[,] gameMatrix =
              {
                 {false, true,  true,  false, false, false},
                 {true,  true,  true,  false, false, false},
                 {true,  true,  true,  true,  true,  true},
                 {false, true,  true,  false, true,  true},
                 {false, true,  true,  true,  false, true},
                 {false, false, false, false, false, false},
             };

            Console.WriteLine(BoatMovements.CanTravelTo(gameMatrix, 3, 2, 2, 2)); // true, Valid move
            Console.WriteLine(BoatMovements.CanTravelTo(gameMatrix, 3, 2, 3, 4)); // false, Can't travel through land
            Console.WriteLine(BoatMovements.CanTravelTo(gameMatrix, 3, 2, 6, 2)); // false, Out of bounds
        }
        */
}