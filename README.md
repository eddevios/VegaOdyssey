# [VEGA ODYESSEY]

## Descripción General

Un shootém-up mezclado con run´n-gun de acción en 2D, centrado en un mundo post-apocalíptico/fantástico. 

## Características Principales y Mecánicas

* La idea principal es un juego de naves que una vez eliminado cae al planeta correspondiente a su fase para continuar su aventura como un juego del tipo Metal Slug. 
* Llegando a un enemigo final de fase, si se llega en el run´n-gun se enfrenta a un gran enemigo, y vuelve a subir a su nave ya reparada, una vez superado. 
* Si llega sin ser derribado en el shootém-up, entonces un enemigo final fuerza que caigas derribado y procedas a jugar el run´n-gun.
* La nave posee 4 armas, que puede ir cambiando al gusto el jugador entre las 4 a derechas o a izquierdas con los botones L y R
* El runner inicia con un arma potente pero simple, podrá recoger del escenario o enemigos otras 3, diferentes.
* Estilo artístico Pixel Art"
* Fases: alternancia “Espacio → Superficie” (10 fases numeradas).
* Armas de la nave: 4 slots con rotación L/R.
* Armas terrestres: 4 slots, se recogen en escenario.
* Progresión: caída forzada al planeta si te derriban en el espacio (o al revés si llegas íntegro).
* Sistema de upgrade (si ya está implementado en Prefabs/PowerUpPrefab).

## Requisitos del Sistema

### Mínimos
* **Sistema Operativo:** [Ej: Windows 10 (64-bit), macOS 10.13+]
* **Procesador:** [Ej: Intel Core i5 o equivalente]
* **Memoria:** [Ej: 8 GB RAM]
* **Gráficos:** [Ej: NVIDIA GeForce GTX 970 / AMD Radeon RX 580 o equivalente]
* **Almacenamiento:** [Ej: 5 GB de espacio disponible]

### Recomendados
* **Sistema Operativo:** [Ej: Windows 10 (64-bit), macOS 10.15+]
* **Procesador:** [Ej: Intel Core i7 o equivalente]
* **Memoria:** [Ej: 16 GB RAM]
* **Gráficos:** [Ej: NVIDIA GeForce RTX 2060 / AMD Radeon RX 5700 XT o equivalente]
* **Almacenamiento:** [Ej: 10 GB de espacio disponible]

## Instalación y Ejecución

### Para Usuarios Finales
1.  [Instrucciones para descargar el juego compilado, si aplica.]
2.  [Instrucciones para ejecutar el juego.]

### Para Desarrolladores (Abrir el Proyecto en Unity)
1.  **Clonar el repositorio:**
    SSH:
    ```bash
    git clone git@github.com:eddevios/VegaOdyssey.git
    ```
    HTTPS: 
    ```bash
    git clone https://github.com/eddevios/VegaOdyssey.git

    ```
2.  **Abrir en Unity:**
    * Abre Unity Hub.
    * Haz clic en "Add" y navega hasta la carpeta raíz del proyecto clonado.
    * Asegúrate de tener instalada la versión de Unity utilizada en el proyecto ([Versión de Unity, ej: 2022.3.62f1]). Si no la tienes, Unity Hub te ofrecerá instalarla.
    * Abre el proyecto.

## Estructura del Proyecto (Unity)
```text
Assets/
├─ _Scenes/                                   # Escenas del proyecto
│  ├─ Core/                                   # Escenas base: logo, inicio, términos
│  │  ├─ 00_Logo.unity                        # Logotipo animado, pantallas intro
│  │  ├─ 01_StartScreen.unity                 # Menú principal
│  │  ├─ 02_TermsAndConditions.unity         # Términos y condiciones
│  │  └─ 10_LoadingScene.unity                # Carga nivel con addressables
│  └─ Phases/                                # Fases de juego (10 niveles)
│     ├─ Phase1_SpaceBattle.unity             # Nivel espacial fase 1
│     ├─ Phase1_PlanetSurface.unity           # Modo terrestre fase 1
│     ├─ ... hasta Phase10_*
│
├─ Art/                                       # Recursos visuales
│  ├─ Sprites/                                # Sprites en pixel art
│  │  ├─ Player/                              # Nave del jugador
│  │  ├─ Enemies/                             # Enemigos y props
│  │  └─ Tiles/                               # Tiles de entorno
│  ├─ Animations/                             # Animaciones, controllers
│  └─ Effects/                                # Explosiones, partículas (FX Cartoon Remaster)
│
├─ Audio/                                     # Música y efectos sonoros
│  ├─ Music/
│  └─ SFX/
│
├─ Prefabs/                                   # Prefabs de objetos instanciables
│  ├─ Player/                                 # Nave y personaje terrestre
│  ├─ Enemies/                                # Enemigos y bosses
│  ├─ Bosses/                                 # Jefes por fase
│  └─ PowerUps/                               # Mejoras y power-ups
│
├─ Scripts/                                   # Código en C#
│  ├─ Core/                                   # Sistema central
│  │  ├─ GameManager.cs                       # Controlador principal del ciclo
│  │  ├─ SceneLoader.cs                       # Carga escenas asíncronas con Addressables
│  │  ├─ PhaseController.cs                   # Gestiona fases y transiciones
│  │  └─ SaveSystem.cs                        # Guardado y carga
│  ├─ Player/                                 # Scripts del jugador
│  │  ├─ PlayerShipController.cs              # Control nave shoot’em-up
│  │  ├─ RunnerController.cs                   # Control personaje terrestre
│  │  ├─ WeaponWheel.cs                        # Selección rotatoria de armas
│  │  └─ Weapon.cs                             # lógica de armas, balas
│  ├─ Enemies/                                # IA y enemigos
│  │  ├─ EnemyBase.cs                         # Clase base
│  │  ├─ BossAI.cs                            # IA específico de bosses
│  │  └─ Spawner.cs                           # Spawners y control de oleadas
│  ├─ UI/                                     # Elementos HUD y controles
│  │  ├─ HUDController.cs                     # Vida, arma, estado del juego
│  │  └─ LifeBarSegment.cs                     # Vida segmentada
│  ├─ Data/                                   # ScriptableObjects y datos
│  │  ├─ PlayerStatsSO.cs                     # Estado del jugador
│  │  └─ BossDataSO.cs                        # Datos boss
│  └─ Utilities/                              # Utilidades diversas
│     ├─ ServiceLocator.cs                     # Registro global de servicios
│     ├─ Extensions.cs                         # Métodos de extensión útiles
│     └─ InputManager.cs                       # Manejo de input (Input System)
│
├─ Settings/                                  # Configuración del proyecto
│  ├─ Input/                                  # Archivos de Input System
│  ├─ Graphics/                               # Configuración de renderizado
│  └─ Quality/                                # Settings de calidad
|
├─ AddressableAssetsData/                      # AssetBundles y perfiles Addressables

```

## Tecnologías Utilizadas

* **Unity Engine** ([Versión específica, ej: 2022.3.61f1])
* **Lenguaje de Programación:** C#
* **Plugins/Paquetes de Unity:**
* URP 2D + 2D Renderer
* Addressables 1.21 (streaming de assets)
* Localization (idioma ES/EN)
* Input System 1.7
* Lean Pool para pooling eficiente
* TextMesh Pro para UI
* 2D Animation 8.x + PSD Importer

8. Roadmap (Q3 2025)
 Boss de Fase 3 (sprite + IA).
 Sistema de progreso y guardado (PlayerPrefs → Addressables).
 Integrar FX Cartoon Remaster en explosiones.
 Pulir HUD (barra de vida multisegmento + iconos de armas).
 Implementar traducción al japonés con Localization.

9. Créditos
Arte: Bardic, JMO Studios, Kenney.
Música: [nombre Eddevios].
Programación: Edu “Eddevios”.
Testing: [equipo QA].

