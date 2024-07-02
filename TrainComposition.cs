using System;
using System.Collections.Generic;

public class TrainComposition
{
    private LinkedList<int> wagons = new LinkedList<int>();
    public void AttachWagonFromLeft(int wagonId)
    {
        wagons.AddFirst(wagonId);
    }

    public void AttachWagonFromRight(int wagonId)
    {
        wagons.AddLast(wagonId);
    }

    public int DetachWagonFromLeft()
    {
        if (wagons.Count == 0)
        {
            throw new InvalidOperationException("No wagons to detach");
        }

        int leftWagon = wagons.First.Value;
        wagons.RemoveFirst();
        return leftWagon;
    }
    public int DetachWagonFromRight()
    {
        if (wagons.Count == 0)
        {
            throw new InvalidOperationException("No wagons to detach");
        }

        int rightWagon = wagons.Last.Value;
        wagons.RemoveLast();
        return rightWagon;
    }

    /*  public static void Main(string[] args)
      {
          TrainComposition train = new TrainComposition();
          train.AttachWagonFromLeft(7);
          train.AttachWagonFromLeft(13);
          Console.WriteLine(train.DetachWagonFromRight()); // 7 
          Console.WriteLine(train.DetachWagonFromLeft()); // 13
      }*/
}