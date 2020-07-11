using UnityEngine;
using UnityEngine.Serialization;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Color color = Color.red;
    [SerializeField, Range(0, 0.05f)] private float width = 0.05f;
    [SerializeField] private float scopeRange = 100f;
    
    [SerializeField] private int damage = 1;
    
    [SerializeField] private float magnitude = 5f;
    [SerializeField, Range(0, 1f)] private float duration = 0.5f;

    private LineRenderer _lineRenderer;

    private Vector2 _target;
    
    private Animation _anim;
    private AnimationClip _animationClip;

    private GameObject _targeted;

    private AudioSource _source;
    
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animation> ();
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 2;
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        DrawSight();

        if (Input.GetMouseButtonDown(0) && _targeted != null)
        {
            _anim.Play();
            _source.Play();
            
            StartCoroutine(Camera.main.GetComponent<ShakeCamera>().Shake(duration, magnitude));

            _targeted.GetComponent<IIsKillable>().Damage(damage);
        } 
        else if (Input.GetMouseButtonDown(0))
        {
            _anim.Play();
            _source.Play();
            
            StartCoroutine(Camera.main.GetComponent<ShakeCamera>().Shake(duration, magnitude));
        }
    }

    void DrawSight()
    {
        _lineRenderer.startWidth = width;
        _lineRenderer.endWidth = width;
        _lineRenderer.startColor = color;
        _lineRenderer.endColor = color;
        
        RaycastHit2D hit = Physics2D.Raycast( transform.position, transform.TransformDirection(Vector3.right) , scopeRange);
        Ray2D ray = new Ray2D(transform.position, transform.TransformDirection(Vector3.right));
        
        _target = hit ? hit.point : ray.GetPoint(scopeRange);
        _lineRenderer.SetPositions(new Vector3[]{transform.position, _target});

        if (hit && hit.collider.CompareTag("Enemy"))
            _targeted = hit.transform.gameObject;
        else
            _targeted = null;
    }
}
