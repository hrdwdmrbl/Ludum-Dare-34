using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class Maze : MonoBehaviour {

    public IntVector2 size = new IntVector2(20, 20);

    public MazeCell cellPrefab;

    private MazeCell[,] cells;

    public float generationStepDelay;

    public int mazeLength = 30;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator Generate () {
        WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
        cells = new MazeCell[size.x, size.z];
        IntVector2 coordinates = RandomCoordinates;
        int cellsPlaced = 0;
        while (cellsPlaced < mazeLength && ContainsCoordinates(coordinates)) {
            yield return delay;
            CreateCell(coordinates);
            IntVector2 proposedCellLocation = coordinates + MazeDirections.RandomValue.ToIntVector2();
            int maxTries = 8;
            int tries = 0;
            while (proposedCellLocation.x >= size.x || proposedCellLocation.z >= size.z || GetCell(proposedCellLocation) != null || ContainsCoordinates(proposedCellLocation) == false) {
                if (tries > maxTries) {
                    break;
                }
                proposedCellLocation = coordinates + MazeDirections.RandomValue.ToIntVector2();
                Debug.Log(proposedCellLocation.x + ", " + proposedCellLocation.z);
                tries++;
            }
            coordinates = proposedCellLocation;
            cellsPlaced ++;
        }
    }



    public IntVector2 RandomCoordinates {
        get {
            return new IntVector2(Random.Range(0, size.x), Random.Range(0, size.z));
        }
    }

    public bool ContainsCoordinates (IntVector2 coordinates) {
        return coordinates.x > 0 && coordinates.x < size.x && coordinates.z > 0 && coordinates.z < size.z;
    }

    private void CreateCell (IntVector2 coordinates) {
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
        cells[coordinates.x, coordinates.z] = newCell;
        newCell.coordinates = coordinates;
        newCell.name = "MazeCell X: " + coordinates.x + " Z: " + coordinates.z;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);
    }

    public MazeCell GetCell(IntVector2 coordinates) {
        return cells[coordinates.x, coordinates.z];
    }
}
