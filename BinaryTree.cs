
class BinaryTree : Algorithm
{
  public override Grid CreateMaze(Grid grid)
  {
    Random choose_side = new Random();
    int width = grid.Columns;
    int height = grid.Rows;

    for (int y = 1; y < height; y++)
    {
      for (int x = 0; x < width - 1; x++)
      {
        int num = choose_side.Next(0, 2);
        if (num == 0)
        {
          grid.Link(x, y, Side.North);
        }
        else
        {
          grid.Link(x, y, Side.East);
        }
      }
    }

    for (int x = 0; x < width - 1; x++) // draw up line
    {
      grid.Link(x, 0, Side.East);
    }

    for (int y = height - 1; y > 0; y--) // draw right column
    {
      grid.Link(width - 1, y, Side.North);
    }

    grid.MakeInputExit();
    return grid;
  }
}