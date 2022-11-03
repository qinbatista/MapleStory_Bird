using UnityEngine;
using UnityEngine.SceneManagement;
public class NormalBird : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 _initialPosition;
    private bool _birdWasLaunched = true;
    private float _timeSittingAround;
    [SerializeField] private float _launchPower = 500;

    void Start()
    {

    }
    private void Awake() {
        _initialPosition = transform.position;
    }
    void Update()
    {
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position );
        if (_birdWasLaunched && GetComponent<Rigidbody2D>().velocity.magnitude<= 0.1)
        {
            _timeSittingAround += Time.deltaTime;
        }
        if (transform.position.y >100 || transform.position.y <-100 || transform.position.x >100 || transform.position.x <-100)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }
    private void OnMouseUp() 
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 directionToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialPosition*_launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunched = true;
        GetComponent<LineRenderer>().enabled = false;
    }
        // Update is called once per frame
    private void OnMouseDrag() 
    {
        Vector3 newPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new  Vector3(newPostion.x, newPostion.y, 0) ;
    }

}
