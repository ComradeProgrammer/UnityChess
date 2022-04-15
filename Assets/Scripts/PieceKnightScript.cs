using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PieceKnightScript : PieceScript {

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

        if (Mathf.Abs(targetRow - rowOnChessBoard) == 2 && Mathf.Abs(targetColumn - columnOnChessBoard) == 1) {
            return true;
        }
        if (Mathf.Abs(targetRow - rowOnChessBoard) == 1 && Mathf.Abs(targetColumn - columnOnChessBoard) == 2) {
            return true;
        }
        return false;
    }
};