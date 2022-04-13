using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PieceScript : MonoBehaviour
{
    private Material originalMaterial = null;
    Material selectedMaterial = null;
    Material errorMaterial = null;
    private int _row,_column;
    public int row{get{
        positionToRowColumn(transform.position[0],transform.position[2],out _row,out _column);
        return _row;
    }}
    public int column{get{
        positionToRowColumn(transform.position[0],transform.position[2],out _row,out _column);
        return _column;
    }}

    // Start is called before the first frame update
    void Start()
    {
        selectedMaterial = Resources.Load<Material>("Materials/Chosen");
        errorMaterial=Resources.Load<Material>("Materials/Error");
        originalMaterial=GetComponent<MeshRenderer>().materials[1];
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void moveTo(int row,int column){
        float x,y;
        rowColumnToLocalPosition(row,column,out x,out y);
        transform.position=new Vector3(x,transform.position[1],y);
    }

    public void switchToSelectedApperance(){
        Material[] tmp=GetComponent<MeshRenderer>().materials;
        tmp[1]=selectedMaterial;
        GetComponent<MeshRenderer>().materials=tmp;
    }

    public void switchToErrorApperance(){
        Material[] tmp=GetComponent<MeshRenderer>().materials;
        tmp[1]=errorMaterial;
        GetComponent<MeshRenderer>().materials=tmp;
    }

    public void switchToNormalApperance(){
        Material[] tmp=GetComponent<MeshRenderer>().materials;
        tmp[1]=originalMaterial;
        GetComponent<MeshRenderer>().materials=tmp;
    }

    /// <summary>
    /// convert global coordination of piece to row and column
    /// </summary>
    /// <param name="x">x component of global coordination of piece</param>
    /// <param name="z">z component of global coordination of piece</param>
    /// <param name="row">return the row num</param>
    /// <param name="column">return the column num</param>
    public static void positionToRowColumn(float x, float z,out int row,out int column){
        row=(int)((x+2.4f)/0.6f);
        column=(int)((-z+2.4f)/0.6f);
    }
    /// <summary>
    /// convert row and column to global coordination of piece
    /// </summary>
    /// <param name="row">row num</param>
    /// <param name="column">column num</param>
    /// <param name="x">return x component of global coordination of piece</param>
    /// <param name="z">return z component of global coordination of piece</param>
    public static void rowColumnToLocalPosition(int row,int column,out float x, out float z){
        x=row*0.6f-2.1f;
        z=-0.6f*column+2.1f;
    }   

    
}
