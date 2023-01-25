
class Dijkstra
{
  public Grid SolveMaze(Grid grid)
  {
    grid = NumerateCells(grid);
    grid = FindSolution(grid);
    return grid;
  }

  private Grid NumerateCells(Grid grid)
  {
    Cell OutputCell = grid.OutputCell;
    OutputCell.Distance = 0;
    List<Cell> cells = grid.GetLinkedCells(OutputCell);
    List<Cell> copy_cells;
    int distance = 0;

    while (cells.Count != 0)
    {
      distance++;
      foreach (var cell in cells)
      {
        cell.Distance = distance;
      }
      copy_cells = cells.GetRange(0, cells.Count);
      cells.Clear();
      foreach (var cell in copy_cells)
      {
        cells.AddRange(grid.GetLinkedCells(cell));
      }
      cells.RemoveAll(cell => cell.Distance != null); //delete complete cells
    }
    return grid;
  }

  private Grid FindSolution(Grid grid)
  {
    Cell input_cell = grid.InputCell;
    input_cell.CellOnWay = true;
    Cell this_cell = input_cell;

    while (this_cell.Distance != 0)
    {
      foreach (var cell in grid.GetLinkedCells(this_cell))
      {
        if (cell.Distance < this_cell.Distance)
        {
          this_cell = cell;
          this_cell.CellOnWay = true;
          break;
        }
      }
    }
    return grid;
  }
}