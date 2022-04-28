using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PieceRockScript : PieceScript {

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

        if (pieceOntargetPlace != null && pieceOntargetPlace.GetColor() == GetColor()) {
            //a piece with same color is on the target place
            return false;
        }
        //special rule: Castling
        if (GetColor() == PieceColor.White && firstTimeMove) {
            if (gameController.whiteKingMove == 2 && rowOnChessBoard == 0 && columnOnChessBoard == 0 && gameController.GetPiece(0, 2).GetPieceType() == PieceType.King) {
                if (targetRow == 0 && targetColumn == 3) {
                    return true;
                }
            }
            if (gameController.whiteKingMove == 2 && rowOnChessBoard == 0 && columnOnChessBoard == 7 && gameController.GetPiece(0, 6).GetPieceType() == PieceType.King) {
                if (targetRow == 0 && targetColumn == 5) {
                    return true;
                }
            }
        }
        if (GetColor() == PieceColor.Black && firstTimeMove) {
            if (gameController.whiteKingMove == 2 && rowOnChessBoard == 7 && columnOnChessBoard == 0 && gameController.GetPiece(7, 2).GetPieceType() == PieceType.King) {
                if (targetRow == 7 && targetColumn == 3) {
                    return true;
                }
            }
            if (gameController.whiteKingMove == 2 && rowOnChessBoard == 7 && columnOnChessBoard == 7 && gameController.GetPiece(7, 6).GetPieceType() == PieceType.King) {
                if (targetRow == 7 && targetColumn == 5) {
                    return true;
                }
            }
        }
        //we need to check whether there is some other pieces blocking the way
        if (targetColumn == columnOnChessBoard) {
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
        }
        return false;
    }
    public override PieceType GetPieceType() { return PieceType.Rock; }
};