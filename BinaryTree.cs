
class BinaryTree : Algorithm
{
  public override Grid Run(Grid grid)
  {
    Random random1 = new Random();
    int width = grid.Columns;
    int height = grid.Rows;

    for(int y=1; y<height; y++)
    {
      for(int x=0; x<width-1; x++)
      {
        int num = random1.Next(0,2);
        if(num == 0)
        {
          grid.Link(x, y, Side.North);
        }
        else
        {
          grid.Link(x, y, Side.East);
        }
      }
    } 

    for(int x=0; x<width-1; x++)
    {
      grid.Link(x,0,Side.East);
    }

    for(int y=height-1; y>0; y--)
    {
      grid.Link(width-1,y,Side.North);
    }    
    return grid;
  }
}