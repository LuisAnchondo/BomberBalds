using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    private GameObject player;
    public GameObject prefabBomb;
    public int maxBombs = 3;
    public int timeLimit = 3;

    private int bombCount = 0;
    private ArrayList bombArray = new ArrayList();
    private int lastBomb;

    // Start is called before the first frame update
    void Start()
    {
        player  = GameObject.FindWithTag("Player");
        CreateBombs();
        StartCoroutine(timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator timer(){
        while(true){
            foreach (Bomb bomb in bombArray)
            {
                if(bomb.IsActive()){
                    if(bomb.GetTimeCount() >= timeLimit)
                    {
                        bomb.SetActive(false);
                        bomb.ResetTimeCount();
                        bombCount--;
                    }else
                    {
                        bomb.IncreaseTimeCount();
                    }
                }
            }
            yield return new WaitForSeconds(0.01F);
        }
    }

    public void GetNextBomb(){
        if(bombCount < maxBombs){
            Bomb bomb = (Bomb)bombArray[lastBomb];
            bombCount++;
            lastBomb++;
            if(lastBomb == maxBombs)
            {
                lastBomb = 0;
            }
            bomb.SetActive(true);

            float x;
            float y;
            
            if(player.transform.position.x >= 0){
                x = (int)player.transform.position.x + 0.5f;
            }else{
                x = (int)player.transform.position.x - 0.5f;
            }
            
            if(player.transform.position.y >= 0){
                y = (int)player.transform.position.y + 0.5f;
            }else{
                y = (int)player.transform.position.y - 0.5f;
            }
            bomb.GetBomb().transform.position = new Vector2(x,y);
        }
    }

    private void CreateBombs(){
        for(int i=0;i < maxBombs;i++)
        {
            bombArray.Add(new Bomb(Instantiate(prefabBomb, new Vector2(100,0), Quaternion.identity)));
        }
    }
}

class Bomb{

    private GameObject bomb;
    public float timeCount = 0;
    private bool active=false;

    public Bomb(GameObject bomb){
        this.bomb = bomb;
    }

    public void IncreaseTimeCount(){
        timeCount += 0.01F;
    }

    public float GetTimeCount(){
        return timeCount;
    }

    public void ResetTimeCount(){
        timeCount = 0;
    }
    public GameObject GetBomb(){
        return bomb;
    }

    public bool IsActive(){
        return active;
    }

    public void SetActive(bool active){
        this.active = active;
        this.bomb.SetActive(active);
    }
}