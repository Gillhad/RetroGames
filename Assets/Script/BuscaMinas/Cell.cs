using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool hasMine;
    public Sprite[] emptyTextures;
    public Sprite mineTexture;
    void Start()
    {

        hasMine = (Random.value < 0.15);
        //LoadTexture(2); // Test de sprites
        int x = (int)this.transform.position.x;
        int y = (int)this.transform.parent.transform.position.y;
        GridHelper.cells[x,y] = this;
    }

    public bool IsCovered()
    {

        return GetComponent<SpriteRenderer>().sprite.texture.name == "Bloque";
    }

    private void OnMouseDown()
    {
        if (hasMine)
        {
            Debug.Log("mina");
            GridHelper.UncoverAllTheMines();
        }
        else
        {
            int x = (int)this.transform.position.x;
            int y = (int)this.transform.parent.transform.position.y;
            LoadTexture(GridHelper.CountAdjacentMines(x, y));
            GridHelper.FloodFillUncover(x, y, new bool[GridHelper.w, GridHelper.h]);
            if (GridHelper.HasTheGameEnded()) {
                Debug.Log("fin de la partida");
            }
        }
    }

    /*  test de sprites*/
    public void LoadTexture(int adjancentCount)
    {
        if (hasMine)
        {
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = emptyTextures[adjancentCount];
        }
    }

    




}
