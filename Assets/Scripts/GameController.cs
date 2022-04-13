using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    private PieceScript[][] pieces;
    void Start()
    {
        pieces = new PieceScript[8][];
        for (int i = 0; i < 8; i++)
        {
            pieces[i] = new PieceScript[8];
            for (int j = 0; j < 8; j++)
            {
                pieces[i][j] = null;
            }
        }
        //get handler of each piece
        pieces[0][0] = GameObject.FindGameObjectWithTag("Rock White 2").GetComponent<PieceScript>();
        pieces[0][1] = GameObject.FindGameObjectWithTag("Knight White 2").GetComponent<PieceScript>();
        pieces[0][2] = GameObject.FindGameObjectWithTag("Bishop White").GetComponent<PieceScript>();
        pieces[0][3] = GameObject.FindGameObjectWithTag("Queen White").GetComponent<PieceScript>();
        pieces[0][4] = GameObject.FindGameObjectWithTag("King White").GetComponent<PieceScript>();
        pieces[0][5] = GameObject.FindGameObjectWithTag("Bishop White 2").GetComponent<PieceScript>();
        pieces[0][6] = GameObject.FindGameObjectWithTag("Knight White").GetComponent<PieceScript>();
        pieces[0][7] = GameObject.FindGameObjectWithTag("Rock White").GetComponent<PieceScript>();

        pieces[1][0] = GameObject.FindGameObjectWithTag("Pawn White").GetComponent<PieceScript>();
        pieces[1][1] = GameObject.FindGameObjectWithTag("Pawn White 2").GetComponent<PieceScript>();
        pieces[1][2] = GameObject.FindGameObjectWithTag("Pawn White 3").GetComponent<PieceScript>();
        pieces[1][3] = GameObject.FindGameObjectWithTag("Pawn White 4").GetComponent<PieceScript>();
        pieces[1][4] = GameObject.FindGameObjectWithTag("Pawn White 5").GetComponent<PieceScript>();
        pieces[1][5] = GameObject.FindGameObjectWithTag("Pawn White 6").GetComponent<PieceScript>();
        pieces[1][6] = GameObject.FindGameObjectWithTag("Pawn White 7").GetComponent<PieceScript>();
        pieces[1][7] = GameObject.FindGameObjectWithTag("Pawn White 8").GetComponent<PieceScript>();

        pieces[7][0] = GameObject.FindGameObjectWithTag("Rock Black").GetComponent<PieceScript>();
        pieces[7][1] = GameObject.FindGameObjectWithTag("Knight Black").GetComponent<PieceScript>();
        pieces[7][2] = GameObject.FindGameObjectWithTag("Bishop Black 2").GetComponent<PieceScript>();
        pieces[7][3] = GameObject.FindGameObjectWithTag("King Black").GetComponent<PieceScript>();
        pieces[7][4] = GameObject.FindGameObjectWithTag("Queen Black").GetComponent<PieceScript>();
        pieces[7][5] = GameObject.FindGameObjectWithTag("Bishop Black").GetComponent<PieceScript>();
        pieces[7][6] = GameObject.FindGameObjectWithTag("Knight Black 2").GetComponent<PieceScript>();
        pieces[7][7] = GameObject.FindGameObjectWithTag("Rock Black 2").GetComponent<PieceScript>();

        pieces[6][7] = GameObject.FindGameObjectWithTag("Pawn Black").GetComponent<PieceScript>();
        pieces[6][6] = GameObject.FindGameObjectWithTag("Pawn Black 2").GetComponent<PieceScript>();
        pieces[6][5] = GameObject.FindGameObjectWithTag("Pawn Black 3").GetComponent<PieceScript>();
        pieces[6][4] = GameObject.FindGameObjectWithTag("Pawn Black 4").GetComponent<PieceScript>();
        pieces[6][3] = GameObject.FindGameObjectWithTag("Pawn Black 5").GetComponent<PieceScript>();
        pieces[6][2] = GameObject.FindGameObjectWithTag("Pawn Black 6").GetComponent<PieceScript>();
        pieces[6][1] = GameObject.FindGameObjectWithTag("Pawn Black 7").GetComponent<PieceScript>();
        pieces[6][0] = GameObject.FindGameObjectWithTag("Pawn Black 8").GetComponent<PieceScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void moveTo(PieceScript piece, int targetRow, int targetColumn)
    {
        //check whether this place is valid
        PieceScript existingPiece = pieces[targetRow][targetColumn];
        if (existingPiece != null && existingPiece != piece)
        {
            Debug.LogFormat("{0} {1}", existingPiece.name, piece.name);
            piece.switchToErrorApperance();
        }else{
            piece.switchToSelectedApperance();
        }
        piece.moveTo(targetRow, targetColumn);
    }
}
