
class SideWinder : Algorithm
{
  public override Grid Run(Grid grid)
  {
    TerminalInputOutput graphics = new();

    Random random = new();
    int width = grid.Columns;
    int height = grid.Rows;
    HashSet<CellCoords> visited_cells = new();

    for (int y = height - 1; y > 0; y--)
    {
      for (int x = 0; x < width; x++)
      {
        CellCoords cell = new(x, y);
        visited_cells.Add(cell);

        if (cell.X == width - 1)
        {
          (grid, visited_cells) = ClosingOutRun(visited_cells, grid, random);
          break;
        }

        (grid, visited_cells) = Step(visited_cells, grid, random, cell);

        //        graphics.Draw(grid);
        //        System.Threading.Thread.Sleep(300);
      }
      (grid, visited_cells) = ClosingOutRun(visited_cells, grid, random);
    }

    grid = DrawUpLine(grid, width);
    grid.MakeInputExit();
    return grid;
  }

  (Grid, HashSet<CellCoords>) Step(HashSet<CellCoords> visited_cells, Grid grid, Random random, CellCoords cell)
  {
    int num = random.Next(0,2);
    if(num==1)
    {
      grid.Link(cell.X, cell.Y, Side.East);
    }
    else
    {
      (grid, visited_cells) = ClosingOutRun(visited_cells, grid, random);
    }
    return (grid, visited_cells);
  } 




  (Grid, HashSet<CellCoords>) ClosingOutRun(HashSet<CellCoords> visited_cells, Grid grid, Random random)
  {
    if(visited_cells.Count != 0)
    {
      CellCoords cell = visited_cells.ElementAt(random.Next(visited_cells.Count())); //random cell in this run
      grid.Link(cell.X, cell.Y, Side.North);
      visited_cells.Clear();
    }
    return (grid, visited_cells);
  }

   Grid DrawUpLine(Grid grid, int width)
  {
    for (int x = 0; x < width - 1; x++) //up line
    {
      grid.Link(x, 0, Side.East);
    }
    return grid;
  }
}
