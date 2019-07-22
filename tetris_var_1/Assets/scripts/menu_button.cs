using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_button : MonoBehaviour {
	
	public void goToVar1(){
		SceneManager.LoadScene (1);
	}
	public void goToVar2(){
		SceneManager.LoadScene (2);
	}
}
