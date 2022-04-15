using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PiecePawnScript : PieceScript {

    private GameController gameController = null;

    private bool firstTimeMove = true;

    new protected void Start() {
        base.Start();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    new protected void Update() {

    }
    public override PieceScript SetRowAndColumnOnChessBoard(int row, int column) {
        firstTimeMove = false;
        return base.SetRowAndColumnOnChessBoard(row, column);
    }

    public override bool CheckMovementValidity(int targetRow, int targetColumn) {
        if (targetColumn < 0 || targetColumn >= 8 || targetRow < 0 || targetColumn >= 8) {
            return false;
        }
        //check whether target place is available
        PieceScript pieceOntargetPlace = gameController.GetPiece(targetRow, targetColumn);
        if (targetRow == rowOnChessBoard && targetColumn == columnOnChessBoard) {
            //piece can be put in the original position
            return true;
        }

        int direction = GetColor() == PieceColor.White ? 1 : -1;


        //check whether this pawn can move forward without eating other pieces.
        if (targetColumn == columnOnChessBoard && targetRow == rowOnChessBoard + direction) {
            if (pieceOntargetPlace == null) {
                return true;
            }
            return false;
        }

        if (firstTimeMove && targetColumn == columnOnChessBoard && targetRow == rowOnChessBoard + 2 * direction) {
            if (pieceOntargetPlace == null) {
                return true;
            }
            return false;
        }
        //check whether this pawn can move and eat
        if (Mathf.Abs(targetColumn - columnOnChessBoard) == 1 && targetRow == rowOnChessBoard + direction) {
            if (pieceOntargetPlace != null) {
                return true;
            }
            return false;
        }
        return false;
    }

};