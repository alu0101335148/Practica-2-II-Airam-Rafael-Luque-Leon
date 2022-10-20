# Practica-2-II-Airam-Rafael-Luque-Leon

## Descripción
En esta segunda practica vamos a profundizar en los conocimientos que tenemos acerca de los scripts, y las físicas

## Probando las físicas

Para esta tarea vamos a crear una escena simple sobre la que probar diferentes configuraciones de objetos físicos en Unity. La escena va a tener un plano a modo de suelo, una esfera y un cubo.

### a.	Ninguno de los objetos será físico.
![1a](/img/1a.gif)

### b.	La esfera tiene físicas, el cubo no.
![1b](/img/1b.gif)

### c.	La esfera y el cubo tienen físicas.
![1c](/img/1c.gif)

### d.	La esfera y el cubo son físicos y la esfera tiene 10 veces la masa del cubo.
![1d](/img/1d.gif)

### e.	La esfera tiene físicas y el cubo es de tipo IsTrigger.
![1e](/img/1e.gif)

### f.	La esfera tiene físicas, el cubo es de tipo IsTrigger y tiene físicas.
![1f](/img/1f.gif)

### g.	La esfera y el cubo son físicos y la esfera tiene 10 veces la masa del cubo, se impide la rotación del cubo sobre el plano XZ.
![1g](/img/1g.gif)

## Creando un script para mover un objeto

Vamos a crear un script que nos permita mover un objeto con las teclas de dirección. El script se va a llamar CharacterController.cs y se va a añadir al objeto que queramos mover. El script va a tener una variable pública de tipo float que va a determinar la velocidad de movimiento del objeto. El script va a tener un método Update que va a comprobar si se ha pulsado alguna de las teclas de dirección y en ese caso va a mover el objeto en la dirección correspondiente.

Código del script:

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    public float speed = 5.0f;

    void Start()
    {

    }

    void Update() {
        // Use the keys awsd to move the player (transform.Translate(X, Y, Z))
        float xMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float zMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(xMovement, 0, zMovement);
        // transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        // Rotate the player around the y-axis using the keys q and e (transform.Rotate(X, Y, Z))
        if (Input.GetKey(KeyCode.Q)) {
            transform.Rotate(0, -speed / 100, 0);
        }
        if (Input.GetKey(KeyCode.E)) {
            transform.Rotate(0, speed / 100, 0);
        }
    }
}
```

![2](/img/2.gif)

## Agregando funcionalidades extras

Sobre la escena que hemos trabajado se van a agregar scripts para las siguientes acciones:

###	Incluir varios cilindros sobre la escena. Cada vez que el objeto jugador colisione con alguno de ellos, deben aumentar su tamaño y el jugador aumentar puntuación.

Para este punto desarrollamos el script `GrowingScript` que se encarga de aumentar el tamaño de los cilindros. Y por otro lado se ha modificado el script `CharacterControler.cs` para que se detecte cuando se colisiona con este tipo de cilindros, se aumente un atributo de puntuación y se imprima por la consola de Debug.

Código de `GrowingScript.cs`:

```csharp
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class GrowingScript : MonoBehaviour {
        public float growingFactor = 0.1f;
        public float maxScale = 2f;

        private void OnCollisionEnter(Collision collision) {
            if (collision.gameObject.tag == "Player") {
                if (transform.localScale.x < maxScale) {
                    transform.localScale += new Vector3(growingFactor, growingFactor, growingFactor);
                }
            }
        }
    }
```

Cópdigo de `CharacterController.cs`

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    public float speed = 5.0f;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update() {
        /* Previous code */
    }

    // new code
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "ScoreCylinder") {
            score += 1;
            Debug.Log("Score: " + score);
        }
    }
}


```

### Agregar cilindros de tipo A, en los que, además, si el jugador pulsa la barra espaciadora lo mueve hacia fuera de él.

Para este punto alteraremos nuevamente el script `CharacterController`, que se encarga de mover los cilindros de un tipo en específico, lejos de la posición actual del jugador, cuando se presione la barra espaciadora.

Código de `CharacterController.cs`

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    public float speed = 5.0f;
    private int score = 0;

    void Start() {

    }

    void Update() {
        /* Previous code... */
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject[] cylinders = GameObject.FindGameObjectsWithTag("PushCylinder");
            foreach (GameObject cylinder in cylinders) {
                Vector3 direction = cylinder.transform.position - transform.position;
                cylinder.GetComponent<Rigidbody>().AddForce(direction * 100);
            }
        }
    }

    /* ... */
}
```

### Se deben incluir cilindros que se alejen del jugador cuando esté próximo.

En este apartado se ha creado un script `GetAwayScript.cs` que se encarga de mover los cilindros de un tipo en específico, lejos de la posición actual del jugador, cuando se acerca a ellos a una distancia en específico, para ello se ha optado por la utilización de un `SphereCollider`, con la cual podemos utilizar el evento `OnTriggerEnter` para detectar que es el momento de aplicar una fuerza de repulsión en la dirección opuesta del jugador.

Código de `GetAwayScript.cs`

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAwayScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }

    // push the object away from the player when the player in close to it
    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.name == "Player") {
            Vector3 distanceToPlayer = transform.position - collision.transform.position;
            GetComponent<Rigidbody>().AddForce(distanceToPlayer * 1.5f, ForceMode.Impulse);
        }
    }
}

```

### Ubicar un tercer objeto que sea capaz de detectar colisiones y que se mueva con las teclas: I, L, J, K

Se ha instanciado un objeto de tipo esfera, y se le ha agregado un script `Player2Controller.cs`, que se encarga de mover el objeto con las teclas I, L, J, K. De forma adicional, hemos agregado dos funcionalidades, el poder rotar el objeto con las teclas U y O, y el poder cambiar entre dos cámaras con las teclas 1 y 2, siendo estas, las cámaras referentes a cada player (cubo o esfera).

Código de `Player2Controller.cs`

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour {
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() {
        if (Input.GetKey(KeyCode.I)) {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.L)) {
            transform.Translate(Vector3.right * Time.deltaTime * speed);            
        }
        if (Input.GetKey(KeyCode.J)) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.K)) {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        // Rotate the player around the y-axis using the keys "u" and "o"
        if (Input.GetKey(KeyCode.U)) {
            transform.Rotate(0, -speed / 100, 0);
        }
        if (Input.GetKey(KeyCode.O)) {
            transform.Rotate(0, speed / 100, 0);
        }
    }
}

```

### Ubicar cubos que aumentan de tamaño cuando se le acerca una esfera y que disminuye cuando se le acerca el jugador.

Finalmente en este apartado se han instanciado cubos, con sus respectivos spheres colliders (como ya hicimos en apartados anteriores), para aplicar la funcionalidad de que aumenten de tamaño cuando se acerca una esfera, y disminuyan cuando se acerca el jugador.

Código de `ChangingCubeScript.cs`

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingCubeScript : MonoBehaviour {
    public float scale = 0.25f;

    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.name == "Player2") {
            transform.localScale += new Vector3(scale, scale, scale);
            transform.position += new Vector3(0, scale, 0);
        }
        if (collision.gameObject.name == "Player") {
            transform.localScale -= new Vector3(scale, scale, scale);
            transform.position -= new Vector3(0, scale, 0);
        }
    }
}
```

### Demostración de funcionalidades

![3](/img/3.gif)

# Referencias

[Switching cameras in Unity](https://fanzhongzeng78.medium.com/switching-cameras-in-unity-174ef13ec6e)
