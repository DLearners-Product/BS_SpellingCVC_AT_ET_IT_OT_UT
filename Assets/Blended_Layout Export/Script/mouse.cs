using UnityEngine;

using UnityEngine.EventSystems;



public class mouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler

{
	//public string name;
	public AudioClip AC_clip;
	public AudioSource AS_Empty;

	Vector2 startscale;
	public void Start()

	{
		startscale = this.gameObject.transform.localScale;
		name = this.gameObject.name;
		

	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		//Debug.Log(this.name);

		{
			
			this.gameObject.transform.localScale = new Vector2(1.3f, 1.3f);
			AS_Empty.clip = AC_clip;
			AS_Empty.Play();
			//if (this.gameObject.GetComponent<Animator>() != null)
			//{
			//	this.gameObject.GetComponent<Animator>().SetInteger("cond", 1);
			//}
			
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("exit");
		this.gameObject.transform.localScale = new Vector2(1, 1);
		AS_Empty.Stop();
		//if (this.gameObject.GetComponent<Animator>() != null)
		//{
		//	this.gameObject.GetComponent<Animator>().SetInteger("cond", 0);
		//}
	}
}