# Mazmorra LINQ  
Un RPG de consola escrito en C# donde cada decisión cuenta y cada combate importa.

Mazmorra LINQ es un proyecto diseñado para practicar programación en C#, uso de LINQ, colecciones, lógica de combate por turnos y arquitectura modular.  
El jugador avanza por una mazmorra generada aleatoriamente, recoge objetos, mejora su equipamiento y lucha contra enemigos cada vez más fuertes.

---

## Características principales

### Generación procedural de mazmorras
- 10 salas generadas automáticamente.
- Enemigos y objetos aleatorios en cada sala.
- Salas especiales con jefes (BOSS) en la 5 y la 10.

### Sistema de combate por turnos
- Turnos alternos entre jugador y enemigo.
- Turno extra si la velocidad del jugador duplica la del enemigo.
- Daño, defensa y velocidad calculados dinámicamente.
- Vida del jugador y enemigo nunca baja de 0.

### Inventario y objetos
- Armas, armaduras, botas y pociones.
- Rarezas y valores distintos.
- Equipamiento intercambiable en cualquier momento.
- Botín aleatorio tras derrotar enemigos.

### Cenizas de guerra
- Habilidades especiales ligadas al arma equipada.
- Daño adicional.
- Sistema de cooldown por arma.

### Arquitectura modular
El proyecto está dividido en carpetas claras:
- **Entidades** → Jugador, Enemigo, Objeto, Sala.
- **Datos** → Listas base de enemigos y objetos.
- **SistemaInventario** → Gestión del inventario.
- **SistemasCombates** → Combate, turnos, cálculos y menús.
- **Nucleo** → Generador de mazmorra, juego principal, botín, SistemasCombates y SistemaInventario.

---

## Tecnologías utilizadas

- **C# 10**
- **.NET 6 / .NET 7**
- **LINQ** (usado para:
  - Filtrar inventario  
  - Ordenar y seleccionar enemigos  
  - Generar botín  
  - Mostrar listas numeradas  
  - Recorrer colecciones sin bucles tradicionales  
)

---

## Cómo jugar
1. Descarge el proyecto
2. Extraigalo todo
3. Metase en Visual Studio Code con el proyecto
4. Metase a la carpeta Dungeon
   ```bash
   cd Dungeon
   ```
5. Ejecute el proyecto
   ```bash
   dotnet run
   ```
