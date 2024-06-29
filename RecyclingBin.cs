public class RecyclingBin
{
    protected List<string> recyclables = new List<string>();
    public void Add(string recyclable)
    {
        if (recyclable.Split(' ').Length > 1 && recyclable.Split(' ')[1].Length > 3)
        {
            recyclables.Add(recyclable);
        }
    }

    public List<IGrouping<string, string>> SortRecyclabes()
    {
        return recyclables.GroupBy(recyclable => recyclable.Split(' ').First()).ToList();
    }

    /*   public static async Task Main(string[] args)
       {
           RecyclingBin recyclingBin = new RecyclingBin();
           recyclingBin.Add("metal pipe");
           recyclingBin.Add("plastic toy");
           recyclingBin.Add("metal bar");
           recyclingBin.Add("copper wire");
           recyclingBin.Add("plastic button");
           recyclingBin.Add("wire");
           recyclingBin.Add("brass");

           var result = recyclingBin.SortRecyclabes();

           foreach (var group in result)
           {
               Console.WriteLine($"Group: {group.Key}");
               foreach (var item in group)
               {
                   Console.WriteLine($"  Item: {item}");
               }
           }
       }*/
}