# Mini GDD - Minijuego Asteroids

## 1. Escena

**Game** es la unica escena jugable. Contiene la camara ortografica, nave, fondo, Canvas de interfaz, EventSystem, PoolManager y el sistema de aparicion de enemigos.

La presentacion es 2D, mientras que el movimiento y las colisiones utilizan componentes de fisica 3D restringidos al plano XY.

La nave dispone de espacio infinito: al superar un borde reaparece por el lado contrario.

## 2. Assets y GameObjects

- **Nave:** objeto controlado por el jugador. Incluye Rigidbody, collider, Player.cs y el punto BulletSpawn.
- **Bala (Prefab):** proyectil reutilizado mediante pooling.
- **Meteorito (Prefab):** enemigo con Rigidbody y collider. Puede variar de tamaño y masa y puede fragmentarse.
- **Fondo:** sprite espacial.
- **Canvas / UI:** puntuacion, boton de pausa y PausePanel.
- **PoolManager:** administra las colas de balas y meteoritos.
- **EnemySpawner:** genera meteoritos desde los cuatro bordes.

## 3. Mecanicas

- **Movimiento:** A/D rotan la nave y W/S aplican impulso.
- **Disparo:** Espacio obtiene una bala del pool y la lanza desde BulletSpawn.
- **Spawn:** los meteoritos aparecen aleatoriamente por arriba, abajo, izquierda o derecha.
- **Dificultad progresiva:** aumenta la frecuencia de aparicion.
- **Tamaño y masa:** cada meteorito recibe un tamaño aleatorio y su masa se calcula a partir de ese tamaño.
- **Fragmentacion:** un meteorito grande alcanzado crea dos fragmentos; un fragmento alcanzado desaparece.
- **Colisiones:** chocar con un meteorito reinicia la partida y la puntuacion.
- **Pooling:** balas y meteoritos se reutilizan en lugar de crearse y destruirse continuamente.

## 4. Scripts

- **Player.cs:** movimiento, giro, espacio infinito, disparo y colision con enemigos.
- **Bullet.cs:** movimiento, tiempo de vida, impacto, puntuacion y retorno al pool.
- **EnemySpawner.cs:** posicion de spawn, tamaño, masa, direccion, velocidad y frecuencia.
- **Asteroid.cs:** orientacion visual, fragmentacion, limites y retorno al pool.
- **PoolManager.cs:** precarga y reutilizacion de balas y meteoritos.
- **PauseMenu.cs:** pausa, reanudacion, reinicio y salida.

## 5. Interaccion

| Entrada | Accion |
| --- | --- |
| A / D | Rotar nave |
| W / S | Aplicar impulso |
| Espacio | Disparar |
| ESC | Abrir o cerrar pausa |
| Boton II | Abrir pausa |
| Reanudar | Continuar partida |
| Reiniciar | Reiniciar escena y puntos |
| Salir | Cerrar la aplicacion |

## Elementos extra

- Fragmentacion de enemigos.
- Pausa y reinicio.
- Object Pooling de balas y meteoritos.
