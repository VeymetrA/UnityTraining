using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float movementSpeed;
    public Transform otherObject;
    public float attackRange;
    public int attackSpeed;
    private Animator _animator;
    private Rigidbody2D _rb;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
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
                _rb.velocity = Vector3.zero;
                return;
            }
        }
        _animator.SetBool("moveAgain", true);
        //transform.position += Vector3.right * movementSpeed * Time.deltaTime;

        _rb.velocity = Vector3.right * movementSpeed;
    }

    public void CharacterAttack()
    {
        if (otherObject == null)
        {
            return;
        }
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