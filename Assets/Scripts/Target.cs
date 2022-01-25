using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private float minSpeed = 10.0f;
    private float maxSpeed = 12.0f;
    private float maxTorque = 50.0f;
    private float xRange = 4.0f;
    private float ySpawnPos = 0.0f;
    private GameManager gameManager;
    private CameraSoundPlay soundPlay;
    public ParticleSystem explosionParticle;
  
    private float increasingValue;


    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
       

        targetRB.AddForce(randomForce(), ForceMode.Impulse);
        targetRB.AddTorque(randomTorque(), randomTorque(), randomTorque(),
            ForceMode.Impulse);

        transform.position = randomSpawnPos();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        soundPlay = GameObject.Find("MainCamera").GetComponent<CameraSoundPlay>();
        increasingValue = 0.2f;

    }
  
    public void increaseSpeed(float value)
    {
        this.minSpeed += value;
        this.maxSpeed += value;
    }
    Vector3 randomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float randomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 randomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
      
    
private void OnMouseDown()
{

    if (!gameManager.isGameOver&&!gameManager.isGamePaused)
        {
            Destroy(gameObject);
            
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
           
            if (gameObject.CompareTag("bad"))
            {
                soundPlay.PlaySound(0);
                gameManager.GameOver();
            }
            else
            {
                soundPlay.PlaySound(1);

                gameManager.UpdateScore();
                increasingValue = 0.1f * gameManager.score;

                increaseSpeed(increasingValue);
            }
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        
        if (!gameObject.CompareTag("bad") && other.gameObject.CompareTag("Sensor")&&!gameManager.isGameOver)
        {
            gameManager.GameOver();
        }
    }
   
}

