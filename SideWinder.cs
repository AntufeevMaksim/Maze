
class SideWinder
{
  public Grid Run(Grid grid)
  {
    Random random = new Random();
    int width = grid.Columns;
    int height = grid.Rows;

    HashSet<int[]> visited_cells = new HashSet<int[]>();

    for(int y=height-1; y>0; y--)////
    {
      for(int x=0; x<width; x++)////
      {
        visited_cells.Add(new int[]{x,y});
        
        if(x == width-1)
        {
          (grid, visited_cells) = ClosingOutRun(visited_cells, grid, random);
          break;
        }

        (grid, visited_cells) = Step(visited_cells, grid, random, x, y);
      }
      (grid, visited_cells) = ClosingOutRun(visited_cells, grid, random);
    }

    for(int x=0; x<width-1; x++)
    {
      grid.Link(x,0, Side.East);
    }

    return grid;
  }

  (Grid, HashSet<int[]>) Step(HashSet<int[]> visited_cells, Grid grid, Random random, int x, int y)
  {
    int num = random.Next(0,2);
    if(num==1)
    {
      grid.Link(x,y,Side.East);
    }
    else
    {
      (grid, visited_cells) = ClosingOutRun(visited_cells, grid, random);
    }
    return (grid, visited_cells);
  } 




  (Grid, HashSet<int[]>) ClosingOutRun(HashSet<int[]> visited_cells, Grid grid, Random random)
  {
    if(visited_cells.Count != 0)
    {
      int[] cell = visited_cells.ElementAt(random.Next(visited_cells.Count()));
      grid.Link(cell[0], cell[1], Side.North);
      visited_cells.Clear();
    }
    return (grid, visited_cells);
  }


}