
class ASCIIGraphics
{
  public void Draw(Grid grid)
  {
    Console.Clear();
    for(int y=0; y<grid.Rows; y++)
    {
      for(int x=0; x<grid.Columns; x++)
      {
        DrawCell(x,y, grid[x,y]);
      }
    }
    Console.WriteLine(); //line feed
    Console.WriteLine(); //line feed
    Console.WriteLine(); //line feed
  }

  void DrawCell(int x, int y, Cell cell)
  {
     
    Console.SetCursorPosition(4*x, 2*y+1);

    HashSet<Side> empty_walls = cell.Links;

    //north wall
    Console.Write("+");
    if(!empty_walls.Contains(Side.North)){Console.Write("---");}
    Console.SetCursorPosition(4*x+4, 2*y+1);
    Console.Write("+");

    //west wall
    if(!empty_walls.Contains(Side.West))
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


    //east wall
    if(!empty_walls.Contains(Side.East))
    {
      Console.SetCursorPosition(4*x+4, 2*y+2);
      Console.Write("|");
    }       
  }
}