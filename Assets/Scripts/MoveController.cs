using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {

	private NavMeshAgent agent;
    public Animator anim;

    public int persuers;
    public int[] EnemyType; 
	private Vector3 posicaoRaio ;
	private Vector3 direcaoRaio ;
	private Vector3 posicaoDoMouse ;
    private RaycastHit hit;
    public Transform Arrow;
	
	public Camera  cameraPrincipal;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		posicaoDoMouse = Input.mousePosition;
		posicaoRaio = cameraPrincipal.ScreenToWorldPoint(posicaoDoMouse);
		posicaoDoMouse.z += 1;
		direcaoRaio = cameraPrincipal.ScreenToWorldPoint(posicaoDoMouse) - posicaoRaio;

		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(posicaoRaio, direcaoRaio, out hit, 1000f)){
				//Debug.DrawRay(posicaoRaio, direcaoRaio*1000f, Color.red);
                agent.SetDestination(new Vector3(hit.point.x, hit.point.y, hit.point.z));
                DestroyArrows();
                Transform arrowClone = Instantiate(Arrow, new Vector3(hit.point.x, 2.09f, hit.point.z), Quaternion.Euler(0, 0, 0)) as Transform;
                anim.SetFloat("posX", (hit.point.x - transform.position.x));
                anim.SetFloat("posY", (hit.point.z - transform.position.z));
			}			
		}
	}

    void DestroyArrows()
    {
        Destroy(GameObject.FindWithTag("Arrow"));
    }

    void PlayerStop()
    {
        anim.SetFloat("posX", 0);
        anim.SetFloat("posY", 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Arrow")
        {
            DestroyArrows();
            PlayerStop();
        }
    }


}
