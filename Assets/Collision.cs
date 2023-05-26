using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    public int score;
    public Text scorePoints;
    public int life;
    public Text lifepoints;
    public int score1;
    public Text scorePoints1;
    public int life1;
    public Text lifepoints1;
    public Renderer rend;
    public AudioSource AudioPlay;
    public AudioSource AudioPlay2;

    public void Start()
    {
        score = 0;
        scorePoints.text = score.ToString();
        life = 3;
        lifepoints.text = life.ToString();
        score1 = score;  
        scorePoints1.text = score.ToString();
        life1 = life;
        lifepoints1.text = life.ToString();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Esfera")
        {
            score++;
            scorePoints.text = score.ToString();
            scorePoints1.text = score.ToString();
            print("Score"+score);
            print("ScorePunto" +   score);
            AudioPlay.Play();
            StartCoroutine(dentrin());
        }

        if (other.tag == "anel")
        {
            
            AudioPlay2.Play();
            life = life - 1;
            lifepoints.text = life.ToString();
            lifepoints1.text = life.ToString();
            print("anel");
            print(life);
            print(lifepoints);
            StartCoroutine(anelin());
            if (life == 0)
            {
                score = 0;
                scorePoints.text = score.ToString();
                life = 3;
                lifepoints.text = life.ToString();
                lifepoints1.text = life.ToString();
            }
        }

        }

    private IEnumerator anelin()
    {
        rend.gameObject.GetComponent<Renderer>().material.color = Color.red;
        print("anelin");
        Physics.IgnoreLayerCollision(3, 6,true);
        yield return new WaitForSeconds(5f);
        Physics.IgnoreLayerCollision(3, 6, false);
        print("anelin2");
    }
    private IEnumerator dentrin()
    {
        print("dentrin");
        Physics.IgnoreLayerCollision(3, 7, true);
        yield return new WaitForSeconds(3f);
        Physics.IgnoreLayerCollision(3, 7, false); ;    
        print("dentrin2");
    }   
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "anel")
        {
            rend.gameObject.GetComponent<Renderer>().material.color = Color.yellow;

        }
    }
}
