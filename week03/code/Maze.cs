/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    public void MoveLeft()
    {
        // Check if current position exists
        if (!_mazeMap.ContainsKey((_currX, _currY)))
            throw new InvalidOperationException("Can't go that way!");

        // Check if moving left is allowed from current position
        if (!_mazeMap[(_currX, _currY)][0])
            throw new InvalidOperationException("Can't go that way!");

        // Check if target position (x-1, y) exists
        if (!_mazeMap.ContainsKey((_currX - 1, _currY)))
            throw new InvalidOperationException("Can't go that way!");

        // Move left by updating x coordinate
        _currX--;
    }

    public void MoveRight()
    {
        // Check if current position exists
        if (!_mazeMap.ContainsKey((_currX, _currY)))
            throw new InvalidOperationException("Can't go that way!");

        // Check if moving right is allowed from current position
        if (!_mazeMap[(_currX, _currY)][1])
            throw new InvalidOperationException("Can't go that way!");

        // Check if target position (x+1, y) exists
        if (!_mazeMap.ContainsKey((_currX + 1, _currY)))
            throw new InvalidOperationException("Can't go that way!");

        // Move right by updating x coordinate
        _currX++;
    }

    public void MoveUp()
    {
        // Check if current position exists
        if (!_mazeMap.ContainsKey((_currX, _currY)))
            throw new InvalidOperationException("Can't go that way!");

        // Check if moving up is allowed from current position
        if (!_mazeMap[(_currX, _currY)][2])
            throw new InvalidOperationException("Can't go that way!");

        // Check if target position (x, y+1) exists
        if (!_mazeMap.ContainsKey((_currX, _currY + 1)))
            throw new InvalidOperationException("Can't go that way!");

        // Move up by updating y coordinate
        _currY++;
    }

    public void MoveDown()
    {
        // Check if current position exists
        if (!_mazeMap.ContainsKey((_currX, _currY)))
            throw new InvalidOperationException("Can't go that way!");

        // Check if moving down is allowed from current position
        if (!_mazeMap[(_currX, _currY)][3])
            throw new InvalidOperationException("Can't go that way!");

        // Check if target position (x, y-1) exists
        if (!_mazeMap.ContainsKey((_currX, _currY - 1)))
            throw new InvalidOperationException("Can't go that way!");

        // Move down by updating y coordinate
        _currY--;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
