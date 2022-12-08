using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{

	public GameObject[] hearts;
	private int life;

	private float checkPointPositionX, checkPointPositionY;

	public Animator animator;

	//sonido de daño
	public AudioSource audio;

	public AudioSource audioLife;



	void Start()
    {

		life = hearts.Length;

		if (PlayerPrefs.GetFloat("checkPointPositionX")!=0)
		{
			transform.position=(new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
		}
    }

    private void CheckLife()
    {

		if (life < 1)
		{
			//desactivamos los corazones sin destruirlos
			hearts[0].SetActive(false);
			animator.Play("Hit");
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			//reproducimos el sonido que esta en enabled y evitar el error de que no se puede reproducir el sonido
			
			audio.Play();
		}
		else if (life < 2)
		{
			hearts[1].SetActive(false);
			animator.Play("Hit");
			audio.Play();
		}
        else if (life <3)
        {
			hearts[2].SetActive(false);
			animator.Play("Hit");
			audio.Play();
		}

    }

    public void ReachedCheckPoint(float x, float y)
	{
		PlayerPrefs.SetFloat("checkPointPositionX", x);
		PlayerPrefs.SetFloat("checkPointPositionY", y);
	}

	public void PlayerDamaged()
	{
		life--;
		CheckLife();

	}

	public void PlayerAddLife()
	{
		//le damos un corazón más al jugador

		if (life < 3)
		{
			life++;
			animator.Play("Hit");
			hearts[life - 1].SetActive(true);
			audioLife.Play();
			
		}

		animator.Play("Hit");
		audioLife.Play();

	}

   
}
