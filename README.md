# Minijuego - Asteroids

Proyecto realizado en Unity 6.

El jugador controla una nave, dispara a meteoritos que aparecen desde los bordes y obtiene puntos al destruirlos. El proyecto incluye fragmentacion, pausa/reinicio y Object Pooling.

## Contenido del repositorio

- `Assets/`, `Packages/` y `ProjectSettings/`: proyecto Unity.
- `Documentacion/MiniGDD.pdf`: mini GDD de la practica.
- `Documentacion/MiniGDD.md`: version editable de la documentacion.
- `Demo/`: build ejecutable comprimida.

## Controles

| Control | Accion |
| --- | --- |
| A / D | Rotar la nave |
| W / S | Aplicar impulso |
| Espacio | Disparar |
| ESC | Pausar / reanudar |
| Boton II | Abrir menu de pausa |

Desde el menu de pausa se puede **Reanudar**, **Reiniciar** o **Salir**.

## Mecanicas implementadas

- Movimiento e impulso de la nave.
- Disparo.
- Spawn progresivo de enemigos desde los cuatro bordes.
- Meteoritos con tamaño y masa variables.
- Fragmentacion de meteoritos.
- Sistema de puntuacion.
- Espacio infinito para la nave.
- Menu de pausa y reinicio.
- Object Pooling para balas y meteoritos.

## Demo

La build final debe colocarse como `Demo/Minijuego.zip`.
