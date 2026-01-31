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

## 🛠️ Tecnologías utilizadas
- Unity
- C#
- Input Manager (Mouse X / Mouse Y)

---

## 📈 Estado del proyecto
🟢 En desarrollo  
Este README se actualizará progresivamente conforme se agreguen nuevos sistemas y funcionalidades.

---