using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    private float gameTime = 0.0f;
    private PieceScript[][] pieces;
    private Text textLeftTop;
    private GameObject promotionGUI;
    private GameObject mainCamera;
    private GameObject currentObject = null;
    private PieceColor currentPlayer = PieceColor.White;
    private bool isInPromotion = false;
    PieceScript pieceInPromotion = null;

    public int whiteKingMove=0;
    public int blackKingMove=0;
    // Start is called before the first frame update
    void Start() {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        promotionGUI = GameObject.FindGameObjectWithTag("Promotion");
        promotionGUI.SetActive(false);

        textLeftTop = GameObject.FindGameObjectWithTag("TextLeftUp").GetComponent<Text>();
        textLeftTop.text = "00:00:00";


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
        pieces[7][3] = GameObject.FindGameObjectWithTag("King Black").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(7, 4).SetColor(PieceColor.Black);
        pieces[7][4] = GameObject.FindGameObjectWithTag("Queen Black").GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(7, 3).SetColor(PieceColor.Black);
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
        //update the time
        gameTime += Time.deltaTime;
        int hours = (int)(gameTime / 3600);
        int minutes = (int)((gameTime % 3600) / 60);
        int seconds = (int)(gameTime % 60);
        textLeftTop.text = string.Format("Total Time {0,2:D2}:{1,2:D2}:{2,2:D2}", hours, minutes, seconds);

        if (isInPromotion) {
            return;
        }

        //handle the input event
        if (Input.GetMouseButtonDown(0)) {
            //mouse is pressed 
            if (currentObject == null) {
                selectObjectWithMouse();
            } else {
                var currentPiece = currentObject.GetComponent<PieceScript>();
                bool move;
                if (MoveTo(currentPiece, currentPiece.row, currentPiece.column, out move)) {
                    currentObject = null;
                    if (move && !isInPromotion) {
                        swtichPlayer();
                    }
                }

            }
        } else {
            //mouse is not pressed
            if (currentObject != null) {
                //move the selected piece
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycastHit = new RaycastHit();
                if (Physics.Raycast(ray, out raycastHit)) {
                    //Debug.DrawRay(ray.origin,ray.direction*100000,Color.green,1000000);
                    var boardPosition = raycastHit.point;
                    int column, row;
                    PieceScript.PositionToRowColumn(boardPosition[0], boardPosition[2], out row, out column);
                    //Debug.LogFormat("{0} {1} {2}", row, column, boardPosition);
                    HoverOn(currentObject.GetComponent<PieceScript>(), row, column);
                }
            }
        }
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
    /// <param name="move">whether this can be regarded as a move</param>
    /// <returns>whether it is leagal to do so(whether this piece can be released)</returns>
    internal bool MoveTo(PieceScript piece, int targetRow, int targetColumn, out bool move) {
        if (piece.rowOnChessBoard == targetRow && piece.columnOnChessBoard == targetColumn) {
            move = false;
        } else {
            move = true;
        }
        if (!CheckMovementValidity(piece, targetRow, targetColumn)) {
            piece.SwitchToErrorApperance();
            move=false;
            return false;
        }
        piece.SwitchToNormalApperance();
        pieces[piece.rowOnChessBoard][piece.columnOnChessBoard] = null;
        if (pieces[targetRow][targetColumn] != null) {
            Destroy(pieces[targetRow][targetColumn].gameObject);
        }
        pieces[targetRow][targetColumn] = piece;
        piece.SetRowAndColumnOnChessBoard(targetRow, targetColumn);
        //for promotion
        if (piece.GetPieceType() == PieceType.Pawn) {
            if (piece.GetColor() == PieceColor.White && targetRow == 7 || piece.GetColor() == PieceColor.Black && targetRow == 0) {
                isInPromotion = true;
                pieceInPromotion = piece;
                promotionGUI.SetActive(true);
            }
        }
        if(piece.GetPieceType()==PieceType.King){
            if(piece.GetColor()==PieceColor.White){
                whiteKingMove+=1;
            }else{
                blackKingMove+=1;
            }
        }
        return true;
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

    /// <summary>
    ///  use a RaycastHit to select a object, and set it to the currentObject
    /// </summary>
    bool selectObjectWithMouse() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit = new RaycastHit();
        if (Physics.Raycast(ray, out raycastHit)) {
            if (raycastHit.transform.gameObject.GetComponent<PieceScript>() == null) {
                //if the chosen one is not piece, return
                return false;
            }
            if (currentObject != null) {
                currentObject.GetComponent<PieceScript>().SwitchToNormalApperance();
            }
            //Debug.Log(currentObject.GetComponent<MeshRenderer>().materials[1]);
            currentObject = raycastHit.transform.gameObject;
            currentObject.GetComponent<PieceScript>().SwitchToSelectedApperance();
            return true;
        }
        return false;
    }

    /// <summary>
    /// switch the camera to another side+
    /// </summary>
    void swtichPlayer() {
        if (currentPlayer == PieceColor.Black) {
            mainCamera.transform.position = new Vector3(-3.5f, 3.5f, 0f);
            mainCamera.transform.rotation = Quaternion.Euler(new Vector3(55f, 90f, 0f));
            currentPlayer = PieceColor.White;
        } else {
            mainCamera.transform.position = new Vector3(3.5f, 3.5f, 0f);
            mainCamera.transform.rotation = Quaternion.Euler(new Vector3(55f, -90f, 0f));
            currentPlayer = PieceColor.Black;
        }
    }

    public void onQueenPromotion() {
        int x = pieceInPromotion.rowOnChessBoard;
        int y = pieceInPromotion.columnOnChessBoard;
        GameObject obj, newObj;
        if (pieceInPromotion.GetColor() == PieceColor.White) {
            obj = GameObject.FindGameObjectWithTag("Queen White");
        } else {
            obj = GameObject.FindGameObjectWithTag("Queen Black");
        }
        newObj = Instantiate(obj, pieceInPromotion.transform.parent);
        newObj.GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(x, y).SetColor(pieceInPromotion.GetColor()).HoverOn(x, y);
        pieces[x][y] = newObj.GetComponent<PieceScript>();
        Destroy(pieceInPromotion.gameObject);

        //remove the menu and restore isInPromotion
        promotionGUI.SetActive(false);
        isInPromotion = false;
        swtichPlayer();
    }
    public void onKnightPromotion() {
        int x = pieceInPromotion.rowOnChessBoard;
        int y = pieceInPromotion.columnOnChessBoard;
        GameObject obj, newObj;
        if (pieceInPromotion.GetColor() == PieceColor.White) {
            obj = GameObject.FindGameObjectWithTag("Knight White");
        } else {
            obj = GameObject.FindGameObjectWithTag("Knight Black");
        }
        newObj = Instantiate(obj, pieceInPromotion.transform.parent);
        newObj.GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(x, y).SetColor(pieceInPromotion.GetColor()).HoverOn(x, y);
        pieces[x][y] = newObj.GetComponent<PieceScript>();
        Destroy(pieceInPromotion.gameObject);

        //remove the menu and restore isInPromotion
        promotionGUI.SetActive(false);
        isInPromotion = false;
        swtichPlayer();
    }
    public void onBishopPromotion() {
        int x = pieceInPromotion.rowOnChessBoard;
        int y = pieceInPromotion.columnOnChessBoard;
        GameObject obj, newObj;
        if (pieceInPromotion.GetColor() == PieceColor.White) {
            obj = GameObject.FindGameObjectWithTag("Bishop White");
        } else {
            obj = GameObject.FindGameObjectWithTag("Bishop Black");
        }
        newObj = Instantiate(obj, pieceInPromotion.transform.parent);
        newObj.GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(x, y).SetColor(pieceInPromotion.GetColor()).HoverOn(x, y);
        pieces[x][y] = newObj.GetComponent<PieceScript>();
        Destroy(pieceInPromotion.gameObject);

        //remove the menu and restore isInPromotion
        promotionGUI.SetActive(false);
        isInPromotion = false;
        swtichPlayer();
    }
    public void onRockPromotion() {
        int x = pieceInPromotion.rowOnChessBoard;
        int y = pieceInPromotion.columnOnChessBoard;
        GameObject obj, newObj;
        if (pieceInPromotion.GetColor() == PieceColor.White) {
            obj = GameObject.FindGameObjectWithTag("Rock White");
        } else {
            obj = GameObject.FindGameObjectWithTag("Rock Black");
        }
        newObj = Instantiate(obj, pieceInPromotion.transform.parent);
        newObj.GetComponent<PieceScript>().InitRowAndColumnOnChessBoard(x, y).SetColor(pieceInPromotion.GetColor()).HoverOn(x, y);
        pieces[x][y] = newObj.GetComponent<PieceScript>();
        Destroy(pieceInPromotion.gameObject);

        //remove the menu and restore isInPromotion
        promotionGUI.SetActive(false);
        isInPromotion = false;
        swtichPlayer();
    }
}
