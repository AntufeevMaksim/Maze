
class ASCIIGraphics
{
  public void Draw(Grid grid)
  {
    for(int y=0; y<grid.Rows; y++)
    {
      for(int x=0; x<grid.Rows; x++)
      {
        DrawCell(x,y, grid[x,y]);
      }
    }
  }

  void DrawCell(int x, int y, Cell cell)
  {
     

    HashSet<Side> empty_walls = cell.Links;

    //north wall
    Console.Write("+");
    if(!empty_walls.Contains(Side.North)){Console.Write("---");}
    Console.SetCursorPosition(4*x+4, 2*y+1);
    Console.Write("+");

    //east wall
    if(!empty_walls.Contains(Side.East))
    {
      Console.SetCursorPosition(4*x, 2*y+2);
      Console.Write("|");
    }
    Console.SetCursorPosition(4*x, 2*y+3);
    Console.Write("+");    

    //south wall
    if(!empty_walls.Contains(Side.South)){Console.Write("---");}
    Console.SetCursorPosition(4*x+4, 2*y+3);
    Console.Write("+");

    if(!empty_walls.Contains(Side.East))
    {
      Console.SetCursorPosition(4*x+4, 2*y+2);
      Console.Write("|");
    }       
  }
}