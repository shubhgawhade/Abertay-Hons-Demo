using UnityEngine;
using UnityEngine.AI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    
    [RequireComponent(typeof (NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Vector3 target;                                    // target to aim for

        private bool cooldown;
        private RaycastHit hit;
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            // agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        private void Update()
        {
            if (target == Vector3.zero)
            {
                target = transform.position;
            }
            

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (GameManager.isControllable && Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0) && hit.collider.CompareTag("Ground"))
            {
                target = new Vector3(hit.point.x, 0, hit.point.z);
                agent.SetDestination(target);
            }
            
            if (agent.remainingDistance > 0.3f)
            {
                print(Mathf.Abs((transform.position - target).magnitude));
                character.Move(agent.desiredVelocity, false, false);
            }
        }
    }
}
