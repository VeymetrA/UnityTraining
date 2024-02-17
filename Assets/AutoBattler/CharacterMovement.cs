using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float movementSpeed;
    public Transform otherObject;
    public float attackRange;
    public int attackSpeed;
    private Animator _animator;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TargetSearch();
        if (otherObject != null)
        {
            float distance = Vector3.Distance(otherObject.position, transform.position);
            if (distance <= attackRange)
            {
                _animator.SetBool("moveAgain", false);
                _animator?.CrossFade("Attack", 0);
                return;
            }
        }
        _animator.SetBool("moveAgain", true);
        transform.position += Vector3.right * movementSpeed * Time.deltaTime;
    }

    public void CharacterAttack()
    {
        transform.GetComponent<Damaging>().Attack(otherObject.GetComponent<Damaging>());
        //возможность урона по области
    }

    private void TargetSearch()
    {
        otherObject = null;
        string targetTag = gameObject.tag == "Player" ? "Enemy" : "Player";
        GameObject[] possibleTargets;
        possibleTargets = GameObject.FindGameObjectsWithTag(targetTag);
        float minimalDistance = float.PositiveInfinity;
        float currentDistance = 0;
        for (int i = 0; i < possibleTargets.Length; i++)
        {
            currentDistance = Vector3.Distance(possibleTargets[i].transform.position, transform.position);
            if (currentDistance < minimalDistance)
            {
                minimalDistance = currentDistance;
                otherObject = possibleTargets[i].transform;
            }
        }
    }
}