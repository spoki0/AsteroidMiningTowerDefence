var speed : float = 5.0;

function Start() 
{
 var randomDirection : Vector3 = new Vector3(Random.Range(-359, 359),Random.Range(-359, 359), 0);
 transform.Rotate(randomDirection);
}
 
function Update()
{
  transform.position += transform.forward * speed * Time.deltaTime;
}