using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    // Start is called before the first frame update
    private PieceScript[][] pieces;
    void Start() {
        pieces = new PieceScript[8][];
        for (int i = 0; i < 8; i++) {
            pieces[i] = new PieceScript[8];
            for (int j = 0; j < 8; j++) {
                pieces[i][j] = null;
            }
        }
        //get handler of each piece
        pieces[0][0] = GameObject.FindGameObjectWithTag("Rock White 2").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(0, 0).SetColor(PieceColor.White);
        pieces[0][1] = GameObject.FindGameObjectWithTag("Knight White 2").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(0, 1).SetColor(PieceColor.White);
        pieces[0][2] = GameObject.FindGameObjectWithTag("Bishop White").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(0, 2).SetColor(PieceColor.White);
        pieces[0][3] = GameObject.FindGameObjectWithTag("Queen White").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(0, 3).SetColor(PieceColor.White);
        pieces[0][4] = GameObject.FindGameObjectWithTag("King White").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(0, 4).SetColor(PieceColor.White);
        pieces[0][5] = GameObject.FindGameObjectWithTag("Bishop White 2").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(0, 5).SetColor(PieceColor.White);
        pieces[0][6] = GameObject.FindGameObjectWithTag("Knight White").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(0, 6).SetColor(PieceColor.White);
        pieces[0][7] = GameObject.FindGameObjectWithTag("Rock White").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(0, 7).SetColor(PieceColor.White);

        pieces[1][0] = GameObject.FindGameObjectWithTag("Pawn White").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(1, 0).SetColor(PieceColor.White);
        pieces[1][1] = GameObject.FindGameObjectWithTag("Pawn White 2").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(1, 1).SetColor(PieceColor.White);
        pieces[1][2] = GameObject.FindGameObjectWithTag("Pawn White 3").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(1, 2).SetColor(PieceColor.White);
        pieces[1][3] = GameObject.FindGameObjectWithTag("Pawn White 4").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(1, 3).SetColor(PieceColor.White);
        pieces[1][4] = GameObject.FindGameObjectWithTag("Pawn White 5").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(1, 4).SetColor(PieceColor.White);
        pieces[1][5] = GameObject.FindGameObjectWithTag("Pawn White 6").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(1, 5).SetColor(PieceColor.White);
        pieces[1][6] = GameObject.FindGameObjectWithTag("Pawn White 7").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(1, 6).SetColor(PieceColor.White);
        pieces[1][7] = GameObject.FindGameObjectWithTag("Pawn White 8").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(1, 7).SetColor(PieceColor.White);

        pieces[7][0] = GameObject.FindGameObjectWithTag("Rock Black").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(7, 0).SetColor(PieceColor.Black);
        pieces[7][1] = GameObject.FindGameObjectWithTag("Knight Black").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(7, 1).SetColor(PieceColor.Black);
        pieces[7][2] = GameObject.FindGameObjectWithTag("Bishop Black 2").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(7, 2).SetColor(PieceColor.Black);
        pieces[7][3] = GameObject.FindGameObjectWithTag("King Black").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(7, 3).SetColor(PieceColor.Black);
        pieces[7][4] = GameObject.FindGameObjectWithTag("Queen Black").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(7, 4).SetColor(PieceColor.Black);
        pieces[7][5] = GameObject.FindGameObjectWithTag("Bishop Black").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(7, 5).SetColor(PieceColor.Black);
        pieces[7][6] = GameObject.FindGameObjectWithTag("Knight Black 2").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(7, 6).SetColor(PieceColor.Black);
        pieces[7][7] = GameObject.FindGameObjectWithTag("Rock Black 2").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(7, 7).SetColor(PieceColor.Black);

        pieces[6][7] = GameObject.FindGameObjectWithTag("Pawn Black").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(6, 7).SetColor(PieceColor.Black);
        pieces[6][6] = GameObject.FindGameObjectWithTag("Pawn Black 2").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(6, 6).SetColor(PieceColor.Black);
        pieces[6][5] = GameObject.FindGameObjectWithTag("Pawn Black 3").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(6, 5).SetColor(PieceColor.Black);
        pieces[6][4] = GameObject.FindGameObjectWithTag("Pawn Black 4").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(6, 4).SetColor(PieceColor.Black);
        pieces[6][3] = GameObject.FindGameObjectWithTag("Pawn Black 5").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(6, 3).SetColor(PieceColor.Black);
        pieces[6][2] = GameObject.FindGameObjectWithTag("Pawn Black 6").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(6, 2).SetColor(PieceColor.Black);
        pieces[6][1] = GameObject.FindGameObjectWithTag("Pawn Black 7").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(6, 1).SetColor(PieceColor.Black);
        pieces[6][0] = GameObject.FindGameObjectWithTag("Pawn Black 8").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(6, 0).SetColor(PieceColor.Black);
    }

    // Update is called once per frame
    void Update() {

    }

    public PieceScript GetPiece(int row, int column) {
        if (row < 0 || row >= 8 || column < 0 || column >= 8) {
            return null;
        }
        return pieces[row][column];
    }

    /// <summary>
    /// check whether a piece can be moved to a specified place on chessboard.
    /// </summary>
    /// <param name="piece">piece which is about to be moved</param>
    /// <param name="targetRow">row number of target position</param>
    /// <param name="targetColumn">column number of target position</param>
    /// <returns>whether a piece can be moved to a specified place on chessboard.</returns>
    internal bool CheckMovementValidity(PieceScript piece, int targetRow, int targetColumn) {
        if (targetRow < 0 || targetRow >= 8 || targetColumn < 0 || targetColumn >= 8) {
            return false;
        }
        // PieceScript existingPiece = pieces[targetRow][targetColumn];
        // if (existingPiece != null && existingPiece != piece) {
        //     return false;
        // }
        return piece.CheckMovementValidity(targetRow, targetColumn);
    }

    /// <summary>
    /// try to change the LOGIC POSITION of a piece ON THE CHESSBOARD. The real positition of the piece will not be effected.
    /// Besides, if the action is valid, the piece's material will be change to original material
    /// </summary>
    /// <param name="piece">piece which is about to be moved</param>
    /// <param name="targetRow">row number of target position</param>
    /// <param name="targetColumn">column number of target position</param>
    /// <returns>whether it is leagal to do so</returns>
    internal bool MoveTo(PieceScript piece, int targetRow, int targetColumn) {
        if (CheckMovementValidity(piece, targetRow, targetColumn)) {
            piece.SwitchToNormalApperance();
            pieces[piece.rowOnChessBoard][piece.columnOnChessBoard] = null;
            pieces[targetRow][targetColumn] = piece;
            piece.SetRowAndColumnOnChessBoard(targetRow,targetColumn);
            return true;
        } else {
            piece.SwitchToErrorApperance();
            return false;
        }
    }

    /// <summary>
    /// move the piece to the specified row and column. Only change the objection's POSITION
    /// IN UNITY WORLD, NOT the logic place of this piece. Besides, if the target position is legal, the material
    /// of the piece will be changed to "selected". Otherwise it will be changed to "error"
    /// </summary>
    /// <param name="piece">piece which is about to be moved</param>
    /// <param name="targetRow">row number of target position</param>
    /// <param name="targetColumn">column number of target position</param>
    internal void HoverOn(PieceScript piece, int targetRow, int targetColumn) {
        //check whether this place is valid
        if (CheckMovementValidity(piece, targetRow, targetColumn)) {
            piece.SwitchToSelectedApperance();
        } else {
            piece.SwitchToErrorApperance();
        }
        piece.HoverOn(targetRow, targetColumn);
    }
}
