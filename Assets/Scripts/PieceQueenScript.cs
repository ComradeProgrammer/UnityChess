using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PieceQueenScript : PieceScript {

    private GameController gameController = null;

    new protected void Start() {
        base.Start();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    new protected void Update() {

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

        if (pieceOntargetPlace != null && pieceOntargetPlace.GetColor() == GetColor()) {
            //a piece with same color is on the target place
            return false;
        }

        //we need to check whether there is some other pieces blocking the way
        if (targetColumn == columnOnChessBoard) {
            //left or right
            int from = Mathf.Min(targetRow, rowOnChessBoard);
            int to = Mathf.Max(targetRow, rowOnChessBoard);
            for (int i = from + 1; i < to; i++) {
                PieceScript middlePiece = gameController.GetPiece(i, targetColumn);
                if (middlePiece != null) {
                    //there is a piece in the way
                    return false;
                }
            }
            return true;
        } else if (targetRow == rowOnChessBoard) {
            //up or down
            int from = Mathf.Min(targetColumn, columnOnChessBoard);
            int to = Mathf.Max(targetColumn, columnOnChessBoard);
            for (int i = from + 1; i < to; i++) {
                PieceScript middlePiece = gameController.GetPiece(targetRow, i);
                if (middlePiece != null) {
                    //there is a piece in the way
                    return false;
                }
            }
            return true;
        } else if (Mathf.Abs(targetRow - rowOnChessBoard) == Mathf.Abs(targetColumn - columnOnChessBoard)) {
            //walk diagonally
            int xstep = (int)(Mathf.Sign(targetRow - rowOnChessBoard));
            int ystep = (int)(Mathf.Sign(targetColumn - columnOnChessBoard));
            int xItr = rowOnChessBoard + xstep;
            int yItr = columnOnChessBoard + ystep;
            for (int i = 0; i < Mathf.Abs(targetRow - rowOnChessBoard) - 1; i++) {
                PieceScript middlePiece = gameController.GetPiece(xItr, yItr);
                if (middlePiece != null) {
                    return false;
                }
                xItr += xstep;
                yItr += ystep;
            }
            return true;
        }
        return false;
    }
    public override PieceType GetPieceType(){return PieceType.Queen;}

};