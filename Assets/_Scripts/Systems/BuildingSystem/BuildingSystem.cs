using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{

    public static BuildingSystem Instance { get; private set; }

    public static event Action GridChanged;
    [SerializeField] 
    private BuildingTypeSO tempBuilding;
    [SerializeField]
    private int witdh, height;
    [SerializeField]
    private Vector2 gridCenter;
    
    private Grid<GridObject> _grid;
    private int cellSize = 1;

    public bool isActive = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }
    void Start()
    {

        _grid = new(witdh, height, cellSize, gridCenter, (Grid<GridObject> gr, int x, int y) => new GridObject(gr,x,y));

    }

    public void ChooseBuilding(BuildingTypeSO selectedBuilding)
    {
        isActive = true;
        tempBuilding = selectedBuilding;
    }
    public void ClearBuilding(Transform buildingTransform)
    {
        Vector2Int pos = _grid.GetXY(buildingTransform.position);
        _grid.GetValue(pos).ClearTransform();
        GridChanged?.Invoke();
    }
    private void Update()
    {
        if (!isActive)
            return;
        
        if (Input.GetMouseButtonDown(0))
        {

            GridObject gridObj = _grid.GetValue(Utils.GetMouseWorldPos());
            if (gridObj == null) return;

            List<Vector2Int> objectPositionList = tempBuilding.GetObjectPositionList(new Vector2Int(gridObj.x,gridObj.y));

            bool canBuild = true;
            foreach (Vector2Int gridPos in objectPositionList)
            {
                if (!_grid.GetValue(gridPos.x,gridPos.y).CanBuild()) //if any of the gridobjects have building on it you cant build there.
                {
                    print("you cant build here " + gridPos.x + ", " + gridPos.y + " have transforms");
                    canBuild = false;
                    break;
                }
            }

            if (canBuild) {
                Transform placedBuilding = Instantiate(tempBuilding.Prefab, _grid.GetWorldPos(gridObj.x,gridObj.y) , Quaternion.identity);
                foreach (var gridPos in objectPositionList)
                {
                    _grid.GetValue(gridPos.x, gridPos.y).SetTransform(placedBuilding);
                }
                GridChanged?.Invoke();
                isActive= false;
                tempBuilding = null;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            GridObject gridobj = _grid.GetValue(Utils.GetMouseWorldPos());
            print(gridobj.ToString());
            gridobj.ClearTransform();
            GridChanged?.Invoke();
            isActive = false;
            tempBuilding = null;
        }
    }



    public class GridObject
    {
        private Grid<GridObject> grid;
        public int x { get; private set; }
        public int y { get; private set; }
        private Transform buildingTransform;

        public GridObject(Grid<GridObject> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
        }

        public void SetTransform(Transform transform)
        {
            this.buildingTransform = transform;
        }

        public void ClearTransform()
        {
            if (buildingTransform)
            {
                Destroy(this.buildingTransform.gameObject);
                this.buildingTransform = null;
            }
        }

        public bool CanBuild()
        {
            return buildingTransform == null;
        }

        public Vector2Int GetXY()
        {
            return new Vector2Int(x, y);
        }

        public override string ToString()
        {
            return x + "," + y;
        }
    }


}
