using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PieceColor {
    White,
    Black
};

public class PieceScript : MonoBehaviour {
    private Material originalMaterial = null;
    private Material selectedMaterial = null;
    private Material errorMaterial = null;
    private PieceColor color;

    /// <summary>
    /// current row and column of the REAL POSITION of the piece. For example, if a piece is at (0,0), then it was selected and moved to (1,1) via cursor,
    /// then the row and column will be 1,1
    /// </summary>
    protected int _row, _column;
    public int row {
        get {
            PositionToRowColumn(transform.position[0], transform.position[2], out _row, out _column);
            return _row;
        }
    }
    public int column {
        get {
            PositionToRowColumn(transform.position[0], transform.position[2], out _row, out _column);
            return _column;
        }
    }

    /// <summary>
    /// current row and column of the LOGIC POSITION of the piece ON THE CHESSBOARD. 
    /// For example, if a piece is at (0,0), then it was selected and moved to (1,1) via cursor,
    /// then the rowOnChessBoard and columnOnChessBoard will be 0,0
    /// </summary>
    public int rowOnChessBoard { get; protected set; }
    public int columnOnChessBoard { get; protected set; }


    // Start is called before the first frame update
    protected void Start() {
        selectedMaterial = Resources.Load<Material>("Materials/Chosen");
        errorMaterial = Resources.Load<Material>("Materials/Error");
        originalMaterial = GetComponent<MeshRenderer>().materials[1];
    }

    // Update is called once per frame
    protected void Update() {

    }

    /// <summary>
    /// set value for rowOnChessBoard and columnOnChessBoard 
    /// </summary>
    /// <param name="row">value for rowOnChessBoard</param>
    /// <param name="column">value for columnOnChessBoard </param>
    /// <returns>this</returns>
    public PieceScript SetRowAndColumnOnChessBoard(int row, int column) {
        rowOnChessBoard = row;
        columnOnChessBoard = column;
        return this;
    }

    /// <summary>
    /// move the piece to the specified row and column. Only change the objection's position
    /// in unity world, not the logic place of this piece
    /// </summary>
    /// <param name="row">target row index</param>
    /// <param name="column">target column index</param>
    public void HoverOn(int row, int column) {
        if (row < 0 || row >= 8 || column < 0 || column >= 8) {
            return;
        }
        float x, y;
        RowColumnToLocalPosition(row, column, out x, out y);
        transform.position = new Vector3(x, transform.position[1], y);
    }

    public void SwitchToSelectedApperance() {
        Material[] tmp = GetComponent<MeshRenderer>().materials;
        tmp[1] = selectedMaterial;
        GetComponent<MeshRenderer>().materials = tmp;
    }

    public void SwitchToErrorApperance() {
        Material[] tmp = GetComponent<MeshRenderer>().materials;
        tmp[1] = errorMaterial;
        GetComponent<MeshRenderer>().materials = tmp;
    }

    public void SwitchToNormalApperance() {
        Material[] tmp = GetComponent<MeshRenderer>().materials;
        tmp[1] = originalMaterial;
        GetComponent<MeshRenderer>().materials = tmp;
    }

    /// <summary>
    /// check whether this piece can be moved to the specified position on chess board. This function will be override by subclasses.
    /// </summary>
    /// <returns>whether this piece can be moved to the specified position on chess board. </returns>
    public virtual bool CheckMovementValidity(int targetRow, int targetColumn) {
        return true;
    }


    public PieceColor GetColor() {
        return color;
    }
    public PieceScript SetColor(PieceColor c) {
        color = c;
        return this;
    }

    /// <summary>
    /// convert global coordination of piece to row and column
    /// </summary>
    /// <param name="x">x component of global coordination of piece</param>
    /// <param name="z">z component of global coordination of piece</param>
    /// <param name="row">return the row num</param>
    /// <param name="column">return the column num</param>
    public static void PositionToRowColumn(float x, float z, out int row, out int column) {
        row = (int)((x + 2.4f) / 0.6f);
        column = (int)((-z + 2.4f) / 0.6f);
    }

    /// <summary>
    /// convert row and column to global coordination of piece
    /// </summary>
    /// <param name="row">row num</param>
    /// <param name="column">column num</param>
    /// <param name="x">return x component of global coordination of piece</param>
    /// <param name="z">return z component of global coordination of piece</param>
    public static void RowColumnToLocalPosition(int row, int column, out float x, out float z) {
        x = row * 0.6f - 2.1f;
        z = -0.6f * column + 2.1f;
    }

}
