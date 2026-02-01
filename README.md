# FPS Controller – Unity (Learning Project)

## 🎮 Descripción
Proyecto FPS desarrollado en Unity como parte de un proceso de aprendizaje paso a paso.  
El objetivo es construir un controlador FPS desde cero, entendiendo tanto la parte técnica (scripts) como la construcción del entorno (level design básico).

Este proyecto sigue un videotutorial dividido en múltiples capítulos, pero el foco está en **comprender y replicar los sistemas**, no solo copiarlos.

---

## 📚 Progreso actual

### ✅ Capítulo 01 – Introducción
- Presentación del proyecto
- Configuración inicial del entorno de trabajo
- Enfoque del tutorial y objetivos generales

---

### ✅ Capítulo 02 – Escena inicial y elementos básicos
- Creación del **suelo** del nivel
- Creación del **Player** usando una cápsula
- Agregado de elementos simples para interactuar en la escena
- Creación y aplicación de **Materials** para dar color y diferenciación visual a los objetos
- Organización básica de la escena

📌 En este punto el enfoque fue visual y estructural, sin lógica de control todavía.

---

### ✅ Capítulo 03 – Cámara FPS (Camera Look)
Implementación del sistema básico de cámara en primera persona.

#### Características:
- Control del mouse para rotación de cámara
- Separación de responsabilidades:
  - **Mouse X** → rota el cuerpo del jugador (yaw)
  - **Mouse Y** → rota solo la cámara (pitch)
- Uso de `localRotation` para evitar conflictos con la rotación del player
- Límite de rotación vertical usando `Mathf.Clamp`
- Bloqueo del cursor para experiencia FPS

#### Script principal:
- `Assets/Scripts/Camera/CameraLook.cs`

---

### ✅ Capítulo 04 – Movimiento del jugador
Implementación del movimiento básico del Player utilizando `CharacterController`.

#### Características:
- Movimiento en los ejes horizontal y vertical
- Movimiento relativo a la orientación del jugador
- Uso de `transform.forward` y `transform.right`
- Velocidad configurable
- Movimiento independiente del frame rate (`Time.deltaTime`)

#### Script:
- `Assets/Scripts/Player/PlayerMovement.cs`

---

### ✅ Capítulo 05 – Gravedad del jugador
Extensión del sistema de movimiento para incluir gravedad manual utilizando `CharacterController`.

#### Características:
- Aplicación de gravedad sin uso de `Rigidbody`
- Uso de una velocidad vertical acumulada (`velocity.y`)
- Integración de la gravedad con `CharacterController.Move`
- Separación entre movimiento horizontal y fuerza vertical
- Uso de `Time.deltaTime` para una simulación consistente

#### Script:
- `Assets/Scripts/Player/PlayerMovement.cs`

---

### ✅ Capítulo 06 – Salto y detección de suelo
Implementación del sistema de salto y detección de contacto con el suelo utilizando físicas manuales.

#### Características:
- Detección de suelo mediante `Physics.CheckSphere`
- Uso de `LayerMask` para identificar superficies caminables
- Control del estado `isGrounded` para permitir el salto
- Aplicación de fuerza de salto basada en la fórmula de movimiento vertical
- Uso de una pequeña fuerza negativa para mantener al jugador pegado al suelo
- Integración del salto con el sistema de gravedad manual

#### Script:
- `Assets/Scripts/Player/PlayerMovement.cs`

---

### ✅ Capítulos 07 & 08 – Arma básica y sistema de disparo
Integración de un arma al jugador y creación del sistema básico de disparo.

#### Características:
- Importación de un modelo de pistola desde el Asset Store
- Posicionamiento y rotación manual del arma respecto al jugador
- Arma configurada como hija de la cámara principal para seguir la vista del jugador
- Creación de un `spawnPoint` en la punta del arma
- Implementación de un sistema de disparo básico mediante instanciación de proyectiles
- Creación de un proyectil simple usando una esfera con `SphereCollider` y `Rigidbody`
- Uso del nuevo Input System para detectar el disparo con el botón izquierdo del mouse

#### Script:
- `Assets/Scripts/Weapon/Shot.cs`

---

### ✅ Capítulo 09 – Disparo con fuerza y colisiones
Mejora del sistema de disparo incorporando física, cadencia y detección de colisiones.

#### Características:
- Aplicación de fuerza al proyectil usando `Rigidbody.AddForce`
- Implementación de cadencia de disparo mediante control de tiempo
- Destrucción automática del proyectil tras un tiempo definido
- Detección de colisiones del proyectil
- Uso de tags para identificar enemigos
- Eliminación de enemigos al impacto del proyectil

#### Scripts:
- `Assets/Scripts/Weapon/Shot.cs`
- `Assets/Scripts/Weapon/Bullet.cs`

---

### ✅ Capítulo 10 – Animaciones básicas y NavMesh
Introducción a animaciones simples y configuración inicial del sistema de navegación.

#### Características:
- Creación de una animación básica mediante el sistema de Animation de Unity
- Animación de movimiento cíclico de un objeto en el eje Z
- Introducción al sistema de navegación usando NavMesh
- Configuración de `NavMeshSurface` sobre el piso con el área por defecto `Walkable`
- Preparación del escenario para futura navegación de enemigos

---

### ✅ Capítulo 11 – Navegación básica del enemigo
Implementación de un sistema de navegación simple para el enemigo utilizando `NavMeshAgent`.

#### Características:
- Uso de `NavMeshAgent` para mover al enemigo sobre el NavMesh
- Definición de destinos mediante puntos en la escena
- Cambio dinámico de destino según la distancia al objetivo
- Integración del enemigo con el sistema de navegación previamente configurado


#### Scripts:
- `Assets/Scripts/AI/AI.cs`
---

## 🛠️ Tecnologías utilizadas
- Unity
- C#
- Input Manager (Mouse X / Mouse Y)

---

## 📈 Estado del proyecto
🟢 En desarrollo  
Este README se actualizará progresivamente conforme se agreguen nuevos sistemas y funcionalidades.

---