using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    // Start is called before the first frame update
    private GameObject currentObject = null;
    private GameController gameController = null;
    void Start() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButtonDown(0)) {
            //mouse is pressed 
            if (currentObject == null) {
                selectObjectWithMouse();
            } else {
                var currentPiece = currentObject.GetComponent<PieceScript>();
                if (gameController.moveTo(currentPiece, currentPiece.row, currentPiece.column)) {
                    currentObject = null;
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
                    PieceScript.positionToRowColumn(boardPosition[0], boardPosition[2], out row, out column);
                    //Debug.LogFormat("{0} {1} {2}", row, column, boardPosition);
                    gameController.hoverOn(currentObject.GetComponent<PieceScript>(), row, column);
                }
            }
        }
    }


    bool selectObjectWithMouse() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit = new RaycastHit();
        if (Physics.Raycast(ray, out raycastHit)) {
            if (raycastHit.transform.gameObject.GetComponent<PieceScript>() == null) {
                //if the chosen one is not piece, return
                return false;
            }
            if (currentObject != null) {
                currentObject.GetComponent<PieceScript>().switchToNormalApperance();
            }
            //Debug.Log(currentObject.GetComponent<MeshRenderer>().materials[1]);
            currentObject = raycastHit.transform.gameObject;
            currentObject.GetComponent<PieceScript>().switchToSelectedApperance();
            return true;
        }
        return false;
    }
}
