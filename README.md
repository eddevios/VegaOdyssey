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
    ```bash
    git clone [https://git-scm.com/book/es/v2/Fundamentos-de-Git-Obteniendo-un-repositorio-Git](https://git-scm.com/book/es/v2/Fundamentos-de-Git-Obteniendo-un-repositorio-Git)
    ```
2.  **Abrir en Unity:**
    * Abre Unity Hub.
    * Haz clic en "Add" y navega hasta la carpeta raíz del proyecto clonado.
    * Asegúrate de tener instalada la versión de Unity utilizada en el proyecto ([Versión de Unity, ej: 2022.3.62f1]). Si no la tienes, Unity Hub te ofrecerá instalarla.
    * Abre el proyecto.

## Estructura del Proyecto (Unity)

Assets/
├─ _Scenes/                   # 00_Logo, 01_StartScreen, 02_TermsAndConditions…
│   ├─ Phase1_PlanetSurface   # Alterna con Phase1_SpaceBattle (y así hasta Phase10)
│   └─ 10_LoadingScene
├─ AddressableAssetsData/     # Catálogo de bundles y perfiles
├─ Art/
│   ├─ Animations/            # PSD bones + Animator Controllers
│   ├─ Effects/               # Muzzle flashes, explosions
│   ├─ Sprites/
│   │   └─ Tiles/             # Tile palettes (EnvironmentPalette_Env)
│   └─ Logo/
├─ Audio/
│   ├─ Music/
│   └─ SFX/UI/
├─ Bandits - Pixel Art/       # Pack comercial (enemigos, props)
├─ JMO Assets/                # Cartoon FX Remaster, Welcome Screen
├─ Materials/
├─ Plugins/
│   └─ CW/LeanPool            # Pooling de objetos
├─ Prefabs/
│   ├─ Cinematic/
│   ├─ Enemies/
│   │   ├─ Runner/
│   │   └─ Shooter/
│   ├─ Player/
│   │   ├─ Runner/
│   │   └─ Shooter/
│   ├─ PlayerBulletsPrefab/
│   └─ PowerUpPrefab/
├─ Resources/                 # Carga dinámica fuera de Addressables
├─ Scripts/
│   ├─ Cinematic/
│   ├─ Common/
│   ├─ Enemies/
│   ├─ Environment/
│   ├─ Input/
│   ├─ Managers/              # GameManager, AudioManager, LocalizationManager
│   ├─ Player/
│   ├─ UI/
│   └─ Weapon/
└─ Settings/                  # Input System, URP, HDR, Quality


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

