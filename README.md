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

![2](/img/2.gif)

## Agregando funcionalidades extras

Sobre la escena que hemos trabajado se van a agregar scripts para las siguientes acciones:

-	Incluir varios cilindros sobre la escena. Cada vez que el objeto jugador colisione con alguno de ellos, deben aumentar su tamaño y el jugador aumentar puntuación.

-	Agregar cilindros de tipo A, en los que, además, si el jugador pulsa la barra espaciadora lo mueve hacia fuera de él. 

-	Se deben incluir cilindros que se alejen del jugador cuando esté próximo.

-	Ubicar un tercer objeto que sea capaz de detectar colisiones y que se mueva con las teclas: I, L, J, K

-	Ubicar cubos que aumentan de tamaño cuando se le acerca una esfera y que disminuye cuando se le acerca el jugador.

![3](/img/3.gif)

# Referencias

[Switching cameras in Unity](https://fanzhongzeng78.medium.com/switching-cameras-in-unity-174ef13ec6e)
