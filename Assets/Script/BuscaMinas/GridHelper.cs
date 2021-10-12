using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHelper : MonoBehaviour
{
    public static int w = 20;
    public static int h = 10;

    public static Cell[,] cells = new Cell[w,h];

    private void Start()
    {
        
    }

    public static void UncoverAllTheMines() {
        foreach (Cell c in cells) {
            if (c.hasMine) {
                c.LoadTexture(0);
            }
        }
    }
    public static bool HasMineAt(int x,int y) {
        if (x >= 0 && y >= 0 && x < w && y < h)
        {
            Cell cell = cells[x, y];
            return cell.hasMine;
        }
        else {
            return false;
        }
        
        
        return false;
    }

    public static int CountAdjacentMines(int x, int y) {
        int count = 0;
        if (HasMineAt(x - 1, y - 1)) count++;
        if (HasMineAt(x + 1, y - 1)) count++;
        if (HasMineAt(x - 1, y + 1)) count++;
        if (HasMineAt(x + 1, y + 1)) count++;
        if (HasMineAt(x, y - 1)) count++;
        if (HasMineAt(x, y + 1)) count++;
        if (HasMineAt(x - 1, y )) count++;
        if (HasMineAt(x + 1, y )) count++;


        return count;
    }

    public static void FloodFillUncover(int x, int y, bool[,] visited) {
        if(x >=0 && y >=0 && x < w && y < h){
            if (visited[x, y]) return;
            //cuento numero de minas
            int adjacentMines = CountAdjacentMines(x, y);
            //destapo el numero de la celda
            cells[x, y].LoadTexture(adjacentMines);
            //si hay una bomba no destapo -> si hay minas no debe seguir
            if (adjacentMines > 0) return;
            //marcamos la actual como visitada
            visited[x, y] = true;
            //destapamos vecinos
            FloodFillUncover(x - 1, y, visited);
            FloodFillUncover(x, y + 1, visited);
            FloodFillUncover(x + 1, y, visited);
            FloodFillUncover(x, y - 1, visited);

        }
    }

    public static bool HasTheGameEnded() {
        foreach (Cell cell in cells) {
            if (cell.IsCovered() && !cell.hasMine) {
                return false;
            }
        }

        return true;

    }

}
